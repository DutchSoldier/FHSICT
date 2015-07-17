namespace WindowsFormsApplication2
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
            this.Btoeuro = new System.Windows.Forms.Button();
            this.Btodollar = new System.Windows.Forms.Button();
            this.TBeuro = new System.Windows.Forms.TextBox();
            this.TBdollar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btoeuro
            // 
            this.Btoeuro.Location = new System.Drawing.Point(166, 90);
            this.Btoeuro.Name = "Btoeuro";
            this.Btoeuro.Size = new System.Drawing.Size(75, 23);
            this.Btoeuro.TabIndex = 0;
            this.Btoeuro.Text = "<";
            this.Btoeuro.UseVisualStyleBackColor = true;
            this.Btoeuro.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btodollar
            // 
            this.Btodollar.Location = new System.Drawing.Point(247, 89);
            this.Btodollar.Name = "Btodollar";
            this.Btodollar.Size = new System.Drawing.Size(75, 23);
            this.Btodollar.TabIndex = 1;
            this.Btodollar.Text = ">";
            this.Btodollar.UseVisualStyleBackColor = true;
            this.Btodollar.Click += new System.EventHandler(this.button2_Click);
            // 
            // TBeuro
            // 
            this.TBeuro.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TBeuro.Location = new System.Drawing.Point(89, 92);
            this.TBeuro.Name = "TBeuro";
            this.TBeuro.Size = new System.Drawing.Size(71, 20);
            this.TBeuro.TabIndex = 2;
            this.TBeuro.Text = "1";
            this.TBeuro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TBdollar
            // 
            this.TBdollar.Location = new System.Drawing.Point(328, 90);
            this.TBdollar.Name = "TBdollar";
            this.TBdollar.Size = new System.Drawing.Size(71, 20);
            this.TBdollar.TabIndex = 3;
            this.TBdollar.Text = "1";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 51);
            this.label1.TabIndex = 7;
            this.label1.Text = "$";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 51);
            this.label2.TabIndex = 8;
            this.label2.Text = "€";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Koers 1 euro = $";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(236, 194);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(86, 20);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 335);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBdollar);
            this.Controls.Add(this.TBeuro);
            this.Controls.Add(this.Btodollar);
            this.Controls.Add(this.Btoeuro);
            this.Name = "Form1";
            this.Text = "Euro - US dollar converter";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btoeuro;
        private System.Windows.Forms.Button Btodollar;
        private System.Windows.Forms.TextBox TBeuro;
        private System.Windows.Forms.TextBox TBdollar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

