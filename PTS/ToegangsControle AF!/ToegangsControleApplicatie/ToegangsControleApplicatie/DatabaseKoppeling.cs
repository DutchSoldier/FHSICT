using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ToegangsControleApplicatie
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

        //UpdateBetalingStatus() : void
        // Update betaling status in de database van Niet Betaald -> Betaald
        public static void UpdateBetalingStatus(int reserveringsnummer, string betaald)
        {
            string sql = "UPDATE RESERVERING SET BETAALD = '" + betaald + "' WHERE RESERVERINGSNUMMER = " + reserveringsnummer + "";
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

        //GetResrvering: <Object>
        // Get reservering zoals in Toegangscontrole.cs
        public static Reservering GetReservering(string rfid)
        {
            List<string> klantres = GetKlantReservering(rfid);
            Reservering reservering = null;

            string sqla = "SELECT reserveringsnummer, LTRIM(MAX(SYS_CONNECT_BY_PATH(plaatsnummer,',')) KEEP (DENSE_RANK LAST ORDER BY curr),',') AS plaatsen FROM (SELECT reserveringsnummer, plaatsnummer, ROW_NUMBER() OVER (PARTITION BY reserveringsnummer ORDER BY plaatsnummer) AS curr, ROW_NUMBER() OVER (PARTITION BY reserveringsnummer ORDER BY plaatsnummer) -1 AS prev FROM reservering_plaats) WHERE reserveringsnummer = " + Convert.ToInt32(klantres[0]) + " GROUP BY reserveringsnummer CONNECT BY prev = PRIOR curr AND reserveringsnummer = PRIOR reserveringsnummer START WITH curr = 1";
            OracleCommand cmda = new OracleCommand(sqla, conn);
            string sqlb = "SELECT betaald FROM reservering WHERE reserveringsnummer = " + Convert.ToInt32(klantres[0]) + "";
            OracleCommand cmdb = new OracleCommand(sqlb, conn);
            string sqlc = "SELECT SUM(prijs) AS prijs FROM kampeerplaats p, reservering_plaats rp WHERE p.plaatsnummer = rp.plaatsnummer AND rp.reserveringsnummer =  " + Convert.ToInt32(klantres[0]) + "";
            OracleCommand cmdc = new OracleCommand(sqlc, conn);

            try
            {
                conn.Open();
                OracleDataReader readera = cmda.ExecuteReader();
                OracleDataReader readerb = cmdb.ExecuteReader();
                OracleDataReader readerc = cmdc.ExecuteReader();
                string plaatsen = null;
                bool betaald = false;
                int prijs = 0;
                while (readera.Read())
                {
                    plaatsen = readera["PLAATSEN"].ToString();
                }
                while (readerb.Read())
                {
                    betaald = Convert.ToBoolean(readerb["BETAALD"]);
                }
                while (readerc.Read())
                {
                    prijs = Convert.ToInt32(readerc["PRIJS"]);
                }
                reservering = new Reservering(klantres[1].ToString(), rfid, plaatsen, betaald, prijs,Convert.ToInt32(klantres[0]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return reservering;
        }

        /// <summary>
        /// Krijg naam en reserveringsnummer bij bijbehoren RFID nummer.
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns>List met naam & reserveringsnummer van de klant.</returns>
        private static List<string> GetKlantReservering(string rfid)
        {
            List<string> klantres = new List<string>();

            string sql = "SELECT kb.reserveringsnummer, naam FROM klant_betalend kb LEFT JOIN klant k ON kb.reserveringsnummer = k.reserveringsnummer WHERE kb.rfid = '" + rfid + "' OR k.rfid = '" + rfid + "'";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    klantres.Add(reader["RESERVERINGSNUMMER"].ToString());
                    klantres.Add(reader["NAAM"].ToString());
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

            return klantres;
        }
    }
}
