namespace Filesharingapplicatie
{
    partial class AddCommentform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCommentform));
            this.bt_maakcomment = new System.Windows.Forms.Button();
            this.panel_comment = new System.Windows.Forms.Panel();
            this.tb_opmerking = new System.Windows.Forms.TextBox();
            this.lb_naam = new System.Windows.Forms.Label();
            this.lb_datum = new System.Windows.Forms.Label();
            this.panel_comment.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_maakcomment
            // 
            this.bt_maakcomment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_maakcomment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_maakcomment.ImageIndex = 10;
            this.bt_maakcomment.Location = new System.Drawing.Point(201, 104);
            this.bt_maakcomment.Name = "bt_maakcomment";
            this.bt_maakcomment.Size = new System.Drawing.Size(104, 32);
            this.bt_maakcomment.TabIndex = 18;
            this.bt_maakcomment.Text = "Plaats bericht";
            this.bt_maakcomment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_maakcomment.UseVisualStyleBackColor = true;
            this.bt_maakcomment.Click += new System.EventHandler(this.bt_maakcomment_Click);
            // 
            // panel_comment
            // 
            this.panel_comment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_comment.Controls.Add(this.tb_opmerking);
            this.panel_comment.Controls.Add(this.lb_naam);
            this.panel_comment.Controls.Add(this.lb_datum);
            this.panel_comment.Location = new System.Drawing.Point(12, 11);
            this.panel_comment.Name = "panel_comment";
            this.panel_comment.Size = new System.Drawing.Size(482, 87);
            this.panel_comment.TabIndex = 19;
            // 
            // tb_opmerking
            // 
            this.tb_opmerking.Location = new System.Drawing.Point(10, 31);
            this.tb_opmerking.MaxLength = 200;
            this.tb_opmerking.Multiline = true;
            this.tb_opmerking.Name = "tb_opmerking";
            this.tb_opmerking.Size = new System.Drawing.Size(460, 45);
            this.tb_opmerking.TabIndex = 22;
            // 
            // lb_naam
            // 
            this.lb_naam.AutoSize = true;
            this.lb_naam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_naam.Location = new System.Drawing.Point(5, 8);
            this.lb_naam.Name = "lb_naam";
            this.lb_naam.Size = new System.Drawing.Size(0, 13);
            this.lb_naam.TabIndex = 20;
            // 
            // lb_datum
            // 
            this.lb_datum.AutoSize = true;
            this.lb_datum.Location = new System.Drawing.Point(361, 8);
            this.lb_datum.Name = "lb_datum";
            this.lb_datum.Size = new System.Drawing.Size(0, 13);
            this.lb_datum.TabIndex = 21;
            // 
            // AddCommentform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(506, 144);
            this.Controls.Add(this.panel_comment);
            this.Controls.Add(this.bt_maakcomment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCommentform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opmerking Toevoegen";
            this.panel_comment.ResumeLayout(false);
            this.panel_comment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_maakcomment;
        private System.Windows.Forms.Panel panel_comment;
        private System.Windows.Forms.Label lb_naam;
        private System.Windows.Forms.Label lb_datum;
        private System.Windows.Forms.TextBox tb_opmerking;
    }
}