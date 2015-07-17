namespace s23a_Fileshare
{
    partial class FileshareForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grp_Files = new System.Windows.Forms.GroupBox();
            this.lb_TableHeader = new System.Windows.Forms.ListBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Download = new System.Windows.Forms.Button();
            this.btn_SetDlFolder = new System.Windows.Forms.Button();
            this.tb_SaveDirectory = new System.Windows.Forms.TextBox();
            this.lb_Files = new System.Windows.Forms.ListBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.radBtn_MyUploads = new System.Windows.Forms.RadioButton();
            this.radBtn_SearchResults = new System.Windows.Forms.RadioButton();
            this.radBtn_Browse = new System.Windows.Forms.RadioButton();
            this.grp_Details = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RateMin = new System.Windows.Forms.Button();
            this.lbl_DetType = new System.Windows.Forms.Label();
            this.lbl_DetTitle = new System.Windows.Forms.Label();
            this.lbl_DetTags = new System.Windows.Forms.Label();
            this.lbl_DetRFID = new System.Windows.Forms.Label();
            this.btn_RatePlus = new System.Windows.Forms.Button();
            this.btn_Flag = new System.Windows.Forms.Button();
            this.lb_Details = new System.Windows.Forms.ListBox();
            this.grp_Admin = new System.Windows.Forms.GroupBox();
            this.btn_Ban = new System.Windows.Forms.Button();
            this.tb_Ban = new System.Windows.Forms.TextBox();
            this.lbl_AdminBan = new System.Windows.Forms.Label();
            this.btn_RemFileInstr = new System.Windows.Forms.Button();
            this.lb_FlagsForFile = new System.Windows.Forms.ListBox();
            this.btn_FlagsForFile = new System.Windows.Forms.Button();
            this.lb_FlagLog = new System.Windows.Forms.ListBox();
            this.lbl_FlagLog = new System.Windows.Forms.Label();
            this.grp_Upload = new System.Windows.Forms.GroupBox();
            this.tb_uploadTitle = new System.Windows.Forms.TextBox();
            this.lbl_uploadTitle = new System.Windows.Forms.Label();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.cb_uploadType = new System.Windows.Forms.ComboBox();
            this.lbl_uploadType = new System.Windows.Forms.Label();
            this.tb_Description = new System.Windows.Forms.TextBox();
            this.tb_uploadTags = new System.Windows.Forms.TextBox();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.lbl_uploadTags = new System.Windows.Forms.Label();
            this.btn_selectUpload = new System.Windows.Forms.Button();
            this.tb_Filepath = new System.Windows.Forms.TextBox();
            this.lbl_Filepath = new System.Windows.Forms.Label();
            this.grp_Search = new System.Windows.Forms.GroupBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tb_searchText = new System.Windows.Forms.TextBox();
            this.cb_searchType = new System.Windows.Forms.ComboBox();
            this.lbl_searchText = new System.Windows.Forms.Label();
            this.lbl_searchType = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SaveDirectoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.grp_Files.SuspendLayout();
            this.grp_Details.SuspendLayout();
            this.grp_Admin.SuspendLayout();
            this.grp_Upload.SuspendLayout();
            this.grp_Search.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_Files
            // 
            this.grp_Files.Controls.Add(this.lb_TableHeader);
            this.grp_Files.Controls.Add(this.btn_Delete);
            this.grp_Files.Controls.Add(this.btn_Download);
            this.grp_Files.Controls.Add(this.btn_SetDlFolder);
            this.grp_Files.Controls.Add(this.tb_SaveDirectory);
            this.grp_Files.Controls.Add(this.lb_Files);
            this.grp_Files.Controls.Add(this.btn_Refresh);
            this.grp_Files.Controls.Add(this.radBtn_MyUploads);
            this.grp_Files.Controls.Add(this.radBtn_SearchResults);
            this.grp_Files.Controls.Add(this.radBtn_Browse);
            this.grp_Files.Location = new System.Drawing.Point(13, 13);
            this.grp_Files.Name = "grp_Files";
            this.grp_Files.Size = new System.Drawing.Size(971, 385);
            this.grp_Files.TabIndex = 0;
            this.grp_Files.TabStop = false;
            this.grp_Files.Text = "Files";
            // 
            // lb_TableHeader
            // 
            this.lb_TableHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_TableHeader.Font = new System.Drawing.Font("Comic Sans MS", 8.75F, System.Drawing.FontStyle.Bold);
            this.lb_TableHeader.FormattingEnabled = true;
            this.lb_TableHeader.ItemHeight = 16;
            this.lb_TableHeader.Location = new System.Drawing.Point(6, 46);
            this.lb_TableHeader.Name = "lb_TableHeader";
            this.lb_TableHeader.Size = new System.Drawing.Size(958, 18);
            this.lb_TableHeader.TabIndex = 9;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(632, 344);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(97, 28);
            this.btn_Delete.TabIndex = 0;
            this.btn_Delete.Text = "Remove";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Download
            // 
            this.btn_Download.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Download.Location = new System.Drawing.Point(529, 344);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(97, 28);
            this.btn_Download.TabIndex = 8;
            this.btn_Download.Text = "Download";
            this.btn_Download.UseVisualStyleBackColor = true;
            this.btn_Download.Visible = false;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // btn_SetDlFolder
            // 
            this.btn_SetDlFolder.Location = new System.Drawing.Point(194, 351);
            this.btn_SetDlFolder.Name = "btn_SetDlFolder";
            this.btn_SetDlFolder.Size = new System.Drawing.Size(126, 23);
            this.btn_SetDlFolder.TabIndex = 7;
            this.btn_SetDlFolder.Text = "Set Download Folder";
            this.btn_SetDlFolder.UseVisualStyleBackColor = true;
            this.btn_SetDlFolder.Click += new System.EventHandler(this.btn_SetDlFolder_Click);
            // 
            // tb_SaveDirectory
            // 
            this.tb_SaveDirectory.Location = new System.Drawing.Point(7, 352);
            this.tb_SaveDirectory.Name = "tb_SaveDirectory";
            this.tb_SaveDirectory.Size = new System.Drawing.Size(181, 20);
            this.tb_SaveDirectory.TabIndex = 6;
            // 
            // lb_Files
            // 
            this.lb_Files.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Files.FormattingEnabled = true;
            this.lb_Files.Location = new System.Drawing.Point(6, 63);
            this.lb_Files.Name = "lb_Files";
            this.lb_Files.ScrollAlwaysVisible = true;
            this.lb_Files.Size = new System.Drawing.Size(958, 275);
            this.lb_Files.TabIndex = 5;
            this.lb_Files.SelectedIndexChanged += new System.EventHandler(this.lb_Files_SelectedIndexChanged);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Enabled = false;
            this.btn_Refresh.Location = new System.Drawing.Point(890, 344);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 4;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // radBtn_MyUploads
            // 
            this.radBtn_MyUploads.AutoSize = true;
            this.radBtn_MyUploads.Checked = true;
            this.radBtn_MyUploads.Location = new System.Drawing.Point(6, 20);
            this.radBtn_MyUploads.Name = "radBtn_MyUploads";
            this.radBtn_MyUploads.Size = new System.Drawing.Size(81, 17);
            this.radBtn_MyUploads.TabIndex = 3;
            this.radBtn_MyUploads.TabStop = true;
            this.radBtn_MyUploads.Text = "My Uploads";
            this.radBtn_MyUploads.UseVisualStyleBackColor = true;
            this.radBtn_MyUploads.CheckedChanged += new System.EventHandler(this.radBtn_ListMode_CheckedChanged);
            // 
            // radBtn_SearchResults
            // 
            this.radBtn_SearchResults.AutoSize = true;
            this.radBtn_SearchResults.Location = new System.Drawing.Point(159, 20);
            this.radBtn_SearchResults.Name = "radBtn_SearchResults";
            this.radBtn_SearchResults.Size = new System.Drawing.Size(97, 17);
            this.radBtn_SearchResults.TabIndex = 1;
            this.radBtn_SearchResults.Text = "Search Results";
            this.radBtn_SearchResults.UseVisualStyleBackColor = true;
            this.radBtn_SearchResults.CheckedChanged += new System.EventHandler(this.radBtn_ListMode_CheckedChanged);
            // 
            // radBtn_Browse
            // 
            this.radBtn_Browse.AutoSize = true;
            this.radBtn_Browse.Location = new System.Drawing.Point(93, 20);
            this.radBtn_Browse.Name = "radBtn_Browse";
            this.radBtn_Browse.Size = new System.Drawing.Size(60, 17);
            this.radBtn_Browse.TabIndex = 0;
            this.radBtn_Browse.Text = "Browse";
            this.radBtn_Browse.UseVisualStyleBackColor = true;
            this.radBtn_Browse.CheckedChanged += new System.EventHandler(this.radBtn_ListMode_CheckedChanged);
            // 
            // grp_Details
            // 
            this.grp_Details.Controls.Add(this.label1);
            this.grp_Details.Controls.Add(this.btn_RateMin);
            this.grp_Details.Controls.Add(this.lbl_DetType);
            this.grp_Details.Controls.Add(this.lbl_DetTitle);
            this.grp_Details.Controls.Add(this.lbl_DetTags);
            this.grp_Details.Controls.Add(this.lbl_DetRFID);
            this.grp_Details.Controls.Add(this.btn_RatePlus);
            this.grp_Details.Controls.Add(this.btn_Flag);
            this.grp_Details.Controls.Add(this.lb_Details);
            this.grp_Details.Location = new System.Drawing.Point(990, 13);
            this.grp_Details.Name = "grp_Details";
            this.grp_Details.Size = new System.Drawing.Size(262, 261);
            this.grp_Details.TabIndex = 1;
            this.grp_Details.TabStop = false;
            this.grp_Details.Text = "Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rate";
            // 
            // btn_RateMin
            // 
            this.btn_RateMin.Location = new System.Drawing.Point(77, 230);
            this.btn_RateMin.Name = "btn_RateMin";
            this.btn_RateMin.Size = new System.Drawing.Size(26, 23);
            this.btn_RateMin.TabIndex = 7;
            this.btn_RateMin.Text = "-";
            this.btn_RateMin.UseVisualStyleBackColor = true;
            this.btn_RateMin.Click += new System.EventHandler(this.btn_RateMin_Click);
            // 
            // lbl_DetType
            // 
            this.lbl_DetType.AutoSize = true;
            this.lbl_DetType.Location = new System.Drawing.Point(16, 69);
            this.lbl_DetType.Name = "lbl_DetType";
            this.lbl_DetType.Size = new System.Drawing.Size(34, 13);
            this.lbl_DetType.TabIndex = 6;
            this.lbl_DetType.Text = "Type:";
            // 
            // lbl_DetTitle
            // 
            this.lbl_DetTitle.AutoSize = true;
            this.lbl_DetTitle.Location = new System.Drawing.Point(16, 22);
            this.lbl_DetTitle.Name = "lbl_DetTitle";
            this.lbl_DetTitle.Size = new System.Drawing.Size(30, 13);
            this.lbl_DetTitle.TabIndex = 5;
            this.lbl_DetTitle.Text = "Title:";
            // 
            // lbl_DetTags
            // 
            this.lbl_DetTags.AutoSize = true;
            this.lbl_DetTags.Location = new System.Drawing.Point(16, 92);
            this.lbl_DetTags.Name = "lbl_DetTags";
            this.lbl_DetTags.Size = new System.Drawing.Size(37, 13);
            this.lbl_DetTags.TabIndex = 4;
            this.lbl_DetTags.Text = "Tags: ";
            // 
            // lbl_DetRFID
            // 
            this.lbl_DetRFID.AutoSize = true;
            this.lbl_DetRFID.Location = new System.Drawing.Point(16, 46);
            this.lbl_DetRFID.Name = "lbl_DetRFID";
            this.lbl_DetRFID.Size = new System.Drawing.Size(81, 13);
            this.lbl_DetRFID.TabIndex = 3;
            this.lbl_DetRFID.Text = "Uploader RFID:";
            // 
            // btn_RatePlus
            // 
            this.btn_RatePlus.Location = new System.Drawing.Point(9, 230);
            this.btn_RatePlus.Name = "btn_RatePlus";
            this.btn_RatePlus.Size = new System.Drawing.Size(26, 23);
            this.btn_RatePlus.TabIndex = 2;
            this.btn_RatePlus.Text = "+";
            this.btn_RatePlus.UseVisualStyleBackColor = true;
            this.btn_RatePlus.Click += new System.EventHandler(this.btn_RatePlus_Click);
            // 
            // btn_Flag
            // 
            this.btn_Flag.Location = new System.Drawing.Point(205, 230);
            this.btn_Flag.Name = "btn_Flag";
            this.btn_Flag.Size = new System.Drawing.Size(51, 23);
            this.btn_Flag.TabIndex = 1;
            this.btn_Flag.Text = "Flag";
            this.btn_Flag.UseVisualStyleBackColor = true;
            this.btn_Flag.Click += new System.EventHandler(this.btn_Flag_Click);
            // 
            // lb_Details
            // 
            this.lb_Details.FormattingEnabled = true;
            this.lb_Details.Location = new System.Drawing.Point(6, 129);
            this.lb_Details.Name = "lb_Details";
            this.lb_Details.Size = new System.Drawing.Size(250, 95);
            this.lb_Details.TabIndex = 0;
            // 
            // grp_Admin
            // 
            this.grp_Admin.Controls.Add(this.btn_Ban);
            this.grp_Admin.Controls.Add(this.tb_Ban);
            this.grp_Admin.Controls.Add(this.lbl_AdminBan);
            this.grp_Admin.Controls.Add(this.btn_RemFileInstr);
            this.grp_Admin.Controls.Add(this.lb_FlagsForFile);
            this.grp_Admin.Controls.Add(this.btn_FlagsForFile);
            this.grp_Admin.Controls.Add(this.lb_FlagLog);
            this.grp_Admin.Controls.Add(this.lbl_FlagLog);
            this.grp_Admin.Location = new System.Drawing.Point(990, 280);
            this.grp_Admin.Name = "grp_Admin";
            this.grp_Admin.Size = new System.Drawing.Size(262, 390);
            this.grp_Admin.TabIndex = 2;
            this.grp_Admin.TabStop = false;
            this.grp_Admin.Text = "Admin Functions";
            this.grp_Admin.Visible = false;
            // 
            // btn_Ban
            // 
            this.btn_Ban.Location = new System.Drawing.Point(181, 356);
            this.btn_Ban.Name = "btn_Ban";
            this.btn_Ban.Size = new System.Drawing.Size(75, 23);
            this.btn_Ban.TabIndex = 7;
            this.btn_Ban.Text = "Ban User";
            this.btn_Ban.UseVisualStyleBackColor = true;
            this.btn_Ban.Click += new System.EventHandler(this.btn_Ban_Click);
            // 
            // tb_Ban
            // 
            this.tb_Ban.Location = new System.Drawing.Point(119, 358);
            this.tb_Ban.MaxLength = 5;
            this.tb_Ban.Name = "tb_Ban";
            this.tb_Ban.Size = new System.Drawing.Size(56, 20);
            this.tb_Ban.TabIndex = 6;
            this.tb_Ban.Text = "RFID nr";
            // 
            // lbl_AdminBan
            // 
            this.lbl_AdminBan.AutoSize = true;
            this.lbl_AdminBan.Location = new System.Drawing.Point(6, 361);
            this.lbl_AdminBan.Name = "lbl_AdminBan";
            this.lbl_AdminBan.Size = new System.Drawing.Size(29, 13);
            this.lbl_AdminBan.TabIndex = 5;
            this.lbl_AdminBan.Text = "Ban:";
            // 
            // btn_RemFileInstr
            // 
            this.btn_RemFileInstr.Location = new System.Drawing.Point(123, 12);
            this.btn_RemFileInstr.Name = "btn_RemFileInstr";
            this.btn_RemFileInstr.Size = new System.Drawing.Size(133, 23);
            this.btn_RemFileInstr.TabIndex = 4;
            this.btn_RemFileInstr.Text = "Remove File Instructions";
            this.btn_RemFileInstr.UseVisualStyleBackColor = true;
            this.btn_RemFileInstr.Click += new System.EventHandler(this.btn_RemFileInstr_Click);
            // 
            // lb_FlagsForFile
            // 
            this.lb_FlagsForFile.FormattingEnabled = true;
            this.lb_FlagsForFile.Location = new System.Drawing.Point(9, 210);
            this.lb_FlagsForFile.Name = "lb_FlagsForFile";
            this.lb_FlagsForFile.Size = new System.Drawing.Size(247, 134);
            this.lb_FlagsForFile.TabIndex = 3;
            // 
            // btn_FlagsForFile
            // 
            this.btn_FlagsForFile.Location = new System.Drawing.Point(181, 181);
            this.btn_FlagsForFile.Name = "btn_FlagsForFile";
            this.btn_FlagsForFile.Size = new System.Drawing.Size(75, 23);
            this.btn_FlagsForFile.TabIndex = 2;
            this.btn_FlagsForFile.Text = "Flags for File";
            this.btn_FlagsForFile.UseVisualStyleBackColor = true;
            this.btn_FlagsForFile.Click += new System.EventHandler(this.btn_FlagsForFile_Click);
            // 
            // lb_FlagLog
            // 
            this.lb_FlagLog.FormattingEnabled = true;
            this.lb_FlagLog.Location = new System.Drawing.Point(7, 41);
            this.lb_FlagLog.Name = "lb_FlagLog";
            this.lb_FlagLog.Size = new System.Drawing.Size(249, 134);
            this.lb_FlagLog.TabIndex = 1;
            // 
            // lbl_FlagLog
            // 
            this.lbl_FlagLog.AutoSize = true;
            this.lbl_FlagLog.Location = new System.Drawing.Point(6, 24);
            this.lbl_FlagLog.Name = "lbl_FlagLog";
            this.lbl_FlagLog.Size = new System.Drawing.Size(51, 13);
            this.lbl_FlagLog.TabIndex = 0;
            this.lbl_FlagLog.Text = "Flag Log:";
            // 
            // grp_Upload
            // 
            this.grp_Upload.Controls.Add(this.tb_uploadTitle);
            this.grp_Upload.Controls.Add(this.lbl_uploadTitle);
            this.grp_Upload.Controls.Add(this.btn_Upload);
            this.grp_Upload.Controls.Add(this.cb_uploadType);
            this.grp_Upload.Controls.Add(this.lbl_uploadType);
            this.grp_Upload.Controls.Add(this.tb_Description);
            this.grp_Upload.Controls.Add(this.tb_uploadTags);
            this.grp_Upload.Controls.Add(this.lbl_Description);
            this.grp_Upload.Controls.Add(this.lbl_uploadTags);
            this.grp_Upload.Controls.Add(this.btn_selectUpload);
            this.grp_Upload.Controls.Add(this.tb_Filepath);
            this.grp_Upload.Controls.Add(this.lbl_Filepath);
            this.grp_Upload.Location = new System.Drawing.Point(623, 404);
            this.grp_Upload.Name = "grp_Upload";
            this.grp_Upload.Size = new System.Drawing.Size(361, 266);
            this.grp_Upload.TabIndex = 3;
            this.grp_Upload.TabStop = false;
            this.grp_Upload.Text = "Upload";
            // 
            // tb_uploadTitle
            // 
            this.tb_uploadTitle.Location = new System.Drawing.Point(104, 54);
            this.tb_uploadTitle.Name = "tb_uploadTitle";
            this.tb_uploadTitle.Size = new System.Drawing.Size(112, 20);
            this.tb_uploadTitle.TabIndex = 11;
            // 
            // lbl_uploadTitle
            // 
            this.lbl_uploadTitle.AutoSize = true;
            this.lbl_uploadTitle.Location = new System.Drawing.Point(7, 57);
            this.lbl_uploadTitle.Name = "lbl_uploadTitle";
            this.lbl_uploadTitle.Size = new System.Drawing.Size(30, 13);
            this.lbl_uploadTitle.TabIndex = 10;
            this.lbl_uploadTitle.Text = "Title:";
            // 
            // btn_Upload
            // 
            this.btn_Upload.Location = new System.Drawing.Point(280, 237);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(75, 23);
            this.btn_Upload.TabIndex = 9;
            this.btn_Upload.Text = "Upload";
            this.btn_Upload.UseVisualStyleBackColor = true;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // cb_uploadType
            // 
            this.cb_uploadType.FormattingEnabled = true;
            this.cb_uploadType.Location = new System.Drawing.Point(104, 80);
            this.cb_uploadType.Name = "cb_uploadType";
            this.cb_uploadType.Size = new System.Drawing.Size(112, 21);
            this.cb_uploadType.TabIndex = 8;
            // 
            // lbl_uploadType
            // 
            this.lbl_uploadType.AutoSize = true;
            this.lbl_uploadType.Location = new System.Drawing.Point(7, 83);
            this.lbl_uploadType.Name = "lbl_uploadType";
            this.lbl_uploadType.Size = new System.Drawing.Size(34, 13);
            this.lbl_uploadType.TabIndex = 7;
            this.lbl_uploadType.Text = "Type:";
            // 
            // tb_Description
            // 
            this.tb_Description.Location = new System.Drawing.Point(104, 133);
            this.tb_Description.Multiline = true;
            this.tb_Description.Name = "tb_Description";
            this.tb_Description.Size = new System.Drawing.Size(251, 98);
            this.tb_Description.TabIndex = 6;
            // 
            // tb_uploadTags
            // 
            this.tb_uploadTags.Location = new System.Drawing.Point(104, 107);
            this.tb_uploadTags.Name = "tb_uploadTags";
            this.tb_uploadTags.Size = new System.Drawing.Size(112, 20);
            this.tb_uploadTags.TabIndex = 5;
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.Location = new System.Drawing.Point(7, 136);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(63, 13);
            this.lbl_Description.TabIndex = 4;
            this.lbl_Description.Text = "Description:";
            // 
            // lbl_uploadTags
            // 
            this.lbl_uploadTags.AutoSize = true;
            this.lbl_uploadTags.Location = new System.Drawing.Point(7, 110);
            this.lbl_uploadTags.Name = "lbl_uploadTags";
            this.lbl_uploadTags.Size = new System.Drawing.Size(34, 13);
            this.lbl_uploadTags.TabIndex = 3;
            this.lbl_uploadTags.Text = "Tags:";
            // 
            // btn_selectUpload
            // 
            this.btn_selectUpload.Location = new System.Drawing.Point(222, 28);
            this.btn_selectUpload.Name = "btn_selectUpload";
            this.btn_selectUpload.Size = new System.Drawing.Size(24, 20);
            this.btn_selectUpload.TabIndex = 2;
            this.btn_selectUpload.Text = "...";
            this.btn_selectUpload.UseVisualStyleBackColor = true;
            this.btn_selectUpload.Click += new System.EventHandler(this.btn_selectUpload_Click);
            // 
            // tb_Filepath
            // 
            this.tb_Filepath.Location = new System.Drawing.Point(104, 28);
            this.tb_Filepath.Name = "tb_Filepath";
            this.tb_Filepath.Size = new System.Drawing.Size(112, 20);
            this.tb_Filepath.TabIndex = 1;
            // 
            // lbl_Filepath
            // 
            this.lbl_Filepath.AutoSize = true;
            this.lbl_Filepath.Location = new System.Drawing.Point(7, 31);
            this.lbl_Filepath.Name = "lbl_Filepath";
            this.lbl_Filepath.Size = new System.Drawing.Size(50, 13);
            this.lbl_Filepath.TabIndex = 0;
            this.lbl_Filepath.Text = "File path:";
            // 
            // grp_Search
            // 
            this.grp_Search.Controls.Add(this.btn_Search);
            this.grp_Search.Controls.Add(this.tb_searchText);
            this.grp_Search.Controls.Add(this.cb_searchType);
            this.grp_Search.Controls.Add(this.lbl_searchText);
            this.grp_Search.Controls.Add(this.lbl_searchType);
            this.grp_Search.Location = new System.Drawing.Point(410, 404);
            this.grp_Search.Name = "grp_Search";
            this.grp_Search.Size = new System.Drawing.Size(207, 136);
            this.grp_Search.TabIndex = 4;
            this.grp_Search.TabStop = false;
            this.grp_Search.Text = "Searching";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(51, 97);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(104, 23);
            this.btn_Search.TabIndex = 4;
            this.btn_Search.Text = "Search!";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // tb_searchText
            // 
            this.tb_searchText.Location = new System.Drawing.Point(83, 61);
            this.tb_searchText.Name = "tb_searchText";
            this.tb_searchText.Size = new System.Drawing.Size(110, 20);
            this.tb_searchText.TabIndex = 3;
            // 
            // cb_searchType
            // 
            this.cb_searchType.FormattingEnabled = true;
            this.cb_searchType.Location = new System.Drawing.Point(83, 28);
            this.cb_searchType.Name = "cb_searchType";
            this.cb_searchType.Size = new System.Drawing.Size(110, 21);
            this.cb_searchType.TabIndex = 2;
            // 
            // lbl_searchText
            // 
            this.lbl_searchText.AutoSize = true;
            this.lbl_searchText.Location = new System.Drawing.Point(6, 64);
            this.lbl_searchText.Name = "lbl_searchText";
            this.lbl_searchText.Size = new System.Drawing.Size(68, 13);
            this.lbl_searchText.TabIndex = 1;
            this.lbl_searchText.Text = "Search Text:";
            // 
            // lbl_searchType
            // 
            this.lbl_searchType.AutoSize = true;
            this.lbl_searchType.Location = new System.Drawing.Point(6, 31);
            this.lbl_searchType.Name = "lbl_searchType";
            this.lbl_searchType.Size = new System.Drawing.Size(71, 13);
            this.lbl_searchType.TabIndex = 0;
            this.lbl_searchType.Text = "Search Type:";
            // 
            // Timer
            // 
            this.Timer.Interval = 300000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // SaveDirectoryBrowser
            // 
            this.SaveDirectoryBrowser.SelectedPath = "C:\\";
            // 
            // FileshareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.grp_Search);
            this.Controls.Add(this.grp_Upload);
            this.Controls.Add(this.grp_Admin);
            this.Controls.Add(this.grp_Details);
            this.Controls.Add(this.grp_Files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FileshareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fileshare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileshareForm_FormClosing);
            this.grp_Files.ResumeLayout(false);
            this.grp_Files.PerformLayout();
            this.grp_Details.ResumeLayout(false);
            this.grp_Details.PerformLayout();
            this.grp_Admin.ResumeLayout(false);
            this.grp_Admin.PerformLayout();
            this.grp_Upload.ResumeLayout(false);
            this.grp_Upload.PerformLayout();
            this.grp_Search.ResumeLayout(false);
            this.grp_Search.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_Files;
        private System.Windows.Forms.RadioButton radBtn_SearchResults;
        private System.Windows.Forms.RadioButton radBtn_Browse;
        private System.Windows.Forms.GroupBox grp_Details;
        private System.Windows.Forms.GroupBox grp_Admin;
        private System.Windows.Forms.GroupBox grp_Upload;
        private System.Windows.Forms.ComboBox cb_uploadType;
        private System.Windows.Forms.Label lbl_uploadType;
        private System.Windows.Forms.TextBox tb_Description;
        private System.Windows.Forms.TextBox tb_uploadTags;
        private System.Windows.Forms.Label lbl_Description;
        private System.Windows.Forms.Label lbl_uploadTags;
        private System.Windows.Forms.Button btn_selectUpload;
        private System.Windows.Forms.TextBox tb_Filepath;
        private System.Windows.Forms.Label lbl_Filepath;
        private System.Windows.Forms.GroupBox grp_Search;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox tb_searchText;
        private System.Windows.Forms.ComboBox cb_searchType;
        private System.Windows.Forms.Label lbl_searchText;
        private System.Windows.Forms.Label lbl_searchType;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_RatePlus;
        private System.Windows.Forms.Button btn_Flag;
        private System.Windows.Forms.ListBox lb_Details;
        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.RadioButton radBtn_MyUploads;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.ListBox lb_Files;
        private System.Windows.Forms.Label lbl_DetTitle;
        private System.Windows.Forms.Label lbl_DetTags;
        private System.Windows.Forms.Label lbl_DetRFID;
        private System.Windows.Forms.TextBox tb_SaveDirectory;
        private System.Windows.Forms.Button btn_SetDlFolder;
        private System.Windows.Forms.FolderBrowserDialog SaveDirectoryBrowser;
        private System.Windows.Forms.Button btn_Download;
        private System.Windows.Forms.ListBox lb_FlagLog;
        private System.Windows.Forms.Label lbl_FlagLog;
        private System.Windows.Forms.Button btn_FlagsForFile;
        private System.Windows.Forms.Button btn_RemFileInstr;
        private System.Windows.Forms.ListBox lb_FlagsForFile;
        private System.Windows.Forms.Label lbl_DetType;
        private System.Windows.Forms.Button btn_Ban;
        private System.Windows.Forms.TextBox tb_Ban;
        private System.Windows.Forms.Label lbl_AdminBan;
        private System.Windows.Forms.TextBox tb_uploadTitle;
        private System.Windows.Forms.Label lbl_uploadTitle;
        private System.Windows.Forms.ListBox lb_TableHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_RateMin;
    }
}