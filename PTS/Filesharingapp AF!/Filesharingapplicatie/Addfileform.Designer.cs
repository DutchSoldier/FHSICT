namespace Filesharingapplicatie
{
    partial class Addfileform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Addfileform));
            this.bt_browse = new System.Windows.Forms.Button();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tb_beschrijving = new System.Windows.Forms.TextBox();
            this.bt_accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_browse
            // 
            this.bt_browse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_browse.Location = new System.Drawing.Point(215, 8);
            this.bt_browse.Name = "bt_browse";
            this.bt_browse.Size = new System.Drawing.Size(31, 31);
            this.bt_browse.TabIndex = 0;
            this.tooltip.SetToolTip(this.bt_browse, "Browse");
            this.bt_browse.UseVisualStyleBackColor = true;
            this.bt_browse.Click += new System.EventHandler(this.bt_browse_Click);
            // 
            // tb_url
            // 
            this.tb_url.BackColor = System.Drawing.Color.White;
            this.tb_url.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_url.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tb_url.Location = new System.Drawing.Point(11, 15);
            this.tb_url.Name = "tb_url";
            this.tb_url.ReadOnly = true;
            this.tb_url.Size = new System.Drawing.Size(198, 20);
            this.tb_url.TabIndex = 1;
            this.tb_url.Text = "Bestandslocatie";
            // 
            // tb_beschrijving
            // 
            this.tb_beschrijving.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tb_beschrijving.Location = new System.Drawing.Point(12, 45);
            this.tb_beschrijving.MaxLength = 200;
            this.tb_beschrijving.Multiline = true;
            this.tb_beschrijving.Name = "tb_beschrijving";
            this.tb_beschrijving.Size = new System.Drawing.Size(234, 87);
            this.tb_beschrijving.TabIndex = 2;
            this.tb_beschrijving.Text = "Beschrijving";
            this.tb_beschrijving.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_beschrijving_MouseClick);
            // 
            // bt_accept
            // 
            this.bt_accept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_accept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_accept.Location = new System.Drawing.Point(12, 138);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(233, 56);
            this.bt_accept.TabIndex = 3;
            this.bt_accept.Text = "Bestand Uploaden";
            this.bt_accept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // Addfileform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(257, 202);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.tb_beschrijving);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.bt_browse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Addfileform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bestand Uploaden";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_browse;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.TextBox tb_beschrijving;
        private System.Windows.Forms.Button bt_accept;
    }
}