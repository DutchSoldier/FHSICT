using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace s23a_Fileshare
{
    public partial class FileshareForm : Form
    {
        LoginForm ParentForm;
        FlagForm FlagForm;
        User User;
        Database FORMDB;
        bool isAdmin;

        #region //Listbox and file reference Lists

        //All MyUp Lists indices match. the Path in spot [0] belongs to the File_name spot [0].
        List<String> MyUpPath;          //List of all User's Uploads Paths on the Server.
        List<String> MyUpTitle;
        List<String> MyUpType_Name;     //List of all User's Upload Types per file.
        List<String> MyUpFile_Name;     //List of all User's FileNames per file.
        List<String> MyUpFileTags;      //
        List<String> MyUpDescription;
        List<String> MyUpRating;
        List<String> MyUpListData;

        //All Search Lists indices match. the Path in spot [0] belongs to the File_name spot [0].
        List<String> SearchPath;
        List<String> SearchRFID;
        List<String> SearchTitle;
        List<String> SearchType_Name;
        List<String> SearchFile_Name;
        List<String> SearchFileTags;
        List<String> SearchDescription;
        List<String> SearchRating;
        List<String> SearchListData;

        //All Browse Lists indices match. the Path in spot [0] belongs to the File_name spot [0].
        List<String> BrowsePath;
        List<String> BrowseRFID;
        List<String> BrowseTitle;
        List<String> BrowseType_Name;
        List<String> BrowseFile_Name;
        List<String> BrowseFileTags;
        List<String> BrowseDescription;
        List<String> BrowseRating;
        List<String> BrowseListData;

        #endregion

        //Basic Application Data
        List<String> FileTypes;
        DateTime LastRefresh;

        public FileshareForm(string rfidnumber, bool isadmin, LoginForm parentform)
        {
            ParentForm = parentform;
            ParentForm.Hide();
            InitializeComponent();
            isAdmin = true;
            LastRefresh = DateTime.Now;


            if (isAdmin)
            {
                User = new Admin(rfidnumber);
                grp_Admin.Visible = true;
            }
            else
            {
                User = new User(rfidnumber);
            }
            this.Show();

            FORMDB = new Database(rfidnumber);
            initializeLists();
            FillTableHeader();
            lb_TableHeader.SelectedIndex = 0;
            //setFileTypes();
            //setSearchTypes();
            //getMyUploadsData();
            //getBrowseData();
        }
        #region //General
        private void convertDataToList(List<List<String>> Data)
        {

        }

        #endregion
        #region //Form Initialize Methods

        private void initializeLists()
        {
            MyUpPath = new List<String>();
            MyUpTitle = new List<String>();
            MyUpType_Name = new List<String>();
            MyUpFile_Name = new List<String>();
            MyUpFileTags = new List<String>();
            MyUpDescription = new List<String>();
            MyUpRating = new List<String>();
            MyUpListData = new List<String>();

            SearchPath = new List<String>();
            SearchRFID = new List<String>();
            SearchTitle = new List<String>();
            SearchType_Name = new List<String>();
            SearchFile_Name = new List<String>();
            SearchFileTags = new List<String>();
            SearchDescription = new List<String>();
            SearchRating = new List<String>();
            SearchListData = new List<String>();

            BrowsePath = new List<String>();
            BrowseRFID = new List<String>();
            BrowseTitle = new List<String>();
            BrowseType_Name = new List<String>();
            BrowseFile_Name = new List<String>();
            BrowseFileTags = new List<String>();
            BrowseDescription = new List<String>();
            BrowseRating = new List<String>();
            BrowseListData = new List<String>();
        }
        private void setFileTypes()
        {
            cb_uploadType.Items.Clear();
            FileTypes = FORMDB.getFileTypes();
            foreach (String Type in FileTypes)
            {
                cb_uploadType.Items.Add(Type);
            }
        }
        private void setSearchTypes()
        {
            cb_searchType.Items.Add("Uploader");
            cb_searchType.Items.Add("File Title");
            cb_searchType.Items.Add("File Type");
            cb_searchType.Items.Add("Tags");
        }
        private void FillTableHeader()
        {
            // RFID = 25 chars, Title = 250 chars, Rating = 15 chars
            int rfidLength = 25;
            int titleLength = 70;
            int typeLength = 30;
            int ratingLength = 20;

            string rfidnumber = "Uploader";
            string title = "Title";
            string rating = "Rating";
            string type = "Type";

            while (rfidnumber.Length < rfidLength)
            {
                rfidnumber += " ";
            }

            while (title.Length < titleLength)
            {
                title += " ";
            }

            while (type.Length < typeLength)
            {
                type += " ";
            }

            while (rating.Length < ratingLength)
            {
                rating += " ";
            }

            string ColumnNames = rfidnumber + title + type + rating;

            lb_TableHeader.Items.Add(ColumnNames);
        }

        private void getMyUploadsData()
        {
            MyUpPath.Clear(); MyUpType_Name.Clear(); MyUpFile_Name.Clear();
            MyUpFileTags.Clear(); MyUpTitle.Clear(); MyUpDescription.Clear();

            List<List<String>> RawData = User.getMyUploadData();
            int counter = 0;
            foreach (List<String> DatabaseEntry in RawData)
            {
                MyUpPath.Add(RawData[0][counter]);
                MyUpType_Name.Add(RawData[2][counter]);
                MyUpFile_Name.Add(RawData[3][counter]);
                MyUpFileTags.Add(RawData[4][counter]);
                MyUpTitle.Add(RawData[5][counter]);
                MyUpDescription.Add(RawData[6][counter]);
                counter++;
            }
        }
        private void getBrowseData()
        {
            BrowsePath.Clear(); BrowseRFID.Clear(); BrowseType_Name.Clear(); BrowseFile_Name.Clear();
            BrowseFileTags.Clear(); BrowseTitle.Clear(); BrowseDescription.Clear();
            List<List<String>> RawData = User.getBrowseData();
            int counter = 0;
            foreach (List<String> DatabaseEntry in RawData)
            {
                BrowsePath.Add(RawData[0][counter]);
                BrowseRFID.Add(RawData[1][counter]);
                BrowseType_Name.Add(RawData[2][counter]);
                BrowseFile_Name.Add(RawData[3][counter]);
                BrowseFileTags.Add(RawData[4][counter]);
                BrowseTitle.Add(RawData[5][counter]);
                BrowseDescription.Add(RawData[6][counter]);
                counter++;
            }
        }
        private void getSearchData(string searchtype, string searchfield)
        {
            SearchPath.Clear(); SearchRFID.Clear(); SearchType_Name.Clear(); SearchFile_Name.Clear();
            SearchFileTags.Clear(); SearchTitle.Clear(); SearchDescription.Clear();

            List<List<String>> RawData = User.SearchFiles(searchtype, searchfield);
            int counter = 0;
            foreach (List<String> DatabaseEntry in RawData)
            {
                SearchPath.Add(RawData[0][counter]);
                SearchRFID.Add(RawData[1][counter]);
                SearchType_Name.Add(RawData[2][counter]);
                SearchFile_Name.Add(RawData[3][counter]);
                SearchFileTags.Add(RawData[4][counter]);
                SearchTitle.Add(RawData[5][counter]);
                SearchDescription.Add(RawData[6][counter]);
                counter++;
            }
        }

        private void FillList(List<String> Data, string whichList)
        {
            int rfidLength = 25;
            int titleLength = 200;
            int typeLength = 50;
            int ratingLength = 15;

            string rfidnumber;
            string title;
            string type;
            string rating;
            string FileToAdd;

            if (whichList == "My")
            {
                for (int x = 0; x < MyUpTitle.Count; x++)
                {
                    rfidnumber = User.rfidnumber;
                    while (rfidnumber.Length < rfidLength)
                    {
                        rfidnumber += " ";
                    }

                    title = MyUpTitle[x];
                    while (title.Length < titleLength)
                    {
                        title += " ";
                    }

                    type = MyUpType_Name[x];
                    while (type.Length < typeLength)
                    {
                        type += " ";
                    }

                    rating = MyUpRating[x];
                    while (rating.Length < ratingLength)
                    {
                        rating += " ";
                    }

                    FileToAdd = rfidnumber + title + type + rating;
                    Data.Add(FileToAdd);
                }

                if (whichList == "Br")
                {
                    for (int x = 0; x < BrowseTitle.Count; x++)
                    {
                        rfidnumber = BrowseRFID[x];
                        while (rfidnumber.Length < rfidLength)
                        {
                            rfidnumber += " ";
                        }

                        title = BrowseTitle[x];
                        while (title.Length < titleLength)
                        {
                            title += " ";
                        }

                        type = BrowseType_Name[x];
                        while (type.Length < typeLength)
                        {
                            type += " ";
                        }

                        rating = BrowseRating[x];
                        while (rating.Length < ratingLength)
                        {
                            rating += " ";
                        }

                        FileToAdd = rfidnumber + title + type + rating;
                        Data.Add(FileToAdd);
                    }

                    if (whichList == "Se")
                    {
                        for (int x = 0; x < SearchTitle.Count; x++)
                        {
                            rfidnumber = SearchRFID[x];
                            while (rfidnumber.Length < rfidLength)
                            {
                                rfidnumber += " ";
                            }

                            title = SearchTitle[x];
                            while (title.Length < titleLength)
                            {
                                title += " ";
                            }

                            type = SearchType_Name[x];
                            while (type.Length < typeLength)
                            {
                                type += " ";
                            }

                            rating = SearchRating[x];
                            while (rating.Length < ratingLength)
                            {
                                rating += " ";
                            }

                            FileToAdd = rfidnumber + title + type + rating;
                            Data.Add(FileToAdd);
                        }
                    }
                }
            }
        }
        #endregion
        #region //Event Handlers

        private void FileshareForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParentForm.Show();
        }

        private void lb_Files_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> lstDetailsTitle = new List<String>();
            List<String> lstDetailsRFID = new List<String>();
            List<String> lstDetailsType = new List<String>();
            List<String> lstDetailsTags = new List<String>();
            List<String> lstDetailsDescription = new List<String>();

            if (radBtn_MyUploads.Checked)
            {
                lstDetailsTitle = MyUpTitle;
                lstDetailsRFID.Add(User.rfidnumber);
                lstDetailsType = MyUpType_Name;
                lstDetailsTags = MyUpFileTags;
                lstDetailsDescription = MyUpDescription;
            }
            else if (radBtn_Browse.Checked)
            {
                lstDetailsTitle = BrowseTitle;
                lstDetailsRFID = BrowseRFID;
                lstDetailsType = BrowseType_Name;
                lstDetailsTags = BrowseFileTags;
                lstDetailsDescription = BrowseDescription;
            }
            else if (radBtn_SearchResults.Checked)
            {
                lstDetailsTitle = SearchTitle;
                lstDetailsRFID = SearchRFID;
                lstDetailsType = SearchType_Name;
                lstDetailsTags = SearchFileTags;
                lstDetailsDescription = SearchDescription;
            }
            int selectedIndex = lb_Files.SelectedIndex;
            lbl_DetTitle.Text = "Title: " + lstDetailsTitle[selectedIndex];
            if (radBtn_MyUploads.Checked)
            {
                lbl_DetRFID.Text = "Uploader RFID: " + lstDetailsRFID[0];
            }
            else
            {
                lbl_DetRFID.Text = "Uploader RFID: " + lstDetailsRFID[selectedIndex];
            }
            lbl_DetType.Text = "Type: " + lstDetailsType[selectedIndex];
            lbl_DetTags.Text = "Tags: " + lstDetailsTags[selectedIndex];
            lb_Details.Items.Add(lstDetailsDescription[selectedIndex]);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                lb_FlagLog.Items.Clear();
                foreach (List<String> entry in User.GetFlagLog())
                {
                    lb_FlagLog.Items.Add(entry[0] + "   :   " + entry[1]);
                }
            }
        }

        #region //button events

        //user interface buttons
        private void btn_Download_Click(object sender, EventArgs e)
        {
            if (radBtn_Browse.Checked)
            {
                if (File.Exists(BrowsePath[lb_Files.SelectedIndex]))
                {
                    String source = BrowsePath[lb_Files.SelectedIndex];
                    User.DownloadFile(source, tb_SaveDirectory.Text);
                }
            }
            else if (radBtn_SearchResults.Checked)
            {
                if (File.Exists(SearchPath[lb_Files.SelectedIndex]))
                {
                    String source = SearchPath[lb_Files.SelectedIndex];
                    User.DownloadFile(source, tb_SaveDirectory.Text);
                }
            }
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            if (File.Exists(tb_Filepath.Text))
            {
                User.UploadFile(tb_Filepath.Text, (User.serverPath + tb_Filepath.Text.Substring(tb_Filepath.Text.LastIndexOf(@"\") + 1)),
                    cb_uploadType.SelectedText, tb_uploadTags.Text, tb_uploadTitle.Text, tb_Description.Text);

                MyUpPath.Add((User.serverPath + tb_Filepath.Text.Substring(tb_Filepath.Text.LastIndexOf(@"\") + 1)));
                MyUpTitle.Add(tb_uploadTitle.Text);
                MyUpType_Name.Add(cb_uploadType.SelectedText);
                MyUpFileTags.Add(tb_uploadTags.Text);
                MyUpDescription.Add(tb_Description.Text);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (File.Exists(MyUpPath[lb_Files.SelectedIndex]))
            {
                if (isAdmin)
                {
                    if (radBtn_MyUploads.Checked)
                    {
                        User.DeleteFile(MyUpPath[lb_Files.SelectedIndex], User.rfidnumber);
                    }
                    else if (radBtn_Browse.Checked)
                    {
                        User.DeleteFile(BrowsePath[lb_Files.SelectedIndex], BrowseRFID[lb_Files.SelectedIndex]);
                    }
                    else if (radBtn_SearchResults.Checked)
                    {
                        User.DeleteFile(SearchPath[lb_Files.SelectedIndex], SearchRFID[lb_Files.SelectedIndex]);
                    }
                }
                else
                {
                    User.DeleteFile(MyUpPath[lb_Files.SelectedIndex], User.rfidnumber);
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (cb_searchType.SelectedText == "Tags")
            {
                //annoying bit
            }
            else
            {
                //getSearchData(cb_searchType.SelectedText, tb_searchText.Text);
                //FillList(SearchListData, "Se");
                radBtn_SearchResults.Checked = true;
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (LastRefresh.AddMinutes(1) < DateTime.Now)
            {
                User.getBrowseData();
                User.getMyUploadData();
                LastRefresh = DateTime.Now;
                FillList(BrowseListData, "Br");
                FillList(MyUpListData, "My");
                if (radBtn_Browse.Checked)
                {
                    radBtn_MyUploads.Checked = true;
                    radBtn_Browse.Checked = true;
                }
                else if (radBtn_MyUploads.Checked)
                {
                    radBtn_Browse.Checked = true;
                    radBtn_MyUploads.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("You have already refreshed in the past minute. Please wait a while.");
            }

        }

        //admin interface buttons
        private void btn_FlagsForFile_Click(object sender, EventArgs e)
        {
            
        }
        private void btn_RemFileInstr_Click(object sender, EventArgs e)
        {
            MessageBox.Show("As an Admin, you can delete any file on the server." + "\r\n" +
                 "To allow this, the \"Remove\" Button is always enabled." + "\r\n" +
                 "To remove files from a specific user, Search for their RFID number." + "\r\n" +
                 "You can remove then all inappropriate files via the \"Remove\" Button.", "Remove instructions:");
        }
        private void btn_Ban_Click(object sender, EventArgs e)
        {
            string banRFID = tb_Ban.Text;
        }

        //Details box buttons
        private void btn_Flag_Click(object sender, EventArgs e)
        {
            if (!radBtn_MyUploads.Checked)
            {
                string Filepath = "";
                string Filetitle = "";
                string UpldrRFID = "";
                string Filetype = "";
                string Filetags = "";
                if (radBtn_Browse.Checked)
                {
                    Filepath = BrowsePath[lb_Files.SelectedIndex];
                    Filetitle = BrowseTitle[lb_Files.SelectedIndex];
                    UpldrRFID = BrowseRFID[lb_Files.SelectedIndex];
                    Filetype = BrowseType_Name[lb_Files.SelectedIndex];
                    Filetags = BrowseFileTags[lb_Files.SelectedIndex];
                }
                else if (radBtn_SearchResults.Checked)
                {
                    Filepath = SearchPath[lb_Files.SelectedIndex];
                    Filetitle = SearchTitle[lb_Files.SelectedIndex];
                    UpldrRFID = SearchRFID[lb_Files.SelectedIndex];
                    Filetype = SearchType_Name[lb_Files.SelectedIndex];
                    Filetags = SearchFileTags[lb_Files.SelectedIndex];
                }
                FlagForm = new FlagForm(User.rfidnumber, Filepath, Filetitle, UpldrRFID, Filetype, Filetags);
            }
            else
            {
                MessageBox.Show("You cannot flag your own files. If you find it innapropriate, please remove it.", "Cannot flag:");
            }
        }

        private void btn_RatePlus_Click(object sender, EventArgs e)
        {
            if (!radBtn_MyUploads.Checked)
            {
                if (radBtn_Browse.Checked)
                {
                    FORMDB.Rate(BrowsePath[lb_Files.SelectedIndex], true);
                }
                else if (radBtn_SearchResults.Checked)
                {
                    FORMDB.Rate(SearchPath[lb_Files.SelectedIndex], true);
                }
                else
                {
                    MessageBox.Show("You cannot rate your own files.", "Cannot rate:");
                }
            }
        }

        private void btn_RateMin_Click(object sender, EventArgs e)
        {
            if (!radBtn_MyUploads.Checked)
            {
                if (radBtn_Browse.Checked)
                {
                    FORMDB.Rate(BrowsePath[lb_Files.SelectedIndex], false);
                }
                else if (radBtn_SearchResults.Checked)
                {
                    FORMDB.Rate(SearchPath[lb_Files.SelectedIndex], false);
                }
                else
                {
                    MessageBox.Show("You cannot rate your own files.", "Cannot rate:");
                }
            }
        }

        //Load & SaveFolder Dialogs
        private void btn_SetDlFolder_Click(object sender, EventArgs e)
        {
            if (SaveDirectoryBrowser.ShowDialog() == DialogResult.OK)
            {
                tb_SaveDirectory.Text = SaveDirectoryBrowser.SelectedPath;
                int LastCharacter = tb_SaveDirectory.Text.Length - 1;
                if (tb_SaveDirectory.Text[LastCharacter] != '\\')
                {
                    tb_SaveDirectory.Text += @"\";
                }
            }
        }

        private void btn_selectUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_Filepath.Text = openFileDialog.FileName;
            }
        }

        #endregion

        #region //Radiobutton events

        private void radBtn_ListMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtn_MyUploads.Checked)
            {
                btn_Refresh.Enabled = true;
                btn_Download.Visible = false;
                btn_Delete.Visible = true;

                lb_Files.Items.Clear();
                foreach (String ListItem in MyUpListData)
                {
                    lb_Files.Items.Add(ListItem);
                }
            }
            else if (radBtn_Browse.Checked)
            {
                if (isAdmin)
                {
                    btn_Refresh.Enabled = true;
                    btn_Delete.Visible = true;
                    btn_Download.Visible = true;
                }
                else
                {
                    btn_Refresh.Enabled = true;
                    btn_Delete.Visible = false;
                    btn_Download.Visible = true;
                }
                lb_Files.Items.Clear();
                foreach (String ListItem in BrowseListData)
                {
                    lb_Files.Items.Add(ListItem);
                }
            }
            else if (radBtn_SearchResults.Checked)
            {
                if (isAdmin)
                {
                    btn_Refresh.Enabled = false;
                    btn_Delete.Visible = true;
                    btn_Download.Visible = true;
                }
                else
                {
                    btn_Refresh.Enabled = false;
                    btn_Delete.Visible = false;
                    btn_Download.Visible = true;
                }
                lb_Files.Items.Clear();
                foreach (String ListItem in SearchListData)
                {
                    lb_Files.Items.Add(ListItem);
                }
            }
        }

        #endregion

        #endregion
    }
}
