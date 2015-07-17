namespace s23a_Fileshare
{
    partial class FlagForm
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
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_Uploader = new System.Windows.Forms.Label();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.lbl_Tags = new System.Windows.Forms.Label();
            this.cb_FlagReasons = new System.Windows.Forms.ComboBox();
            this.lbl_FlagReason = new System.Windows.Forms.Label();
            this.btn_Flag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Location = new System.Drawing.Point(35, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(33, 13);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "Title: ";
            // 
            // lbl_Uploader
            // 
            this.lbl_Uploader.AutoSize = true;
            this.lbl_Uploader.Location = new System.Drawing.Point(12, 30);
            this.lbl_Uploader.Name = "lbl_Uploader";
            this.lbl_Uploader.Size = new System.Drawing.Size(56, 13);
            this.lbl_Uploader.TabIndex = 1;
            this.lbl_Uploader.Text = "Uploader: ";
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Location = new System.Drawing.Point(31, 53);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(37, 13);
            this.lbl_Type.TabIndex = 2;
            this.lbl_Type.Text = "Type: ";
            // 
            // lbl_Tags
            // 
            this.lbl_Tags.AutoSize = true;
            this.lbl_Tags.Location = new System.Drawing.Point(31, 75);
            this.lbl_Tags.Name = "lbl_Tags";
            this.lbl_Tags.Size = new System.Drawing.Size(37, 13);
            this.lbl_Tags.TabIndex = 3;
            this.lbl_Tags.Text = "Tags: ";
            // 
            // cb_FlagReasons
            // 
            this.cb_FlagReasons.FormattingEnabled = true;
            this.cb_FlagReasons.Items.AddRange(new object[] {
            "Copyright Material",
            "Pornographic Material",
            "Detected by virusscanner",
            "Other"});
            this.cb_FlagReasons.Location = new System.Drawing.Point(86, 128);
            this.cb_FlagReasons.Name = "cb_FlagReasons";
            this.cb_FlagReasons.Size = new System.Drawing.Size(121, 21);
            this.cb_FlagReasons.TabIndex = 4;
            // 
            // lbl_FlagReason
            // 
            this.lbl_FlagReason.AutoSize = true;
            this.lbl_FlagReason.Location = new System.Drawing.Point(12, 131);
            this.lbl_FlagReason.Name = "lbl_FlagReason";
            this.lbl_FlagReason.Size = new System.Drawing.Size(68, 13);
            this.lbl_FlagReason.TabIndex = 5;
            this.lbl_FlagReason.Text = "Flag reason: ";
            // 
            // btn_Flag
            // 
            this.btn_Flag.Location = new System.Drawing.Point(213, 126);
            this.btn_Flag.Name = "btn_Flag";
            this.btn_Flag.Size = new System.Drawing.Size(55, 23);
            this.btn_Flag.TabIndex = 6;
            this.btn_Flag.Text = "Flag File";
            this.btn_Flag.UseVisualStyleBackColor = true;
            this.btn_Flag.Click += new System.EventHandler(this.btn_Flag_Click);
            // 
            // FlagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 155);
            this.Controls.Add(this.btn_Flag);
            this.Controls.Add(this.lbl_FlagReason);
            this.Controls.Add(this.cb_FlagReasons);
            this.Controls.Add(this.lbl_Tags);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.lbl_Uploader);
            this.Controls.Add(this.lbl_Title);
            this.Name = "FlagForm";
            this.Text = "FlagForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_Uploader;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.Label lbl_Tags;
        private System.Windows.Forms.ComboBox cb_FlagReasons;
        private System.Windows.Forms.Label lbl_FlagReason;
        private System.Windows.Forms.Button btn_Flag;
    }
}