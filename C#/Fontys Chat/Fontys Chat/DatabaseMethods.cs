// Database methodes.

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Diagnostics;

    public static class DatabaseMethods
    {
        /*
         * BELANGRIJK - Als je de tabel User gebruikt in een query, zet er dan [ en ] omheen
         * [User]
         * 
         * VB:
         * SELECT id, name FROM [User] WHERE email = @mail AND password = @pass", connection);
         * (Geld ook voor INSERT, UPDATE en DELETE)
         * 
         * Als je dit niet doet krijg je namelijk een error.
         * 
         * Let er ook op dat je je de FontysChatDB.mdf connectie in visual studio UIT hebt staan. Dit voorkomt erg veel problemen ;)
         */

        /// <summary>
        /// Checks if a user with the provided email exists.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="pass">The pass.</param>
        /// <returns></returns>
        public static bool DoesEmailExist(string email, string pass)
        {
            int login = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) AS LOGIN FROM [USER] WHERE EMAIL = @email AND PASSWORD = @pass", connection);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        login = Convert.ToInt32(reader["LOGIN"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return login >= 1;
        }

        /// <summary>
        /// Checks if a user with the provided username exists.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static bool DoesUsernameExist(string username)
        {
            int login = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) AS LOGIN FROM [USER] WHERE username = @uname", connection);
                    command.Parameters.AddWithValue("@uname", username);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        login = Convert.ToInt32(reader["LOGIN"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return login >= 1;
        }

        /// <summary>
        /// Loads the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="pass">The pass.</param>
        /// <returns></returns>
        public static User LoadUser(string email, string pass)
        {
            User user = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT id, username FROM [User] WHERE email = @mail AND password = @pass", connection);
                    command.Parameters.AddWithValue("@mail", email);
                    command.Parameters.AddWithValue("@pass", pass);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        user = new User(Convert.ToInt32(reader["id"]), reader["username"].ToString(), email);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); 
            }
            return user;
        }

        /// <summary>
        /// Sets the online status.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="online">if set to <c>true</c> [online].</param>
        public static void SetOnlineStatus(int id, bool online)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE [User] SET Online = " + (online ? 1 : 0) + " WHERE id = @userId", connection);
                    command.Parameters.AddWithValue("@userId", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Bij een error de error message weergeven.
            }
        }

        /// <summary>
        /// Adds the friend.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="friendId">The friend id.</param>
        /// <returns></returns>
        public static bool AddFriend(int id, int friendId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Friend VALUES (@userId, @friendId)", connection);
                    command.Parameters.AddWithValue("@userId", id);
                    command.Parameters.AddWithValue("@friendId", friendId);
                    command.ExecuteNonQuery();
                    return true;
                }  
            }
            catch (Exception)
            {
                // Bij een error de error message weergeven.
            }
            return false;
        }

        /// <summary>
        /// Adds the chat text.
        /// </summary>
        /// <param name="authorId">The author id.</param>
        /// <param name="text">The text.</param>
        public static void AddChatText(int authorId, string text)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Text VALUES (@authorId, @date, @text)", connection);
                    command.Parameters.AddWithValue("@authorId", authorId);
                    command.Parameters.AddWithValue("@date", DateTime.Now);
                    command.Parameters.AddWithValue("@text", text);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Signs up.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The email.</param>
        public static void SignUp(string username, string password, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO [USER] VALUES (@username, @password, @email, '0')", connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Bij een error de error message weergeven.
            }
        }

        /// <summary>
        /// Changes the account.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="id">The id.</param>
        public static void ChangeAccount(string username, string password, int iD)
        {           
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE [USER] SET Username = @username, Password = @password Where ID = @UserID", connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@UserID", iD);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Bij een error de error message weergeven.
            }
        }

        /// <summary>
        /// Creates a new friend.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public static User NewFriend(string username)
        {
            User friend = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT id, email FROM [User] WHERE username = @username", connection);
                    command.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        friend = new User(Convert.ToInt32(reader["id"]), username, reader["email"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return friend;
        }
    }
}