//Database Koppeling

namespace MateriaalVerhuurApplicatie
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using System.Web;

    public static class DatabaseKoppeling
    {
        private static OracleConnection conn;

        /// <summary>DatabaseKoppeling() is de constructor class.
        /// <para> Hierin wordt de login + password en het adress van de oracle database ingevoerd.</para>
        /// </summary>
        static DatabaseKoppeling()
        {
            conn = new OracleConnection();
            conn.ConnectionString = GetConString();
        }

        /// <summary>
        /// Used to get the connection string for the database connection. 
        /// A windows forms application will get it from a config file and a web application from web.config.
        /// </summary>
        /// <returns>The connection string.</returns>
        public static string GetConString()
        {
            string conString = string.Empty;
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string filePath = appPath + "/config.txt";

            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(appPath + "/config.txt");
                int startpoint = text.IndexOf("DBConString");
                int getStringStart = text.IndexOf('"', startpoint) + 1;
                int getStringEnd = text.IndexOf('"', getStringStart);
                getStringEnd -= getStringStart;

                conString = text.Substring(getStringStart, getStringEnd);

                return conString;
            }
            else
            {
                conString = string.Empty;
                return conString;
            }
        }

        /// <summary>
        /// Changes the connectionstring.
        /// </summary>
        /// <param name="constring">The new connection string.</param>
        public static void SetConString(string constring)
        {
            conn.ConnectionString = constring;
        }

        /// <summary>
        /// This method is used to check if the database connection is available.
        /// </summary>
        /// <returns>true if the database connection is available, false if it isn't.</returns>
        public static bool ConnectionTest()
        {
            try
            {
                conn.Open();
                if ((conn.State & ConnectionState.Open) > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        /// <summary> getUitlening geeft de uitleningen terug met gegeven reserveringsnummer.
        /// <para> getUitlening returned een List met Uitleningen waarin elke uitlening met het gegeven Reserveringsnummer instaan.</para>
        /// </summary>
        /// <param name="reserveringsNummer">Het reserveringsNummer van de klant.</param>
        /// <returns>List</returns>
        public static List<Uitlening> GetUitlening(int reserveringsNummer)
        {
            List<Uitlening> uitlening = new List<Uitlening>();

            string sql = "SELECT TO_CHAR(DATUM_UITGELEEND, 'DD/MMM/YYYY') AS DATUM_UITGELEEND, TO_CHAR(DATUM_INGELEVERD, 'DD/MMM/YYYY') AS DATUM_INGELEVERD, TYPE, AANTAL FROM UITLENING WHERE RESERVERINGSNUMMER = " + reserveringsNummer + string.Empty;
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Uitlening lening = new Uitlening(Convert.ToString(reader["TYPE"]), Convert.ToInt32(reserveringsNummer), Convert.ToDateTime(reader["DATUM_INGELEVERD"]), Convert.ToDateTime(reader["DATUM_UITGELEEND"]), Convert.ToInt32(reader["AANTAL"]));
                    uitlening.Add(lening);
                }
            }
            catch (Exception fail)
            {

                System.Windows.Forms.MessageBox.Show(fail.Message);
            }
            finally
            {
                conn.Close();
            }
            return uitlening;

        }

        /// <summary> getMateriaal haalt al het materiaal op uit de Database.
        /// <para>Al het ingevoerde materiaal in de MATERIAAL tabel wordt in een lijst ingevoerd en gereturned. </para>
        /// </summary>
        /// <returns>List met Materiaal</returns>
        public static List<Materiaal> GetMateriaal()
        {
            List<Materiaal> materialen = new List<Materiaal>();

            string sql = "SELECT * FROM MATERIAAL";
            OracleCommand cmd = new OracleCommand(sql, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materiaal materiaal = new Materiaal(Convert.ToString(reader["TYPE"]), Convert.ToInt32(reader["VERHUURPRIJS"]), Convert.ToInt32(reader["AANTAL"]));
                    materialen.Add(materiaal);
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return materialen;
        }

        /// <summary> addUitlening voegt een nieuwe uitlening toe.
        /// <para>Er wordt een nieuwe uitlening in de Database aangemaakt mbv de gegeven parameters.</para>
        /// </summary>
        /// <param name="reserveringsnummer">Het reserveringsnummer van de klant.</param>
        /// <param name="mat">Het materiaal dat de klant wil lenen.</param>
        /// <param name="uitgeleend">De datum waarop de uitlening van start gaat.</param>
        /// <param name="ingeleverd">De datum waarop het materiaal uiterlijk teruggebracht moet worden.</param>
        /// <param name="lBox">De listbox met beschikbare materiaal dat al door de klant gehuurd wordt (Wordt gebruikt om te kijken of er een INSERT of UPDATE SQL commando uitgevoerd moet worden.</param>
        public static void AddUitlening(int reserveringsnummer, Materiaal mat, DateTime uitgeleend, DateTime ingeleverd, ListBox lBox)
        {
            {
                if (lBox.FindString(mat.Type) == ListBox.NoMatches)
                {
                    string nieuwuitleningins = "INSERT INTO UITLENING (RESERVERINGSNUMMER, TYPE, DATUM_UITGELEEND, DATUM_INGELEVERD, AANTAL) VALUES(" + reserveringsnummer + ", " + "'" + mat.Type + "', TO_DATE('"  + uitgeleend.ToString("DD/MMM/YYYY") + "'), TO_DATE('" + ingeleverd.ToString("DD/MMM/YYYY") + "'), 1)";
                    OracleCommand insertuitleningcmd = new OracleCommand(nieuwuitleningins, conn);

                    try
                    {
                        conn.Open();
                        insertuitleningcmd.ExecuteNonQuery();
                    }
                    catch (Exception ef)
                    {
                        System.Windows.Forms.MessageBox.Show(ef.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    string sqlverhoogaantal = "UPDATE UITLENING SET AANTAL = AANTAL + 1 WHERE (RESERVERINGSNUMMER = " + reserveringsnummer + " AND TYPE = '" + mat.Type + "')";
                    OracleCommand verhoogcmd = new OracleCommand(sqlverhoogaantal, conn);
                    try
                    {
                        conn.Open();
                        verhoogcmd.ExecuteNonQuery();

                    }
                    catch (Exception fe)
                    {

                        MessageBox.Show(fe.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Een aparte methode om uitleningen toe te voegen voor aspx.
        /// </summary>
        /// <param name="reserveringsnummer">Het reserveringsnummer van de klant.</param>
        /// <param name="mat">Het materiaal dat de klant wil lenen.</param>
        /// <param name="uitgeleend">De datum waarop de uitlening van start gaat.</param>
        /// <param name="ingeleverd">De datum waarop het materiaal uiterlijk teruggebracht moet worden.</param>
        /// <param name="list">Een lijst met daarin alle materialen die de klant al heeft gehuurd.</param>
        public static void AddUitleningAspx(int reserveringsnummer, Materiaal mat, DateTime uitgeleend, DateTime ingeleverd, List<string> list)
        {
            {
                if (!list.Contains(mat.Type))
                {
                    string nieuwuitleningins = "INSERT INTO UITLENING (RESERVERINGSNUMMER, TYPE, DATUM_UITGELEEND, DATUM_INGELEVERD, AANTAL) VALUES(" + reserveringsnummer + ", " + "'" + mat.Type + "', TO_DATE('" + uitgeleend.ToString("DD/MMM/YYYY") + "'), TO_DATE('" + ingeleverd.ToString("DD/MMM/YYYY") + "'), 1)";
                    OracleCommand insertuitleningcmd = new OracleCommand(nieuwuitleningins, conn);

                    try
                    {
                        conn.Open();
                        insertuitleningcmd.ExecuteNonQuery();
                    }
                    catch (Exception ef)
                    {
                        System.Windows.Forms.MessageBox.Show(ef.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    string sqlverhoogaantal = "UPDATE UITLENING SET AANTAL = AANTAL + 1 WHERE (RESERVERINGSNUMMER = " + reserveringsnummer + " AND TYPE = '" + mat.Type + "')";
                    OracleCommand verhoogcmd = new OracleCommand(sqlverhoogaantal, conn);
                    try
                    {
                        conn.Open();
                        verhoogcmd.ExecuteNonQuery();

                    }
                    catch (Exception fe)
                    {

                        MessageBox.Show(fe.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// RemoveUitlening verwijdert een uitlening uit de database.
        /// </summary>
        /// <param name="uitlening">De uitlening van de klant.</param>
        /// <param name="reserveringsnummer">Het reserveringsnummer van de klant.</param>
        public static void RemoveUitlening(Uitlening uitlening, int reserveringsnummer)
        {
            //Als het aantal == 1 dan moet de uitlening verwijdert worden (aantal wordt dus 0 en is niet langer geldig.)
            if (uitlening.Aantal == 1)
            {
                string sqla = "DELETE FROM UITLENING WHERE (RESERVERINGSNUMMER = " + reserveringsnummer + " AND TYPE = '" + uitlening.Type + "')";
                OracleCommand deletecmd = new OracleCommand(sqla, conn);
                try
                {
                    conn.Open();
                    deletecmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {

                    System.Windows.Forms.MessageBox.Show(exc.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            //Als het aantal groter dan 1 is moet de uitlening geupdate worden. Het aantal zelfde artikelen wordt dus gewijzigd.
            if (uitlening.Aantal >= 2)
            {
                string sqlb = "UPDATE UITLENING SET AANTAL = AANTAL -1 WHERE (RESERVERINGSNUMMER = " + reserveringsnummer + " AND TYPE = '" + uitlening.Type + "')";
                OracleCommand update = new OracleCommand(sqlb, conn);

                try
                {
                    conn.Open();
                    update.ExecuteNonQuery();
                }
                catch (Exception exc)
                {

                    System.Windows.Forms.MessageBox.Show(exc.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// getAantalUitgeleend returned een List met leningen.
        /// <para>Deze methode voegt uitlening objecten toe in de list. In deze list kan uitgelezen worden welke materialen er op het moment uitgeleend worden.</para>
        /// </summary>
        /// <returns>List met op het moment uitgeleend materiaal.</returns>
        public static List<Uitlening> GetAantalUitgeleend()
        {
            List<Uitlening> leningen = new List<Uitlening>();

            string sqla = "SELECT DISTINCT TYPE FROM UITLENING";
            OracleCommand sqlacommand = new OracleCommand(sqla, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = sqlacommand.ExecuteReader();
                while (reader.Read())
                {
                    Uitlening lening = new Uitlening(Convert.ToString(reader["TYPE"]), 0, DateTime.MinValue, DateTime.MinValue, 0);
                    leningen.Add(lening);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return leningen;
        }

        /// <summary>
        /// getPersonenBijUitlening returned een List met uitleninging waarin reserveringsnummers staan met bijbehorend gehuurd materiaal.
        /// </summary>
        /// <param name="type">Het type (=naam) materiaal.</param>
        /// <returns>Een list met uitleningen(=reserveringsnummers).</returns>
        public static List<Uitlening> GetPersonenBijUitlening(string type)
        {
            List<Uitlening> personen = new List<Uitlening>();
            string sqla = "SELECT DISTINCT RESERVERINGSNUMMER FROM UITLENING WHERE TYPE = '" + type + "'";
            OracleCommand sqlacommand = new OracleCommand(sqla, conn);

            try
            {
                conn.Open();
                OracleDataReader reader = sqlacommand.ExecuteReader();
                while (reader.Read())
                {
                    Uitlening lening = new Uitlening(type, Convert.ToInt32(reader["RESERVERINGSNUMMER"]), DateTime.MinValue, DateTime.MinValue, 0);
                    personen.Add(lening);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return personen;
        }

        /// <summary>
        /// Deze methode verwijdert een gehele reservering uit het systeem.
        /// </summary>
        /// <param name="reserveringsnummer">Het reserveringsnummer van de klant.</param>
        public static void RemoveGeheleUitlening(int reserveringsnummer)
        {
            string sqla = "DELETE FROM UITLENING WHERE RESERVERINGSNUMMER = " + reserveringsnummer;
            OracleCommand sqlacommand = new OracleCommand(sqla, conn);

            try
            {
                conn.Open();
                sqlacommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Deze methode kijkt hoeveel materiaal er nog over is.
        /// <para>Het beschikbaar materiaal wordt uitgelezen vanaf de DB, het uitgeleend materiaal wordt uitgelezen uit de DB. Hierdoor kan lokaal het aantal materiaal bijgehouden worden zonder dit in de Database aan te passen.</para>
        /// </summary>
        /// <param name="mat">Het materiaal.</param>
        /// <returns>Een int; de hoeveelheid Materiaal dat er nog is.</returns>
        public static int GetHoeveelheidMateriaal(Materiaal mat)
        {
            int beschikbaar = 0; // Hoeveel materiaal er normaal is.
            int uitgeleend = 0; // Hoeveel materiaal er is verhuurd.
            int totaal = 0;     // beschikbaar - uitgeleend

            string sqla = "SELECT AANTAL FROM MATERIAAL WHERE TYPE = '" + mat.Type + "'";
            string sqlb = "SELECT AANTAL FROM UITLENING WHERE TYPE = '" + mat.Type + "'";
            OracleCommand sqlacommand = new OracleCommand(sqla, conn);
            OracleCommand sqlbcommand = new OracleCommand(sqlb, conn);

            try
            {
                conn.Open();
                OracleDataReader sqlareader = sqlacommand.ExecuteReader();
                while (sqlareader.Read())
                {
                    beschikbaar = Convert.ToInt32(sqlareader["AANTAL"]);
                }
                OracleDataReader sqlbreader = sqlbcommand.ExecuteReader();
                while (sqlbreader.Read())
                {
                    uitgeleend = Convert.ToInt32(sqlbreader["AANTAL"]);
                }
                totaal = (beschikbaar - uitgeleend);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                
            }
            return totaal;
        }

        /// <summary>
        /// Deze methode kijkt wat de naam van de persoon is bij gegeven reserveringsnummer.
        /// </summary>
        /// <param name="reserveringsnummer">Het reserveringsnummer van de klant.</param>
        /// <returns>De naam die bij dit reserveringsnummer hoort.</returns>
        public static string GetPersoonByReserveringsnr(int reserveringsnummer)
        {
            string naam = string.Empty;

            string sqla = "SELECT NAAM FROM KLANT_BETALEND WHERE RESERVERINGSNUMMER = " + reserveringsnummer;
            OracleCommand sqlacommand = new OracleCommand(sqla, conn);

            try
            {
                conn.Open();
                OracleDataReader sqlareader = sqlacommand.ExecuteReader();
                while (sqlareader.Read())
                {
                    naam = Convert.ToString(sqlareader["NAAM"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return naam;
        }
    }
}
