namespace Filesharingapplicatie
{
    partial class Addmapform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Addmapform));
            this.tb_mapnaam = new System.Windows.Forms.TextBox();
            this.bt_accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_mapnaam
            // 
            this.tb_mapnaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_mapnaam.Location = new System.Drawing.Point(13, 12);
            this.tb_mapnaam.MaxLength = 15;
            this.tb_mapnaam.Name = "tb_mapnaam";
            this.tb_mapnaam.Size = new System.Drawing.Size(200, 26);
            this.tb_mapnaam.TabIndex = 0;
            this.tb_mapnaam.Text = "Nieuwe Map";
            // 
            // bt_accept
            // 
            this.bt_accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_accept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_accept.Location = new System.Drawing.Point(13, 44);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(200, 56);
            this.bt_accept.TabIndex = 1;
            this.bt_accept.Text = "Map Toevoegen";
            this.bt_accept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // Addmapform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(226, 112);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.tb_mapnaam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Addmapform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map Toevoegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_mapnaam;
        private System.Windows.Forms.Button bt_accept;
    }
}