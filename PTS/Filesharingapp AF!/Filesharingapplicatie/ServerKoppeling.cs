using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Filesharingapplicatie
{
    public static class ServerKoppeling
    {
        /// <summary>
        /// Deze functie maakt een nieuwe verbinding aan tussen de client en de server.
        /// </summary>
        /// <returns>De socket tussen client en server.</returns>
        public static Socket newConnection()
        {
            Socket MySocket = null;
            try
            {
                IPAddress MyIPAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint MyIPEndPoint = new IPEndPoint(MyIPAddress, 7000);
                MySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                MySocket.Connect(MyIPEndPoint);
            }
            catch (Exception se)
            {

                throw se;
            }
            return MySocket;
        }   // zet de constante waarden
        /// <summary>
        /// Deze functie haalt een opgevraagd bestand binnen en bouwt deze op in de User downloads map.
        /// </summary>
        /// <param name="MySocket">De socket tussen client en server.</param>
        private static void receiveFile(Socket MySocket)
        {
            try
            {
                byte[] data = new byte[1024];
                MySocket.Receive(data);
                string identifier = Encoding.ASCII.GetString(data, 0, 1);
                long sizeDownloaded = 0;
                long fileLength = Convert.ToInt64(Encoding.ASCII.GetString(data, 1, 15));

                int fileNameLength = Convert.ToInt32(Encoding.ASCII.GetString(data, 16, 3));

                string fileName = Encoding.ASCII.GetString(data, 19, fileNameLength);
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\" + fileName;

                FileStream newFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(newFile);
                while ((fileLength - sizeDownloaded) >= 1024)
                {
                    data = new byte[1024];
                    int blockSize = MySocket.Receive(data);
                    sizeDownloaded += blockSize;
                    writer.Write(data, 0, blockSize);
                }
                if (sizeDownloaded != fileLength)
                {
                    data = new byte[(fileLength - sizeDownloaded)];
                    sizeDownloaded += MySocket.Receive(data);
                    writer.Write(data);
                }
                writer.Close();
                newFile.Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MySocket != null)
                {
                    MySocket.Close();
                }
            }
        }   // download een bestand van de server
        /// <summary>
        /// Deze functie stuurt een bestand in delen op naar de server
        /// </summary>
        /// <param name="fileFullPath">Output pad</param>
        /// <param name="toFolderPath">Input pad</param>
        public static void sendFile(string fileFullPath, string toFolderPath)
        {
            Socket MySocket = null;
            FileInfo file = null;
            try
            {
                MySocket = newConnection();
                //File openen en gegevens uitlezen
                file = new FileInfo(fileFullPath);
                string fileLength = file.Length.ToString();
                string fileName = toFolderPath + "\\" + file.Name;
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
                byte[] identifierBytes = Encoding.ASCII.GetBytes("2");
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
                MySocket.Send(data);
                //FileData pakketten sturen
                MySocket.SendFile(fileFullPath);
                //Socket sluiten
                //Console.WriteLine("File sent!");
                MySocket.Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MySocket != null)
                {
                    MySocket.Close();
                }
            }
        }   // upload een bestand naar de server
        /// <summary>
        /// Deze functie vraagt aan de server een bepaald bestand op.
        /// </summary>
        /// <param name="filepath">Pad van het gevraagde bestand.</param>
        public static void requestFile(object filepath)
        {
            string filePath = (string)filepath;
            Socket MySocket = null;
            try
            {
                MySocket = newConnection();
                string filePathLengthString = filePath.Length.ToString();
                byte[] identifierBytes = Encoding.ASCII.GetBytes("0");
                byte[] filePathBytes = Encoding.ASCII.GetBytes(filePath);
                byte[] fileRequestBytes = new byte[1024];
                identifierBytes.CopyTo(fileRequestBytes, 0);
                while (filePathLengthString.Length < 3)
                {
                    filePathLengthString = "0" + filePathLengthString;
                }
                byte[] filePathLengthBytes = Encoding.ASCII.GetBytes(filePathLengthString);
                filePathLengthBytes.CopyTo(fileRequestBytes, 1);
                filePathBytes.CopyTo(fileRequestBytes, 4);
                MySocket.Send(fileRequestBytes);
                receiveFile(MySocket);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MySocket != null)
                {
                    MySocket.Close();
                }
            }
            
        }   // request een bestand van de server
        /// <summary>
        /// Deze functie verzoekt de server om een bepaald bestand te verwijderen.
        /// </summary>
        /// <param name="filePath">Pad van het te verwijderen bestand.</param>
        public static void deleteFile(string filePath)
        {
            Socket MySocket = null;
            try
            {
                MySocket = newConnection();
                string filePathLengthString = filePath.Length.ToString();
                byte[] identifierBytes = Encoding.ASCII.GetBytes("1");
                byte[] filePathBytes = Encoding.ASCII.GetBytes(filePath);
                byte[] fileRequestBytes = new byte[1024];
                identifierBytes.CopyTo(fileRequestBytes, 0);
                while (filePathLengthString.Length < 3)
                {
                    filePathLengthString = "0" + filePathLengthString;
                }
                byte[] filePathLengthBytes = Encoding.ASCII.GetBytes(filePathLengthString);
                filePathLengthBytes.CopyTo(fileRequestBytes, 1);
                filePathBytes.CopyTo(fileRequestBytes, 4);
                MySocket.Send(fileRequestBytes);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MySocket != null)
                {
                    MySocket.Close();
                }
            }
        }   // verwijderd een bestand van de server
        /// <summary>
        /// Deze functie verzoekt de server om een map aan te maken.
        /// </summary>
        /// <param name="folderPath">Pad van de aan te maken map.</param>
        public static void createFolder(string folderPath)
        {
            Socket MySocket = null;
            try
            {
                MySocket = newConnection();
                string folderPathLengthString = folderPath.Length.ToString();
                byte[] identifierBytes = Encoding.ASCII.GetBytes("4");
                byte[] folderPathBytes = Encoding.ASCII.GetBytes(folderPath);
                byte[] folderRequestBytes = new byte[1024];
                identifierBytes.CopyTo(folderRequestBytes, 0);
                while (folderPathLengthString.Length < 3)
                {
                    folderPathLengthString = "0" + folderPathLengthString;
                }
                byte[] folderPathLengthBytes = Encoding.ASCII.GetBytes(folderPathLengthString);
                folderPathLengthBytes.CopyTo(folderRequestBytes, 1);
                folderPathBytes.CopyTo(folderRequestBytes, 4);
                MySocket.Send(folderRequestBytes);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MySocket != null)
                {
                    MySocket.Close();
                }
            }
        }   // maakt een nieuwe folder aan op de server
        /// <summary>
        /// Deze functie verzoekt de server om een map met content te verwijderen.
        /// </summary>
        /// <param name="folderPath">Pad van de te verwijderen map.</param>
        public static void deleteFolder(string folderPath)
        {
            Socket MySocket = null;
            try
            {
                MySocket = newConnection();
                string folderPathLengthString = folderPath.Length.ToString();
                byte[] identifierBytes = Encoding.ASCII.GetBytes("3");
                byte[] folderPathBytes = Encoding.ASCII.GetBytes(folderPath);
                byte[] folderRequestBytes = new byte[1024];
                identifierBytes.CopyTo(folderRequestBytes, 0);
                while (folderPathLengthString.Length < 3)
                {
                    folderPathLengthString = "0" + folderPathLengthString;
                }
                byte[] folderPathLengthBytes = Encoding.ASCII.GetBytes(folderPathLengthString);
                folderPathLengthBytes.CopyTo(folderRequestBytes, 1);
                folderPathBytes.CopyTo(folderRequestBytes, 4);
                MySocket.Send(folderRequestBytes);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MySocket != null)
                {
                    MySocket.Close();
                }
            }            
        }   // verwijderd een folder van de server
    }
}
