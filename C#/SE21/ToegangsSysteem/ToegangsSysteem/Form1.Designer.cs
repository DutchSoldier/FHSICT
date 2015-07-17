namespace ToegangsSysteem
{
    partial class Form1
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
            this.lRFID = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.lRfidNumber = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.pbDenied = new System.Windows.Forms.PictureBox();
            this.pbAllowed = new System.Windows.Forms.PictureBox();
            this.bDeny = new System.Windows.Forms.Button();
            this.tbDeny = new System.Windows.Forms.TextBox();
            this.bConfirmDeny = new System.Windows.Forms.Button();
            this.lDenied = new System.Windows.Forms.Label();
            this.lCheck = new System.Windows.Forms.Label();
            this.lDenyReason = new System.Windows.Forms.Label();
            this.lReason = new System.Windows.Forms.Label();
            this.bAllow = new System.Windows.Forms.Button();
            this.bConfirmAllow = new System.Windows.Forms.Button();
            this.bAddTags = new System.Windows.Forms.Button();
            this.bCheckin = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDenied)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAllowed)).BeginInit();
            this.SuspendLayout();
            // 
            // lRFID
            // 
            this.lRFID.AutoSize = true;
            this.lRFID.Location = new System.Drawing.Point(17, 26);
            this.lRFID.Name = "lRFID";
            this.lRFID.Size = new System.Drawing.Size(75, 13);
            this.lRFID.TabIndex = 0;
            this.lRFID.Text = "RFID Number:";
            this.lRFID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lRFID.Visible = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(17, 96);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name:";
            this.labelName.Visible = false;
            // 
            // lRfidNumber
            // 
            this.lRfidNumber.AutoSize = true;
            this.lRfidNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRfidNumber.Location = new System.Drawing.Point(118, 21);
            this.lRfidNumber.Name = "lRfidNumber";
            this.lRfidNumber.Size = new System.Drawing.Size(0, 20);
            this.lRfidNumber.TabIndex = 3;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(118, 91);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(0, 20);
            this.lName.TabIndex = 4;
            // 
            // pbDenied
            // 
            this.pbDenied.BackColor = System.Drawing.Color.Red;
            this.pbDenied.Location = new System.Drawing.Point(404, 166);
            this.pbDenied.Name = "pbDenied";
            this.pbDenied.Size = new System.Drawing.Size(150, 150);
            this.pbDenied.TabIndex = 6;
            this.pbDenied.TabStop = false;
            this.pbDenied.Visible = false;
            // 
            // pbAllowed
            // 
            this.pbAllowed.BackColor = System.Drawing.Color.Chartreuse;
            this.pbAllowed.Location = new System.Drawing.Point(404, 8);
            this.pbAllowed.Name = "pbAllowed";
            this.pbAllowed.Size = new System.Drawing.Size(150, 150);
            this.pbAllowed.TabIndex = 7;
            this.pbAllowed.TabStop = false;
            this.pbAllowed.Visible = false;
            // 
            // bDeny
            // 
            this.bDeny.Location = new System.Drawing.Point(616, 149);
            this.bDeny.Name = "bDeny";
            this.bDeny.Size = new System.Drawing.Size(87, 23);
            this.bDeny.TabIndex = 8;
            this.bDeny.Text = "Deny person";
            this.bDeny.UseVisualStyleBackColor = true;
            this.bDeny.Visible = false;
            this.bDeny.Click += new System.EventHandler(this.bDeny_Click);
            // 
            // tbDeny
            // 
            this.tbDeny.Enabled = false;
            this.tbDeny.Location = new System.Drawing.Point(616, 178);
            this.tbDeny.MaxLength = 150;
            this.tbDeny.Multiline = true;
            this.tbDeny.Name = "tbDeny";
            this.tbDeny.Size = new System.Drawing.Size(170, 138);
            this.tbDeny.TabIndex = 10;
            this.tbDeny.Visible = false;
            // 
            // bConfirmDeny
            // 
            this.bConfirmDeny.Location = new System.Drawing.Point(711, 149);
            this.bConfirmDeny.Name = "bConfirmDeny";
            this.bConfirmDeny.Size = new System.Drawing.Size(75, 23);
            this.bConfirmDeny.TabIndex = 11;
            this.bConfirmDeny.Text = "Confirm";
            this.bConfirmDeny.UseVisualStyleBackColor = true;
            this.bConfirmDeny.Visible = false;
            this.bConfirmDeny.Click += new System.EventHandler(this.bConfirmDeny_Click);
            // 
            // lDenied
            // 
            this.lDenied.AutoSize = true;
            this.lDenied.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDenied.Location = new System.Drawing.Point(3, 136);
            this.lDenied.Name = "lDenied";
            this.lDenied.Size = new System.Drawing.Size(332, 24);
            this.lDenied.TabIndex = 12;
            this.lDenied.Text = "This person is not allowed to enter";
            this.lDenied.Visible = false;
            // 
            // lCheck
            // 
            this.lCheck.AutoSize = true;
            this.lCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCheck.Location = new System.Drawing.Point(416, 174);
            this.lCheck.Name = "lCheck";
            this.lCheck.Size = new System.Drawing.Size(0, 20);
            this.lCheck.TabIndex = 13;
            // 
            // lDenyReason
            // 
            this.lDenyReason.AutoSize = true;
            this.lDenyReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDenyReason.Location = new System.Drawing.Point(5, 206);
            this.lDenyReason.Name = "lDenyReason";
            this.lDenyReason.Size = new System.Drawing.Size(0, 20);
            this.lDenyReason.TabIndex = 14;
            // 
            // lReason
            // 
            this.lReason.AutoSize = true;
            this.lReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lReason.Location = new System.Drawing.Point(4, 174);
            this.lReason.Name = "lReason";
            this.lReason.Size = new System.Drawing.Size(69, 20);
            this.lReason.TabIndex = 15;
            this.lReason.Text = "Reason:";
            this.lReason.Visible = false;
            // 
            // bAllow
            // 
            this.bAllow.Location = new System.Drawing.Point(616, 120);
            this.bAllow.Name = "bAllow";
            this.bAllow.Size = new System.Drawing.Size(87, 23);
            this.bAllow.TabIndex = 16;
            this.bAllow.Text = "Allow person";
            this.bAllow.UseVisualStyleBackColor = true;
            this.bAllow.Visible = false;
            this.bAllow.Click += new System.EventHandler(this.bAllow_Click);
            // 
            // bConfirmAllow
            // 
            this.bConfirmAllow.Location = new System.Drawing.Point(711, 120);
            this.bConfirmAllow.Name = "bConfirmAllow";
            this.bConfirmAllow.Size = new System.Drawing.Size(75, 23);
            this.bConfirmAllow.TabIndex = 17;
            this.bConfirmAllow.Text = "Confirm";
            this.bConfirmAllow.UseVisualStyleBackColor = true;
            this.bConfirmAllow.Visible = false;
            this.bConfirmAllow.Click += new System.EventHandler(this.bConfirmAllow_Click);
            // 
            // bAddTags
            // 
            this.bAddTags.Location = new System.Drawing.Point(248, 96);
            this.bAddTags.Name = "bAddTags";
            this.bAddTags.Size = new System.Drawing.Size(112, 23);
            this.bAddTags.TabIndex = 18;
            this.bAddTags.Text = "Add new RFID tags";
            this.bAddTags.UseVisualStyleBackColor = true;
            this.bAddTags.Click += new System.EventHandler(this.bAddTags_Click);
            // 
            // bCheckin
            // 
            this.bCheckin.Location = new System.Drawing.Point(404, 96);
            this.bCheckin.Name = "bCheckin";
            this.bCheckin.Size = new System.Drawing.Size(112, 23);
            this.bCheckin.TabIndex = 19;
            this.bCheckin.Text = "Start check-in application";
            this.bCheckin.UseVisualStyleBackColor = true;
            this.bCheckin.Click += new System.EventHandler(this.bCheckin_Click);
            // 
            // bBack
            // 
            this.bBack.Location = new System.Drawing.Point(696, 8);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(75, 23);
            this.bBack.TabIndex = 20;
            this.bBack.Text = "Back";
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Visible = false;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 332);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bCheckin);
            this.Controls.Add(this.bAddTags);
            this.Controls.Add(this.bConfirmAllow);
            this.Controls.Add(this.bAllow);
            this.Controls.Add(this.lReason);
            this.Controls.Add(this.lDenyReason);
            this.Controls.Add(this.lCheck);
            this.Controls.Add(this.lDenied);
            this.Controls.Add(this.bConfirmDeny);
            this.Controls.Add(this.tbDeny);
            this.Controls.Add(this.bDeny);
            this.Controls.Add(this.pbAllowed);
            this.Controls.Add(this.pbDenied);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lRfidNumber);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.lRFID);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDenied)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAllowed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lRFID;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label lRfidNumber;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.PictureBox pbDenied;
        private System.Windows.Forms.PictureBox pbAllowed;
        private System.Windows.Forms.Button bDeny;
        private System.Windows.Forms.TextBox tbDeny;
        private System.Windows.Forms.Button bConfirmDeny;
        private System.Windows.Forms.Label lDenied;
        private System.Windows.Forms.Label lCheck;
        private System.Windows.Forms.Label lDenyReason;
        private System.Windows.Forms.Label lReason;
        private System.Windows.Forms.Button bAllow;
        private System.Windows.Forms.Button bConfirmAllow;
        private System.Windows.Forms.Button bAddTags;
        private System.Windows.Forms.Button bCheckin;
        private System.Windows.Forms.Button bBack;
    }
}

