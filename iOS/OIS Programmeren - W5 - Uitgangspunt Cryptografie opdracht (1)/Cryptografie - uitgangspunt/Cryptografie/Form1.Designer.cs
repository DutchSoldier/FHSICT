namespace Cryptografie
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
            this.omgezetteTekstTextBox = new System.Windows.Forms.TextBox();
            this.normaleTekstTextBox = new System.Windows.Forms.TextBox();
            this.codeerDecodeerKnop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // omgezetteTekstTextBox
            // 
            this.omgezetteTekstTextBox.Location = new System.Drawing.Point(12, 127);
            this.omgezetteTekstTextBox.Multiline = true;
            this.omgezetteTekstTextBox.Name = "omgezetteTekstTextBox";
            this.omgezetteTekstTextBox.Size = new System.Drawing.Size(461, 80);
            this.omgezetteTekstTextBox.TabIndex = 5;
            // 
            // normaleTekstTextBox
            // 
            this.normaleTekstTextBox.Location = new System.Drawing.Point(12, 12);
            this.normaleTekstTextBox.Multiline = true;
            this.normaleTekstTextBox.Name = "normaleTekstTextBox";
            this.normaleTekstTextBox.Size = new System.Drawing.Size(461, 80);
            this.normaleTekstTextBox.TabIndex = 4;
            // 
            // codeerDecodeerKnop
            // 
            this.codeerDecodeerKnop.Location = new System.Drawing.Point(12, 98);
            this.codeerDecodeerKnop.Name = "codeerDecodeerKnop";
            this.codeerDecodeerKnop.Size = new System.Drawing.Size(461, 23);
            this.codeerDecodeerKnop.TabIndex = 3;
            this.codeerDecodeerKnop.Text = "Codeer / decodeer middels ROT13";
            this.codeerDecodeerKnop.UseVisualStyleBackColor = true;
            this.codeerDecodeerKnop.Click += new System.EventHandler(this.codeerDecodeerKnop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 215);
            this.Controls.Add(this.omgezetteTekstTextBox);
            this.Controls.Add(this.normaleTekstTextBox);
            this.Controls.Add(this.codeerDecodeerKnop);
            this.Name = "Form1";
            this.Text = "Cryptografie ROT13";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox omgezetteTekstTextBox;
        private System.Windows.Forms.TextBox normaleTekstTextBox;
        private System.Windows.Forms.Button codeerDecodeerKnop;
    }
}

