namespace Diertjes
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
            this.schijten = new System.Windows.Forms.Button();
            this.schaften = new System.Windows.Forms.Button();
            this.Lopen = new System.Windows.Forms.Button();
            this.LbDieren = new System.Windows.Forms.ListBox();
            this.TbNaam = new System.Windows.Forms.TextBox();
            this.Nleeftijd = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnVoegToe = new System.Windows.Forms.Button();
            this.BtnOverleden = new System.Windows.Forms.Button();
            this.BtnDierenZien = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Nleeftijd)).BeginInit();
            this.SuspendLayout();
            // 
            // schijten
            // 
            this.schijten.Location = new System.Drawing.Point(12, 41);
            this.schijten.Name = "schijten";
            this.schijten.Size = new System.Drawing.Size(75, 23);
            this.schijten.TabIndex = 0;
            this.schijten.Text = "Schijten";
            this.schijten.UseVisualStyleBackColor = true;
            this.schijten.Click += new System.EventHandler(this.schijten_Click);
            // 
            // schaften
            // 
            this.schaften.Location = new System.Drawing.Point(12, 70);
            this.schaften.Name = "schaften";
            this.schaften.Size = new System.Drawing.Size(75, 23);
            this.schaften.TabIndex = 1;
            this.schaften.Text = "schaften";
            this.schaften.UseVisualStyleBackColor = true;
            this.schaften.Click += new System.EventHandler(this.schaften_Click);
            // 
            // Lopen
            // 
            this.Lopen.Location = new System.Drawing.Point(12, 12);
            this.Lopen.Name = "Lopen";
            this.Lopen.Size = new System.Drawing.Size(75, 23);
            this.Lopen.TabIndex = 2;
            this.Lopen.Text = "Lopen";
            this.Lopen.UseVisualStyleBackColor = true;
            this.Lopen.Click += new System.EventHandler(this.Lopen_Click);
            // 
            // LbDieren
            // 
            this.LbDieren.FormattingEnabled = true;
            this.LbDieren.Location = new System.Drawing.Point(602, 12);
            this.LbDieren.Name = "LbDieren";
            this.LbDieren.Size = new System.Drawing.Size(190, 186);
            this.LbDieren.TabIndex = 3;
            // 
            // TbNaam
            // 
            this.TbNaam.Location = new System.Drawing.Point(422, 14);
            this.TbNaam.Name = "TbNaam";
            this.TbNaam.Size = new System.Drawing.Size(100, 20);
            this.TbNaam.TabIndex = 4;
            // 
            // Nleeftijd
            // 
            this.Nleeftijd.Location = new System.Drawing.Point(422, 44);
            this.Nleeftijd.Name = "Nleeftijd";
            this.Nleeftijd.Size = new System.Drawing.Size(100, 20);
            this.Nleeftijd.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Naam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Leeftijd:";
            // 
            // BtnVoegToe
            // 
            this.BtnVoegToe.Location = new System.Drawing.Point(422, 82);
            this.BtnVoegToe.Name = "BtnVoegToe";
            this.BtnVoegToe.Size = new System.Drawing.Size(111, 23);
            this.BtnVoegToe.TabIndex = 10;
            this.BtnVoegToe.Text = "Voeg dier toe";
            this.BtnVoegToe.UseVisualStyleBackColor = true;
            this.BtnVoegToe.Click += new System.EventHandler(this.BtnVoegToe_Click);
            // 
            // BtnOverleden
            // 
            this.BtnOverleden.Location = new System.Drawing.Point(12, 227);
            this.BtnOverleden.Name = "BtnOverleden";
            this.BtnOverleden.Size = new System.Drawing.Size(75, 23);
            this.BtnOverleden.TabIndex = 11;
            this.BtnOverleden.Text = "Overleden";
            this.BtnOverleden.UseVisualStyleBackColor = true;
            // 
            // BtnDierenZien
            // 
            this.BtnDierenZien.Location = new System.Drawing.Point(422, 112);
            this.BtnDierenZien.Name = "BtnDierenZien";
            this.BtnDierenZien.Size = new System.Drawing.Size(111, 23);
            this.BtnDierenZien.TabIndex = 12;
            this.BtnDierenZien.Text = "Laat dieren zien";
            this.BtnDierenZien.UseVisualStyleBackColor = true;
            this.BtnDierenZien.Click += new System.EventHandler(this.BtnDierenZien_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(703, 217);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(79, 23);
            this.BtnSave.TabIndex = 13;
            this.BtnSave.Text = "Sla dieren op";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(602, 217);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(95, 23);
            this.BtnLoad.TabIndex = 14;
            this.BtnLoad.Text = "Laadt alle dieren";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 262);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnDierenZien);
            this.Controls.Add(this.BtnOverleden);
            this.Controls.Add(this.BtnVoegToe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nleeftijd);
            this.Controls.Add(this.TbNaam);
            this.Controls.Add(this.LbDieren);
            this.Controls.Add(this.Lopen);
            this.Controls.Add(this.schaften);
            this.Controls.Add(this.schijten);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Nleeftijd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button schijten;
        private System.Windows.Forms.Button schaften;
        private System.Windows.Forms.Button Lopen;
        private System.Windows.Forms.ListBox LbDieren;
        private System.Windows.Forms.TextBox TbNaam;
        private System.Windows.Forms.NumericUpDown Nleeftijd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnVoegToe;
        private System.Windows.Forms.Button BtnOverleden;
        private System.Windows.Forms.Button BtnDierenZien;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnLoad;
    }
}

