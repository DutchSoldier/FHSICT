using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Reserveringssysteem
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
        }

        /// <summary>
        /// Haalt een vrij rfid op uit de database.
        /// </summary>
        /// <returns>Een vrij RFID.</returns>
        public static string GetVrijRFID()
        {
            string rfid = null;

            string sql = "SELECT rfid FROM rfid_col WHERE rfid NOT IN (SELECT rfid FROM persoon) AND ROWNUM = 1";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rfid = reader["RFID"].ToString();
                }

                if (string.IsNullOrEmpty(rfid))
                {
                    throw new System.ArgumentException("Er zijn geen vrije RFID's meer aanwezig!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rfid;
        }

        /// <summary>
        /// Geeft een nieuw reserveringsnummer uit.
        /// </summary>
        /// <returns>Een nieuw reserveringsnummer.</returns>
        public static int GetNieuwReserveringsnummer()
        {
            int reserveringsnummer = 1;

            string sql = "SELECT seq_reservering.nextval FROM dual";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    reserveringsnummer = Convert.ToInt32(reader["NEXTVAL"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return reserveringsnummer;
        }

        /// <summary>
        /// Haalt een lijst met reserveringen uit de DB.
        /// </summary>
        /// <returns>Een lijst van ReserveringView classen.</returns>
        public static List<ReserveringView> GetReserveringen()
        {
            List<ReserveringView> reserveringen = new List<ReserveringView>();

            string sql = "SELECT klb.reserveringsnummer, klb.naam, (SELECT COUNT(rfid) + 1 FROM klant WHERE reserveringsnummer = klb.reserveringsnummer) AS personen FROM klant_betalend klb GROUP BY klb.reserveringsnummer, klb.naam";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReserveringView rv = new ReserveringView(Convert.ToInt32(reader["RESERVERINGSNUMMER"]), reader["NAAM"].ToString(), Convert.ToInt32(reader["PERSONEN"]));
                    reserveringen.Add(rv);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return reserveringen;
        }

        /// <summary>
        /// Geeft het aantal personen in een reservering terug.
        /// </summary>
        /// <param name="reserveringsnummer">De reservering waarvan je het aantal personen wilt weten.</param>
        /// <returns>Geeft een int terug met het aantal personen.</returns>
        public static int GetAantalPersonen(int reserveringsnummer)
        {
            int personen = 0;

            string sql = "SELECT COUNT(rfid) + 1 AS personen FROM klant WHERE reserveringsnummer = " + reserveringsnummer + "";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    personen = Convert.ToInt32(reader["personen"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return personen;
        }

        /// <summary>
        /// Maakt een Klant aan in een al BESTAANDE reservering.
        /// </summary>
        /// <param name="klant">De klant gegevens die toegevoegd worden.</param>
        public static void AddKlant(Klant klant)
        {
            string sql = "INSERT ALL INTO PERSOON (RFID, WACHTWOORD, TYPE) VALUES('" + klant.Rfid + "', '" + SHA1Hashing.MaakSHA1(klant.Wachtwoord) + "', '" + klant.Type + "') INTO KLANT (RFID, RESERVERINGSNUMMER) VALUES ('" + klant.Rfid + "', " + klant.Reserveringsnummer + ") SELECT * FROM dual";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
      
        /// <summary>
        /// Maakt een Klant_betalend aan in een al BESTAANDE reservering.
        /// </summary>
        /// <param name="klant">De Klant_betalend gegevens die toegevoegd worden.</param>
        public static void AddBetalendeKlant(BetalendeKlant klant)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.Parameters.Add(new OracleParameter("naam", klant.Naam.ToString()));
            cmd.Parameters.Add(new OracleParameter("straat", klant.Straat.ToString()));
            cmd.Parameters.Add(new OracleParameter("postcode", klant.Postcode.ToString()));
            cmd.Parameters.Add(new OracleParameter("woonplaats", klant.Woonplaats.ToString()));
            cmd.Parameters.Add(new OracleParameter("telefoon", klant.Telefoon.ToString()));
            cmd.Parameters.Add(new OracleParameter("email", klant.Email.ToString()));
            cmd.Parameters.Add(new OracleParameter("rekeningnummer", klant.Rekeningnummer.ToString()));
            cmd.Parameters.Add(new OracleParameter("rijbewijsnummer", klant.Rijbewijsnummer.ToString()));
            cmd.CommandText = "INSERT ALL INTO PERSOON (RFID, WACHTWOORD, TYPE) VALUES('" + klant.Rfid + "', '" + SHA1Hashing.MaakSHA1(klant.Wachtwoord) + "', '" + klant.Type + "') INTO KLANT_BETALEND (RFID, RESERVERINGSNUMMER, NAAM, STRAAT, POSTCODE, WOONPLAATS, TELEFOON, EMAIL, REKENINGNUMMER, SOFINUMMER) VALUES ('" + klant.Rfid + "', " + klant.Reserveringsnummer + ", :naam, :straat, :postcode, :woonplaats, :telefoon, :email, :rekeningnummer, :sofi) SELECT * FROM dual";

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Past de gegevens aan van een Klant_betalend.
        /// </summary>
        /// <param name="klant">De gewijzigde gegevens van een Klant_betalend</param>
        public static void UpdateKlantBetalend(BetalendeKlant klant)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.Parameters.Add(new OracleParameter("naam", klant.Naam.ToString()));
            cmd.Parameters.Add(new OracleParameter("straat", klant.Straat.ToString()));
            cmd.Parameters.Add(new OracleParameter("postcode", klant.Postcode.ToString()));
            cmd.Parameters.Add(new OracleParameter("woonplaats", klant.Woonplaats.ToString()));
            cmd.Parameters.Add(new OracleParameter("telefoon", klant.Telefoon));
            cmd.Parameters.Add(new OracleParameter("email", klant.Email.ToString()));
            cmd.Parameters.Add(new OracleParameter("rekeningnummer", klant.Rekeningnummer.ToString()));
            cmd.Parameters.Add(new OracleParameter("sofi", klant.Rijbewijsnummer.ToString()));
            cmd.CommandText = "UPDATE klant_betalend SET naam = :naam, straat = :straat, postcode = :postcode, woonplaats = :woonplaats, telefoon = :telefoon, email = :email, rekeningnummer = :rekeningnummer, sofinummer = :sofi WHERE reserveringsnummer = " + klant.Reserveringsnummer + "";

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Haalt een klant_betalend op uit de database.
        /// </summary>
        /// <param name="reserveringsnummer">Het reserveringsnummer waarvan je de klant_betalend wilt ophalen.</param>
        /// <returns>Geeft een BetalendeKlant object terug.</returns>
        public static BetalendeKlant GetKlantBetalend(int reserveringsnummer)
        {
            BetalendeKlant klant = null;

            string sql = "SELECT * FROM klant_betalend WHERE reserveringsnummer = " + reserveringsnummer + "";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    klant = new BetalendeKlant(reader["RFID"].ToString(), reader["NAAM"].ToString(), reader["SOFINUMMER"].ToString(), reader["EMAIL"].ToString(), reader["TELEFOON"].ToString(), reader["WOONPLAATS"].ToString(), reader["STRAAT"].ToString(), reader["REKENINGNUMMER"].ToString(), reader["POSTCODE"].ToString(), Convert.ToInt32(reader["RESERVERINGSNUMMER"]));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return klant;
        }

        /// <summary>
        /// Verwijderd een Klant of een Klant_betalend uit de DB
        /// </summary>
        /// <param name="rfid">RFID van Klant of Klant_betalend</param>
        public static void RemoveKlant(string rfid)
        {
            string sql = "DELETE FROM PERSOON WHERE RFID = '" + rfid + "'";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Geeft een willekeurig Klant RFID dat bij een bepaalde reservering hoort.
        /// </summary>
        /// <param name="reserveringsnummer">Reservering identificatie.</param>
        /// <returns>Geeft een string met RFID terug.</returns>
        public static string GetRFIDReservering(int reserveringsnummer)
        {
            string rfid = null;

            string sql = "SELECT rfid FROM klant WHERE reserveringsnummer = " + reserveringsnummer + " AND ROWNUM = 1";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rfid = reader["RFID"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rfid;
        }

        /// <summary>
        /// Eerste stap voor het aanmaken van een reservering. 
        /// </summary>
        /// <param name="reservering">Uniek reserveringsnummer en aangeven of er al betaald is.</param>
        public static void AddReservering(Reservering reservering)
        {
            string sql = "INSERT INTO RESERVERING (RESERVERINGSNUMMER, BETAALD) VALUES(" + reservering.ReserveringsNummer + ", '" + reservering.Betaald + "')";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Functie benodigd voor RemoveReservering(). Om de klanten van een reservering op te sporen.
        /// </summary>
        /// <param name="reserveringsnummer">Reserveringsnummer van de klanten</param>
        /// <returns>Een lijst met RFID's van de klanten in een reservering.</returns>
        private static List<string> GetToRemoveKlanten(int reserveringsnummer)
        {
            List<string> klanten = new List<string>();

            string sql = "SELECT CASE PIVOT WHEN 1 THEN rfidk WHEN 2 THEN rfidkb ELSE NULL END rfid FROM (SELECT k.rfid AS rfidk, kb.rfid AS rfidkb FROM klant k, klant_betalend kb WHERE k.reserveringsnummer = " + reserveringsnummer + " AND kb.reserveringsnummer = " + reserveringsnummer + "), (SELECT ROWNUM PIVOT FROM dual CONNECT BY LEVEL <= 2)";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    klanten.Add(reader["RFID"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return klanten;
        }

        /// <summary>
        /// Verwijderd eerst de klanten van een reservering alvorens de reservering zelf ook te verwijderen.
        /// </summary>
        /// <param name="reserveringsnummer">Het reserveringsnummer dat verwijderd moet worden.</param>
        public static void RemoveReservering(int reserveringsnummer)
        {
            List<string> klanten = GetToRemoveKlanten(reserveringsnummer);
            foreach (string kl in klanten)
            {
                RemoveKlant(kl);
            }

            string sql = "DELETE FROM RESERVERING WHERE RESERVERINGSNUMMER = " + reserveringsnummer + "";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Alle kampeerplekken worden uit de DB gehaald.
        /// </summary>
        /// <returns>Een lijst met alle gegevens over de kampeerplekken.</returns>
        public static List<Kampeerplek> GetKampeerplekken()
        {
            List<Kampeerplek> kampeerplekken = new List<Kampeerplek>();

            string sql = "SELECT * FROM KAMPEERPLAATS";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kampeerplek kp = new Kampeerplek(reader["PLAATSNUMMER"].ToString(), reader["OPMERKINGEN"].ToString(), Convert.ToInt32(reader["COORDINAAT_X"]), Convert.ToInt32(reader["COORDINAAT_Y"]), Convert.ToInt32(reader["PRIJS"]));
                    kampeerplekken.Add(kp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return kampeerplekken;
        }

        /// <summary>
        /// Verwijderd een kampeerplaats uit de DB.
        /// </summary>
        /// <param name="plaatsnummer">Nummer van de te verwijderen plaats.</param>
        public static void RemovePlaats(string plaatsnummer)
        {
            string sql = "DELETE FROM reservering_plaats WHERE plaatsnummer = '" + plaatsnummer + "'";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Voegt een Kampeerplaats toe aan een reservering.
        /// </summary>
        /// <param name="reserveringsnummer">Reserveringsnummer waaraan toegevoegd moet worden.</param>
        /// <param name="plaatsnummer">Kampeerplaats die toegevoegd moet worden.</param>
        public static void AddReserveringPlaats(int reserveringsnummer, string plaatsnummer)
        {
            string sql = "INSERT INTO reservering_plaats (reserveringsnummer, plaatsnummer) VALUES(" + reserveringsnummer + ", '" + plaatsnummer + "')";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Geeft een lijst met alle gereserveerde plaatsen.
        /// </summary>
        /// <returns>Lijst met gereserveerde plaatsen.</returns>
        public static List<string> GetAlleGereserveerdePlaatsen()
        {
            List<string> kampeerplekken = new List<string>();

            string sql = "SELECT * FROM reservering_plaats";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    kampeerplekken.Add(reader["PLAATSNUMMER"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return kampeerplekken;
        }

        /// <summary>
        /// Geeft lijst met plaatsen in een reservering.
        /// </summary>
        /// <param name="reserveringsnummer">Reserveringskenmerk</param>
        /// <returns>Een lijst met plekken in de reservering.</returns>
        public static List<Kampeerplek> GetReserveringPlaatsen(int reserveringsnummer)
        {
            List<Kampeerplek> kampeerplekken = new List<Kampeerplek>();

            string sql = "SELECT rp.plaatsnummer, (SELECT prijs FROM kampeerplaats WHERE plaatsnummer = rp.plaatsnummer) AS prijs FROM reservering_plaats rp WHERE rp.reserveringsnummer = " + reserveringsnummer + "";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kampeerplek plek = new Kampeerplek(reader["PLAATSNUMMER"].ToString(), Convert.ToInt32(reader["PRIJS"]));
                    kampeerplekken.Add(plek);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return kampeerplekken;
        }

        /// <summary>
        /// Geeft de totale prijs van een reservering terug uit de DB.
        /// </summary>
        /// <param name="reserveringsnummer">Het kenmerk van de reservering</param>
        /// <returns>Een int met de totaal prijs van de reservering.</returns>
        public static int GetReserveringPrijs(int reserveringsnummer)
        {
            int prijs = 0;

            string sql = "SELECT SUM((SELECT prijs FROM kampeerplaats WHERE plaatsnummer = rp.plaatsnummer)) AS prijs FROM reservering_plaats rp WHERE rp.reserveringsnummer = " + reserveringsnummer + "";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["PRIJS"] != DBNull.Value)
                    {
                        prijs = Convert.ToInt32(reader["PRIJS"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return prijs;
        }

        /// <summary>
        /// Haalt de inloggevens, benodigd voor de bevestigingsmail, op uit de database.
        /// </summary>
        /// <param name="reserveringsnummer">De reservering waarvoor de inloggegevens benodigd zijn.</param>
        /// <returns>Geeft een lijst met Rfid's terug. (Gebruikersnaam en wachtwoord zijn in eerste instantie hetzelfde)</returns>
        public static List<Persoon> GetInlogGegevens(int reserveringsnummer)
        {
            List<Persoon> inloggegevens = new List<Persoon>();

            string sql = "SELECT rfid, type FROM persoon WHERE rfid IN ((SELECT rfid FROM klant WHERE reserveringsnummer = " + reserveringsnummer + ")) OR rfid IN ((SELECT rfid FROM klant_betalend WHERE reserveringsnummer = " + reserveringsnummer + "))";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Persoon persoon = new Persoon(reader["RFID"].ToString(), reader["TYPE"].ToString());
                    inloggegevens.Add(persoon);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return inloggegevens;
        }
    }
}
