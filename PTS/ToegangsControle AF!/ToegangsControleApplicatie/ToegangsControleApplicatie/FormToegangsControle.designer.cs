namespace ToegangsControleApplicatie
{
    partial class FormToegangsControle
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
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbNaam = new System.Windows.Forms.Label();
            this.lbPlaats = new System.Windows.Forms.Label();
            this.lbRFID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBetaald = new System.Windows.Forms.ComboBox();
            this.lbBedrag = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Naam:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Gereserveerde plaats:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Betaling voltooid:";
            // 
            // lbNaam
            // 
            this.lbNaam.AutoSize = true;
            this.lbNaam.Location = new System.Drawing.Point(155, 52);
            this.lbNaam.Name = "lbNaam";
            this.lbNaam.Size = new System.Drawing.Size(0, 13);
            this.lbNaam.TabIndex = 8;
            // 
            // lbPlaats
            // 
            this.lbPlaats.AutoSize = true;
            this.lbPlaats.Location = new System.Drawing.Point(155, 79);
            this.lbPlaats.Name = "lbPlaats";
            this.lbPlaats.Size = new System.Drawing.Size(0, 13);
            this.lbPlaats.TabIndex = 9;
            // 
            // lbRFID
            // 
            this.lbRFID.AutoSize = true;
            this.lbRFID.Location = new System.Drawing.Point(155, 28);
            this.lbRFID.Name = "lbRFID";
            this.lbRFID.Size = new System.Drawing.Size(0, 13);
            this.lbRFID.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "RFID nummer:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBetaald);
            this.groupBox1.Controls.Add(this.lbBedrag);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbPlaats);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbNaam);
            this.groupBox1.Controls.Add(this.lbRFID);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 168);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uitgelezen gegevens";
            // 
            // cbBetaald
            // 
            this.cbBetaald.FormattingEnabled = true;
            this.cbBetaald.Items.AddRange(new object[] {
            "Voltooid",
            "Onvoltooid"});
            this.cbBetaald.Location = new System.Drawing.Point(152, 104);
            this.cbBetaald.Name = "cbBetaald";
            this.cbBetaald.Size = new System.Drawing.Size(107, 21);
            this.cbBetaald.TabIndex = 13;
            this.cbBetaald.Text = "Onvoltooid";
            this.cbBetaald.SelectedValueChanged += new System.EventHandler(this.cbBetaald_SelectedValueChanged);
            // 
            // lbBedrag
            // 
            this.lbBedrag.AutoSize = true;
            this.lbBedrag.Location = new System.Drawing.Point(155, 137);
            this.lbBedrag.Name = "lbBedrag";
            this.lbBedrag.Size = new System.Drawing.Size(0, 13);
            this.lbBedrag.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Bedrag:";
            // 
            // FormToegangsControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 191);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormToegangsControle";
            this.Text = "Toegangs Controle Systeem";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbNaam;
        private System.Windows.Forms.Label lbPlaats;
        private System.Windows.Forms.Label lbRFID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbBetaald;
        private System.Windows.Forms.Label lbBedrag;
        private System.Windows.Forms.Label label2;
    }
}

