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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lRfidNummer = new System.Windows.Forms.Label();
            this.lNaam = new System.Windows.Forms.Label();
            this.lKampeerPlaats = new System.Windows.Forms.Label();
            this.pbGeweigerd = new System.Windows.Forms.PictureBox();
            this.pbToegestaan = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGeweigerd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToegestaan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RFID Nummer:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Naam:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "KampeerPlaats:";
            // 
            // lRfidNummer
            // 
            this.lRfidNummer.AutoSize = true;
            this.lRfidNummer.Location = new System.Drawing.Point(219, 68);
            this.lRfidNummer.Name = "lRfidNummer";
            this.lRfidNummer.Size = new System.Drawing.Size(0, 13);
            this.lRfidNummer.TabIndex = 3;
            // 
            // lNaam
            // 
            this.lNaam.AutoSize = true;
            this.lNaam.Location = new System.Drawing.Point(219, 123);
            this.lNaam.Name = "lNaam";
            this.lNaam.Size = new System.Drawing.Size(0, 13);
            this.lNaam.TabIndex = 4;
            // 
            // lKampeerPlaats
            // 
            this.lKampeerPlaats.AutoSize = true;
            this.lKampeerPlaats.Location = new System.Drawing.Point(219, 175);
            this.lKampeerPlaats.Name = "lKampeerPlaats";
            this.lKampeerPlaats.Size = new System.Drawing.Size(0, 13);
            this.lKampeerPlaats.TabIndex = 5;
            // 
            // pbGeweigerd
            // 
            this.pbGeweigerd.Location = new System.Drawing.Point(272, 216);
            this.pbGeweigerd.Name = "pbGeweigerd";
            this.pbGeweigerd.Size = new System.Drawing.Size(100, 100);
            this.pbGeweigerd.TabIndex = 6;
            this.pbGeweigerd.TabStop = false;
            // 
            // pbToegestaan
            // 
            this.pbToegestaan.Location = new System.Drawing.Point(143, 216);
            this.pbToegestaan.Name = "pbToegestaan";
            this.pbToegestaan.Size = new System.Drawing.Size(100, 100);
            this.pbToegestaan.TabIndex = 7;
            this.pbToegestaan.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 382);
            this.Controls.Add(this.pbToegestaan);
            this.Controls.Add(this.pbGeweigerd);
            this.Controls.Add(this.lKampeerPlaats);
            this.Controls.Add(this.lNaam);
            this.Controls.Add(this.lRfidNummer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGeweigerd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToegestaan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lRfidNummer;
        private System.Windows.Forms.Label lNaam;
        private System.Windows.Forms.Label lKampeerPlaats;
        private System.Windows.Forms.PictureBox pbGeweigerd;
        private System.Windows.Forms.PictureBox pbToegestaan;
    }
}

