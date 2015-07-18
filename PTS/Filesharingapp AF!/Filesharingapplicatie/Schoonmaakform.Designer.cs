namespace Filesharingapplicatie
{
    partial class Schoonmaakform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schoonmaakform));
            this.rb_gebruiker = new System.Windows.Forms.RadioButton();
            this.tb_RFID = new System.Windows.Forms.TextBox();
            this.rb_alle = new System.Windows.Forms.RadioButton();
            this.panel_gebruikers = new System.Windows.Forms.Panel();
            this.rb_extensie = new System.Windows.Forms.RadioButton();
            this.rb_alleextensies = new System.Windows.Forms.RadioButton();
            this.tb_extensie = new System.Windows.Forms.TextBox();
            this.lb_vanaf = new System.Windows.Forms.Label();
            this.lb_tot = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtp_vanaf = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtp_tot = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_accept = new System.Windows.Forms.Button();
            this.panel_gebruikers.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rb_gebruiker
            // 
            this.rb_gebruiker.AutoSize = true;
            this.rb_gebruiker.Location = new System.Drawing.Point(10, 14);
            this.rb_gebruiker.Name = "rb_gebruiker";
            this.rb_gebruiker.Size = new System.Drawing.Size(90, 17);
            this.rb_gebruiker.TabIndex = 10;
            this.rb_gebruiker.Text = "van gebruiker";
            this.rb_gebruiker.UseVisualStyleBackColor = true;
            // 
            // tb_RFID
            // 
            this.tb_RFID.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tb_RFID.Location = new System.Drawing.Point(106, 13);
            this.tb_RFID.MaxLength = 15;
            this.tb_RFID.Name = "tb_RFID";
            this.tb_RFID.Size = new System.Drawing.Size(100, 20);
            this.tb_RFID.TabIndex = 11;
            this.tb_RFID.Text = "RFID";
            this.tb_RFID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_RFID_MouseClick);
            // 
            // rb_alle
            // 
            this.rb_alle.AutoSize = true;
            this.rb_alle.Checked = true;
            this.rb_alle.Location = new System.Drawing.Point(10, 39);
            this.rb_alle.Name = "rb_alle";
            this.rb_alle.Size = new System.Drawing.Size(114, 17);
            this.rb_alle.TabIndex = 12;
            this.rb_alle.TabStop = true;
            this.rb_alle.Text = "van alle gebruikers";
            this.rb_alle.UseVisualStyleBackColor = true;
            // 
            // panel_gebruikers
            // 
            this.panel_gebruikers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_gebruikers.Controls.Add(this.tb_RFID);
            this.panel_gebruikers.Controls.Add(this.rb_gebruiker);
            this.panel_gebruikers.Controls.Add(this.rb_alle);
            this.panel_gebruikers.Location = new System.Drawing.Point(11, 103);
            this.panel_gebruikers.Name = "panel_gebruikers";
            this.panel_gebruikers.Size = new System.Drawing.Size(244, 71);
            this.panel_gebruikers.TabIndex = 13;
            // 
            // rb_extensie
            // 
            this.rb_extensie.AutoSize = true;
            this.rb_extensie.Location = new System.Drawing.Point(10, 14);
            this.rb_extensie.Name = "rb_extensie";
            this.rb_extensie.Size = new System.Drawing.Size(99, 17);
            this.rb_extensie.TabIndex = 10;
            this.rb_extensie.Text = "met de extensie";
            this.rb_extensie.UseVisualStyleBackColor = true;
            // 
            // rb_alleextensies
            // 
            this.rb_alleextensies.AutoSize = true;
            this.rb_alleextensies.Checked = true;
            this.rb_alleextensies.Location = new System.Drawing.Point(10, 39);
            this.rb_alleextensies.Name = "rb_alleextensies";
            this.rb_alleextensies.Size = new System.Drawing.Size(108, 17);
            this.rb_alleextensies.TabIndex = 12;
            this.rb_alleextensies.TabStop = true;
            this.rb_alleextensies.Text = "met alle extensies";
            this.rb_alleextensies.UseVisualStyleBackColor = true;
            // 
            // tb_extensie
            // 
            this.tb_extensie.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tb_extensie.Location = new System.Drawing.Point(115, 13);
            this.tb_extensie.MaxLength = 15;
            this.tb_extensie.Name = "tb_extensie";
            this.tb_extensie.Size = new System.Drawing.Size(83, 20);
            this.tb_extensie.TabIndex = 11;
            // 
            // lb_vanaf
            // 
            this.lb_vanaf.AutoSize = true;
            this.lb_vanaf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_vanaf.Location = new System.Drawing.Point(7, 12);
            this.lb_vanaf.Name = "lb_vanaf";
            this.lb_vanaf.Size = new System.Drawing.Size(35, 13);
            this.lb_vanaf.TabIndex = 8;
            this.lb_vanaf.Text = "Vanaf";
            // 
            // lb_tot
            // 
            this.lb_tot.AutoSize = true;
            this.lb_tot.Location = new System.Drawing.Point(7, 12);
            this.lb_tot.Name = "lb_tot";
            this.lb_tot.Size = new System.Drawing.Size(23, 13);
            this.lb_tot.TabIndex = 9;
            this.lb_tot.Text = "Tot";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtp_vanaf);
            this.panel2.Controls.Add(this.lb_vanaf);
            this.panel2.Location = new System.Drawing.Point(11, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 40);
            this.panel2.TabIndex = 15;
            // 
            // dtp_vanaf
            // 
            this.dtp_vanaf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_vanaf.Location = new System.Drawing.Point(58, 9);
            this.dtp_vanaf.Name = "dtp_vanaf";
            this.dtp_vanaf.Size = new System.Drawing.Size(172, 20);
            this.dtp_vanaf.TabIndex = 19;
            this.dtp_vanaf.Value = new System.DateTime(2011, 4, 1, 0, 0, 1, 0);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dtp_tot);
            this.panel3.Controls.Add(this.lb_tot);
            this.panel3.Location = new System.Drawing.Point(11, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 40);
            this.panel3.TabIndex = 16;
            // 
            // dtp_tot
            // 
            this.dtp_tot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp_tot.Location = new System.Drawing.Point(58, 9);
            this.dtp_tot.Name = "dtp_tot";
            this.dtp_tot.Size = new System.Drawing.Size(172, 20);
            this.dtp_tot.TabIndex = 18;
            this.dtp_tot.Value = new System.DateTime(2011, 4, 1, 23, 59, 59, 0);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tb_extensie);
            this.panel1.Controls.Add(this.rb_extensie);
            this.panel1.Controls.Add(this.rb_alleextensies);
            this.panel1.Location = new System.Drawing.Point(11, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 71);
            this.panel1.TabIndex = 14;
            // 
            // bt_accept
            // 
            this.bt_accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_accept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_accept.Location = new System.Drawing.Point(50, 257);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(179, 56);
            this.bt_accept.TabIndex = 17;
            this.bt_accept.Text = "Schoonmaken";
            this.bt_accept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // Schoonmaakform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(266, 325);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_gebruikers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Schoonmaakform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schoonmaken";
            this.panel_gebruikers.ResumeLayout(false);
            this.panel_gebruikers.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_gebruiker;
        private System.Windows.Forms.TextBox tb_RFID;
        private System.Windows.Forms.RadioButton rb_alle;
        private System.Windows.Forms.Panel panel_gebruikers;
        private System.Windows.Forms.RadioButton rb_extensie;
        private System.Windows.Forms.RadioButton rb_alleextensies;
        private System.Windows.Forms.TextBox tb_extensie;
        private System.Windows.Forms.Label lb_vanaf;
        private System.Windows.Forms.Label lb_tot;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_accept;
        private System.Windows.Forms.DateTimePicker dtp_tot;
        private System.Windows.Forms.DateTimePicker dtp_vanaf;

    }
}