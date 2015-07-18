using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace ServerApp1
{
    class Program {
        public static void Main() 
        {
            //Socket reference maken en Endpoint maken
            Socket MySocket = null;
            IPAddress MyIPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint MyIPEndPoint = new IPEndPoint(MyIPAddress, 7000);
            try
            {
                //Socket openen
                MySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                MySocket.Bind(MyIPEndPoint);
                //Maximaal 256 listening ports
                MySocket.Listen(256);

                while (true)
                {
                    // Nieuwe verbinding accepteren
                    Socket clientsocket = MySocket.Accept();
                    // Thread starten die naar de socket blijft luisteren.
                    new Thread(clientMessageHandler).Start(clientsocket);
                }
            }
            catch (SocketException e)
            {
                // Error geven en socket sluiten
                Console.WriteLine("Error: " + e.Message);
                System.Threading.Thread.Sleep(5000);
                MySocket.Close();
            }
        }
        /// <summary>
        /// Deze functie wordt altijd als thread gestart wanneer een client een verbinding maakt, 
        /// en als argument krijgt de functie de verbinding tussen die server en client mee.
        /// Deze functie blijft kijken of de client een berichtje stuurt naar de server om vervolgens
        /// te kijken wat ermee moet gebeuren en de juiste functie hiervoor te triggeren. Totdat de 
        /// client of server de verbinding sluit.
        /// </summary>
        /// <param name="clientsocket">De verbinding tussen server en client.</param>
        public static void clientMessageHandler(object clientsocket)
        {
            //object converten naar socket
            Socket clientSock = (Socket) clientsocket;

            while (clientSock.Connected)
            {
                byte[] dataReceived = new byte[1024];
                int fileNameLength;
                string fileName;
                try
                {
                    //Data ontvangen
                    clientSock.Receive(dataReceived);
                    //Uitzoeken watvoor pakket
                    string identifier = Encoding.ASCII.GetString(dataReceived).First().ToString();
                    switch (identifier)
                    {
                        case "0":
                            fileNameLength = Convert.ToInt32(Encoding.ASCII.GetString(dataReceived, 1, 3));
                            fileName = Encoding.ASCII.GetString(dataReceived, 4, fileNameLength);
                            //Bestand versturen
                            Console.WriteLine("Client " + clientSock.RemoteEndPoint + " has requested file " + fileName);
                            sendFile(clientSock, fileName);
                            break;
                        case "1":
                            fileNameLength = Convert.ToInt32(Encoding.ASCII.GetString(dataReceived, 1, 3));
                            fileName = Encoding.ASCII.GetString(dataReceived, 4, fileNameLength);
                            //Bestand deleten
                            Console.WriteLine("Client " + clientSock.RemoteEndPoint + " requests to delete file " + fileName);
                            deleteFile(clientSock, fileName);
                            break;
                        case "2":
                            Console.WriteLine("Receiving file from " + clientSock.RemoteEndPoint);
                            receiveFile(clientSock, dataReceived);
                            break;
                        case "3":
                            fileNameLength = Convert.ToInt32(Encoding.ASCII.GetString(dataReceived, 1, 3));
                            fileName = Encoding.ASCII.GetString(dataReceived, 4, fileNameLength);
                            Console.WriteLine("Client " + clientSock.RemoteEndPoint + " requests to delete folder " + fileName);
                            deleteFolder(clientSock, fileName);
                            break;
                        case "4":
                            fileNameLength = Convert.ToInt32(Encoding.ASCII.GetString(dataReceived, 1, 3));
                            fileName = Encoding.ASCII.GetString(dataReceived, 4, fileNameLength);
                            Console.WriteLine("Client " + clientSock.RemoteEndPoint + " requests to create folder " + fileName);
                            createFolder(clientSock, fileName);
                            break;
                    }
                }
                catch (Exception)
                {
                    clientSock.Close();
                }
            }
        }
        /// <summary>
        /// Deze functie stuurt gegevens over de door de client gevraagde file, en daarop volgend
        /// de file zelf in delen op naar de client en sluit vervolgens de verbinding.
        /// </summary>
        /// <param name="clientSock">De verbinding tussen de client en de server</param>
        /// <param name="fileFullPath">Het bestandpad van de gevraagde file.</param>
        public static void sendFile(Socket clientSock, string fileFullPath)
        {
            FileInfo file = null;
            try
            {
                //File openen en gegevens uitlezen
                file = new FileInfo(@"C:\Fileserver\" + fileFullPath);
                string fileLength = file.Length.ToString();
                string fileName = file.Name;
                string fileNameLength = fileName.Length.ToString();
                //integers aanvullen
                while (fileLength.Length < 15)
                {
                    fileLength = "0" + fileLength;
                }
                while (fileNameLength.Length < 3)
                {
                    fileNameLength = "0" + fileNameLength;
                }
                //Headerpakketdelen maken
                byte[] identifierBytes = Encoding.ASCII.GetBytes("4");
                byte[] fileLengthBytes = Encoding.ASCII.GetBytes(fileLength);
                byte[] fileNameLengthBytes = Encoding.ASCII.GetBytes(fileNameLength);
                byte[] fileNameBytes = Encoding.ASCII.GetBytes(fileName);
                byte[] data = new byte[1024];
                //Headerpakket samenstellen
                identifierBytes.CopyTo(data, 0);
                fileLengthBytes.CopyTo(data, 1);
                fileNameLengthBytes.CopyTo(data, 16);
                fileNameBytes.CopyTo(data, 19);
                //Headerpakket sturen
                clientSock.Send(data);
                //FileData pakketten sturen
                clientSock.SendFile(@"C:\Fileserver\" + fileFullPath);
                //Socket sluiten%
                clientSock.Close();
            }
            catch (Exception e)
            {
                sendMessage(clientSock, e.Message);
            }
        }
        /// <summary>
        /// Deze functie verwijderd het gevraagde bestand van de server.
        /// </summary>
        /// <param name="clientSock">De verbinding tussen de client en de server.</param>
        /// <param name="fileFullPath">Het bestandspad van de desbetreffende file.</param>
        public static void deleteFile(Socket clientSock, string fileFullPath)
        {
            //File deleten
            File.Delete(@"C:\Fileserver\" + fileFullPath);
            //Socket sluiten
            clientSock.Close();
        }

        public static void deleteFolder(Socket clientSock, string path)
        {
            if (Directory.Exists(@"C:\Fileserver\" + path))
            {
                Directory.Delete(@"C:\Fileserver\" + path, true);
            }
            
        }

        public static void createFolder(Socket clientSock, string path)
        {
            if (!Directory.Exists(@"C:\Fileserver\" + path))
            {
                // Create the directory.
                Directory.CreateDirectory(@"C:\Fileserver\" + path);
            }
            clientSock.Close();
        }

        /// <summary>
        /// Deze functie stuurt een bericht naar de client.
        /// </summary>
        /// <param name="clientSock">de verbinding tussen de client en de server.</param>
        /// <param name="message">Het bericht</param>
        public static void sendMessage(Socket clientSock, string message)
        {
            string errorLength = message.Length.ToString();
            //integers aanvullen
            while (errorLength.Length < 3)
            {
                errorLength = "0" + errorLength;
            }
            //Pakketdelen maken
            byte[] identifierBytes = Encoding.ASCII.GetBytes("5");
            byte[] errorLengthBytes = Encoding.ASCII.GetBytes(errorLength);
            byte[] errorBytes = Encoding.ASCII.GetBytes(message);
            byte[] data = new byte[1024];
            //Samenstellen headerpakket
            identifierBytes.CopyTo(data, 0);
            errorLengthBytes.CopyTo(data, 1);
            errorBytes.CopyTo(data, 4);
            //Versturen headerpakket
            clientSock.Send(data);
            //Socket sluiten
            clientSock.Close();
        }

        public static void receiveFile(Socket clientSock, byte[] data)
        {
            string identifier = Encoding.ASCII.GetString(data, 0, 1);
            long sizeDownloaded = 0;
            long fileLength = Convert.ToInt64(Encoding.ASCII.GetString(data, 1, 15));            
            int fileNameLength = Convert.ToInt32(Encoding.ASCII.GetString(data, 16, 3));
            string fileName = Encoding.ASCII.GetString(data, 19, fileNameLength);
            string filePath = @"C:\Fileserver\" + fileName;

            FileStream newFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(newFile);

            while ((fileLength - sizeDownloaded) >= 1024)
            {
                data = new byte[1024];
                int blockSize = clientSock.Receive(data);
                sizeDownloaded += blockSize;
                writer.Write(data, 0, blockSize);
            }
            if (sizeDownloaded != fileLength)
            {
                data = new byte[(fileLength - sizeDownloaded)];
                sizeDownloaded += clientSock.Receive(data);
                writer.Write(data);
            }
            newFile.Close();
            writer.Close();
        }
    }
}