using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phidgets;
using Phidgets.Events;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Diagnostics;
using System.Windows.Forms;


namespace ToegangsSysteem
{
    class DatabaseKoppeling
    {

        private OracleConnection conn;
        private OracleCommand command;
        OracleDataReader reader;
        public string presence;
        public string name;
        public string reason;
        public bool accepted;
        public bool tag;
        public DatabaseKoppeling()
        {
            conn = new OracleConnection();        //voor koppeling met oracle via internet
            command = conn.CreateCommand();

        }

        //Check status of RFID (Checked in, checked out, or not assigned to a customer yet)
        public void CheckPresence(string rfidID)
        {
            //
            //                  WERKT
            //


            String pcn = "252753";
            String pw = "2179985";
            string query = "SELECT Presence, Name FROM PERSON WHERE RFIDNUMBER = '" + rfidID + "'";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    presence = Convert.ToString(reader["Presence"]);

                    name = Convert.ToString(reader["Name"]);
                }
            }
            catch
            {
            }
            finally
            {
                conn.Close();

            }
        }

        public void ConfirmCheckIn(string rfidID)
        {
            //
            //                  WERKT
            //


            String pcn = "252753";
            String pw = "2179985";
            String query = "SELECT COUNT(*) FROM DENIED WHERE RFIDNUMBER = '" + rfidID + "'";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";

            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["COUNT(*)"]) > 0)
                    {
                        accepted = false;
                    }
                    else
                    {
                        accepted = true;
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

        }

        public void CheckIn(string rfidID)
        {
            //
            //                  WERKT
            //


            String pcn = "252753";
            String pw = "2179985";
            String query = "UPDATE Person SET Presence = '1' WHERE RFIDNUMBER = '" + rfidID + "'";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";


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
                query = "commit";
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }

        }


        public void CheckOut(string rfidID)
        {
            //
            //                  WERKT
            //


            String pcn = "252753";
            String pw = "2179985";
            String query = "UPDATE Person SET PRESENCE = 0 WHERE RFIDNUMBER = '" + rfidID + "'";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";


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
                query = "commit";
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DenyAccess(string rfidID, string reason)
        {
            //
            //                  WERKT
            //


            String pcn = "252753";
            String pw = "2179985";
            String query = "INSERT INTO Denied VALUES('" + rfidID + "', '" + reason + "')";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";

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
                query = "commit";
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }

        }

        public void DenyReason(string rfidID)
        {
            String pcn = "252753";
            String pw = "2179985";
            string query = "SELECT DESCRIPTION FROM DENIED WHERE RFIDNUMBER = '" + rfidID + "'";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    reason = Convert.ToString(reader["DESCRIPTION"]);
                    Debug.WriteLine(reason);
                }
            }
            catch
            {
            }
            finally
            {
                conn.Close();

            }
        }

        public void AllowAccess(string rfidID)
        {
            String pcn = "252753";
            String pw = "2179985";
            String query = "DELETE FROM DENIED WHERE RFIDNUMBER = '" + rfidID + "'";
            Debug.WriteLine(query);
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";

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
                query = "commit";
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AddTags(string rfidID)
        {
            String pcn = "252753";
            String pw = "2179985";
            String query = "INSERT INTO RFIDLIST VALUES('" + rfidID + "', 1)";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";


            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                Debug.WriteLine(query);
            }

            catch
            {
            }

            finally
            {
                query = "commit";
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CheckTags(string rfidID)
        {
            String pcn = "252753";
            String pw = "2179985";
            String query = "SELECT COUNT(*) FROM RFIDLIST WHERE RFIDNUMBER = '" + rfidID + "'";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";

            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["COUNT(*)"]) == 0)
                    {
                        tag = true;
                    }
                    else
                    {
                        tag = false;
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
        }

        public void setRfidUnavailable(string rfid)
        {
            String pcn = "252753";
            String pw = "2179985";
            String query = "UPDATE RFIDLIST SET AVAILABLE = '0' WHERE RFIDNUMBER = '" + rfid + "'";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";
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
                query = "commit";
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
