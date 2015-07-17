using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace s23a_Fileshare
{
    class Database
    {
        string RFIDnumber;
        string connstring;

        OracleCommand command;
        OracleConnection conn;
        OracleDataReader reader;

        public Database(string rfidnumber)
        {
            RFIDnumber = rfidnumber;
            connstring = GetConString();
        }

        #region //Front End
        #region //User read database methods
        
        public List<List<String>> getMyUploads(string rfidnumber)
        {
            String Query = SelectQuery("*", "FILES", "RFIDNUMBER", rfidnumber, true, false);
            return SelectMultipleMethod(Query, 6);
        }

        public List<List<String>> getBrowseFiles(string rfidnumber)
        {
            String Query = "SELECT * FROM FILES WHERE RFIDNUMBER <> " + rfidnumber;
            return SelectMultipleMethod(Query, 6);
        }
        public List<List<String>> SearchFiles(string searchtype, string searchfield)
        {
            String Query = "";
            switch(searchtype)
            {
                case "File Title": Query = SelectQuery("*", "FILES", "FILETITLE", searchfield, true, true); break;
                case "File Type": Query = SelectQuery("*", "FILES", "TYPE_NAME", searchfield, true, false); break;
                case "Tags": Query = SelectQuery("*", "FILES", "TAGS", searchfield, true, true); break;
                case "Uploader": Query = SelectQuery("*", "FILES", "RFIDNUMBER", searchfield, true, false); break;
            }

            return SelectMultipleMethod(Query, 6);
        }

        #endregion
        #region //User database editing methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepathtarget"></param>
        /// <param name="tags"></param>
        /// <param name="filetype"></param>
        public void Upload(string filepath, string filetype, string tags, string title, string description)
        {
            string filename = filepath.Substring(filepath.LastIndexOf(@"\" + 1));
            
            String Query = InsertQuery("FILES");
            Query += InsertQueryAdd("FILEPATH", false, false, false);
            Query += InsertQueryAdd("RFIDNUMBER", false, false, false);
            Query += InsertQueryAdd("TYPE_NAME", false, false, false);
            Query += InsertQueryAdd("FILENAME", false, false, false);
            Query += InsertQueryAdd("TAGS", false, false, false);
            Query += InsertQueryAdd("FILETITLE", false, false, false);
            Query += InsertQueryAdd("DESCRIPTION", true, false, false);

            Query += InsertQueryAdd(filepath, false, true, true);
            Query += InsertQueryAdd(RFIDnumber, false, true, true);
            Query += InsertQueryAdd(filetype, false, true, true);
            Query += InsertQueryAdd(filename, false, true, true);
            Query += InsertQueryAdd(tags, false, true, true);
            Query += InsertQueryAdd(title, false, true, true);
            Query += InsertQueryAdd(description, true, true, true);

            InsertMethod(Query);
        }

        /// <summary>
        /// Deletes entry from the FILES table.
        /// </summary>
        /// <param name="filepath">unique filepath</param>
        /// <param name="rfidnumber"></param>
        public void DeleteUpload(string filepath, string rfidnumber)
        {
            String Query;
            Query = DeleteQueryOpen("FILES");
            Query += DeleteQueryAdd("FILEPATH", filepath, false);
            Query += DeleteQueryAdd("RFIDNUMBER", rfidnumber, true);

            DeleteMethod(Query);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="rating"></param>
        public void Rate(string filepath, bool rating)
        {
            String Query;

            Query = InsertQuery("RATING");
            Query += InsertQueryAdd("FILEPATH", false, false, false);
            Query += InsertQueryAdd("RFIDNUMBER", false, false, false);
            Query += InsertQueryAdd("RATING", true, false, false);

            Query += InsertQueryAdd(filepath, false, true, true);
            Query += InsertQueryAdd(RFIDnumber, false, true, true);
            if (rating)
            { Query += InsertQueryAdd("1", true, true, false); }
            else
            { Query += InsertQueryAdd("-1", true, true, false); }

            InsertMethod(Query);
            UpdateMethod(("UPDATE FILES SET RATING = (SELECT SUM(RATING) FROM RATING WHERE FILEPATH = " + filepath + ")"));
        }

        /// <summary>
        /// Inserts new Flag record in de FLAG entiteit in de database.
        /// </summary>
        /// <param name="filepath">filenumber to flag.</param>
        /// <param name="comment">reason file was flagged.</param>
        public void Flag(string filepath, string comment)
        {
            String Query;
            
            Query = InsertQuery("FLAG");
            Query += InsertQueryAdd("FILEPATH", false, false, false);
            Query += InsertQueryAdd("RFIDNUMBER", false, false, false);
            Query += InsertQueryAdd("DESCRIPTION", true, false, false);

            Query += InsertQueryAdd(filepath, false, true, true);
            Query += InsertQueryAdd(RFIDnumber, false, true, true);
            Query += InsertQueryAdd(comment, true, true, true);

            InsertMethod(Query);
        }

        #endregion
        
        #region //Admin read database methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<List<String>> RetrieveFlaglog()
        {
            return SelectMultipleMethod("SELECT FILETITLE, COUNT(FILEPATH) AS NumberOfFlags FROM FLAG GROUP BY FILETITLE", 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public List<List<String>> RetrieveFlagsForFile(string filepath)
        {
            return SelectMultipleMethod(("SELECT * FROM FLAG WHERE FILEPATH = " + filepath), 3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<List<String>> RetrieveUploadlog()
        {
            return SelectMultipleMethod("SELECT * FROM FILES", 5);
        }

        #endregion
        #region //Admin database editing methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rfidnumber"></param>
        /// <param name="description"></param>
        public void BanUser(string rfidnumber, string description)
        {
            String Query = InsertQuery("DENIED");
            Query += InsertQueryAdd("RFIDNUMBER", false, false, false);
            Query += InsertQueryAdd("DESCRIPTION", false, false, false);
            Query += InsertQueryAdd(rfidnumber, false, true, true);
            Query += InsertQueryAdd(description, true, true, true);

            InsertMethod(Query);
        }
        #endregion

        #region //System data requests

        #region //Login Form
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rfidnumber"></param>
        /// <returns></returns>
        public List<String> checkAdmin(string rfidnumber)
        {
            string Query = SelectQuery("RFIDNUMBER", "EMPLOYEE", "EMPLOYEETYPE", "ADMIN", true, false);
            List<String> Admins = SelectSingleMethod(Query, 1);

            return Admins;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rfidnumber"></param>
        /// <returns></returns>
        public bool checkBanned(string rfidnumber)
        {
            List<String> banned;

            string Query = SelectQuery("RFIDNUMBER", "DENIED", "RFIDNUMBER", rfidnumber, true, false);
            banned = SelectSingleMethod(Query, 1);

            if (banned.Contains(rfidnumber))
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rfidnumber"></param>
        /// <returns></returns>
        public List<String> checkPassword(string rfidnumber)
        {
            List<String> accountDetails = new List<String>();
            string Query = SelectQuery("RFID, PASSWORD", "PERSON", "RFID", rfidnumber, true, false);
            accountDetails = SelectSingleMethod(Query, 2);

            return accountDetails;
        }
        #endregion
        #region //Fileshare Form
        public List<String> getFileTypes()
        {
            List<String> FileTypes = new List<String>();

            String Query = "SELECT TYPE_NAME FROM FILETYPE";
            FileTypes = SelectSingleMethod(Query, 1);
            return FileTypes;
        }
        #endregion
        #endregion
        #endregion

        #region //Back-End
        
        public string GetConString()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string Text = File.ReadAllText(appPath + "/config.txt");

            int startpoint = Text.IndexOf("DBConString");
            int getStringStart = Text.IndexOf('"', startpoint) + 1;
            int getStringEnd = Text.IndexOf('"', getStringStart);
            getStringEnd -= getStringStart;

            string ConString = Text.Substring(getStringStart, getStringEnd);

            return ConString;
        }
        #region //Database approach methods

        private List<List<String>> SelectMultipleMethod(string query, int numberofcolumns)
        {
            command = new OracleCommand();
            conn = new OracleConnection();
            
            List<List<String>> returnData = new List<List<String>>();

            reader = command.ExecuteReader();
            command.CommandText = query;
            conn.ConnectionString = connstring;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                int i = 0; //entry
                int c = 0; //column
                while (reader.Read())
                {
                    returnData.Add(new List<String>());
                    for (int column = c; column < numberofcolumns; c++)
                    {
                        returnData[i].Add(reader[c].ToString());
                    }
                    i++;
                    c = 0;
                }
            }
            catch
            {
            }
            finally
            {
                conn.Close();

            }

            return returnData;
        }

        private List<String> SelectSingleMethod(string query, int numberofcolumns)
        {
            command = new OracleCommand();
            conn = new OracleConnection();
            
            List<String> returnData = new List<String>();

            command.CommandText = query;
            conn.ConnectionString = connstring;
            try
            {
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int column = 0; column < numberofcolumns; column++)
                    {
                        returnData.Add(reader[column].ToString());
                    }
                }
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }

            return returnData;
        }

        private void InsertMethod(string query)
        {
            command = new OracleCommand();
            conn = new OracleConnection();

            command.CommandText = query;
            conn.ConnectionString = connstring;

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateMethod(string query)
        {
            command = new OracleCommand();
            conn = new OracleConnection();

            command.CommandText = query;
            conn.ConnectionString = connstring;

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

        private void DeleteMethod(string query)
        {
            command = new OracleCommand();
            conn = new OracleConnection();

            command.CommandText = query;
            conn.ConnectionString = connstring;

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
        #region //Query Methods

        private string SelectQuery(string what, string table, string parameter, string value, bool isString, bool isLike)
        {
            string selectQuery = "SELECT " + what + " FROM " + table + " WHERE " + parameter;

            if (isLike)
            { selectQuery += " LIKE "; }
            else
            { selectQuery += " = "; }

            if (isString || isLike)
            { selectQuery += "'%"; }
            selectQuery += value;
            if (isString || isLike)
            { selectQuery += "%'"; }
            //selectQuery += ";";
            return selectQuery;
        }

        private string InsertQuery(string table)
        {
            string insertQuery = "INSERT INTO " + table + " (";
            return insertQuery;
        }
        private string InsertQueryAdd(string field, bool last, bool value, bool addQuoteMark)
        {
            string queryAdd = "";
            if (addQuoteMark)
            { queryAdd += "'"; }
            queryAdd += field;
            if (addQuoteMark)
            { queryAdd += "'"; }
            if (!last)
            {
                queryAdd += ",";
            }
            else
            {
                queryAdd += ")";
                if (!value)
                {
                    queryAdd += " VALUES (";
                }
            }
            return queryAdd;
        }

        private string UpdateQuery(string table, string column, string value)
        {
            string returnQuery = "UPDATE " + table + " SET " + column + "='" + value + "'";
            return returnQuery;
        }
        private string UpdateQueryAddSet(string column, string value)
        {
            string returnQuery = ", " + column + "='" + value + "'";
            return returnQuery;
        }
        private string UpdateQueryAddWhere(string column, string value, bool first, bool last)
        {
            string returnQuery;
            if (first)
            {
                returnQuery = " WHERE ";
            }
            
            returnQuery = column + "='" + value + "'";

            if (!last)
            {
                returnQuery += " AND ";
            }
            return returnQuery;
        }


        private string DeleteQueryOpen(string table)
        {
            string deleteQuery = "DELETE FROM " + table + " WHERE ";
            return deleteQuery;
        }
        private string DeleteQueryAdd(string field, string value, bool last)
        {
            string queryAdd = field + " = '" + value + "'";

            if (!last)
            {
                queryAdd += " AND ";
            }
            return queryAdd;
        }

        #endregion        

        #endregion
    }
}
