namespace OpdrachtDierenasiel1
{
    /// <summary>
    /// Formulier om dierenasiel te kunnen testen
    /// </summary>
    partial class FormDierenasiel
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
            this.rdBtnHond = new System.Windows.Forms.RadioButton();
            this.rdBtnKat = new System.Windows.Forms.RadioButton();
            this.btnMaakDier = new System.Windows.Forms.Button();
            this.btnGeefInfo = new System.Windows.Forms.Button();
            this.lbGereserveerd = new System.Windows.Forms.ListBox();
            this.lbBeschikbaar = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbChipnummer = new System.Windows.Forms.TextBox();
            this.tbGeboortedag = new System.Windows.Forms.TextBox();
            this.tbRoepnaam = new System.Windows.Forms.TextBox();
            this.tbDag = new System.Windows.Forms.TextBox();
            this.tbMaand = new System.Windows.Forms.TextBox();
            this.tbJaar = new System.Windows.Forms.TextBox();
            this.tbExtraInfo = new System.Windows.Forms.TextBox();
            this.lDag = new System.Windows.Forms.Label();
            this.lMaand = new System.Windows.Forms.Label();
            this.lJaar = new System.Windows.Forms.Label();
            this.lExtraInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGereserveerd = new System.Windows.Forms.CheckBox();
            this.bReserveer = new System.Windows.Forms.Button();
            this.bVerwijder = new System.Windows.Forms.Button();
            this.bttextbestand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdBtnHond
            // 
            this.rdBtnHond.AutoSize = true;
            this.rdBtnHond.Checked = true;
            this.rdBtnHond.Location = new System.Drawing.Point(251, 12);
            this.rdBtnHond.Name = "rdBtnHond";
            this.rdBtnHond.Size = new System.Drawing.Size(57, 17);
            this.rdBtnHond.TabIndex = 0;
            this.rdBtnHond.TabStop = true;
            this.rdBtnHond.Text = "HOND";
            this.rdBtnHond.UseVisualStyleBackColor = true;
            this.rdBtnHond.CheckedChanged += new System.EventHandler(this.rdBtnHond_CheckedChanged);
            // 
            // rdBtnKat
            // 
            this.rdBtnKat.AutoSize = true;
            this.rdBtnKat.Location = new System.Drawing.Point(365, 12);
            this.rdBtnKat.Name = "rdBtnKat";
            this.rdBtnKat.Size = new System.Drawing.Size(46, 17);
            this.rdBtnKat.TabIndex = 1;
            this.rdBtnKat.Text = "KAT";
            this.rdBtnKat.UseVisualStyleBackColor = true;
            // 
            // btnMaakDier
            // 
            this.btnMaakDier.Location = new System.Drawing.Point(19, 12);
            this.btnMaakDier.Name = "btnMaakDier";
            this.btnMaakDier.Size = new System.Drawing.Size(85, 22);
            this.btnMaakDier.TabIndex = 2;
            this.btnMaakDier.Text = "Maak dier";
            this.btnMaakDier.UseVisualStyleBackColor = true;
            this.btnMaakDier.Click += new System.EventHandler(this.btnMaakDier_Click);
            // 
            // btnGeefInfo
            // 
            this.btnGeefInfo.Location = new System.Drawing.Point(482, 9);
            this.btnGeefInfo.Name = "btnGeefInfo";
            this.btnGeefInfo.Size = new System.Drawing.Size(75, 23);
            this.btnGeefInfo.TabIndex = 3;
            this.btnGeefInfo.Text = "Geef info";
            this.btnGeefInfo.UseVisualStyleBackColor = true;
            this.btnGeefInfo.Click += new System.EventHandler(this.btnGeefInfo_Click);
            // 
            // lbGereserveerd
            // 
            this.lbGereserveerd.FormattingEnabled = true;
            this.lbGereserveerd.Location = new System.Drawing.Point(254, 64);
            this.lbGereserveerd.Name = "lbGereserveerd";
            this.lbGereserveerd.Size = new System.Drawing.Size(250, 238);
            this.lbGereserveerd.TabIndex = 4;
            this.lbGereserveerd.SelectedIndexChanged += new System.EventHandler(this.lbGereserveerd_SelectedIndexChanged);
            // 
            // lbBeschikbaar
            // 
            this.lbBeschikbaar.FormattingEnabled = true;
            this.lbBeschikbaar.Location = new System.Drawing.Point(531, 67);
            this.lbBeschikbaar.Name = "lbBeschikbaar";
            this.lbBeschikbaar.Size = new System.Drawing.Size(250, 238);
            this.lbBeschikbaar.TabIndex = 5;
            this.lbBeschikbaar.SelectedIndexChanged += new System.EventHandler(this.lbNietGereserveerd_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gereserveerd:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Niet gereserveerd:";
            // 
            // tbChipnummer
            // 
            this.tbChipnummer.Location = new System.Drawing.Point(104, 67);
            this.tbChipnummer.Name = "tbChipnummer";
            this.tbChipnummer.Size = new System.Drawing.Size(100, 20);
            this.tbChipnummer.TabIndex = 8;
            // 
            // tbGeboortedag
            // 
            this.tbGeboortedag.Location = new System.Drawing.Point(104, 94);
            this.tbGeboortedag.Name = "tbGeboortedag";
            this.tbGeboortedag.Size = new System.Drawing.Size(100, 20);
            this.tbGeboortedag.TabIndex = 9;
            // 
            // tbRoepnaam
            // 
            this.tbRoepnaam.Location = new System.Drawing.Point(104, 121);
            this.tbRoepnaam.Name = "tbRoepnaam";
            this.tbRoepnaam.Size = new System.Drawing.Size(100, 20);
            this.tbRoepnaam.TabIndex = 10;
            // 
            // tbDag
            // 
            this.tbDag.Location = new System.Drawing.Point(112, 189);
            this.tbDag.Name = "tbDag";
            this.tbDag.Size = new System.Drawing.Size(100, 20);
            this.tbDag.TabIndex = 11;
            // 
            // tbMaand
            // 
            this.tbMaand.Location = new System.Drawing.Point(112, 216);
            this.tbMaand.Name = "tbMaand";
            this.tbMaand.Size = new System.Drawing.Size(100, 20);
            this.tbMaand.TabIndex = 12;
            // 
            // tbJaar
            // 
            this.tbJaar.Location = new System.Drawing.Point(112, 243);
            this.tbJaar.Name = "tbJaar";
            this.tbJaar.Size = new System.Drawing.Size(100, 20);
            this.tbJaar.TabIndex = 13;
            // 
            // tbExtraInfo
            // 
            this.tbExtraInfo.Location = new System.Drawing.Point(102, 186);
            this.tbExtraInfo.Multiline = true;
            this.tbExtraInfo.Name = "tbExtraInfo";
            this.tbExtraInfo.Size = new System.Drawing.Size(143, 134);
            this.tbExtraInfo.TabIndex = 14;
            this.tbExtraInfo.Visible = false;
            // 
            // lDag
            // 
            this.lDag.AutoSize = true;
            this.lDag.Location = new System.Drawing.Point(24, 192);
            this.lDag.Name = "lDag";
            this.lDag.Size = new System.Drawing.Size(58, 13);
            this.lDag.TabIndex = 15;
            this.lDag.Text = "Uitlaatdag:";
            // 
            // lMaand
            // 
            this.lMaand.AutoSize = true;
            this.lMaand.Location = new System.Drawing.Point(24, 219);
            this.lMaand.Name = "lMaand";
            this.lMaand.Size = new System.Drawing.Size(72, 13);
            this.lMaand.TabIndex = 16;
            this.lMaand.Text = "Uitlaatmaand:";
            // 
            // lJaar
            // 
            this.lJaar.AutoSize = true;
            this.lJaar.Location = new System.Drawing.Point(24, 246);
            this.lJaar.Name = "lJaar";
            this.lJaar.Size = new System.Drawing.Size(57, 13);
            this.lJaar.TabIndex = 17;
            this.lJaar.Text = "Uitlaatjaar:";
            // 
            // lExtraInfo
            // 
            this.lExtraInfo.AutoSize = true;
            this.lExtraInfo.Location = new System.Drawing.Point(99, 170);
            this.lExtraInfo.Name = "lExtraInfo";
            this.lExtraInfo.Size = new System.Drawing.Size(82, 13);
            this.lExtraInfo.TabIndex = 18;
            this.lExtraInfo.Text = "Extra informatie:";
            this.lExtraInfo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Chipnummer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Geboortejaar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Roepnaam:";
            // 
            // cbGereserveerd
            // 
            this.cbGereserveerd.AutoSize = true;
            this.cbGereserveerd.Location = new System.Drawing.Point(104, 150);
            this.cbGereserveerd.Name = "cbGereserveerd";
            this.cbGereserveerd.Size = new System.Drawing.Size(90, 17);
            this.cbGereserveerd.TabIndex = 22;
            this.cbGereserveerd.Text = "Gereserveerd";
            this.cbGereserveerd.UseVisualStyleBackColor = true;
            // 
            // bReserveer
            // 
            this.bReserveer.Location = new System.Drawing.Point(563, 9);
            this.bReserveer.Name = "bReserveer";
            this.bReserveer.Size = new System.Drawing.Size(141, 23);
            this.bReserveer.TabIndex = 23;
            this.bReserveer.Text = "Reserveer / Geef vrij";
            this.bReserveer.UseVisualStyleBackColor = true;
            this.bReserveer.Click += new System.EventHandler(this.bReserveer_Click);
            // 
            // bVerwijder
            // 
            this.bVerwijder.Location = new System.Drawing.Point(141, 12);
            this.bVerwijder.Name = "bVerwijder";
            this.bVerwijder.Size = new System.Drawing.Size(94, 23);
            this.bVerwijder.TabIndex = 24;
            this.bVerwijder.Text = "Verwijder dier ";
            this.bVerwijder.UseVisualStyleBackColor = true;
            this.bVerwijder.Click += new System.EventHandler(this.bVerwijder_Click);
            // 
            // bttextbestand
            // 
            this.bttextbestand.Location = new System.Drawing.Point(703, 38);
            this.bttextbestand.Name = "bttextbestand";
            this.bttextbestand.Size = new System.Drawing.Size(78, 23);
            this.bttextbestand.TabIndex = 25;
            this.bttextbestand.Text = "Sla Op";
            this.bttextbestand.UseVisualStyleBackColor = true;
            this.bttextbestand.Click += new System.EventHandler(this.bttextbestand_Click);
            // 
            // FormDierenasiel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 324);
            this.Controls.Add(this.bttextbestand);
            this.Controls.Add(this.bVerwijder);
            this.Controls.Add(this.bReserveer);
            this.Controls.Add(this.cbGereserveerd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lExtraInfo);
            this.Controls.Add(this.lJaar);
            this.Controls.Add(this.lMaand);
            this.Controls.Add(this.lDag);
            this.Controls.Add(this.tbExtraInfo);
            this.Controls.Add(this.tbJaar);
            this.Controls.Add(this.tbMaand);
            this.Controls.Add(this.tbDag);
            this.Controls.Add(this.tbRoepnaam);
            this.Controls.Add(this.tbGeboortedag);
            this.Controls.Add(this.tbChipnummer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbBeschikbaar);
            this.Controls.Add(this.lbGereserveerd);
            this.Controls.Add(this.btnGeefInfo);
            this.Controls.Add(this.btnMaakDier);
            this.Controls.Add(this.rdBtnKat);
            this.Controls.Add(this.rdBtnHond);
            this.Name = "FormDierenasiel";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormDierenasiel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdBtnHond;
        private System.Windows.Forms.RadioButton rdBtnKat;
        private System.Windows.Forms.Button btnMaakDier;
        private System.Windows.Forms.Button btnGeefInfo;
        private System.Windows.Forms.ListBox lbGereserveerd;
        private System.Windows.Forms.ListBox lbBeschikbaar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbChipnummer;
        private System.Windows.Forms.TextBox tbGeboortedag;
        private System.Windows.Forms.TextBox tbRoepnaam;
        private System.Windows.Forms.TextBox tbDag;
        private System.Windows.Forms.TextBox tbMaand;
        private System.Windows.Forms.TextBox tbJaar;
        private System.Windows.Forms.TextBox tbExtraInfo;
        private System.Windows.Forms.Label lDag;
        private System.Windows.Forms.Label lMaand;
        private System.Windows.Forms.Label lJaar;
        private System.Windows.Forms.Label lExtraInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbGereserveerd;
        private System.Windows.Forms.Button bReserveer;
        private System.Windows.Forms.Button bVerwijder;
        private System.Windows.Forms.Button bttextbestand;
    }
}

