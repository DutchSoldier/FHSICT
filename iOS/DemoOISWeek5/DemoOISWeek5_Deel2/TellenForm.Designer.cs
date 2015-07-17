namespace DemoOISWeek5_Deel2
{
    partial class TellenForm
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
            this.getalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tellenListBox = new System.Windows.Forms.ListBox();
            this.telButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.getalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // getalNumericUpDown
            // 
            this.getalNumericUpDown.Location = new System.Drawing.Point(93, 17);
            this.getalNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.getalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.getalNumericUpDown.Name = "getalNumericUpDown";
            this.getalNumericUpDown.Size = new System.Drawing.Size(62, 20);
            this.getalNumericUpDown.TabIndex = 0;
            this.getalNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kies een getal";
            // 
            // tellenListBox
            // 
            this.tellenListBox.FormattingEnabled = true;
            this.tellenListBox.Location = new System.Drawing.Point(16, 48);
            this.tellenListBox.Name = "tellenListBox";
            this.tellenListBox.Size = new System.Drawing.Size(197, 290);
            this.tellenListBox.TabIndex = 2;
            // 
            // telButton
            // 
            this.telButton.Location = new System.Drawing.Point(161, 14);
            this.telButton.Name = "telButton";
            this.telButton.Size = new System.Drawing.Size(51, 23);
            this.telButton.TabIndex = 3;
            this.telButton.Text = "Tel";
            this.telButton.UseVisualStyleBackColor = true;
            this.telButton.Click += new System.EventHandler(this.telButton_Click);
            // 
            // TellenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 349);
            this.Controls.Add(this.telButton);
            this.Controls.Add(this.tellenListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getalNumericUpDown);
            this.Name = "TellenForm";
            this.Text = "Tellen";
            ((System.ComponentModel.ISupportInitialize)(this.getalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown getalNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox tellenListBox;
        private System.Windows.Forms.Button telButton;
    }
}

