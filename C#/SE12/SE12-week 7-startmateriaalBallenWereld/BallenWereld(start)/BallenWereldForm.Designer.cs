namespace BallenWereld
{
    partial class BallenWereldForm
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
            this.components = new System.ComponentModel.Container();
            this.bNieuw = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lBallen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bNieuw
            // 
            this.bNieuw.Location = new System.Drawing.Point(389, 437);
            this.bNieuw.Name = "bNieuw";
            this.bNieuw.Size = new System.Drawing.Size(75, 23);
            this.bNieuw.TabIndex = 0;
            this.bNieuw.Text = "Nieuw";
            this.bNieuw.UseVisualStyleBackColor = true;
            this.bNieuw.Click += new System.EventHandler(this.bNieuw_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lBallen
            // 
            this.lBallen.AutoSize = true;
            this.lBallen.Location = new System.Drawing.Point(43, 437);
            this.lBallen.Name = "lBallen";
            this.lBallen.Size = new System.Drawing.Size(0, 13);
            this.lBallen.TabIndex = 1;
            // 
            // BallenWereldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 472);
            this.Controls.Add(this.lBallen);
            this.Controls.Add(this.bNieuw);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BallenWereldForm";
            this.Text = "BallenWereld";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BallenWereldForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bNieuw;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lBallen;

    }
}

