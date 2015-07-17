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
        private const String pad = "Data Source=Databaseproftaak.accdb";
        public int health;
        public int damage;

        public DatabaseClass()
        {

            String provider;
            String connectionString;

            provider = "Provider=Microsoft.ACE.OLEDB.12.0";

            connectionString = provider + ";" + pad;

            connection = new OleDbConnection(connectionString);
        }


        public void GetHealth(string difficulty, string type)
        {

            String sql = "SELECT health FROM " + difficulty + " WHERE type = '" + type + "';";
            OleDbCommand command = new OleDbCommand(sql, connection);

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    health = Convert.ToInt32(reader["health"]);
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }

        public void GetDamage(string difficulty, string type)
        {

            String sql = "SELECT damage FROM " + difficulty + " WHERE type = '" + type + "';";
            OleDbCommand command = new OleDbCommand(sql, connection);

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    damage = Convert.ToInt32(reader["damage"]);
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }

        public void SubmitScore(string naam, int score)
        {
            String sql = "INSERT INTO HighScore ([Naam], [Score]) VALUES('" + naam + "', '" + score + "');";
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

        public void GetScore(string naam, int score)
        {
            String sql = "SELECT FROM HighScore ([Naam], [Score]) VALUES('" + naam + "', '" + score + "') ORDER BY Score;";
            OleDbCommand command = new OleDbCommand(sql, connection);

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    naam = Convert.ToString(reader["Naam"]);
                    score = Convert.ToInt32(reader["Score"]);
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
