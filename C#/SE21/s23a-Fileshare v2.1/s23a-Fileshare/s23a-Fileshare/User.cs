using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace s23a_Fileshare
{
    class User
    {
        protected string RFIDnumber;
        protected bool isAdmin;
        protected string ServerPath;

        protected Database DATA;

        public string rfidnumber { get { return RFIDnumber; } }
        public string serverPath { get { return ServerPath; } }

        public User(string rfidnumber)
        {
            RFIDnumber = rfidnumber;
            isAdmin = false;
            ServerPath = @"C:\" + RFIDnumber + @"\";

            DATA = new Database(RFIDnumber);
        }

        #region //User File-related Methods.

        protected internal void UploadFile(string sourcePath, string targetPath, string filetype, string tags, string title, string description)
        {
            if (!DATA.checkBanned(RFIDnumber))
            {
                File.Copy(sourcePath, targetPath, false);
                DATA.Upload(targetPath, filetype, tags, title, description);
            }
        }

        /// <summary>
        /// User deletes a file.
        /// The system checks if the file is uploaded by this user, else he is not allowed to delete it.
        /// </summary>
        /// <param name="filepath">The filenumber of the file which you want to delete.</param>
        /// <param name="rfidnumber">The RFID number of the user that uploaded the file.</param>
        public virtual void DeleteFile(string filepath, string rfidnumber)
        {
            if (RFIDnumber == rfidnumber)
            {
                DeleteFileFromDisk(filepath);
                DATA.DeleteUpload(filepath, rfidnumber);
            }
            else
            {
                MessageBox.Show("You can only delete your own files.");
            }
        }
        protected virtual void DeleteFileFromDisk(string filepath)
        {
            if (File.Exists(filepath))
            {
                try
                {
                    File.Delete(filepath);
                }
                catch
                {
                    MessageBox.Show("File not found.");
                    return;
                }
            }
        }

        /// <summary>
        /// Download a file
        /// </summary>
        /// <param name="sourcePath">The source of the file.</param>
        /// <param name="targetPath">The target to copy the file to.</param>
        protected internal void DownloadFile(string sourcePath, string targetPath)
        {
            File.Copy(sourcePath, targetPath, false);
        }

        protected internal List<List<String>> SearchFiles(string searchtype, string searchfield)
        {
            if (searchtype == "Tags")
            {

            }
            return DATA.SearchFiles(searchtype, searchfield);
        }

        /// <summary>
        /// User flags a file as inappropriate. 
        /// This relays data to the database class.
        /// </summary>
        /// <param name="filenumber">The universal nr of the file to flag.</param>
        /// <param name="comment">One of the preset list of reasons a file is flagged.</param>
        protected internal void FlagFile(string filepath, string comment)
        {
            DATA.Flag(filepath, comment);
        }

        /// <summary>
        /// User Rates a file as +1 or -1.
        /// This relays data to the database class.
        /// </summary>
        /// <param name="filenumber">The universal nr of the file to rate.</param>
        /// <param name="rating">Like(1) or Dislike(0)</param>
        protected internal void RateFile(string filepath, bool rating)
        {
            DATA.Rate(filepath, rating);
        }

        #endregion

        #region //User Database related Methods
        //Data
        public void AddFileDBEntry(string filepath, string type_name, string tags, string title, string description)
        {
            DATA.Upload(filepath, type_name, tags, title, description);
        }

        //Get
        public List<List<String>> getMyUploadData()
        {
            return DATA.getMyUploads(RFIDnumber);
        }

        public List<List<String>> getBrowseData()
        {
            return DATA.getBrowseFiles(RFIDnumber);
        }
        #endregion

        #region //Admin functions base
        public virtual List<List<String>> GetUploadLog()
        {
            List<List<String>> UploadLogData = DATA.RetrieveUploadlog();

            return null;
        }

        public virtual List<List<String>> GetFlagLog()
        {
            return null;
        }

        public virtual List<List<String>> GetFlagsForFile(string filepath)
        {
            return null;
        }

        public virtual void BanUser(string rfidnumber, string description)
        {

        }
        #endregion
    }
}
