namespace Reserveringssysteem
{
    partial class NieuweReserveringForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NieuweReserveringForm));
            this.GroupBoxBetalendeKlant = new System.Windows.Forms.GroupBox();
            this.tbSofi = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbTelefoon = new System.Windows.Forms.TextBox();
            this.tbPostcode = new System.Windows.Forms.TextBox();
            this.tbWoonplaats = new System.Windows.Forms.TextBox();
            this.tbStraat = new System.Windows.Forms.TextBox();
            this.tbRekening = new System.Windows.Forms.TextBox();
            this.lblSofi = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefoon = new System.Windows.Forms.Label();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.tbNaam = new System.Windows.Forms.TextBox();
            this.lblWoonplaats = new System.Windows.Forms.Label();
            this.lblStraat = new System.Windows.Forms.Label();
            this.lblRekening = new System.Windows.Forms.Label();
            this.lblNaam = new System.Windows.Forms.Label();
            this.btnAnnuleer = new System.Windows.Forms.Button();
            this.btnBevestig = new System.Windows.Forms.Button();
            this.GroupBoxBetalendeKlant.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxBetalendeKlant
            // 
            this.GroupBoxBetalendeKlant.Controls.Add(this.tbSofi);
            this.GroupBoxBetalendeKlant.Controls.Add(this.tbEmail);
            this.GroupBoxBetalendeKlant.Controls.Add(this.tbTelefoon);
            this.GroupBoxBetalendeKlant.Controls.Add(this.tbPostcode);
            this.GroupBoxBetalendeKlant.Controls.Add(this.tbWoonplaats);
            this.GroupBoxBetalendeKlant.Controls.Add(this.tbStraat);
            this.GroupBoxBetalendeKlant.Controls.Add(this.tbRekening);
            this.GroupBoxBetalendeKlant.Controls.Add(this.lblSofi);
            this.GroupBoxBetalendeKlant.Controls.Add(this.lblEmail);
            this.GroupBoxBetalendeKlant.Controls.Add(this.lblTelefoon);
            this.GroupBoxBetalendeKlant.Controls.Add(this.lblPostcode);
            this.GroupBoxBetalendeKlant.Controls.Add(this.tbNaam);
            this.GroupBoxBetalendeKlant.Controls.Add(this.lblWoonplaats);
            this.GroupBoxBetalendeKlant.Controls.Add(this.lblStraat);
            this.GroupBoxBetalendeKlant.Controls.Add(this.lblRekening);
            this.GroupBoxBetalendeKlant.Controls.Add(this.lblNaam);
            this.GroupBoxBetalendeKlant.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxBetalendeKlant.Name = "GroupBoxBetalendeKlant";
            this.GroupBoxBetalendeKlant.Size = new System.Drawing.Size(219, 242);
            this.GroupBoxBetalendeKlant.TabIndex = 4;
            this.GroupBoxBetalendeKlant.TabStop = false;
            this.GroupBoxBetalendeKlant.Text = "Betalende klant";
            // 
            // tbSofi
            // 
            this.tbSofi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbSofi.Location = new System.Drawing.Point(78, 204);
            this.tbSofi.Name = "tbSofi";
            this.tbSofi.Size = new System.Drawing.Size(135, 20);
            this.tbSofi.TabIndex = 14;
            this.tbSofi.Tag = "Voer het sofinummer in van de betalende klant.";
            // 
            // tbEmail
            // 
            this.tbEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbEmail.Location = new System.Drawing.Point(78, 178);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(135, 20);
            this.tbEmail.TabIndex = 13;
            this.tbEmail.Tag = "Voer het email adres in waar de reservering bevesting naar toe wordt gezonden.";
            // 
            // tbTelefoon
            // 
            this.tbTelefoon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbTelefoon.Location = new System.Drawing.Point(78, 152);
            this.tbTelefoon.Name = "tbTelefoon";
            this.tbTelefoon.Size = new System.Drawing.Size(135, 20);
            this.tbTelefoon.TabIndex = 12;
            this.tbTelefoon.Tag = "Voer het telefoonnummer in van de betalende klant. Let op: alleen cijfers gebruik" +
                "en.";
            // 
            // tbPostcode
            // 
            this.tbPostcode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbPostcode.Location = new System.Drawing.Point(78, 126);
            this.tbPostcode.Name = "tbPostcode";
            this.tbPostcode.Size = new System.Drawing.Size(135, 20);
            this.tbPostcode.TabIndex = 11;
            this.tbPostcode.Tag = "Voer de postcode in van de reserverende klant.";
            // 
            // tbWoonplaats
            // 
            this.tbWoonplaats.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbWoonplaats.Location = new System.Drawing.Point(78, 100);
            this.tbWoonplaats.Name = "tbWoonplaats";
            this.tbWoonplaats.Size = new System.Drawing.Size(135, 20);
            this.tbWoonplaats.TabIndex = 10;
            this.tbWoonplaats.Tag = "Voer de woonplaats in van de reserverende klant.";
            // 
            // tbStraat
            // 
            this.tbStraat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbStraat.Location = new System.Drawing.Point(78, 74);
            this.tbStraat.Name = "tbStraat";
            this.tbStraat.Size = new System.Drawing.Size(135, 20);
            this.tbStraat.TabIndex = 9;
            this.tbStraat.Tag = "Voer de straat in van de reserverende klant.";
            // 
            // tbRekening
            // 
            this.tbRekening.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbRekening.Location = new System.Drawing.Point(78, 48);
            this.tbRekening.Name = "tbRekening";
            this.tbRekening.Size = new System.Drawing.Size(135, 20);
            this.tbRekening.TabIndex = 8;
            this.tbRekening.Tag = "Voer het rekeningnummer in van de reserverende klant.";
            // 
            // lblSofi
            // 
            this.lblSofi.AutoSize = true;
            this.lblSofi.Location = new System.Drawing.Point(7, 207);
            this.lblSofi.Name = "lblSofi";
            this.lblSofi.Size = new System.Drawing.Size(65, 13);
            this.lblSofi.TabIndex = 7;
            this.lblSofi.Text = "Sofinummer:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(7, 181);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // lblTelefoon
            // 
            this.lblTelefoon.AutoSize = true;
            this.lblTelefoon.Location = new System.Drawing.Point(7, 155);
            this.lblTelefoon.Name = "lblTelefoon";
            this.lblTelefoon.Size = new System.Drawing.Size(52, 13);
            this.lblTelefoon.TabIndex = 5;
            this.lblTelefoon.Text = "Telefoon:";
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Location = new System.Drawing.Point(7, 129);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(55, 13);
            this.lblPostcode.TabIndex = 4;
            this.lblPostcode.Text = "Postcode:";
            // 
            // tbNaam
            // 
            this.tbNaam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbNaam.Location = new System.Drawing.Point(78, 22);
            this.tbNaam.Name = "tbNaam";
            this.tbNaam.Size = new System.Drawing.Size(135, 20);
            this.tbNaam.TabIndex = 0;
            this.tbNaam.Tag = "Voer de naam in van de reserverende klant.";
            // 
            // lblWoonplaats
            // 
            this.lblWoonplaats.AutoSize = true;
            this.lblWoonplaats.Location = new System.Drawing.Point(7, 103);
            this.lblWoonplaats.Name = "lblWoonplaats";
            this.lblWoonplaats.Size = new System.Drawing.Size(67, 13);
            this.lblWoonplaats.TabIndex = 3;
            this.lblWoonplaats.Text = "Woonplaats:";
            // 
            // lblStraat
            // 
            this.lblStraat.AutoSize = true;
            this.lblStraat.Location = new System.Drawing.Point(7, 77);
            this.lblStraat.Name = "lblStraat";
            this.lblStraat.Size = new System.Drawing.Size(38, 13);
            this.lblStraat.TabIndex = 2;
            this.lblStraat.Text = "Straat:";
            // 
            // lblRekening
            // 
            this.lblRekening.AutoSize = true;
            this.lblRekening.Location = new System.Drawing.Point(6, 51);
            this.lblRekening.Name = "lblRekening";
            this.lblRekening.Size = new System.Drawing.Size(56, 13);
            this.lblRekening.TabIndex = 1;
            this.lblRekening.Text = "Rekening:";
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Location = new System.Drawing.Point(6, 25);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(38, 13);
            this.lblNaam.TabIndex = 0;
            this.lblNaam.Text = "Naam:";
            // 
            // btnAnnuleer
            // 
            this.btnAnnuleer.Image = global::Reserveringssysteem.Properties.Resources.dialog_cancel;
            this.btnAnnuleer.Location = new System.Drawing.Point(126, 260);
            this.btnAnnuleer.Name = "btnAnnuleer";
            this.btnAnnuleer.Size = new System.Drawing.Size(105, 35);
            this.btnAnnuleer.TabIndex = 6;
            this.btnAnnuleer.Tag = "Sluit dit venster af.";
            this.btnAnnuleer.Text = "Annuleren";
            this.btnAnnuleer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnuleer.UseVisualStyleBackColor = true;
            this.btnAnnuleer.Click += new System.EventHandler(this.btnAnnuleer_Click);
            // 
            // btnBevestig
            // 
            this.btnBevestig.Image = global::Reserveringssysteem.Properties.Resources.dialog_ok;
            this.btnBevestig.Location = new System.Drawing.Point(12, 260);
            this.btnBevestig.Name = "btnBevestig";
            this.btnBevestig.Size = new System.Drawing.Size(105, 35);
            this.btnBevestig.TabIndex = 5;
            this.btnBevestig.Tag = "Bevestigd de reservering en schrijft deze weg naar de database.";
            this.btnBevestig.Text = "Bevestig";
            this.btnBevestig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBevestig.UseVisualStyleBackColor = true;
            this.btnBevestig.Click += new System.EventHandler(this.btnBevestig_Click);
            // 
            // NieuweReserveringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 300);
            this.Controls.Add(this.btnAnnuleer);
            this.Controls.Add(this.btnBevestig);
            this.Controls.Add(this.GroupBoxBetalendeKlant);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(259, 338);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(259, 338);
            this.Name = "NieuweReserveringForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voer klant gegevens in";
            this.Load += new System.EventHandler(this.NieuweReserveringForm_Load);
            this.GroupBoxBetalendeKlant.ResumeLayout(false);
            this.GroupBoxBetalendeKlant.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBevestig;
        private System.Windows.Forms.GroupBox GroupBoxBetalendeKlant;
        private System.Windows.Forms.TextBox tbSofi;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbTelefoon;
        private System.Windows.Forms.TextBox tbPostcode;
        private System.Windows.Forms.TextBox tbWoonplaats;
        private System.Windows.Forms.TextBox tbStraat;
        private System.Windows.Forms.TextBox tbRekening;
        private System.Windows.Forms.Label lblSofi;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefoon;
        private System.Windows.Forms.Label lblPostcode;
        private System.Windows.Forms.TextBox tbNaam;
        private System.Windows.Forms.Label lblWoonplaats;
        private System.Windows.Forms.Label lblStraat;
        private System.Windows.Forms.Label lblRekening;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.Button btnAnnuleer;
    }
}