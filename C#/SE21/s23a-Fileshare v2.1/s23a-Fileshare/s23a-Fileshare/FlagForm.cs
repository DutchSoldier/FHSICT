using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace s23a_Fileshare
{
    public partial class FlagForm : Form
    {
        string RFIDnumber;
        Database FlagDB;

        string Path;
        string Title;
        string Uploader;
        string Type;
        string Tags;

        public FlagForm(string userRfidnumber, string filepath, string filetitle, string uploaderRfidnumber, string filetype, string filetags)
        {
            InitializeComponent();
            cb_FlagReasons.SelectedIndex = 0;
            FlagDB = new Database(userRfidnumber);

            RFIDnumber = userRfidnumber;

            Path = filepath;
            Title = filetitle;
            Uploader = uploaderRfidnumber;
            Type = filetype;
            Tags = filetags;
        }

        private void btn_Flag_Click(object sender, EventArgs e)
        {
            FlagDB.Flag(Path, cb_FlagReasons.SelectedText);
        }
    }
}
