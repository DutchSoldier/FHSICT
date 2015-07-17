namespace WindowsFormsApplication3
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
            this.bGooi = new System.Windows.Forms.Button();
            this.numericUpDownWorpen = new System.Windows.Forms.NumericUpDown();
            this.worpenlistbox = new System.Windows.Forms.ListBox();
            this.numericUpDownOgen = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWorpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOgen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bGooi
            // 
            this.bGooi.Location = new System.Drawing.Point(3, 131);
            this.bGooi.Name = "bGooi";
            this.bGooi.Size = new System.Drawing.Size(232, 23);
            this.bGooi.TabIndex = 1;
            this.bGooi.Text = "Gooi dobbelstenen!!!";
            this.bGooi.UseVisualStyleBackColor = true;
            this.bGooi.Click += new System.EventHandler(this.bGooi_Click);
            // 
            // numericUpDownWorpen
            // 
            this.numericUpDownWorpen.Location = new System.Drawing.Point(115, 22);
            this.numericUpDownWorpen.Name = "numericUpDownWorpen";
            this.numericUpDownWorpen.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownWorpen.TabIndex = 2;
            // 
            // worpenlistbox
            // 
            this.worpenlistbox.FormattingEnabled = true;
            this.worpenlistbox.Location = new System.Drawing.Point(16, 19);
            this.worpenlistbox.Name = "worpenlistbox";
            this.worpenlistbox.Size = new System.Drawing.Size(202, 329);
            this.worpenlistbox.TabIndex = 3;
            // 
            // numericUpDownOgen
            // 
            this.numericUpDownOgen.Location = new System.Drawing.Point(115, 80);
            this.numericUpDownOgen.Name = "numericUpDownOgen";
            this.numericUpDownOgen.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownOgen.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Aantal worpen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ogen op dobbelsteen:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownOgen);
            this.groupBox1.Controls.Add(this.numericUpDownWorpen);
            this.groupBox1.Controls.Add(this.bGooi);
            this.groupBox1.Location = new System.Drawing.Point(2, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 192);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instellingen";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.worpenlistbox);
            this.groupBox2.Location = new System.Drawing.Point(270, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 349);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultaten";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 394);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWorpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOgen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bGooi;
        private System.Windows.Forms.NumericUpDown numericUpDownWorpen;
        private System.Windows.Forms.ListBox worpenlistbox;
        private System.Windows.Forms.NumericUpDown numericUpDownOgen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

