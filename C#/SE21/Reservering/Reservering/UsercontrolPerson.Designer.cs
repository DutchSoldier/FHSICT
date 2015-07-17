namespace Reservering
{
    partial class UsercontrolPerson
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbZipCode = new System.Windows.Forms.Label();
            this.tbZipCode = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbHouseNumber = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPhoneNumber = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbEmergencyNumber = new System.Windows.Forms.Label();
            this.tbEmergencyNumber = new System.Windows.Forms.TextBox();
            this.lbHouseNumber = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(113, 19);
            this.tbName.MaxLength = 149;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(148, 20);
            this.tbName.TabIndex = 0;
            this.tbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbName_KeyPress);
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(113, 150);
            this.tbPhoneNumber.MaxLength = 15;
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(148, 20);
            this.tbPhoneNumber.TabIndex = 5;
            this.tbPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPhoneNumber_KeyPress);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(72, 22);
            this.lbName.Name = "lbName";
            this.lbName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "Name";
            // 
            // lbZipCode
            // 
            this.lbZipCode.AutoSize = true;
            this.lbZipCode.Location = new System.Drawing.Point(57, 100);
            this.lbZipCode.Name = "lbZipCode";
            this.lbZipCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbZipCode.Size = new System.Drawing.Size(50, 13);
            this.lbZipCode.TabIndex = 3;
            this.lbZipCode.Text = "Zip Code";
            // 
            // tbZipCode
            // 
            this.tbZipCode.Location = new System.Drawing.Point(113, 97);
            this.tbZipCode.MaxLength = 6;
            this.tbZipCode.Name = "tbZipCode";
            this.tbZipCode.Size = new System.Drawing.Size(148, 20);
            this.tbZipCode.TabIndex = 3;
            this.tbZipCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbZipCode_KeyPress);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(54, 48);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 5;
            this.lbPassword.Text = "Password";
            // 
            // tbHouseNumber
            // 
            this.tbHouseNumber.Location = new System.Drawing.Point(113, 124);
            this.tbHouseNumber.MaxLength = 5;
            this.tbHouseNumber.Name = "tbHouseNumber";
            this.tbHouseNumber.Size = new System.Drawing.Size(148, 20);
            this.tbHouseNumber.TabIndex = 4;
            this.tbHouseNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHouseNumber_KeyPress);
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(75, 74);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbEmail.Size = new System.Drawing.Size(32, 13);
            this.lbEmail.TabIndex = 7;
            this.lbEmail.Text = "Email";
            // 
            // lbPhoneNumber
            // 
            this.lbPhoneNumber.AutoSize = true;
            this.lbPhoneNumber.Location = new System.Drawing.Point(29, 153);
            this.lbPhoneNumber.Name = "lbPhoneNumber";
            this.lbPhoneNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbPhoneNumber.Size = new System.Drawing.Size(78, 13);
            this.lbPhoneNumber.TabIndex = 8;
            this.lbPhoneNumber.Text = "Phone Number";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(113, 71);
            this.tbEmail.MaxLength = 49;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(148, 20);
            this.tbEmail.TabIndex = 2;
            this.tbEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEmail_KeyPress);
            // 
            // lbEmergencyNumber
            // 
            this.lbEmergencyNumber.AutoSize = true;
            this.lbEmergencyNumber.Location = new System.Drawing.Point(7, 179);
            this.lbEmergencyNumber.Name = "lbEmergencyNumber";
            this.lbEmergencyNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbEmergencyNumber.Size = new System.Drawing.Size(100, 13);
            this.lbEmergencyNumber.TabIndex = 10;
            this.lbEmergencyNumber.Text = "Emergency Number";
            // 
            // tbEmergencyNumber
            // 
            this.tbEmergencyNumber.Location = new System.Drawing.Point(113, 176);
            this.tbEmergencyNumber.MaxLength = 15;
            this.tbEmergencyNumber.Name = "tbEmergencyNumber";
            this.tbEmergencyNumber.Size = new System.Drawing.Size(148, 20);
            this.tbEmergencyNumber.TabIndex = 6;
            this.tbEmergencyNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEmergencyNumber_KeyPress);
            // 
            // lbHouseNumber
            // 
            this.lbHouseNumber.AutoSize = true;
            this.lbHouseNumber.Location = new System.Drawing.Point(29, 127);
            this.lbHouseNumber.Name = "lbHouseNumber";
            this.lbHouseNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbHouseNumber.Size = new System.Drawing.Size(78, 13);
            this.lbHouseNumber.TabIndex = 12;
            this.lbHouseNumber.Text = "House Number";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(113, 45);
            this.tbPassword.MaxLength = 15;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(148, 20);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // UsercontrolPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbHouseNumber);
            this.Controls.Add(this.tbEmergencyNumber);
            this.Controls.Add(this.lbEmergencyNumber);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbPhoneNumber);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.tbHouseNumber);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.tbZipCode);
            this.Controls.Add(this.lbZipCode);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbPhoneNumber);
            this.Controls.Add(this.tbName);
            this.Name = "UsercontrolPerson";
            this.Size = new System.Drawing.Size(286, 237);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbZipCode;
        private System.Windows.Forms.TextBox tbZipCode;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbHouseNumber;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPhoneNumber;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbEmergencyNumber;
        private System.Windows.Forms.TextBox tbEmergencyNumber;
        private System.Windows.Forms.Label lbHouseNumber;
        private System.Windows.Forms.TextBox tbPassword;
    }
}
