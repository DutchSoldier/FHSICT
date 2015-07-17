using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;  // nodig voor exe pad van applicatie
using System.Data.OleDb;     // nodig voor connectie met database

namespace DatabaseKoppeling
{
    public class DataKoppeling
    {
        private OleDbConnection connection;

        public DataKoppeling()
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
            pad = "Data Source=" + applicatiePad + "/StudentenDBS.accdb";

            //Enkel bij een datasource kan ook het onderstaande 
            // pad = "Data Source=|DataDirectory|/StudentenDBS.accdb";

            connectionString = provider + ";" + pad;

            connection = new OleDbConnection(connectionString);
        }


        public List<Student> GetAlleStudenten()
        {
            String sql = "SELECT * FROM StudentTabel";
            OleDbCommand command = new OleDbCommand(sql, connection);

            List<Student> hulp;
            hulp = new List<Student>();

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                string naam;
                int nr;
                int stpunten;
                while (reader.Read())
                {
                    naam = Convert.ToString(reader["Naam"]);
                    nr = Convert.ToInt32(reader["Studentnummer"]);
                    stpunten = Convert.ToInt32(reader["Studiepunten"]);
                    hulp.Add(new Student(nr, naam, stpunten));
                }
            }
            catch
            {
                MessageBox.Show("foutje");
            }
            finally
            {
                connection.Close();
            }
            return hulp;
        }

        public void VoegToe(int nummer, string naam, int studpunten)
        {
            String sql = "INSERT INTO StudentTabel VALUES (" + nummer + ",'" + naam + "'" + "," + studpunten + ")";
            OleDbCommand command = new OleDbCommand(sql, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }

        public int AantalStudenten()
        {
            String sql = "SELECT COUNT(*) FROM StudentTabel";
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
        }
    }
}
