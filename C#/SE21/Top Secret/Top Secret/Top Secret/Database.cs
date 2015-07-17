using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;


namespace Cookie_Hero.communications
{
    public class Database
    {
        // DIT PAD MOET JE VERANDEREN NAAR JOU PAD NAAR ONS DATABASE BESTAND, JE MOET DIT EERST OP JE COMPUTER PLAATSEN
        private const String pad = "Data Source=Database41.accdb";
        //D:/Tijs/Documents/school/p2/databases/Database41_daam.accdb
        private OleDbConnection connection;
        public EventTypeClass eventTypeClass { get; private set; }

        public Database()
        {
            String provider, connectionString;
            provider = "Provider=Microsoft.ACE.OLEDB.12.0"; //voor een accdb-database.
            connectionString = provider + ";" + pad;
            connection = new OleDbConnection(connectionString);
            eventTypeClass = new EventTypeClass(this.GetAllEventTypes());
        }

        public List<EventHolder> GetAllEvents(int level)
        {
            String sql = "SELECT * FROM Events WHERE levelId = "+level+" OR levelId > 99 ORDER BY eventId, levelId";
            List<List<String>> result = GetAllData(new String[] { "eventId", "levelId", "eventname", "Beschrijving" }, sql);
            List<EventHolder> events = new List<EventHolder>();
            EventHolder physicsEvent;

            foreach (List<String> row in result)
            {
                Console.WriteLine(row[0] + row[1] + row[2] + "ROW");
                physicsEvent = new EventHolder(
                    Convert.ToInt32(row[0]),
                    Convert.ToInt32(row[1]),
                    row[2],
                    row[3]);
                events.Add(physicsEvent);
            }
            Console.WriteLine("Events:"+events.Count);
            return events;
        }

        public List<EventRow> GetAllEventRows(int selectedEventId)
        {
            String sql = "SELECT * FROM EventRow WHERE eventId = " + selectedEventId + " ORDER BY eventId, numrow";
            List<List<String>> result = GetAllData(new String[] { "eventId", "numrow", "type" }, sql);
            List<EventRow> eventrows = new List<EventRow>();
            EventRow eventrow;

            foreach (List<String> row in result)
            {
                eventrow = new EventRow(
                    Convert.ToInt32(row[1]),
                    selectedEventId,
                    eventTypeClass.GetEventTypeById(Convert.ToInt32(row[2])));
                eventrows.Add(eventrow);
                Console.WriteLine(row[2] + " -> " + eventTypeClass.GetEventTypeById(Convert.ToInt32(row[2])));
            }

            return eventrows;
        }

        public List<EventArgument> GetAllEventRowArguments(int selectedNumrow)
        {
            String sql = "SELECT * FROM Argument WHERE rownum = " + selectedNumrow + " ORDER BY rownum, argnum";
            List<List<String>> result = GetAllData(new String[] { "argnum", "rownum", "argument", "type" }, sql);
            List<EventArgument> eventsrowarguments = new List<EventArgument>();
            EventArgument eventsrowargument;

            foreach (List<String> row in result)
            {
                eventsrowargument = new EventArgument(
                    Convert.ToInt32(row[0]),
                    Convert.ToInt32(row[1]),
                    row[2],
                    row[3]);
                eventsrowarguments.Add(eventsrowargument);
            }

            return eventsrowarguments;
        }

        public void AddEvent(EventHolder eventToAdd)
        {
            executeQuery("INSERT INTO Events VALUES (" +
                        eventToAdd.eventId + ",'" +
                        eventToAdd.name + "'" + "," +
                        eventToAdd.levelId + ", '" +
                        eventToAdd.description + "')");
        }

        public void DeleteEvent(EventHolder eventToDelete)
        {
            executeQuery("DELETE FROM Events WHERE eventId = " +
                        eventToDelete.eventId + " AND eventname = '" +
                        eventToDelete.name + "' AND levelId = " +
                        eventToDelete.levelId + ";");
        }

        public void ModifyEvent(EventHolder eventToModify)
        {
            executeQuery("UPDATE Events SET eventname = " + eventToModify.name +
                        ", levelId = " + eventToModify.levelId +
                        ", Beschrijving = '" + eventToModify.description +
                        "' WHERE eventId = " + eventToModify.eventId + ";");
        }

        public void AddEventRow(EventRow eventrowToAdd)
        {
            executeQuery("INSERT INTO EventRow VALUES (" +
                        eventrowToAdd.numRow + "," +
                        eventrowToAdd.eventId + "," +
                        eventrowToAdd.type.id + ")");
        }

        public void DeleteEventRow(EventRow eventrowToDelete)
        {
            executeQuery("DELETE FROM EventRow WHERE numrow = " +
                        eventrowToDelete.numRow + " AND eventId = " +
                        eventrowToDelete.eventId + ";");
        }

        public void AddArgument(EventArgument argument)
        {
            // TODO check bug
            executeQuery("INSERT INTO Argument VALUES (" +
                        argument.argnum + "," +
                        argument.rownum + ",'" +
                        argument.argument + "', '" +
                        argument.type + "')");
        }

        public void DeleteArgument(EventArgument argument)
        {
            executeQuery("DELETE FROM Argument WHERE argnum = " +
                        argument.argnum + " AND rownum = " +
                        argument.rownum + " AND type = '" +
                        argument.type + "';");
        }

        public List<EventType> GetAllEventTypes()
        {
            String sql = "SELECT * FROM EventType ORDER BY eventtypeId";
            List<List<String>> result = GetAllData(new String[] { "eventtypeId", "type", "args", "beschrijving" }, sql);
            List<EventType> eventTypes = new List<EventType>();
            EventType eventType;

            foreach (List<String> row in result)
            {
                eventType = new EventType(
                    Convert.ToInt32(row[0]),
                    row[1],
                    Convert.ToInt32(row[2]));
                eventTypes.Add(eventType);
            }
            Console.WriteLine("Eventtypes:" + eventTypes.Count);
            return eventTypes;
        }


        public List<PhysicsObject> GetAllObjectsFromLevel(int level)
        {
            String sql = "SELECT * FROM Objects WHERE levelId = " + level + " OR levelId > 99";
            List<List<String>> result = GetAllData(new String[] { "objectname", "objectId", "animation", "X", "Y", "depth" }, sql);
            List<PhysicsObject> physicsObjects = new List<PhysicsObject>();
            PhysicsObject physicsObject;

            foreach (List<String> row in result)
            {
                physicsObject = new PhysicsObject()
                {
                    name = row[0],
                    id = Convert.ToInt32(row[1]),
                    aniTexture = Convert.ToInt32(row[2]),
                    position = new Microsoft.Xna.Framework.Vector2(
                        (float)Convert.ToDouble(row[3]), 
                        (float) Convert.ToDouble(row[4])),
                    layerDepth = Convert.ToInt32(row[5])
                };
                physicsObjects.Add(physicsObject);
            }

            return physicsObjects;
        }

        public ImageSequenceController GetAllAnimations(ImageSequenceController animations)
        {
            // TODO versimpel functie
            String sql = "SELECT * FROM Animation";
            OleDbCommand command = new OleDbCommand(sql, connection);
            string animationName = "unknown", basepath, resname;
            int animationId;
            int previd = 0;

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    animationName = Convert.ToString(reader["animationname"]);
                    animationId = Convert.ToInt32(reader["animationId"]);
                    basepath = Convert.ToString(reader["basepath"]);
                    resname = Convert.ToString(reader["resname"]);
                    while (animationId - previd > 1)
                    {
                        previd++;
                        animations.createSequence(previd, basepath + resname, animationName);
                    }
                    animations.createSequence(animationId, basepath + resname, animationName);
                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Log.E("animation after " + animationName + " failed to load, path not correct");
            }
            catch (System.IO.FileNotFoundException e)
            {
                Log.E("animation after " + animationName + " failed to load, name not correct");
            }
            catch(Exception e)
            {
                // kritiek probleem
                Log.E("Database connection fail while retrieving animations: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            Console.WriteLine("Animations:" + animations.Lenght);

            return animations;
        }

        // NOT TESTED YET
        public List<EventHolder> GetAllEventsFromLevel(int level)
        {
            List<EventHolder> eventholders = GetAllEvents(level);
            foreach (EventHolder eventholder in eventholders)
            {
                List<EventRow> eventrows = GetAllEventRows(eventholder.eventId);
                foreach (EventRow eventrow in eventrows)
                {
                    eventholder.addEventRow(eventrow);
                    List<EventArgument> arguments = GetAllEventRowArguments(eventrow.numRow);
                    foreach (EventArgument argument in arguments)
                    {
                        eventrow.addArgument(argument);
                    }
                }
            }
            return eventholders;
        }

        // bedoeld voor select queries
        public List<List<String>> GetAllData(String[] items, String query)
        {
            OleDbCommand command = new OleDbCommand(query, connection);
            List<List<String>> output = new List<List<String>>();

            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        List<String> row = new List<String>();
                        foreach (String str in items)
                        {
                            row.Add(reader[str].ToString());
                        }
                        output.Add(row);
                    }
                }
            }
            catch (OleDbException e)
            {
                // probleem
                Console.WriteLine("Database Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return output;
        }

        // bedoeld voor update, delete en insert queries
        private bool executeQuery(String query)
        {
            OleDbCommand command = new OleDbCommand(query, connection);

            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (OleDbException e)
            {
                //MessageBox.Show("Er is een fout opgetreden bij het uivoeren van de query: \n\r" + e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

        
    }
}
