using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;  // nodig voor exe pad van applicatie
using System.Data.OleDb;     // nodig voor connectie met database

namespace Hilversum
{
    public class DatabaseClass
    {
        private OleDbConnection connection;

        public DatabaseClass()
        {
            String pad;
            String provider;
            String applicatiePad;
            String connectionString;

            // Deze is voor de ACCES datadase

            provider = "Provider=Microsoft.ACE.OLEDB.12.0"; //voor een accdb-database.
            //provider = "Provider=Microsoft.Jet.OLEDB.4.0"; //voor een oude 32 bits mdb-database.


            /**************************************************************** 
             * opmerking : Normaal is pad iets van de vorm "c:\temp\" 
             *             Dat gaat mis omdat het \ een speciale betekenis heeft
             *             zoals \n of \r. Er zijn 3 oplossingen voor dit probleem.
             *             (1) Dubbele backslash => "c:\\temp\\"
             *             (2) Forwardslash gebruiken => "c:/temp/"
             *             (3) @ voor de string  zodat compiler / niet ziet als speciaal teken =>@"c:\temp\"
             *  
             *              Hieronder in dit voorbeeld is gekozen voor de forwardslash
             * 
             * Het pad in de vorm van "c:\temp\" wil ook zeggen dat de database ALTJD in die directorie
             * moet staan, maar vaak wil je dat niet maar wil je dat de database in dezelfde directorie 
             * komt te staan als de applicatie zelf dan wel in een subdirectorie bij de applicatie
             * Hiervoor is een property ExecutablePath in C# aanwezig, die je het pad geeft van de
             * applicatie. Deze property staat in System.Windows.Forms.Application
             * 
             * Een andere manier is gebruik te maken van "|DataDirectory|" 
             */

            applicatiePad = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\"));
            pad = "Data Source=" + applicatiePad + "/Muziek.accdb";

            //Enkel bij een datasource kan ook het onderstaande 
            // pad = "Data Source=|DataDirectory|/StudentenDBS.accdb";

            connectionString = provider + ";" + pad;

            connection = new OleDbConnection(connectionString);
        }


        public List<Geluidsfragment> Getallefragmenten ()
        {
            String sql = "SELECT * FROM Muziek";
            OleDbCommand command = new OleDbCommand(sql, connection);

            List<Geluidsfragment> hulp;
            hulp = new List<Geluidsfragment>();

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                string Titel;
                int Nummer;
                string Bestandsnaam;
                int Tijdsduur;
                while (reader.Read())
                {
                    Titel = Convert.ToString(reader["Titel"]);
                    Nummer = Convert.ToInt32(reader["Nummer"]);
                    Bestandsnaam = Convert.ToString(reader["Bestandsnaam"]);
                    Tijdsduur = Convert.ToInt32(reader["Tijdsduur"]);
                    hulp.Add(new Geluidsfragment(Nummer, Titel, Bestandsnaam, Tijdsduur / 60, Tijdsduur % 60));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return hulp;
        }

        public void VoegToe(int Nummer, string Titel, string Bestandsnaam, int Tijdsduur)
        {
            String sql = "INSERT INTO Muziek (Nummer, Titel, bestandsnaam, Tijdsduur) VALUES (" + Nummer + ",'" + Titel + "'" + ",'" + Bestandsnaam + "'" + ",'" + Tijdsduur + "')";
            OleDbCommand command = new OleDbCommand(sql, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void RemoveItem(int i)
        {
            String sql = "DELETE FROM Muziek WHERE Nummer = " + Convert.ToString(i);

            OleDbCommand command = new OleDbCommand(sql, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        
        }

      /*  public int AantalStudenten()
        {
            String sql = "SELECT COUNT(*) FROM Muziek";
            OleDbCommand command = new OleDbCommand(sql, connection);
            int aantal = 0;
            try
            {
                connection.Open();
                aantal = Convert.ToInt32(command.ExecuteScalar());
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return aantal;
        }*/
    }
}
