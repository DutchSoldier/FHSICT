namespace RSSReader
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
            this.toonBerichtKnop = new System.Windows.Forms.Button();
            this.RSSTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.titelLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.toonRssCodeKnop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toonBerichtKnop
            // 
            this.toonBerichtKnop.Location = new System.Drawing.Point(521, 45);
            this.toonBerichtKnop.Name = "toonBerichtKnop";
            this.toonBerichtKnop.Size = new System.Drawing.Size(128, 23);
            this.toonBerichtKnop.TabIndex = 0;
            this.toonBerichtKnop.Text = "Toon nieuwste bericht";
            this.toonBerichtKnop.UseVisualStyleBackColor = true;
            this.toonBerichtKnop.Click += new System.EventHandler(this.toonBerichtKnop_Click);
            // 
            // RSSTextBox
            // 
            this.RSSTextBox.Location = new System.Drawing.Point(108, 21);
            this.RSSTextBox.Name = "RSSTextBox";
            this.RSSTextBox.Size = new System.Drawing.Size(407, 20);
            this.RSSTextBox.TabIndex = 1;
            this.RSSTextBox.Text = "http://www.nu.nl/feeds/rss/wetenschap.rss";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "RSS url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Titel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Beschrijving:";
            // 
            // titelLabel
            // 
            this.titelLabel.Location = new System.Drawing.Point(105, 69);
            this.titelLabel.Name = "titelLabel";
            this.titelLabel.Size = new System.Drawing.Size(410, 41);
            this.titelLabel.TabIndex = 7;
            this.titelLabel.Text = "(title van het bericht)";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(105, 119);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(410, 64);
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "(description van het bericht)";
            // 
            // toonRssCodeKnop
            // 
            this.toonRssCodeKnop.Location = new System.Drawing.Point(521, 18);
            this.toonRssCodeKnop.Name = "toonRssCodeKnop";
            this.toonRssCodeKnop.Size = new System.Drawing.Size(128, 23);
            this.toonRssCodeKnop.TabIndex = 9;
            this.toonRssCodeKnop.Text = "Toon RSS code";
            this.toonRssCodeKnop.UseVisualStyleBackColor = true;
            this.toonRssCodeKnop.Click += new System.EventHandler(this.toonRssCodeKnop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 229);
            this.Controls.Add(this.toonRssCodeKnop);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titelLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RSSTextBox);
            this.Controls.Add(this.toonBerichtKnop);
            this.Name = "Form1";
            this.Text = "RSS Reader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button toonBerichtKnop;
        private System.Windows.Forms.TextBox RSSTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label titelLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button toonRssCodeKnop;
    }
}

