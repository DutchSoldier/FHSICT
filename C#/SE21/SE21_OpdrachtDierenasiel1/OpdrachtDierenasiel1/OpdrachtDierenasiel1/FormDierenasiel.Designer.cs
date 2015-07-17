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
            this.lBinfo = new System.Windows.Forms.ListBox();
            this.tbChipnummer = new System.Windows.Forms.TextBox();
            this.tbRoepnaam = new System.Windows.Forms.TextBox();
            this.tbGeboortejaar = new System.Windows.Forms.TextBox();
            this.tbUitlaatdag = new System.Windows.Forms.TextBox();
            this.lChipnummer = new System.Windows.Forms.Label();
            this.lRoepnaam = new System.Windows.Forms.Label();
            this.lGeboortejaar = new System.Windows.Forms.Label();
            this.lUitlaatdag = new System.Windows.Forms.Label();
            this.cbGereserveerd = new System.Windows.Forms.CheckBox();
            this.lUitlaatmaand = new System.Windows.Forms.Label();
            this.lUitlaatjaar = new System.Windows.Forms.Label();
            this.tbUitlaatmaand = new System.Windows.Forms.TextBox();
            this.tbUitlaatjaar = new System.Windows.Forms.TextBox();
            this.lExtrainfo = new System.Windows.Forms.Label();
            this.tbExtrainfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rdBtnHond
            // 
            this.rdBtnHond.AutoSize = true;
            this.rdBtnHond.Checked = true;
            this.rdBtnHond.Location = new System.Drawing.Point(250, 46);
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
            this.rdBtnKat.Location = new System.Drawing.Point(250, 79);
            this.rdBtnKat.Name = "rdBtnKat";
            this.rdBtnKat.Size = new System.Drawing.Size(46, 17);
            this.rdBtnKat.TabIndex = 1;
            this.rdBtnKat.Text = "KAT";
            this.rdBtnKat.UseVisualStyleBackColor = true;
            this.rdBtnKat.CheckedChanged += new System.EventHandler(this.rdBtnKat_CheckedChanged);
            // 
            // btnMaakDier
            // 
            this.btnMaakDier.Location = new System.Drawing.Point(250, 138);
            this.btnMaakDier.Name = "btnMaakDier";
            this.btnMaakDier.Size = new System.Drawing.Size(76, 22);
            this.btnMaakDier.TabIndex = 2;
            this.btnMaakDier.Text = "Maak dier";
            this.btnMaakDier.UseVisualStyleBackColor = true;
            this.btnMaakDier.Click += new System.EventHandler(this.btnMaakDier_Click);
            // 
            // btnGeefInfo
            // 
            this.btnGeefInfo.Location = new System.Drawing.Point(250, 187);
            this.btnGeefInfo.Name = "btnGeefInfo";
            this.btnGeefInfo.Size = new System.Drawing.Size(75, 23);
            this.btnGeefInfo.TabIndex = 3;
            this.btnGeefInfo.Text = "Geef info";
            this.btnGeefInfo.UseVisualStyleBackColor = true;
            this.btnGeefInfo.Click += new System.EventHandler(this.btnGeefInfo_Click);
            // 
            // lBinfo
            // 
            this.lBinfo.FormattingEnabled = true;
            this.lBinfo.Location = new System.Drawing.Point(515, 15);
            this.lBinfo.Name = "lBinfo";
            this.lBinfo.Size = new System.Drawing.Size(206, 251);
            this.lBinfo.TabIndex = 4;
            // 
            // tbChipnummer
            // 
            this.tbChipnummer.Location = new System.Drawing.Point(92, 50);
            this.tbChipnummer.Name = "tbChipnummer";
            this.tbChipnummer.Size = new System.Drawing.Size(100, 20);
            this.tbChipnummer.TabIndex = 5;
            // 
            // tbRoepnaam
            // 
            this.tbRoepnaam.Location = new System.Drawing.Point(92, 76);
            this.tbRoepnaam.Name = "tbRoepnaam";
            this.tbRoepnaam.Size = new System.Drawing.Size(100, 20);
            this.tbRoepnaam.TabIndex = 6;
            // 
            // tbGeboortejaar
            // 
            this.tbGeboortejaar.Location = new System.Drawing.Point(92, 102);
            this.tbGeboortejaar.Name = "tbGeboortejaar";
            this.tbGeboortejaar.Size = new System.Drawing.Size(100, 20);
            this.tbGeboortejaar.TabIndex = 7;
            // 
            // tbUitlaatdag
            // 
            this.tbUitlaatdag.Location = new System.Drawing.Point(92, 128);
            this.tbUitlaatdag.Name = "tbUitlaatdag";
            this.tbUitlaatdag.Size = new System.Drawing.Size(100, 20);
            this.tbUitlaatdag.TabIndex = 8;
            // 
            // lChipnummer
            // 
            this.lChipnummer.AutoSize = true;
            this.lChipnummer.Location = new System.Drawing.Point(21, 50);
            this.lChipnummer.Name = "lChipnummer";
            this.lChipnummer.Size = new System.Drawing.Size(65, 13);
            this.lChipnummer.TabIndex = 9;
            this.lChipnummer.Text = "Chipnummer";
            // 
            // lRoepnaam
            // 
            this.lRoepnaam.AutoSize = true;
            this.lRoepnaam.Location = new System.Drawing.Point(21, 76);
            this.lRoepnaam.Name = "lRoepnaam";
            this.lRoepnaam.Size = new System.Drawing.Size(59, 13);
            this.lRoepnaam.TabIndex = 10;
            this.lRoepnaam.Text = "Roepnaam";
            // 
            // lGeboortejaar
            // 
            this.lGeboortejaar.AutoSize = true;
            this.lGeboortejaar.Location = new System.Drawing.Point(21, 102);
            this.lGeboortejaar.Name = "lGeboortejaar";
            this.lGeboortejaar.Size = new System.Drawing.Size(68, 13);
            this.lGeboortejaar.TabIndex = 11;
            this.lGeboortejaar.Text = "Geboortejaar";
            // 
            // lUitlaatdag
            // 
            this.lUitlaatdag.AutoSize = true;
            this.lUitlaatdag.Location = new System.Drawing.Point(21, 128);
            this.lUitlaatdag.Name = "lUitlaatdag";
            this.lUitlaatdag.Size = new System.Drawing.Size(55, 13);
            this.lUitlaatdag.TabIndex = 12;
            this.lUitlaatdag.Text = "Uitlaatdag";
            // 
            // cbGereserveerd
            // 
            this.cbGereserveerd.AutoSize = true;
            this.cbGereserveerd.Location = new System.Drawing.Point(250, 105);
            this.cbGereserveerd.Name = "cbGereserveerd";
            this.cbGereserveerd.Size = new System.Drawing.Size(90, 17);
            this.cbGereserveerd.TabIndex = 14;
            this.cbGereserveerd.Text = "Gereserveerd";
            this.cbGereserveerd.UseVisualStyleBackColor = true;

            // 
            // lUitlaatmaand
            // 
            this.lUitlaatmaand.AutoSize = true;
            this.lUitlaatmaand.Location = new System.Drawing.Point(21, 159);
            this.lUitlaatmaand.Name = "lUitlaatmaand";
            this.lUitlaatmaand.Size = new System.Drawing.Size(69, 13);
            this.lUitlaatmaand.TabIndex = 15;
            this.lUitlaatmaand.Text = "Uitlaatmaand";
            // 
            // lUitlaatjaar
            // 
            this.lUitlaatjaar.AutoSize = true;
            this.lUitlaatjaar.Location = new System.Drawing.Point(21, 190);
            this.lUitlaatjaar.Name = "lUitlaatjaar";
            this.lUitlaatjaar.Size = new System.Drawing.Size(57, 13);
            this.lUitlaatjaar.TabIndex = 16;
            this.lUitlaatjaar.Text = "UitlaatJaar";
            // 
            // tbUitlaatmaand
            // 
            this.tbUitlaatmaand.Location = new System.Drawing.Point(92, 159);
            this.tbUitlaatmaand.Name = "tbUitlaatmaand";
            this.tbUitlaatmaand.Size = new System.Drawing.Size(100, 20);
            this.tbUitlaatmaand.TabIndex = 17;
            // 
            // tbUitlaatjaar
            // 
            this.tbUitlaatjaar.Location = new System.Drawing.Point(92, 190);
            this.tbUitlaatjaar.Name = "tbUitlaatjaar";
            this.tbUitlaatjaar.Size = new System.Drawing.Size(100, 20);
            this.tbUitlaatjaar.TabIndex = 18;
            // 
            // lExtrainfo
            // 
            this.lExtrainfo.AutoSize = true;
            this.lExtrainfo.Location = new System.Drawing.Point(21, 128);
            this.lExtrainfo.Name = "lExtrainfo";
            this.lExtrainfo.Size = new System.Drawing.Size(52, 13);
            this.lExtrainfo.TabIndex = 19;
            this.lExtrainfo.Text = "Extra Info";
            this.lExtrainfo.Visible = false;
            // 
            // tbExtrainfo
            // 
            this.tbExtrainfo.Location = new System.Drawing.Point(92, 125);
            this.tbExtrainfo.Name = "tbExtrainfo";
            this.tbExtrainfo.Size = new System.Drawing.Size(100, 20);
            this.tbExtrainfo.TabIndex = 20;
            this.tbExtrainfo.Visible = false;
            // 
            // FormDierenasiel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 283);
            this.Controls.Add(this.tbExtrainfo);
            this.Controls.Add(this.lExtrainfo);
            this.Controls.Add(this.tbUitlaatjaar);
            this.Controls.Add(this.tbUitlaatmaand);
            this.Controls.Add(this.lUitlaatjaar);
            this.Controls.Add(this.lUitlaatmaand);
            this.Controls.Add(this.cbGereserveerd);
            this.Controls.Add(this.lUitlaatdag);
            this.Controls.Add(this.lGeboortejaar);
            this.Controls.Add(this.lRoepnaam);
            this.Controls.Add(this.lChipnummer);
            this.Controls.Add(this.tbUitlaatdag);
            this.Controls.Add(this.tbGeboortejaar);
            this.Controls.Add(this.tbRoepnaam);
            this.Controls.Add(this.tbChipnummer);
            this.Controls.Add(this.lBinfo);
            this.Controls.Add(this.btnGeefInfo);
            this.Controls.Add(this.btnMaakDier);
            this.Controls.Add(this.rdBtnKat);
            this.Controls.Add(this.rdBtnHond);
            this.Name = "FormDierenasiel";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdBtnHond;
        private System.Windows.Forms.RadioButton rdBtnKat;
        private System.Windows.Forms.Button btnMaakDier;
        private System.Windows.Forms.Button btnGeefInfo;
        private System.Windows.Forms.ListBox lBinfo;
        private System.Windows.Forms.TextBox tbChipnummer;
        private System.Windows.Forms.TextBox tbRoepnaam;
        private System.Windows.Forms.TextBox tbGeboortejaar;
        private System.Windows.Forms.TextBox tbUitlaatdag;
        private System.Windows.Forms.Label lChipnummer;
        private System.Windows.Forms.Label lRoepnaam;
        private System.Windows.Forms.Label lGeboortejaar;
        private System.Windows.Forms.Label lUitlaatdag;
        private System.Windows.Forms.CheckBox cbGereserveerd;
        private System.Windows.Forms.Label lUitlaatmaand;
        private System.Windows.Forms.Label lUitlaatjaar;
        private System.Windows.Forms.TextBox tbUitlaatmaand;
        private System.Windows.Forms.TextBox tbUitlaatjaar;
        private System.Windows.Forms.Label lExtrainfo;
        private System.Windows.Forms.TextBox tbExtrainfo;
    }
}

