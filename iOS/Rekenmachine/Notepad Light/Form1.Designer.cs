namespace Notepad_Light
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.KnopCopy = new System.Windows.Forms.Button();
            this.KnopPaste = new System.Windows.Forms.Button();
            this.KnopClear = new System.Windows.Forms.Button();
            this.KnopLoad = new System.Windows.Forms.Button();
            this.KnopSave = new System.Windows.Forms.Button();
            this.KnopAbout = new System.Windows.Forms.Button();
            this.openenScherm = new System.Windows.Forms.OpenFileDialog();
            this.OpslaanScherm = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(383, 211);
            this.textBox1.TabIndex = 0;
            // 
            // KnopCopy
            // 
            this.KnopCopy.Location = new System.Drawing.Point(438, 21);
            this.KnopCopy.Name = "KnopCopy";
            this.KnopCopy.Size = new System.Drawing.Size(118, 23);
            this.KnopCopy.TabIndex = 1;
            this.KnopCopy.Text = "Copy Selection";
            this.KnopCopy.UseVisualStyleBackColor = true;
            this.KnopCopy.Click += new System.EventHandler(this.KnopCopy_Click);
            // 
            // KnopPaste
            // 
            this.KnopPaste.Location = new System.Drawing.Point(438, 50);
            this.KnopPaste.Name = "KnopPaste";
            this.KnopPaste.Size = new System.Drawing.Size(118, 23);
            this.KnopPaste.TabIndex = 2;
            this.KnopPaste.Text = "Paste";
            this.KnopPaste.UseVisualStyleBackColor = true;
            this.KnopPaste.Click += new System.EventHandler(this.KnopPaste_Click);
            // 
            // KnopClear
            // 
            this.KnopClear.Location = new System.Drawing.Point(438, 79);
            this.KnopClear.Name = "KnopClear";
            this.KnopClear.Size = new System.Drawing.Size(118, 23);
            this.KnopClear.TabIndex = 3;
            this.KnopClear.Text = "Clear Text";
            this.KnopClear.UseVisualStyleBackColor = true;
            this.KnopClear.Click += new System.EventHandler(this.KnopClear_Click);
            // 
            // KnopLoad
            // 
            this.KnopLoad.Location = new System.Drawing.Point(438, 131);
            this.KnopLoad.Name = "KnopLoad";
            this.KnopLoad.Size = new System.Drawing.Size(118, 23);
            this.KnopLoad.TabIndex = 4;
            this.KnopLoad.Text = "Load...";
            this.KnopLoad.UseVisualStyleBackColor = true;
            this.KnopLoad.Click += new System.EventHandler(this.KnopLoad_Click);
            // 
            // KnopSave
            // 
            this.KnopSave.Location = new System.Drawing.Point(438, 160);
            this.KnopSave.Name = "KnopSave";
            this.KnopSave.Size = new System.Drawing.Size(118, 23);
            this.KnopSave.TabIndex = 5;
            this.KnopSave.Text = "Save As...";
            this.KnopSave.UseVisualStyleBackColor = true;
            this.KnopSave.Click += new System.EventHandler(this.KnopSave_Click);
            // 
            // KnopAbout
            // 
            this.KnopAbout.Location = new System.Drawing.Point(438, 209);
            this.KnopAbout.Name = "KnopAbout";
            this.KnopAbout.Size = new System.Drawing.Size(118, 23);
            this.KnopAbout.TabIndex = 6;
            this.KnopAbout.Text = "About...";
            this.KnopAbout.UseVisualStyleBackColor = true;
            this.KnopAbout.Click += new System.EventHandler(this.KnopAbout_Click);
            // 
            // openenScherm
            // 
            this.openenScherm.FileName = "openenScherm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(614, 261);
            this.Controls.Add(this.KnopAbout);
            this.Controls.Add(this.KnopSave);
            this.Controls.Add(this.KnopLoad);
            this.Controls.Add(this.KnopClear);
            this.Controls.Add(this.KnopPaste);
            this.Controls.Add(this.KnopCopy);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Notepad Light";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button KnopCopy;
        private System.Windows.Forms.Button KnopPaste;
        private System.Windows.Forms.Button KnopClear;
        private System.Windows.Forms.Button KnopLoad;
        private System.Windows.Forms.Button KnopSave;
        private System.Windows.Forms.Button KnopAbout;
        private System.Windows.Forms.OpenFileDialog openenScherm;
        private System.Windows.Forms.SaveFileDialog OpslaanScherm;
    }
}

