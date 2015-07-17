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
            this.btnVoegtoe = new System.Windows.Forms.Button();
            this.tbNaam = new System.Windows.Forms.TextBox();
            this.btnAantalRecords = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listbox1 = new System.Windows.Forms.ListBox();
            this.btnHaalOp = new System.Windows.Forms.Button();
            this.tbNummer = new System.Windows.Forms.TextBox();
            this.tbStudPunten = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoegtoe
            // 
            this.btnVoegtoe.Location = new System.Drawing.Point(27, 76);
            this.btnVoegtoe.Name = "btnVoegtoe";
            this.btnVoegtoe.Size = new System.Drawing.Size(107, 42);
            this.btnVoegtoe.TabIndex = 3;
            this.btnVoegtoe.Text = "Voegtoe";
            this.btnVoegtoe.UseVisualStyleBackColor = true;
            this.btnVoegtoe.Click += new System.EventHandler(this.btnVoegtoe_Click);
            // 
            // tbNaam
            // 
            this.tbNaam.Location = new System.Drawing.Point(85, 32);
            this.tbNaam.Name = "tbNaam";
            this.tbNaam.Size = new System.Drawing.Size(91, 26);
            this.tbNaam.TabIndex = 4;
            // 
            // btnAantalRecords
            // 
            this.btnAantalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAantalRecords.Location = new System.Drawing.Point(25, 381);
            this.btnAantalRecords.Name = "btnAantalRecords";
            this.btnAantalRecords.Size = new System.Drawing.Size(134, 35);
            this.btnAantalRecords.TabIndex = 5;
            this.btnAantalRecords.Text = "AantalRecords";
            this.btnAantalRecords.UseVisualStyleBackColor = true;
            this.btnAantalRecords.Click += new System.EventHandler(this.btnAantalRecords_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // listbox1
            // 
            this.listbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox1.FormattingEnabled = true;
            this.listbox1.ItemHeight = 20;
            this.listbox1.Location = new System.Drawing.Point(148, 14);
            this.listbox1.Name = "listbox1";
            this.listbox1.Size = new System.Drawing.Size(336, 184);
            this.listbox1.TabIndex = 7;
            // 
            // btnHaalOp
            // 
            this.btnHaalOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHaalOp.Location = new System.Drawing.Point(19, 12);
            this.btnHaalOp.Name = "btnHaalOp";
            this.btnHaalOp.Size = new System.Drawing.Size(105, 186);
            this.btnHaalOp.TabIndex = 8;
            this.btnHaalOp.Text = "Haal Op Alle Studenten";
            this.btnHaalOp.UseVisualStyleBackColor = true;
            this.btnHaalOp.Click += new System.EventHandler(this.btnHaalOp_Click);
            // 
            // tbNummer
            // 
            this.tbNummer.Location = new System.Drawing.Point(6, 32);
            this.tbNummer.Name = "tbNummer";
            this.tbNummer.Size = new System.Drawing.Size(59, 26);
            this.tbNummer.TabIndex = 9;
            // 
            // tbStudPunten
            // 
            this.tbStudPunten.Location = new System.Drawing.Point(182, 32);
            this.tbStudPunten.Name = "tbStudPunten";
            this.tbStudPunten.Size = new System.Drawing.Size(68, 26);
            this.tbStudPunten.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox1.Controls.Add(this.tbNummer);
            this.groupBox1.Controls.Add(this.tbStudPunten);
            this.groupBox1.Controls.Add(this.tbNaam);
            this.groupBox1.Controls.Add(this.btnVoegtoe);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 124);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // DatabaseKoppelingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHaalOp);
            this.Controls.Add(this.listbox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAantalRecords);
            this.Name = "DatabaseKoppelingForm";
            this.Text = "Database koppeling voorbeeld";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVoegtoe;
        private System.Windows.Forms.TextBox tbNaam;
        private System.Windows.Forms.Button btnAantalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listbox1;
        private System.Windows.Forms.Button btnHaalOp;
        private System.Windows.Forms.TextBox tbNummer;
        private System.Windows.Forms.TextBox tbStudPunten;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

