namespace PLSQL
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
            this.bProcedure = new System.Windows.Forms.Button();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mUsername = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nTeVerdubbelenGetal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvCategorieen = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTeVerdubbelenGetal)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bProcedure
            // 
            this.bProcedure.Location = new System.Drawing.Point(16, 70);
            this.bProcedure.Name = "bProcedure";
            this.bProcedure.Size = new System.Drawing.Size(252, 23);
            this.bProcedure.TabIndex = 4;
            this.bProcedure.Text = "Voer procedure uit";
            this.bProcedure.UseVisualStyleBackColor = true;
            this.bProcedure.Click += new System.EventHandler(this.bProcedure_Click);
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(117, 48);
            this.tPassword.Name = "tPassword";
            this.tPassword.PasswordChar = '*';
            this.tPassword.Size = new System.Drawing.Size(147, 20);
            this.tPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username (PCN):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Te verdubbelen getal:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Voer procedure uit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 82);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inlog gegevens";
            // 
            // mUsername
            // 
            this.mUsername.Location = new System.Drawing.Point(117, 18);
            this.mUsername.Mask = "000000";
            this.mUsername.Name = "mUsername";
            this.mUsername.Size = new System.Drawing.Size(147, 20);
            this.mUsername.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nTeVerdubbelenGetal);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.bProcedure);
            this.groupBox2.Location = new System.Drawing.Point(11, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 164);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Voorbeeld aanroep stored procedure 1";
            // 
            // nTeVerdubbelenGetal
            // 
            this.nTeVerdubbelenGetal.Location = new System.Drawing.Point(186, 49);
            this.nTeVerdubbelenGetal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nTeVerdubbelenGetal.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nTeVerdubbelenGetal.Name = "nTeVerdubbelenGetal";
            this.nTeVerdubbelenGetal.Size = new System.Drawing.Size(82, 20);
            this.nTeVerdubbelenGetal.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Verdubbelt de opgegeven waarde.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvCategorieen);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(293, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 249);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Voorbeeld aanroep stored procedure 2";
            // 
            // lvCategorieen
            // 
            this.lvCategorieen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvCategorieen.GridLines = true;
            this.lvCategorieen.Location = new System.Drawing.Point(11, 99);
            this.lvCategorieen.Name = "lvCategorieen";
            this.lvCategorieen.Size = new System.Drawing.Size(234, 144);
            this.lvCategorieen.TabIndex = 8;
            this.lvCategorieen.UseCompatibleStateImageBehavior = false;
            this.lvCategorieen.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Naam";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Omschrijving";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Toont alle in de database aanwezige categorieen.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(525, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Let op: maak eerst de benodigde tabel (tip: voeg zelf wat rijen toe) en";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(526, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "stored procedures (zie de .txt bestanden in dit project) in je database.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 332);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "C# stored procedure demo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTeVerdubbelenGetal)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bProcedure;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mUsername;
        private System.Windows.Forms.NumericUpDown nTeVerdubbelenGetal;
        private System.Windows.Forms.ListView lvCategorieen;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

