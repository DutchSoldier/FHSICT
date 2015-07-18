namespace DatabaseKoppeling
{
    partial class DatabaseKoppelingForm
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
            this.HaalOpNamenBtn = new System.Windows.Forms.Button();
            this.VoegtoeBtn = new System.Windows.Forms.Button();
            this.NaamTbx = new System.Windows.Forms.TextBox();
            this.aantalrecBtn = new System.Windows.Forms.Button();
            this.AantalLbl = new System.Windows.Forms.Label();
            this.InhoudDbLbx = new System.Windows.Forms.ListBox();
            this.HaalOpAllesBtn = new System.Windows.Forms.Button();
            this.NrTbx = new System.Windows.Forms.TextBox();
            this.studPuntenTbx = new System.Windows.Forms.TextBox();
            this.StudentenTabelPBx = new System.Windows.Forms.PictureBox();
            this.StructuurLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StudentenTabelPBx)).BeginInit();
            this.SuspendLayout();
            // 
            // HaalOpNamenBtn
            // 
            this.HaalOpNamenBtn.Location = new System.Drawing.Point(19, 93);
            this.HaalOpNamenBtn.Name = "HaalOpNamenBtn";
            this.HaalOpNamenBtn.Size = new System.Drawing.Size(105, 23);
            this.HaalOpNamenBtn.TabIndex = 0;
            this.HaalOpNamenBtn.Text = "Haal op namen";
            this.HaalOpNamenBtn.UseVisualStyleBackColor = true;
            this.HaalOpNamenBtn.Click += new System.EventHandler(this.HaalOpNamen_Click);
            // 
            // VoegtoeBtn
            // 
            this.VoegtoeBtn.Location = new System.Drawing.Point(240, 207);
            this.VoegtoeBtn.Name = "VoegtoeBtn";
            this.VoegtoeBtn.Size = new System.Drawing.Size(92, 22);
            this.VoegtoeBtn.TabIndex = 3;
            this.VoegtoeBtn.Text = "Voegtoe";
            this.VoegtoeBtn.UseVisualStyleBackColor = true;
            this.VoegtoeBtn.Click += new System.EventHandler(this.Voegtoe_Click);
            // 
            // NaamTbx
            // 
            this.NaamTbx.Location = new System.Drawing.Point(278, 181);
            this.NaamTbx.Name = "NaamTbx";
            this.NaamTbx.Size = new System.Drawing.Size(91, 20);
            this.NaamTbx.TabIndex = 4;
            // 
            // aantalrecBtn
            // 
            this.aantalrecBtn.Location = new System.Drawing.Point(19, 12);
            this.aantalrecBtn.Name = "aantalrecBtn";
            this.aantalrecBtn.Size = new System.Drawing.Size(99, 35);
            this.aantalrecBtn.TabIndex = 5;
            this.aantalrecBtn.Text = "AantalRecords";
            this.aantalrecBtn.UseVisualStyleBackColor = true;
            this.aantalrecBtn.Click += new System.EventHandler(this.Aantal_Click);
            // 
            // AantalLbl
            // 
            this.AantalLbl.AutoSize = true;
            this.AantalLbl.Location = new System.Drawing.Point(25, 50);
            this.AantalLbl.Name = "AantalLbl";
            this.AantalLbl.Size = new System.Drawing.Size(35, 13);
            this.AantalLbl.TabIndex = 6;
            this.AantalLbl.Text = "label1";
            // 
            // InhoudDbLbx
            // 
            this.InhoudDbLbx.FormattingEnabled = true;
            this.InhoudDbLbx.Location = new System.Drawing.Point(12, 158);
            this.InhoudDbLbx.Name = "InhoudDbLbx";
            this.InhoudDbLbx.Size = new System.Drawing.Size(157, 95);
            this.InhoudDbLbx.TabIndex = 7;
            // 
            // HaalOpAllesBtn
            // 
            this.HaalOpAllesBtn.Location = new System.Drawing.Point(19, 122);
            this.HaalOpAllesBtn.Name = "HaalOpAllesBtn";
            this.HaalOpAllesBtn.Size = new System.Drawing.Size(105, 23);
            this.HaalOpAllesBtn.TabIndex = 8;
            this.HaalOpAllesBtn.Text = "Haal Op Alles";
            this.HaalOpAllesBtn.UseVisualStyleBackColor = true;
            this.HaalOpAllesBtn.Click += new System.EventHandler(this.HaalOpAllesBtn_Click);
            // 
            // NrTbx
            // 
            this.NrTbx.Location = new System.Drawing.Point(212, 181);
            this.NrTbx.Name = "NrTbx";
            this.NrTbx.Size = new System.Drawing.Size(59, 20);
            this.NrTbx.TabIndex = 9;
            // 
            // studPuntenTbx
            // 
            this.studPuntenTbx.Location = new System.Drawing.Point(376, 181);
            this.studPuntenTbx.Name = "studPuntenTbx";
            this.studPuntenTbx.Size = new System.Drawing.Size(68, 20);
            this.studPuntenTbx.TabIndex = 10;
            // 
            // StudentenTabelPBx
            // 
            this.StudentenTabelPBx.Image = global::DatabaseKoppeling.Properties.Resources.StudentenDBS;
            this.StudentenTabelPBx.Location = new System.Drawing.Point(184, 50);
            this.StudentenTabelPBx.Name = "StudentenTabelPBx";
            this.StudentenTabelPBx.Size = new System.Drawing.Size(284, 111);
            this.StudentenTabelPBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StudentenTabelPBx.TabIndex = 11;
            this.StudentenTabelPBx.TabStop = false;
            // 
            // StructuurLbl
            // 
            this.StructuurLbl.AutoSize = true;
            this.StructuurLbl.Location = new System.Drawing.Point(181, 23);
            this.StructuurLbl.Name = "StructuurLbl";
            this.StructuurLbl.Size = new System.Drawing.Size(206, 13);
            this.StructuurLbl.TabIndex = 12;
            this.StructuurLbl.Text = "Figuur van Structuur van de StudentTabel";
            // 
            // DatabaseKoppelingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 266);
            this.Controls.Add(this.StructuurLbl);
            this.Controls.Add(this.StudentenTabelPBx);
            this.Controls.Add(this.studPuntenTbx);
            this.Controls.Add(this.NrTbx);
            this.Controls.Add(this.HaalOpAllesBtn);
            this.Controls.Add(this.InhoudDbLbx);
            this.Controls.Add(this.AantalLbl);
            this.Controls.Add(this.aantalrecBtn);
            this.Controls.Add(this.NaamTbx);
            this.Controls.Add(this.VoegtoeBtn);
            this.Controls.Add(this.HaalOpNamenBtn);
            this.Name = "DatabaseKoppelingForm";
            this.Text = "Database koppeling voorbeeld";
            ((System.ComponentModel.ISupportInitialize)(this.StudentenTabelPBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HaalOpNamenBtn;
        private System.Windows.Forms.Button VoegtoeBtn;
        private System.Windows.Forms.TextBox NaamTbx;
        private System.Windows.Forms.Button aantalrecBtn;
        private System.Windows.Forms.Label AantalLbl;
        private System.Windows.Forms.ListBox InhoudDbLbx;
        private System.Windows.Forms.Button HaalOpAllesBtn;
        private System.Windows.Forms.TextBox NrTbx;
        private System.Windows.Forms.TextBox studPuntenTbx;
        private System.Windows.Forms.PictureBox StudentenTabelPBx;
        private System.Windows.Forms.Label StructuurLbl;
    }
}

