using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace s23a_Fileshare
{
    class Admin : User
    {
        public Admin(string rfidnumber) : base(rfidnumber)
        {
            RFIDnumber = rfidnumber;
            isAdmin = true;

            DATA = new Database(RFIDnumber);
        }

        public override List<List<String>> GetUploadLog()
        {
            List<List<String>> UploadLogData = DATA.RetrieveUploadlog();

            return UploadLogData;
        }

        public override List<List<String>> GetFlagLog()
        { 
            List<List<String>> FlagLogData = DATA.RetrieveFlaglog();
            return FlagLogData;
        }

        public override List<List<String>> GetFlagsForFile(string filepath)
        {
            List<List<String>> FileFlagData = DATA.RetrieveFlagsForFile(filepath);
            return FileFlagData;
        }

        public override void BanUser(string rfidnumber, string description)
        {
            DATA.BanUser(rfidnumber, description);
        }

        public override void DeleteFile(string filepath, string rfidnumber)
        {
            //Remove the actual file from the server.
            DeleteFileFromDisk(filepath);
            //Removes the Upload data from the Oracle-Database.
            DATA.DeleteUpload(filepath, rfidnumber);
        }
        
        protected override void DeleteFileFromDisk(string filepath)
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
    }
}
