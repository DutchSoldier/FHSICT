using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;     // nodig voor connectie met database
using System.Linq;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Top_Secret
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

            provider = "Provider=Microsoft.ACE.OLEDB.12.0";
            

            applicatiePad = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\"));
            pad = "Data Source=" + applicatiePad + "/Databaseproftaak.accdb";

            connectionString = provider + ";" + pad;

            connection = new OleDbConnection(connectionString);
        }


        public List<Enemy> Getallefragmenten()
        {
            String sql = "SELECT * FROM Databaseproftaak";
            OleDbCommand command = new OleDbCommand(sql, connection);

            List<Enemy> hulp;
            hulp = new List<Enemy>();

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
                    hulp.Add(new Enemy(Nummer, Titel, Bestandsnaam, Tijdsduur / 60, Tijdsduur % 60));
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
            String sql = "INSERT INTO Databaseproftaak (Nummer, Titel, bestandsnaam, Tijdsduur) VALUES (" + Nummer + ",'" + Titel + "'" + ",'" + Bestandsnaam + "'" + ",'" + Tijdsduur + "')";
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
        public void RemoveItem(int i)
        {
            String sql = "DELETE FROM Databaseproftaak WHERE Nummer = " + Convert.ToString(i);

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
    }
}
