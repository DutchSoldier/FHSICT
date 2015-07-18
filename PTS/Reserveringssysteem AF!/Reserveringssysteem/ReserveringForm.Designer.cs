namespace Reserveringssysteem
{
    partial class ReserveringForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReserveringForm));
            this.GroupBoxPlaatsen = new System.Windows.Forms.GroupBox();
            this.lblPrijs = new System.Windows.Forms.Label();
            this.lblTotaalPrijs = new System.Windows.Forms.Label();
            this.listViewPlaatsen = new System.Windows.Forms.ListView();
            this.Plaatsnummer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prijs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVerwijderPlek = new System.Windows.Forms.Button();
            this.GroupBoxBetalendeKlant = new System.Windows.Forms.GroupBox();
            this.tbSofinummer = new System.Windows.Forms.TextBox();
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
            this.btnBevestig = new System.Windows.Forms.Button();
            this.GroupBoxAantal = new System.Windows.Forms.GroupBox();
            this.nudAantal = new System.Windows.Forms.NumericUpDown();
            this.lblAantal = new System.Windows.Forms.Label();
            this.lblReserveringsNummer = new System.Windows.Forms.Label();
            this.tbReserveringsNummer = new System.Windows.Forms.TextBox();
            this.campingPanel = new System.Windows.Forms.Panel();
            this.GroupBoxPlaatsen.SuspendLayout();
            this.GroupBoxBetalendeKlant.SuspendLayout();
            this.GroupBoxAantal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAantal)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxPlaatsen
            // 
            this.GroupBoxPlaatsen.Controls.Add(this.lblPrijs);
            this.GroupBoxPlaatsen.Controls.Add(this.lblTotaalPrijs);
            this.GroupBoxPlaatsen.Controls.Add(this.listViewPlaatsen);
            this.GroupBoxPlaatsen.Controls.Add(this.btnVerwijderPlek);
            this.GroupBoxPlaatsen.Location = new System.Drawing.Point(753, 45);
            this.GroupBoxPlaatsen.Name = "GroupBoxPlaatsen";
            this.GroupBoxPlaatsen.Size = new System.Drawing.Size(169, 251);
            this.GroupBoxPlaatsen.TabIndex = 1;
            this.GroupBoxPlaatsen.TabStop = false;
            this.GroupBoxPlaatsen.Text = "Plaatsen";
            // 
            // lblPrijs
            // 
            this.lblPrijs.AutoSize = true;
            this.lblPrijs.Location = new System.Drawing.Point(105, 179);
            this.lblPrijs.Name = "lblPrijs";
            this.lblPrijs.Size = new System.Drawing.Size(0, 13);
            this.lblPrijs.TabIndex = 4;
            this.lblPrijs.Tag = "De totale kosten voor deze reservering.";
            // 
            // lblTotaalPrijs
            // 
            this.lblTotaalPrijs.AutoSize = true;
            this.lblTotaalPrijs.Location = new System.Drawing.Point(59, 179);
            this.lblTotaalPrijs.Name = "lblTotaalPrijs";
            this.lblTotaalPrijs.Size = new System.Drawing.Size(40, 13);
            this.lblTotaalPrijs.TabIndex = 3;
            this.lblTotaalPrijs.Text = "Totaal:";
            // 
            // listViewPlaatsen
            // 
            this.listViewPlaatsen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Plaatsnummer,
            this.Prijs});
            this.listViewPlaatsen.FullRowSelect = true;
            this.listViewPlaatsen.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewPlaatsen.HideSelection = false;
            this.listViewPlaatsen.Location = new System.Drawing.Point(9, 19);
            this.listViewPlaatsen.MultiSelect = false;
            this.listViewPlaatsen.Name = "listViewPlaatsen";
            this.listViewPlaatsen.Size = new System.Drawing.Size(150, 154);
            this.listViewPlaatsen.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewPlaatsen.TabIndex = 2;
            this.listViewPlaatsen.Tag = "Hier staat een overzicht van de gereserveerde plaatsen in deze reservering.";
            this.listViewPlaatsen.UseCompatibleStateImageBehavior = false;
            this.listViewPlaatsen.View = System.Windows.Forms.View.Details;
            // 
            // Plaatsnummer
            // 
            this.Plaatsnummer.Text = "Plaatsnummer";
            this.Plaatsnummer.Width = 84;
            // 
            // Prijs
            // 
            this.Prijs.Text = "Prijs";
            this.Prijs.Width = 44;
            // 
            // btnVerwijderPlek
            // 
            this.btnVerwijderPlek.Image = global::Reserveringssysteem.Properties.Resources.gtk_remove;
            this.btnVerwijderPlek.Location = new System.Drawing.Point(7, 200);
            this.btnVerwijderPlek.Name = "btnVerwijderPlek";
            this.btnVerwijderPlek.Size = new System.Drawing.Size(152, 35);
            this.btnVerwijderPlek.TabIndex = 1;
            this.btnVerwijderPlek.Tag = "Deze knop verwijderd de plaats die in het overzicht hierboven geselecteerd is uit" +
                " de reservering.";
            this.btnVerwijderPlek.Text = "Verwijder plaats";
            this.btnVerwijderPlek.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerwijderPlek.UseVisualStyleBackColor = true;
            this.btnVerwijderPlek.Click += new System.EventHandler(this.btnVerwijderPlek_Click);
            // 
            // GroupBoxBetalendeKlant
            // 
            this.GroupBoxBetalendeKlant.Controls.Add(this.tbSofinummer);
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
            this.GroupBoxBetalendeKlant.Location = new System.Drawing.Point(753, 360);
            this.GroupBoxBetalendeKlant.Name = "GroupBoxBetalendeKlant";
            this.GroupBoxBetalendeKlant.Size = new System.Drawing.Size(169, 242);
            this.GroupBoxBetalendeKlant.TabIndex = 2;
            this.GroupBoxBetalendeKlant.TabStop = false;
            this.GroupBoxBetalendeKlant.Text = "Betalende klant";
            // 
            // tbSofinummer
            // 
            this.tbSofinummer.Location = new System.Drawing.Point(78, 204);
            this.tbSofinummer.Name = "tbSofinummer";
            this.tbSofinummer.ReadOnly = true;
            this.tbSofinummer.Size = new System.Drawing.Size(81, 20);
            this.tbSofinummer.TabIndex = 14;
            this.tbSofinummer.Tag = "Voer het sofinummer in van de betalende klant.";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(78, 178);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(81, 20);
            this.tbEmail.TabIndex = 13;
            this.tbEmail.Tag = "Voer de email in waar de reserveringsbevestiging naatoe gestuurd moet worden.";
            // 
            // tbTelefoon
            // 
            this.tbTelefoon.Location = new System.Drawing.Point(78, 152);
            this.tbTelefoon.Name = "tbTelefoon";
            this.tbTelefoon.ReadOnly = true;
            this.tbTelefoon.Size = new System.Drawing.Size(81, 20);
            this.tbTelefoon.TabIndex = 12;
            this.tbTelefoon.Tag = "Voer het telefoonnummer in van de betalende klant. Let op: bestaat uit alleen cij" +
                "fers.";
            // 
            // tbPostcode
            // 
            this.tbPostcode.Location = new System.Drawing.Point(78, 126);
            this.tbPostcode.Name = "tbPostcode";
            this.tbPostcode.ReadOnly = true;
            this.tbPostcode.Size = new System.Drawing.Size(81, 20);
            this.tbPostcode.TabIndex = 11;
            this.tbPostcode.Tag = "Voer de postcode in van de reserverende klant.";
            // 
            // tbWoonplaats
            // 
            this.tbWoonplaats.Location = new System.Drawing.Point(78, 100);
            this.tbWoonplaats.Name = "tbWoonplaats";
            this.tbWoonplaats.ReadOnly = true;
            this.tbWoonplaats.Size = new System.Drawing.Size(81, 20);
            this.tbWoonplaats.TabIndex = 10;
            this.tbWoonplaats.Tag = "Voer de woonplaats in van de reserverende klant.";
            // 
            // tbStraat
            // 
            this.tbStraat.Location = new System.Drawing.Point(78, 74);
            this.tbStraat.Name = "tbStraat";
            this.tbStraat.ReadOnly = true;
            this.tbStraat.Size = new System.Drawing.Size(81, 20);
            this.tbStraat.TabIndex = 9;
            this.tbStraat.Tag = "Voer de straat + huisnummer in van de reserverende klant.";
            // 
            // tbRekening
            // 
            this.tbRekening.Location = new System.Drawing.Point(78, 48);
            this.tbRekening.Name = "tbRekening";
            this.tbRekening.ReadOnly = true;
            this.tbRekening.Size = new System.Drawing.Size(81, 20);
            this.tbRekening.TabIndex = 8;
            this.tbRekening.Tag = "Voer het rekeningnummer in van de betalende klant.";
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
            this.tbNaam.Location = new System.Drawing.Point(78, 22);
            this.tbNaam.Name = "tbNaam";
            this.tbNaam.ReadOnly = true;
            this.tbNaam.Size = new System.Drawing.Size(81, 20);
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
            // btnBevestig
            // 
            this.btnBevestig.Image = global::Reserveringssysteem.Properties.Resources.dialog_ok;
            this.btnBevestig.Location = new System.Drawing.Point(763, 608);
            this.btnBevestig.Name = "btnBevestig";
            this.btnBevestig.Size = new System.Drawing.Size(152, 35);
            this.btnBevestig.TabIndex = 3;
            this.btnBevestig.Tag = "Met deze knop bevestig je de reservering en verzend een bevestiging naar de klant" +
                ".";
            this.btnBevestig.Text = "Bevestig reservering";
            this.btnBevestig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBevestig.UseVisualStyleBackColor = true;
            this.btnBevestig.Click += new System.EventHandler(this.btnBevestig_Click);
            // 
            // GroupBoxAantal
            // 
            this.GroupBoxAantal.Controls.Add(this.nudAantal);
            this.GroupBoxAantal.Controls.Add(this.lblAantal);
            this.GroupBoxAantal.Location = new System.Drawing.Point(753, 302);
            this.GroupBoxAantal.Name = "GroupBoxAantal";
            this.GroupBoxAantal.Size = new System.Drawing.Size(169, 52);
            this.GroupBoxAantal.TabIndex = 4;
            this.GroupBoxAantal.TabStop = false;
            this.GroupBoxAantal.Text = "Aantal Personen";
            // 
            // nudAantal
            // 
            this.nudAantal.Location = new System.Drawing.Point(78, 23);
            this.nudAantal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAantal.Name = "nudAantal";
            this.nudAantal.Size = new System.Drawing.Size(81, 20);
            this.nudAantal.TabIndex = 16;
            this.nudAantal.Tag = "Hiermee geef je aan voor hoeveel personen er gereserveerd is.";
            this.nudAantal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAantal
            // 
            this.lblAantal.AutoSize = true;
            this.lblAantal.Location = new System.Drawing.Point(7, 25);
            this.lblAantal.Name = "lblAantal";
            this.lblAantal.Size = new System.Drawing.Size(40, 13);
            this.lblAantal.TabIndex = 15;
            this.lblAantal.Text = "Aantal:";
            // 
            // lblReserveringsNummer
            // 
            this.lblReserveringsNummer.AutoSize = true;
            this.lblReserveringsNummer.Location = new System.Drawing.Point(752, 12);
            this.lblReserveringsNummer.Name = "lblReserveringsNummer";
            this.lblReserveringsNummer.Size = new System.Drawing.Size(86, 13);
            this.lblReserveringsNummer.TabIndex = 5;
            this.lblReserveringsNummer.Text = "Reserverings Nr.";
            // 
            // tbReserveringsNummer
            // 
            this.tbReserveringsNummer.Location = new System.Drawing.Point(845, 10);
            this.tbReserveringsNummer.Name = "tbReserveringsNummer";
            this.tbReserveringsNummer.ReadOnly = true;
            this.tbReserveringsNummer.Size = new System.Drawing.Size(77, 20);
            this.tbReserveringsNummer.TabIndex = 6;
            this.tbReserveringsNummer.Tag = "Reserveringskenmerk van deze reservering.";
            // 
            // campingPanel
            // 
            this.campingPanel.BackColor = System.Drawing.Color.Transparent;
            this.campingPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("campingPanel.BackgroundImage")));
            this.campingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.campingPanel.Location = new System.Drawing.Point(12, 12);
            this.campingPanel.Name = "campingPanel";
            this.campingPanel.Size = new System.Drawing.Size(734, 631);
            this.campingPanel.TabIndex = 0;
            this.campingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.campingPanel_Paint);
            this.campingPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.campingPanel_MouseClick);
            this.campingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.campingPanel_MouseMove);
            // 
            // ReserveringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 659);
            this.Controls.Add(this.tbReserveringsNummer);
            this.Controls.Add(this.lblReserveringsNummer);
            this.Controls.Add(this.GroupBoxAantal);
            this.Controls.Add(this.btnBevestig);
            this.Controls.Add(this.GroupBoxBetalendeKlant);
            this.Controls.Add(this.GroupBoxPlaatsen);
            this.Controls.Add(this.campingPanel);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(945, 697);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(945, 697);
            this.Name = "ReserveringForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservering invullen";
            this.Load += new System.EventHandler(this.ReserveringForm_Load);
            this.GroupBoxPlaatsen.ResumeLayout(false);
            this.GroupBoxPlaatsen.PerformLayout();
            this.GroupBoxBetalendeKlant.ResumeLayout(false);
            this.GroupBoxBetalendeKlant.PerformLayout();
            this.GroupBoxAantal.ResumeLayout(false);
            this.GroupBoxAantal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAantal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel campingPanel;
        private System.Windows.Forms.GroupBox GroupBoxPlaatsen;
        private System.Windows.Forms.Button btnVerwijderPlek;
        private System.Windows.Forms.GroupBox GroupBoxBetalendeKlant;
        private System.Windows.Forms.TextBox tbNaam;
        private System.Windows.Forms.Label lblTelefoon;
        private System.Windows.Forms.Label lblPostcode;
        private System.Windows.Forms.Label lblWoonplaats;
        private System.Windows.Forms.Label lblStraat;
        private System.Windows.Forms.Label lblRekening;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.Label lblSofi;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbSofinummer;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbTelefoon;
        private System.Windows.Forms.TextBox tbPostcode;
        private System.Windows.Forms.TextBox tbWoonplaats;
        private System.Windows.Forms.TextBox tbStraat;
        private System.Windows.Forms.TextBox tbRekening;
        private System.Windows.Forms.Button btnBevestig;
        private System.Windows.Forms.GroupBox GroupBoxAantal;
        private System.Windows.Forms.Label lblAantal;
        private System.Windows.Forms.NumericUpDown nudAantal;
        private System.Windows.Forms.Label lblReserveringsNummer;
        private System.Windows.Forms.TextBox tbReserveringsNummer;
        private System.Windows.Forms.Label lblTotaalPrijs;
        private System.Windows.Forms.ListView listViewPlaatsen;
        private System.Windows.Forms.ColumnHeader Plaatsnummer;
        private System.Windows.Forms.ColumnHeader Prijs;
        private System.Windows.Forms.Label lblPrijs;
    }
}

