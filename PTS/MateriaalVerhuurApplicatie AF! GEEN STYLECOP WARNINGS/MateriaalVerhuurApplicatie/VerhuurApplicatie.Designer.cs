﻿//Verhuurapplicatie

namespace MateriaalVerhuurApplicatie
{
    public partial class VerhuurApplicatie
    {
        private System.Windows.Forms.Label labelReserveringsNr;
        private System.Windows.Forms.TextBox textBoxReserveringsNr;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label labelBeginDatum;
        private System.Windows.Forms.Label labelEindDatum;
        private System.Windows.Forms.Button buttonReserveren;
        private System.Windows.Forms.ListBox listboxBeschikbaarMateriaal;
        private System.Windows.Forms.Label labelBeschikbaarMateriaal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxVerhuurdMateriaal;
        private System.Windows.Forms.Label labelProductInfo;
        private System.Windows.Forms.TabControl tabControlVerhuur;
        private System.Windows.Forms.TabPage verhuren;
        private System.Windows.Forms.TabPage verhuurd;
        private System.Windows.Forms.TabPage materiaalInfo;
        private System.Windows.Forms.Label labelMaterialen;
        private System.Windows.Forms.ListBox listBoxMaterialen;
        private System.Windows.Forms.ListBox listboxDoorKlantGehuurd;
        private System.Windows.Forms.Label labelDoorKlantGehuurd;
        private System.Windows.Forms.ListBox listBoxVerhuurdAan;
        private System.Windows.Forms.Label labelVerhuurdAan;
        private System.Windows.Forms.Button buttonannuleren;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btcancel;

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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.labelReserveringsNr = new System.Windows.Forms.Label();
            this.textBoxReserveringsNr = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.labelBeginDatum = new System.Windows.Forms.Label();
            this.labelEindDatum = new System.Windows.Forms.Label();
            this.buttonReserveren = new System.Windows.Forms.Button();
            this.listboxBeschikbaarMateriaal = new System.Windows.Forms.ListBox();
            this.labelBeschikbaarMateriaal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxVerhuurdMateriaal = new System.Windows.Forms.ListBox();
            this.labelProductInfo = new System.Windows.Forms.Label();
            this.tabControlVerhuur = new System.Windows.Forms.TabControl();
            this.verhuren = new System.Windows.Forms.TabPage();
            this.btcancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonannuleren = new System.Windows.Forms.Button();
            this.listboxDoorKlantGehuurd = new System.Windows.Forms.ListBox();
            this.labelDoorKlantGehuurd = new System.Windows.Forms.Label();
            this.verhuurd = new System.Windows.Forms.TabPage();
            this.listBoxVerhuurdAan = new System.Windows.Forms.ListBox();
            this.labelVerhuurdAan = new System.Windows.Forms.Label();
            this.materiaalInfo = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelMaterialen = new System.Windows.Forms.Label();
            this.listBoxMaterialen = new System.Windows.Forms.ListBox();
            this.tabControlVerhuur.SuspendLayout();
            this.verhuren.SuspendLayout();
            this.verhuurd.SuspendLayout();
            this.materiaalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelReserveringsNr
            // 
            this.labelReserveringsNr.AutoSize = true;
            this.labelReserveringsNr.Location = new System.Drawing.Point(6, 18);
            this.labelReserveringsNr.Name = "labelReserveringsNr";
            this.labelReserveringsNr.Size = new System.Drawing.Size(84, 13);
            this.labelReserveringsNr.TabIndex = 0;
            this.labelReserveringsNr.Text = "Reserveringsnr.:";
            // 
            // textBoxReserveringsNr
            // 
            this.textBoxReserveringsNr.Location = new System.Drawing.Point(96, 15);
            this.textBoxReserveringsNr.Name = "textBoxReserveringsNr";
            this.textBoxReserveringsNr.Size = new System.Drawing.Size(106, 20);
            this.textBoxReserveringsNr.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(173, 108);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.Tag = "Dit is de begindatum van de reservering; waneer het item uitgeleend wordt.";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(173, 147);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 6;
            this.dateTimePicker2.Tag = "Dit is de uitdatum van de reservering, dit is de datum waarop het artikel terugge" +
    "bracht moet worden.";
            // 
            // labelBeginDatum
            // 
            this.labelBeginDatum.AutoSize = true;
            this.labelBeginDatum.Location = new System.Drawing.Point(170, 92);
            this.labelBeginDatum.Name = "labelBeginDatum";
            this.labelBeginDatum.Size = new System.Drawing.Size(66, 13);
            this.labelBeginDatum.TabIndex = 7;
            this.labelBeginDatum.Text = "Begindatum:";
            // 
            // labelEindDatum
            // 
            this.labelEindDatum.AutoSize = true;
            this.labelEindDatum.Location = new System.Drawing.Point(170, 131);
            this.labelEindDatum.Name = "labelEindDatum";
            this.labelEindDatum.Size = new System.Drawing.Size(60, 13);
            this.labelEindDatum.TabIndex = 8;
            this.labelEindDatum.Text = "Einddatum:";
            // 
            // buttonReserveren
            // 
            this.buttonReserveren.Enabled = false;
            this.buttonReserveren.Location = new System.Drawing.Point(277, 66);
            this.buttonReserveren.Name = "buttonReserveren";
            this.buttonReserveren.Size = new System.Drawing.Size(98, 23);
            this.buttonReserveren.TabIndex = 9;
            this.buttonReserveren.Tag = "Reserveerd geselecteerde item van de lijst hier rechts.";
            this.buttonReserveren.Text = "Reserveren <<";
            this.buttonReserveren.UseVisualStyleBackColor = true;
            this.buttonReserveren.Click += new System.EventHandler(this.ButtonReserveren_Click);
            // 
            // listboxBeschikbaarMateriaal
            // 
            this.listboxBeschikbaarMateriaal.FormattingEnabled = true;
            this.listboxBeschikbaarMateriaal.Location = new System.Drawing.Point(384, 66);
            this.listboxBeschikbaarMateriaal.Name = "listboxBeschikbaarMateriaal";
            this.listboxBeschikbaarMateriaal.Size = new System.Drawing.Size(153, 225);
            this.listboxBeschikbaarMateriaal.TabIndex = 10;
            this.listboxBeschikbaarMateriaal.Tag = "Hierin staat het beschikbare materiaal dat nog gehuurd kan worden.";
            // 
            // labelBeschikbaarMateriaal
            // 
            this.labelBeschikbaarMateriaal.AutoSize = true;
            this.labelBeschikbaarMateriaal.Location = new System.Drawing.Point(381, 50);
            this.labelBeschikbaarMateriaal.Name = "labelBeschikbaarMateriaal";
            this.labelBeschikbaarMateriaal.Size = new System.Drawing.Size(114, 13);
            this.labelBeschikbaarMateriaal.TabIndex = 11;
            this.labelBeschikbaarMateriaal.Text = "Beschikbaar materiaal:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Verhuurd materiaal:";
            // 
            // listBoxVerhuurdMateriaal
            // 
            this.listBoxVerhuurdMateriaal.FormattingEnabled = true;
            this.listBoxVerhuurdMateriaal.Location = new System.Drawing.Point(5, 33);
            this.listBoxVerhuurdMateriaal.Name = "listBoxVerhuurdMateriaal";
            this.listBoxVerhuurdMateriaal.Size = new System.Drawing.Size(250, 264);
            this.listBoxVerhuurdMateriaal.TabIndex = 13;
            this.listBoxVerhuurdMateriaal.Tag = "Hierin staat al het materiaal dat momenteel verhuurd wordt.";
            this.listBoxVerhuurdMateriaal.SelectedIndexChanged += new System.EventHandler(this.ListBoxVerhuurdMateriaal_SelectedIndexChanged);
            // 
            // labelProductInfo
            // 
            this.labelProductInfo.AutoSize = true;
            this.labelProductInfo.Location = new System.Drawing.Point(255, 16);
            this.labelProductInfo.Name = "labelProductInfo";
            this.labelProductInfo.Size = new System.Drawing.Size(67, 13);
            this.labelProductInfo.TabIndex = 15;
            this.labelProductInfo.Text = "Product info:";
            // 
            // tabControlVerhuur
            // 
            this.tabControlVerhuur.Controls.Add(this.verhuren);
            this.tabControlVerhuur.Controls.Add(this.verhuurd);
            this.tabControlVerhuur.Controls.Add(this.materiaalInfo);
            this.tabControlVerhuur.Location = new System.Drawing.Point(12, 12);
            this.tabControlVerhuur.Name = "tabControlVerhuur";
            this.tabControlVerhuur.SelectedIndex = 0;
            this.tabControlVerhuur.Size = new System.Drawing.Size(551, 336);
            this.tabControlVerhuur.TabIndex = 16;
            // 
            // verhuren
            // 
            this.verhuren.Controls.Add(this.btcancel);
            this.verhuren.Controls.Add(this.button1);
            this.verhuren.Controls.Add(this.buttonannuleren);
            this.verhuren.Controls.Add(this.labelReserveringsNr);
            this.verhuren.Controls.Add(this.labelBeschikbaarMateriaal);
            this.verhuren.Controls.Add(this.textBoxReserveringsNr);
            this.verhuren.Controls.Add(this.listboxBeschikbaarMateriaal);
            this.verhuren.Controls.Add(this.buttonReserveren);
            this.verhuren.Controls.Add(this.dateTimePicker1);
            this.verhuren.Controls.Add(this.labelEindDatum);
            this.verhuren.Controls.Add(this.labelBeginDatum);
            this.verhuren.Controls.Add(this.dateTimePicker2);
            this.verhuren.Controls.Add(this.listboxDoorKlantGehuurd);
            this.verhuren.Controls.Add(this.labelDoorKlantGehuurd);
            this.verhuren.Location = new System.Drawing.Point(4, 22);
            this.verhuren.Name = "verhuren";
            this.verhuren.Padding = new System.Windows.Forms.Padding(3);
            this.verhuren.Size = new System.Drawing.Size(543, 310);
            this.verhuren.TabIndex = 0;
            this.verhuren.Text = "Verhuren";
            this.verhuren.UseVisualStyleBackColor = true;
            this.verhuren.Click += new System.EventHandler(this.Verhuren_Click);
            // 
            // btcancel
            // 
            this.btcancel.Enabled = false;
            this.btcancel.Location = new System.Drawing.Point(367, 12);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(170, 23);
            this.btcancel.TabIndex = 14;
            this.btcancel.Tag = "Annuleerd de gehele reservering.";
            this.btcancel.Text = "Cancel Reservering";
            this.btcancel.UseVisualStyleBackColor = true;
            this.btcancel.Click += new System.EventHandler(this.Btcancel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 13;
            this.button1.Tag = "Vraagt reserveringsinfo op van ingevoerd reserveringsnummer.";
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonannuleren
            // 
            this.buttonannuleren.Enabled = false;
            this.buttonannuleren.Location = new System.Drawing.Point(173, 66);
            this.buttonannuleren.Name = "buttonannuleren";
            this.buttonannuleren.Size = new System.Drawing.Size(98, 23);
            this.buttonannuleren.TabIndex = 12;
            this.buttonannuleren.Tag = "Verwijderd geselecteerd materiaal uit de lijst hierlangs van de verhuring";
            this.buttonannuleren.Text = ">>";
            this.buttonannuleren.UseVisualStyleBackColor = true;
            this.buttonannuleren.Click += new System.EventHandler(this.Buttonannuleren_Click);
            // 
            // listboxDoorKlantGehuurd
            // 
            this.listboxDoorKlantGehuurd.FormattingEnabled = true;
            this.listboxDoorKlantGehuurd.Location = new System.Drawing.Point(5, 66);
            this.listboxDoorKlantGehuurd.Name = "listboxDoorKlantGehuurd";
            this.listboxDoorKlantGehuurd.Size = new System.Drawing.Size(153, 225);
            this.listboxDoorKlantGehuurd.TabIndex = 4;
            this.listboxDoorKlantGehuurd.Tag = "Hierin staat het materiaal dat momenteel gehuurd wordt door de klant met het Rese" +
    "rveringsnummer hierboven.";
            this.listboxDoorKlantGehuurd.SelectedIndexChanged += new System.EventHandler(this.ListboxDoorKlantGehuurd_SelectedIndexChanged);
            // 
            // labelDoorKlantGehuurd
            // 
            this.labelDoorKlantGehuurd.AutoSize = true;
            this.labelDoorKlantGehuurd.Location = new System.Drawing.Point(6, 50);
            this.labelDoorKlantGehuurd.Name = "labelDoorKlantGehuurd";
            this.labelDoorKlantGehuurd.Size = new System.Drawing.Size(101, 13);
            this.labelDoorKlantGehuurd.TabIndex = 5;
            this.labelDoorKlantGehuurd.Text = "Door klant gehuurd:";
            // 
            // verhuurd
            // 
            this.verhuurd.Controls.Add(this.listBoxVerhuurdAan);
            this.verhuurd.Controls.Add(this.labelVerhuurdAan);
            this.verhuurd.Controls.Add(this.label1);
            this.verhuurd.Controls.Add(this.listBoxVerhuurdMateriaal);
            this.verhuurd.Location = new System.Drawing.Point(4, 22);
            this.verhuurd.Name = "verhuurd";
            this.verhuurd.Padding = new System.Windows.Forms.Padding(3);
            this.verhuurd.Size = new System.Drawing.Size(543, 310);
            this.verhuurd.TabIndex = 1;
            this.verhuurd.Text = "Verhuurd";
            this.verhuurd.UseVisualStyleBackColor = true;
            // 
            // listBoxVerhuurdAan
            // 
            this.listBoxVerhuurdAan.FormattingEnabled = true;
            this.listBoxVerhuurdAan.Location = new System.Drawing.Point(270, 33);
            this.listBoxVerhuurdAan.Name = "listBoxVerhuurdAan";
            this.listBoxVerhuurdAan.Size = new System.Drawing.Size(267, 264);
            this.listBoxVerhuurdAan.TabIndex = 16;
            this.listBoxVerhuurdAan.Tag = "Hierin staat aan wie het materiaal dat hierlinks geselecteerd is aan wordt verhuu" +
    "rd.";
            // 
            // labelVerhuurdAan
            // 
            this.labelVerhuurdAan.AutoSize = true;
            this.labelVerhuurdAan.Location = new System.Drawing.Point(267, 17);
            this.labelVerhuurdAan.Name = "labelVerhuurdAan";
            this.labelVerhuurdAan.Size = new System.Drawing.Size(83, 13);
            this.labelVerhuurdAan.TabIndex = 17;
            this.labelVerhuurdAan.Text = "is verhuurd aan:";
            // 
            // materiaalInfo
            // 
            this.materiaalInfo.Controls.Add(this.label3);
            this.materiaalInfo.Controls.Add(this.label2);
            this.materiaalInfo.Controls.Add(this.textBox2);
            this.materiaalInfo.Controls.Add(this.textBox1);
            this.materiaalInfo.Controls.Add(this.labelMaterialen);
            this.materiaalInfo.Controls.Add(this.listBoxMaterialen);
            this.materiaalInfo.Controls.Add(this.labelProductInfo);
            this.materiaalInfo.Location = new System.Drawing.Point(4, 22);
            this.materiaalInfo.Name = "materiaalInfo";
            this.materiaalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.materiaalInfo.Size = new System.Drawing.Size(543, 310);
            this.materiaalInfo.TabIndex = 2;
            this.materiaalInfo.Text = "Materiaal info";
            this.materiaalInfo.UseVisualStyleBackColor = true;
            this.materiaalInfo.Click += new System.EventHandler(this.MateriaalInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Verhuurprijs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Aantal";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(258, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 19;
            this.textBox2.Tag = "Hierin staan";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(258, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Tag = "Hierin staat hoeveel exemplaren van het artikel er nog zijn.";
            // 
            // labelMaterialen
            // 
            this.labelMaterialen.AutoSize = true;
            this.labelMaterialen.Location = new System.Drawing.Point(6, 16);
            this.labelMaterialen.Name = "labelMaterialen";
            this.labelMaterialen.Size = new System.Drawing.Size(59, 13);
            this.labelMaterialen.TabIndex = 17;
            this.labelMaterialen.Text = "Materialen:";
            // 
            // listBoxMaterialen
            // 
            this.listBoxMaterialen.FormattingEnabled = true;
            this.listBoxMaterialen.Location = new System.Drawing.Point(6, 32);
            this.listBoxMaterialen.Name = "listBoxMaterialen";
            this.listBoxMaterialen.Size = new System.Drawing.Size(236, 264);
            this.listBoxMaterialen.TabIndex = 16;
            this.listBoxMaterialen.Tag = "Hierin staat al het materiaal dat er is.";
            this.listBoxMaterialen.SelectedIndexChanged += new System.EventHandler(this.ListBoxMaterialen_SelectedIndexChanged);
            // 
            // VerhuurApplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 360);
            this.Controls.Add(this.tabControlVerhuur);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerhuurApplicatie";
            this.Text = "Verhuur applicatie";
            this.Load += new System.EventHandler(this.VerhuurApplicatie_Load);
            this.tabControlVerhuur.ResumeLayout(false);
            this.verhuren.ResumeLayout(false);
            this.verhuren.PerformLayout();
            this.verhuurd.ResumeLayout(false);
            this.verhuurd.PerformLayout();
            this.materiaalInfo.ResumeLayout(false);
            this.materiaalInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}