//MenuForm Designer

namespace Reserveringssysteem
{
    public partial class MenuForm
    {
        private System.Windows.Forms.Button btnNieuw;
        private System.Windows.Forms.Button btnWijzig;
        private System.Windows.Forms.Button btnVervers;
        private System.Windows.Forms.Button btnAnnuleer;
        private System.Windows.Forms.ListView listViewReserveringen;
        private System.Windows.Forms.ColumnHeader reserveringsID;
        private System.Windows.Forms.ColumnHeader reserveringsNaam;
        private System.Windows.Forms.ColumnHeader reserveringsPersonen;
        private System.Windows.Forms.TextBox txtZoekString;

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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.listViewReserveringen = new System.Windows.Forms.ListView();
            this.reserveringsID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reserveringsNaam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reserveringsPersonen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAnnuleer = new System.Windows.Forms.Button();
            this.btnVervers = new System.Windows.Forms.Button();
            this.btnWijzig = new System.Windows.Forms.Button();
            this.btnNieuw = new System.Windows.Forms.Button();
            this.txtZoekString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewReserveringen
            // 
            this.listViewReserveringen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewReserveringen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.reserveringsID,
            this.reserveringsNaam,
            this.reserveringsPersonen});
            this.listViewReserveringen.FullRowSelect = true;
            this.listViewReserveringen.HideSelection = false;
            this.listViewReserveringen.Location = new System.Drawing.Point(12, 45);
            this.listViewReserveringen.MultiSelect = false;
            this.listViewReserveringen.Name = "listViewReserveringen";
            this.listViewReserveringen.ShowGroups = false;
            this.listViewReserveringen.Size = new System.Drawing.Size(226, 158);
            this.listViewReserveringen.TabIndex = 1;
            this.listViewReserveringen.Tag = "Hier staan alle reserveringen die momenteel gemaakt zijn.";
            this.listViewReserveringen.UseCompatibleStateImageBehavior = false;
            this.listViewReserveringen.View = System.Windows.Forms.View.Details;
            // 
            // reserveringsID
            // 
            this.reserveringsID.Text = "ID";
            this.reserveringsID.Width = 40;
            // 
            // reserveringsNaam
            // 
            this.reserveringsNaam.Text = "Op naam van";
            this.reserveringsNaam.Width = 100;
            // 
            // reserveringsPersonen
            // 
            this.reserveringsPersonen.Text = "Personen";
            // 
            // btnAnnuleer
            // 
            this.btnAnnuleer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnuleer.Image = global::Reserveringssysteem.Properties.Resources.dialog_cancel;
            this.btnAnnuleer.Location = new System.Drawing.Point(244, 127);
            this.btnAnnuleer.Name = "btnAnnuleer";
            this.btnAnnuleer.Size = new System.Drawing.Size(96, 35);
            this.btnAnnuleer.TabIndex = 4;
            this.btnAnnuleer.Tag = "Verwijderd een reservering uit het systeem. Er verschijnt eerst een bevestigingsv" +
                "enster. ";
            this.btnAnnuleer.Text = "Annuleer reservering";
            this.btnAnnuleer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnuleer.UseVisualStyleBackColor = true;
            this.btnAnnuleer.Click += new System.EventHandler(this.BtnAnnuleer_Click);
            // 
            // btnVervers
            // 
            this.btnVervers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVervers.Image = global::Reserveringssysteem.Properties.Resources.gtk_refresh;
            this.btnVervers.Location = new System.Drawing.Point(244, 168);
            this.btnVervers.Name = "btnVervers";
            this.btnVervers.Size = new System.Drawing.Size(96, 35);
            this.btnVervers.TabIndex = 5;
            this.btnVervers.Tag = "Ververst de lijst met reserveringen, zodat reserveringen die door anderen applica" +
                "ties zijn toegevoegd ook zichtbaar worden.";
            this.btnVervers.Text = "Ververs lijst";
            this.btnVervers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVervers.UseVisualStyleBackColor = true;
            this.btnVervers.Click += new System.EventHandler(this.BtnVervers_Click);
            // 
            // btnWijzig
            // 
            this.btnWijzig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWijzig.Image = global::Reserveringssysteem.Properties.Resources.text_editor;
            this.btnWijzig.Location = new System.Drawing.Point(244, 86);
            this.btnWijzig.Name = "btnWijzig";
            this.btnWijzig.Size = new System.Drawing.Size(96, 35);
            this.btnWijzig.TabIndex = 3;
            this.btnWijzig.Tag = "Opend een venster waarmee de reservering die links geselecteerd is kan worden gew" +
                "ijzigd.";
            this.btnWijzig.Text = "Wijzig reservering";
            this.btnWijzig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWijzig.UseVisualStyleBackColor = true;
            this.btnWijzig.Click += new System.EventHandler(this.BtnWijzig_Click);
            // 
            // btnNieuw
            // 
            this.btnNieuw.AccessibleDescription = string.Empty;
            this.btnNieuw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNieuw.Image = global::Reserveringssysteem.Properties.Resources.list_add;
            this.btnNieuw.Location = new System.Drawing.Point(244, 45);
            this.btnNieuw.Name = "btnNieuw";
            this.btnNieuw.Size = new System.Drawing.Size(96, 35);
            this.btnNieuw.TabIndex = 2;
            this.btnNieuw.Tag = "Opent een nieuw venster waarmee een reservering kan worden toegevoegd.";
            this.btnNieuw.Text = "Nieuwe reservering";
            this.btnNieuw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNieuw.UseVisualStyleBackColor = true;
            this.btnNieuw.Click += new System.EventHandler(this.BtnNieuw_Click);
            // 
            // txtZoekString
            // 
            this.txtZoekString.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZoekString.Location = new System.Drawing.Point(13, 13);
            this.txtZoekString.MaxLength = 50;
            this.txtZoekString.Name = "txtZoekString";
            this.txtZoekString.Size = new System.Drawing.Size(225, 26);
            this.txtZoekString.TabIndex = 0;
            this.txtZoekString.Tag = "Voer een zoekwoord in en de zoekresultaten zullen in de lijst hieronder weergegev" +
                "en worden.";
            this.txtZoekString.Enter += new System.EventHandler(this.TxtZoekString_Enter);
            this.txtZoekString.Leave += new System.EventHandler(this.TxtZoekString_Leave);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 213);
            this.Controls.Add(this.txtZoekString);
            this.Controls.Add(this.listViewReserveringen);
            this.Controls.Add(this.btnAnnuleer);
            this.Controls.Add(this.btnVervers);
            this.Controls.Add(this.btnWijzig);
            this.Controls.Add(this.btnNieuw);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(361, 251);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beheer uw reserveringen";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}