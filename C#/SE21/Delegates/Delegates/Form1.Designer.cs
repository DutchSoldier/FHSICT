namespace Delegates
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
            this.Btn_Naam1 = new System.Windows.Forms.Button();
            this.Btn_Naam2 = new System.Windows.Forms.Button();
            this.Btn_Naam3 = new System.Windows.Forms.Button();
            this.lb_Namen = new System.Windows.Forms.ListBox();
            this.Btn_LaatZien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Naam1
            // 
            this.Btn_Naam1.Location = new System.Drawing.Point(12, 327);
            this.Btn_Naam1.Name = "Btn_Naam1";
            this.Btn_Naam1.Size = new System.Drawing.Size(75, 23);
            this.Btn_Naam1.TabIndex = 0;
            this.Btn_Naam1.Text = "Naam 1";
            this.Btn_Naam1.UseVisualStyleBackColor = true;
            this.Btn_Naam1.Click += new System.EventHandler(this.Btn_Naam1_Click);
            // 
            // Btn_Naam2
            // 
            this.Btn_Naam2.Location = new System.Drawing.Point(93, 327);
            this.Btn_Naam2.Name = "Btn_Naam2";
            this.Btn_Naam2.Size = new System.Drawing.Size(75, 23);
            this.Btn_Naam2.TabIndex = 1;
            this.Btn_Naam2.Text = "Naam 2";
            this.Btn_Naam2.UseVisualStyleBackColor = true;
            this.Btn_Naam2.Click += new System.EventHandler(this.Btn_Naam2_Click);
            // 
            // Btn_Naam3
            // 
            this.Btn_Naam3.Location = new System.Drawing.Point(174, 327);
            this.Btn_Naam3.Name = "Btn_Naam3";
            this.Btn_Naam3.Size = new System.Drawing.Size(75, 23);
            this.Btn_Naam3.TabIndex = 2;
            this.Btn_Naam3.Text = "Naam 3";
            this.Btn_Naam3.UseVisualStyleBackColor = true;
            this.Btn_Naam3.Click += new System.EventHandler(this.Btn_Naam3_Click);
            // 
            // lb_Namen
            // 
            this.lb_Namen.FormattingEnabled = true;
            this.lb_Namen.Location = new System.Drawing.Point(12, 18);
            this.lb_Namen.Name = "lb_Namen";
            this.lb_Namen.Size = new System.Drawing.Size(236, 290);
            this.lb_Namen.TabIndex = 3;
            // 
            // Btn_LaatZien
            // 
            this.Btn_LaatZien.Location = new System.Drawing.Point(12, 365);
            this.Btn_LaatZien.Name = "Btn_LaatZien";
            this.Btn_LaatZien.Size = new System.Drawing.Size(237, 27);
            this.Btn_LaatZien.TabIndex = 4;
            this.Btn_LaatZien.Text = "Laat naam zien";
            this.Btn_LaatZien.UseVisualStyleBackColor = true;
            this.Btn_LaatZien.Click += new System.EventHandler(this.Btn_LaatZien_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 419);
            this.Controls.Add(this.Btn_LaatZien);
            this.Controls.Add(this.lb_Namen);
            this.Controls.Add(this.Btn_Naam3);
            this.Controls.Add(this.Btn_Naam2);
            this.Controls.Add(this.Btn_Naam1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Naam1;
        private System.Windows.Forms.Button Btn_Naam2;
        private System.Windows.Forms.Button Btn_Naam3;
        private System.Windows.Forms.ListBox lb_Namen;
        private System.Windows.Forms.Button Btn_LaatZien;
    }
}

