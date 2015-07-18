using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Drawing;

namespace Filesharingapplicatie
{ 
    static class DatabaseKoppeling
    {
        private static OracleConnection conn;

        static DatabaseKoppeling()
        {
            conn = new OracleConnection();

            String pcn = "233610";
            String pw = "2159122";
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";"; 
        }   // constructor

        public static string[] inlogSeq(string RFID) 
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add(new OracleParameter("RFID", RFID));
            cmd.CommandText = "SELECT Wachtwoord, Type FROM Persoon WHERE RFID = :RFID";
            cmd.Connection = conn;

            string[] data = new string[2];

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    data[0] = reader["WACHTWOORD"].ToString();
                    data[1] = reader["TYPE"].ToString();
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return data;
        }       // zoekt in de database het bijbehorende wachtwoord van het gegeven RFID en returned deze

        public static List<Categorie> getFolders(int id_parent) 
        {
            List<Categorie> categorien = new List<Categorie>();

            string sql = "SELECT * FROM MAP WHERE Parent_id = " + id_parent.ToString();
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categorie ca = new Categorie(Convert.ToInt32(reader["MAP_ID"]), reader["MAP_NAAM"].ToString(), Convert.ToInt32(reader["PARENT_ID"]));
                    if (ca.Parent_id != ca.Map_id)
                    {
                        categorien.Add(ca);
                    }
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return categorien;
        }   // zoekt in de database alle mappen met het gegeven parent_id en returned deze

        public static Categorie newFolder(string map_naam, int id_parent)
        {
            Categorie map;
            string map_id = "";

            string sql = "SELECT seq_map.nextval FROM dual";          
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    map_id = reader["nextval"].ToString();
                }

                cmd = new OracleCommand();
                cmd.Parameters.Add(new OracleParameter("map_naam", map_naam));
                cmd.CommandText = "INSERT INTO MAP VALUES (" + map_id + ", :map_naam, " + id_parent.ToString() + ")";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                map = new Categorie(Convert.ToInt32(map_id), map_naam, id_parent);
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return map;
        }       // slaat een nieuwe map op in de database

        public static void deleteFolder(int id_map)
        {
            string sql = "DELETE FROM MAP WHERE Map_id = " + id_map.ToString();
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }   // verwijderd een map uit de database met het gegeven id_map

        public static List<File> getFiles(int id_map)
        {          
            List<File> files = new List<File>();

            string sql = "SELECT * FROM BESTAND WHERE Map_id = " + id_map.ToString();
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    files.Add(new File(Convert.ToInt32(reader["BESTAND_ID"]), Convert.ToInt32(reader["MAP_ID"]), reader["NAAM"].ToString(), reader["BESCHRIJVING"].ToString(), reader["EXTENSIE"].ToString(), Convert.ToInt32(reader["GROOTTE"]), reader["RFID"].ToString(), Convert.ToDateTime(reader["DATUM"]), Convert.ToInt32(reader["GEDOWNLOAD"]), Convert.ToInt32(reader["RATING"]), reader["PAD"].ToString(), Convert.ToInt16(reader["IMGINDEX"])));
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return files;
        }   // zoekt in de database alle files met het gegeven id_map en returned deze

        public static File newFile(int map_id, string beschrijving, long grootte, string RFID, string url)
        {
            File file;
            string bestand_id = "";
            string sql = "SELECT seq_bestand.nextval FROM dual";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bestand_id = reader["nextval"].ToString();
                }

                string naam = url.Split('\\').Last();
                string extensie = "." + url.Split('.').Last();
                int imgindex = FileHelper.getImageindex(extensie);

                cmd = new OracleCommand();
                cmd.Parameters.Add(new OracleParameter("naam", naam));
                cmd.Parameters.Add(new OracleParameter("beschrijving", beschrijving));
                cmd.Parameters.Add(new OracleParameter("extensie", extensie));
                cmd.Parameters.Add(new OracleParameter("url", url));
                cmd.CommandText = "INSERT INTO BESTAND VALUES (" + bestand_id + ", " + map_id.ToString() + ", :naam, :beschrijving, :extensie, " + grootte.ToString() + ",'" + RFID + "', DEFAULT, DEFAULT, DEFAULT, :url, " + imgindex.ToString() + ")";
                cmd.Connection = conn;

                cmd.ExecuteNonQuery();

                file = new File(Convert.ToInt32(bestand_id), map_id, naam, beschrijving, extensie, grootte, RFID, DateTime.Now, 0, 0, url, imgindex);
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return file;
        }       // slaat een nieuwe file op in de database

        public static void deleteFile(int id_bestand)
        {
            string sql = "DELETE FROM BESTAND WHERE Bestand_id = " + id_bestand.ToString();
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }   // verwijderd een file met het gegeven id_bestand uit de database

        public static List<File> searchFileNameDesc(string sleutel) 
        {
            List<File> files = new List<File>();

            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add(new OracleParameter("sleutel", "%" + sleutel.ToLower() + "%"));
            cmd.CommandText = "SELECT * FROM BESTAND WHERE Lower(Naam) LIKE :sleutel OR Lower(Beschrijving) LIKE :sleutel";
            cmd.Connection = conn;

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    files.Add(new File(Convert.ToInt32(reader["BESTAND_ID"]), Convert.ToInt32(reader["MAP_ID"]), reader["NAAM"].ToString(), reader["BESCHRIJVING"].ToString(), reader["EXTENSIE"].ToString(), Convert.ToInt32(reader["GROOTTE"]), reader["RFID"].ToString(), Convert.ToDateTime(reader["DATUM"]), Convert.ToInt32(reader["GEDOWNLOAD"]), Convert.ToInt32(reader["RATING"]), reader["PAD"].ToString(), Convert.ToInt16(reader["IMGINDEX"])));
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return files;
        }       // zoekt in de database alle files waarvan de naam en/of beschrijving de sleutel bevatten en returned deze

        public static List<File> searchCategories(string sleutel)
        {
            List<File> files = new List<File>();

            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add(new OracleParameter("sleutel", "%" + sleutel.ToLower() + "%"));
            cmd.CommandText = "SELECT * FROM BESTAND WHERE Map_id IN (SELECT Map_id FROM Map WHERE Lower(Map_naam) LIKE :sleutel)";
            cmd.Connection = conn;

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    files.Add(new File(Convert.ToInt32(reader["BESTAND_ID"]), Convert.ToInt32(reader["MAP_ID"]), reader["NAAM"].ToString(), reader["BESCHRIJVING"].ToString(), reader["EXTENSIE"].ToString(), Convert.ToInt32(reader["GROOTTE"]), reader["RFID"].ToString(), Convert.ToDateTime(reader["DATUM"]), Convert.ToInt32(reader["GEDOWNLOAD"]), Convert.ToInt32(reader["RATING"]), reader["PAD"].ToString(), Convert.ToInt16(reader["IMGINDEX"])));
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return files;
        }   // zoekt in de database alle files waarvan de namen van de mappen waarin ze zitten de sleutel bevatten en returned deze   

        public static List<File> searchUserFiles(string RFID)
        {
            List<File> files = new List<File>();

            OracleCommand cmd = new OracleCommand();
            cmd.Parameters.Add(new OracleParameter("RFID", RFID));
            cmd.CommandText = "SELECT * FROM BESTAND WHERE RFID = :RFID";
            cmd.Connection = conn;

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    files.Add(new File(Convert.ToInt32(reader["BESTAND_ID"]), Convert.ToInt32(reader["MAP_ID"]), reader["NAAM"].ToString(), reader["BESCHRIJVING"].ToString(), reader["EXTENSIE"].ToString(), Convert.ToInt64(reader["GROOTTE"]), reader["RFID"].ToString(), Convert.ToDateTime(reader["DATUM"]), Convert.ToInt32(reader["GEDOWNLOAD"]), Convert.ToInt32(reader["RATING"]), reader["PAD"].ToString(), Convert.ToInt16(reader["IMGINDEX"])));
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return files;
        }   // zoekt in de database alle files waarvan de auteur gelijk is aan het ingevoerde RFID en returned deze   

        public static void downloadsOneUp(int bestand_id)
        {
            string sql = "UPDATE Bestand SET Gedownload = Gedownload + 1 WHERE Bestand_id = " + bestand_id.ToString();
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }   // verhoogt het aantal_downloads van de file met het gegeven bestand_id met 1 in de database

        public static void ratingOneUp(int one, int bestand_id)
        {
            string sql = "UPDATE Bestand SET Rating = Rating + " + one.ToString() + " WHERE Bestand_id = " + bestand_id.ToString();
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }   // verhoogt of verlaagt de rating van de file met het gegeven bestand_id met 1 in de database

        public static List<string> clear(DateTime begin, DateTime end, string extension, string user)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            string sql = "SELECT PAD FROM BESTAND WHERE Datum BETWEEN '" + begin.ToShortDateString() + "' AND '" + end.ToShortDateString() + "'";

            List<string> paden = new List<string>();

            if (extension != "")
            {
                cmd.Parameters.Add(new OracleParameter("extension", extension));
                sql += " AND Extensie = :extension";
            }
            if (user != "")
            {
                cmd.Parameters.Add(new OracleParameter("user0", user));
                sql += " AND RFID = :user0";
            }            

            cmd.CommandText = sql;

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    paden.Add(reader["PAD"].ToString());
                }

                sql = "DELETE FROM BESTAND WHERE Datum BETWEEN '" + begin.ToShortDateString() + "' AND '" + end.ToShortDateString() + "'";

                if (extension != "")
                {
                    sql += " AND Extensie = :extension";
                }
                if (user != "")
                {
                    sql += " AND RFID = :user0";
                }

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return paden;
        }   // verwijderd alle bestanden die voldoen aan de parameters uit de database en returned een lijst met URLS van de verwijderde bestanden

        public static void newComment(string RFID, string opmerking, int bestand_id, Point locatie)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.Parameters.Add(new OracleParameter("opmerking", opmerking));
            cmd.CommandText = "INSERT INTO OPMERKING VALUES (seq_opmerking.nextval, '" + RFID + "', " + bestand_id + ", DEFAULT, :opmerking)";

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }   // slaat een nieuwe opmerking op in de database   

        public static List<Opmerking> getComments(int bestand_id)
        {
            List<Opmerking> comments = new List<Opmerking>();
            Point location = new Point(10, 10);

            string sql = "SELECT * FROM Opmerking WHERE Bestand_id = " + bestand_id.ToString() + " ORDER BY Datum DESC";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comments.Add(new Opmerking(reader["RFID"].ToString(), Convert.ToInt32(reader["Bestand_id"]), reader["Opmerking_text"].ToString(), Convert.ToDateTime(reader["Datum"]), Convert.ToInt64(reader["Opmerking_id"]), location));
                    location.Y += 97;
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return comments;
        }   // zoekt in de database naar alle opmerkingen die het ingevoerde bestand_id hebben en returned deze
    }
}
