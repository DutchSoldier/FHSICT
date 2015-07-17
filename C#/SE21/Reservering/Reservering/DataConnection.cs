using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace Reservering
{
    class DataConnection
    {
        string pcn = "252753";
        string pw = "2179985";
        private OracleConnection conn;
        private OracleCommand command;
        private OracleDataReader reader;

        public DataConnection()
        {
            conn = new OracleConnection();
            command = conn.CreateCommand();
        }

        public List<RentalObject> getRentalObjects()
        {
            List<RentalObject> rentalobjects = new List<RentalObject>();
            string query = "SELECT * FROM RENTALOBJECT";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";

            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                Console.WriteLine("test");
                while (reader.Read())
                {
                   rentalobjects.Add(new RentalObject(Convert.ToInt32(reader["RENTALOBJECTNUMBER"]),Convert.ToString(reader["OBJECT_DESCRIPTION"]), Convert.ToDouble(reader["PRICE_OBJECT"]), Convert.ToInt32(reader["STOCK"]),0));
                   
                }
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
            return rentalobjects;
        }

        public List<Campsite> getCampsites()
        {
            List<Campsite> campsites = new List<Campsite>();
            String query = "SELECT * FROM CAMPSPOT";
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";

            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bool available;
                    if (Convert.ToInt32(reader["AVAILABLE"]) == 0)
                    {
                        available = false;
                    }
                    else
                    {
                        available = true;
                    }
                    campsites.Add(new Campsite(Convert.ToInt32(reader["CAMPSPOTNUMBER"]), Convert.ToString(reader["CAMPSPOT_TYPE"]), Convert.ToDouble(reader["PRICE_CAMPSPOT"]), available, Convert.ToInt32(reader["NUMBEROFPERSONS"])));
                }
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
            return campsites;
        }

        public string getFirstAvailableRFID()
        {
            string query = "SELECT RFIDNUMBER FROM RFIDLIST WHERE AVAILABLE = 1";
            string rfid = null;
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";

            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                reader.Read();
                rfid = Convert.ToString(reader["RFIDNUMBER"]);
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            return rfid;
        }

        public void setRfidUnavailable(string rfid)
        {
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

        public void addPerson(Person p)
        {
            String query = "INSERT INTO PERSON VALUES('" + p.name + "', '" + p.password + "', '" + p.zipCode + "', '" + p.email + "', '" + p.phoneNumber + "', 0, '" + p.houseNumber + "', '" + p.emergencyNumber + "', '" + p.rfid + "', 'CUSTOMER')";
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

        public void updatePerson(Person p)
        {
        }

        public void addCustomer(Person p, int customerNumber, int primary)
        {
            String query = "INSERT INTO CUSTOMER VALUES('" + customerNumber + "', '" + p.name + "', '" + p.password + "', '" + primary + "')";
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

        public void updateCustomer(Person p, int customerNumber, int primary)
        {
        }

        public int getNewCustomerNumber()
        {
            String query = "SELECT MAX(CUSTOMERNUMBER) as CUSTOMERNUMBER  FROM CUSTOMER";
            int customerNumber = 0;
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";

            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                reader.Read();
                customerNumber = Convert.ToInt32(reader["CUSTOMERNUMBER"]);
            }

            catch
            {
            }

            finally
            {
                conn.Close();
            }
            return customerNumber;
        }

        public void addRentalObject(int customerNumber, int rentalObjectNumber, int amount)
        {
            String query = "INSERT INTO CUSTOMERRENTALOBJECT VALUES('" + customerNumber + "', '" + rentalObjectNumber + "', '" + amount + "')";
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

        public void updateStock(int rentalObjectNumber, int stock)
        {
            String query = "UPDATE RENTALOBJECT SET STOCK = '" + stock + "' WHERE RENTALOBJECTNUMBER = '" + rentalObjectNumber + "'";
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

        public void reserveCampsite(int campSiteNumber)
        {
            String query = "UPDATE CAMPSPOT SET AVAILABLE = '0' WHERE CAMPSPOTNUMBER = '" + campSiteNumber + "'";
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

        public int getNewReservationNumber()
        {
            String query = "SELECT MAX(RESERVATIONNUMBER) as RESERVATIONNUMBER  FROM RESERVATION";
            int reservationNumber = 0;
            command.CommandText = query;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";

            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                reader.Read();
                reservationNumber = Convert.ToInt32(reader["RESERVATIONNUMBER"]);
            }

            catch
            {
            }

            finally
            {
                conn.Close();
            }
            return reservationNumber;
        }

        public void addCustomerToReservation(int reservationNumber, int customerNumber)
        {
            String query = "INSERT INTO CUSTOMERRESERVATION VALUES('" + reservationNumber + "', '" + customerNumber + "', 0)";
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

        public void addReservation(int campSiteNumber, int reservationNumber)
        {
            String query = "INSERT INTO RESERVATION VALUES('" + reservationNumber + "', '" + campSiteNumber +"')";
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

        public bool login(string rfid, string password)
        {
            String query = "SELECT COUNT(*) AS 'RESULT' FROM PERSON WHERE RFIDNUMBER = '" + rfid + "' AND WHERE PASSWORD = '" + password + "'";
            command.CommandText = query;
            string result = null;
            conn.ConnectionString = "User Id=" + pcn + ";Password=" + pw + ";Data Source=" + "//webdb.hi.fontys.nl:1521/cicdb.informatica.local" + ";";
            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                reader.Read();
                result = Convert.ToString(reader["RFIDNUMBER"]);
            }
            catch
            {
            }

            finally
            {
                conn.Close();
            }
            if (string.IsNullOrEmpty(result))
            {
                return true;
            }
            return false;
        }
    }
}
