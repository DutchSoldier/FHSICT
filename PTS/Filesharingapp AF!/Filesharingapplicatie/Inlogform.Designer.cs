namespace Filesharingapplicatie
{
    partial class Inlogform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inlogform));
            this.tb_RFID = new System.Windows.Forms.TextBox();
            this.tb_wachtwoord = new System.Windows.Forms.TextBox();
            this.lb_RFID = new System.Windows.Forms.Label();
            this.lb_wachtwoord = new System.Windows.Forms.Label();
            this.bt_accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_RFID
            // 
            this.tb_RFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_RFID.Location = new System.Drawing.Point(136, 12);
            this.tb_RFID.MaxLength = 15;
            this.tb_RFID.Name = "tb_RFID";
            this.tb_RFID.Size = new System.Drawing.Size(125, 26);
            this.tb_RFID.TabIndex = 0;
            // 
            // tb_wachtwoord
            // 
            this.tb_wachtwoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_wachtwoord.Location = new System.Drawing.Point(136, 44);
            this.tb_wachtwoord.MaxLength = 15;
            this.tb_wachtwoord.Name = "tb_wachtwoord";
            this.tb_wachtwoord.Size = new System.Drawing.Size(125, 26);
            this.tb_wachtwoord.TabIndex = 1;
            this.tb_wachtwoord.UseSystemPasswordChar = true;
            // 
            // lb_RFID
            // 
            this.lb_RFID.AutoSize = true;
            this.lb_RFID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_RFID.Location = new System.Drawing.Point(15, 15);
            this.lb_RFID.Name = "lb_RFID";
            this.lb_RFID.Size = new System.Drawing.Size(115, 20);
            this.lb_RFID.TabIndex = 2;
            this.lb_RFID.Text = "RFID-nummer:";
            // 
            // lb_wachtwoord
            // 
            this.lb_wachtwoord.AutoSize = true;
            this.lb_wachtwoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_wachtwoord.Location = new System.Drawing.Point(15, 47);
            this.lb_wachtwoord.Name = "lb_wachtwoord";
            this.lb_wachtwoord.Size = new System.Drawing.Size(102, 20);
            this.lb_wachtwoord.TabIndex = 3;
            this.lb_wachtwoord.Text = "Wachtwoord:";
            // 
            // bt_accept
            // 
            this.bt_accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_accept.Image = global::Filesharingapplicatie.Properties.Resources.dialog_password;
            this.bt_accept.Location = new System.Drawing.Point(50, 85);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(179, 56);
            this.bt_accept.TabIndex = 18;
            this.bt_accept.Text = "Inloggen";
            this.bt_accept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_accept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // Inlogform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(276, 152);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.lb_wachtwoord);
            this.Controls.Add(this.lb_RFID);
            this.Controls.Add(this.tb_wachtwoord);
            this.Controls.Add(this.tb_RFID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inlogform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inloggen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Inlogform_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_RFID;
        private System.Windows.Forms.TextBox tb_wachtwoord;
        private System.Windows.Forms.Label lb_RFID;
        private System.Windows.Forms.Label lb_wachtwoord;
        private System.Windows.Forms.Button bt_accept;
    }
}