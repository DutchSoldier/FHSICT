namespace DemoOISWeek5
{
    partial class DobbelenForm
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
            this.aantalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btGooien = new System.Windows.Forms.Button();
            this.dobbelstenenTextBox = new System.Windows.Forms.TextBox();
            this.worpenListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.aantalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // aantalNumericUpDown
            // 
            this.aantalNumericUpDown.Location = new System.Drawing.Point(125, 16);
            this.aantalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aantalNumericUpDown.Name = "aantalNumericUpDown";
            this.aantalNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.aantalNumericUpDown.TabIndex = 0;
            this.aantalNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "aantal dobbelstenen:";
            // 
            // btGooien
            // 
            this.btGooien.Location = new System.Drawing.Point(16, 87);
            this.btGooien.Name = "btGooien";
            this.btGooien.Size = new System.Drawing.Size(166, 23);
            this.btGooien.TabIndex = 2;
            this.btGooien.Text = "Gooien!";
            this.btGooien.UseVisualStyleBackColor = true;
            this.btGooien.Click += new System.EventHandler(this.btGooien_Click);
            // 
            // dobbelstenenTextBox
            // 
            this.dobbelstenenTextBox.Location = new System.Drawing.Point(16, 116);
            this.dobbelstenenTextBox.Name = "dobbelstenenTextBox";
            this.dobbelstenenTextBox.Size = new System.Drawing.Size(166, 20);
            this.dobbelstenenTextBox.TabIndex = 3;
            // 
            // worpenListBox
            // 
            this.worpenListBox.FormattingEnabled = true;
            this.worpenListBox.Location = new System.Drawing.Point(222, 12);
            this.worpenListBox.Name = "worpenListBox";
            this.worpenListBox.Size = new System.Drawing.Size(216, 420);
            this.worpenListBox.TabIndex = 4;
            // 
            // DobbelenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 448);
            this.Controls.Add(this.worpenListBox);
            this.Controls.Add(this.dobbelstenenTextBox);
            this.Controls.Add(this.btGooien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aantalNumericUpDown);
            this.Name = "DobbelenForm";
            this.Text = "Dobbelen";
            ((System.ComponentModel.ISupportInitialize)(this.aantalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown aantalNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGooien;
        private System.Windows.Forms.TextBox dobbelstenenTextBox;
        private System.Windows.Forms.ListBox worpenListBox;
    }
}

