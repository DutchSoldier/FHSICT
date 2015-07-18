namespace Filesharingapplicatie
{
    partial class Filesharingform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filesharingform));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Mijn Bestanden", 9, 9);
            this.imagelist_icons22x22 = new System.Windows.Forms.ImageList(this.components);
            this.Treeview_categories = new System.Windows.Forms.TreeView();
            this.imagelist_icons48x48 = new System.Windows.Forms.ImageList(this.components);
            this.tb_search = new System.Windows.Forms.TextBox();
            this.panel_filebeschrijving = new System.Windows.Forms.Panel();
            this.bt_dontlike = new System.Windows.Forms.Button();
            this.bt_like = new System.Windows.Forms.Button();
            this.bt_maakcomment = new System.Windows.Forms.Button();
            this.lb_uploadervar = new System.Windows.Forms.Label();
            this.lb_auteur = new System.Windows.Forms.Label();
            this.lb_ratingvar = new System.Windows.Forms.Label();
            this.lb_aantaldownloadsvar = new System.Windows.Forms.Label();
            this.lb_datumgeuploadvar = new System.Windows.Forms.Label();
            this.lb_groottevar = new System.Windows.Forms.Label();
            this.lb_beschrijvingvar = new System.Windows.Forms.Label();
            this.tb_beschrijving = new System.Windows.Forms.TextBox();
            this.lb_beschrijving = new System.Windows.Forms.Label();
            this.lb_rating = new System.Windows.Forms.Label();
            this.lb_aantaldownloads = new System.Windows.Forms.Label();
            this.lb_datum = new System.Windows.Forms.Label();
            this.lb_grootte = new System.Windows.Forms.Label();
            this.lb_bestandnaam = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.bt_remove = new System.Windows.Forms.Button();
            this.bt_download = new System.Windows.Forms.Button();
            this.bt_verwijdermap = new System.Windows.Forms.Button();
            this.bt_nieuwemap = new System.Windows.Forms.Button();
            this.bt_clearall = new System.Windows.Forms.Button();
            this.bt_searchfilename = new System.Windows.Forms.Button();
            this.bt_searchmapname = new System.Windows.Forms.Button();
            this.bt_searchauthorname = new System.Windows.Forms.Button();
            this.bt_upload = new System.Windows.Forms.Button();
            this.panel_comments = new System.Windows.Forms.Panel();
            this.listv_files = new System.Windows.Forms.ListView();
            this.column_naam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_grootte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_rating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel_filebeschrijving.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagelist_icons22x22
            // 
            this.imagelist_icons22x22.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelist_icons22x22.ImageStream")));
            this.imagelist_icons22x22.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelist_icons22x22.Images.SetKeyName(0, "document-open.png");
            this.imagelist_icons22x22.Images.SetKeyName(1, "applications-graphics.png");
            this.imagelist_icons22x22.Images.SetKeyName(2, "applications-multimedia.png");
            this.imagelist_icons22x22.Images.SetKeyName(3, "applications-system.png");
            this.imagelist_icons22x22.Images.SetKeyName(4, "gnome-dev-cdrom-audio.png");
            this.imagelist_icons22x22.Images.SetKeyName(5, "ascii.png");
            this.imagelist_icons22x22.Images.SetKeyName(6, "x-office-document.png");
            this.imagelist_icons22x22.Images.SetKeyName(7, "zip.png");
            this.imagelist_icons22x22.Images.SetKeyName(8, "gnome-help.png");
            this.imagelist_icons22x22.Images.SetKeyName(9, "folder_home.png");
            this.imagelist_icons22x22.Images.SetKeyName(10, "xchat.png");
            this.imagelist_icons22x22.Images.SetKeyName(11, "cdwriter_unmount.png");
            this.imagelist_icons22x22.Images.SetKeyName(12, "leuk.PNG");
            this.imagelist_icons22x22.Images.SetKeyName(13, "nietLeuk.PNG");
            // 
            // Treeview_categories
            // 
            this.Treeview_categories.BackColor = System.Drawing.Color.White;
            this.Treeview_categories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Treeview_categories.HideSelection = false;
            this.Treeview_categories.ImageIndex = 0;
            this.Treeview_categories.ImageList = this.imagelist_icons22x22;
            this.Treeview_categories.Indent = 25;
            this.Treeview_categories.Location = new System.Drawing.Point(13, 78);
            this.Treeview_categories.Name = "Treeview_categories";
            treeNode1.ImageIndex = 9;
            treeNode1.Name = "Mijn_Bestanden";
            treeNode1.SelectedImageIndex = 9;
            treeNode1.Text = "Mijn Bestanden";
            this.Treeview_categories.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.Treeview_categories.SelectedImageIndex = 0;
            this.Treeview_categories.ShowPlusMinus = false;
            this.Treeview_categories.ShowRootLines = false;
            this.Treeview_categories.Size = new System.Drawing.Size(432, 364);
            this.Treeview_categories.TabIndex = 1;
            this.Treeview_categories.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Treeview_categories_NodeMouseClick_1);
            // 
            // imagelist_icons48x48
            // 
            this.imagelist_icons48x48.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelist_icons48x48.ImageStream")));
            this.imagelist_icons48x48.TransparentColor = System.Drawing.Color.White;
            this.imagelist_icons48x48.Images.SetKeyName(0, "addfile.png");
            this.imagelist_icons48x48.Images.SetKeyName(1, "document-save.png");
            this.imagelist_icons48x48.Images.SetKeyName(2, "delfile.png");
            this.imagelist_icons48x48.Images.SetKeyName(3, "edit-find.png");
            this.imagelist_icons48x48.Images.SetKeyName(4, "file-manager.png");
            this.imagelist_icons48x48.Images.SetKeyName(5, "stock_search-and-replace.png");
            this.imagelist_icons48x48.Images.SetKeyName(6, "addmap.png");
            this.imagelist_icons48x48.Images.SetKeyName(7, "delmap.png");
            this.imagelist_icons48x48.Images.SetKeyName(8, "stock_home.png");
            this.imagelist_icons48x48.Images.SetKeyName(9, "edittrash.png");
            // 
            // tb_search
            // 
            this.tb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tb_search.Location = new System.Drawing.Point(239, 28);
            this.tb_search.MaxLength = 15;
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(168, 26);
            this.tb_search.TabIndex = 11;
            this.tb_search.Text = "Zoekwoord";
            this.tb_search.Click += new System.EventHandler(this.tb_search_Click);
            // 
            // panel_filebeschrijving
            // 
            this.panel_filebeschrijving.BackColor = System.Drawing.Color.White;
            this.panel_filebeschrijving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_filebeschrijving.Controls.Add(this.bt_dontlike);
            this.panel_filebeschrijving.Controls.Add(this.bt_like);
            this.panel_filebeschrijving.Controls.Add(this.bt_maakcomment);
            this.panel_filebeschrijving.Controls.Add(this.lb_uploadervar);
            this.panel_filebeschrijving.Controls.Add(this.lb_auteur);
            this.panel_filebeschrijving.Controls.Add(this.lb_ratingvar);
            this.panel_filebeschrijving.Controls.Add(this.lb_aantaldownloadsvar);
            this.panel_filebeschrijving.Controls.Add(this.lb_datumgeuploadvar);
            this.panel_filebeschrijving.Controls.Add(this.lb_groottevar);
            this.panel_filebeschrijving.Controls.Add(this.lb_beschrijvingvar);
            this.panel_filebeschrijving.Controls.Add(this.tb_beschrijving);
            this.panel_filebeschrijving.Controls.Add(this.lb_beschrijving);
            this.panel_filebeschrijving.Controls.Add(this.lb_rating);
            this.panel_filebeschrijving.Controls.Add(this.lb_aantaldownloads);
            this.panel_filebeschrijving.Controls.Add(this.lb_datum);
            this.panel_filebeschrijving.Controls.Add(this.lb_grootte);
            this.panel_filebeschrijving.Controls.Add(this.lb_bestandnaam);
            this.panel_filebeschrijving.Location = new System.Drawing.Point(451, 78);
            this.panel_filebeschrijving.Name = "panel_filebeschrijving";
            this.panel_filebeschrijving.Size = new System.Drawing.Size(522, 198);
            this.panel_filebeschrijving.TabIndex = 12;
            // 
            // bt_dontlike
            // 
            this.bt_dontlike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_dontlike.ImageIndex = 13;
            this.bt_dontlike.ImageList = this.imagelist_icons22x22;
            this.bt_dontlike.Location = new System.Drawing.Point(485, 161);
            this.bt_dontlike.Name = "bt_dontlike";
            this.bt_dontlike.Size = new System.Drawing.Size(32, 32);
            this.bt_dontlike.TabIndex = 19;
            this.bt_dontlike.UseVisualStyleBackColor = true;
            this.bt_dontlike.Click += new System.EventHandler(this.bt_dontlike_Click);
            // 
            // bt_like
            // 
            this.bt_like.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_like.ImageIndex = 12;
            this.bt_like.ImageList = this.imagelist_icons22x22;
            this.bt_like.Location = new System.Drawing.Point(447, 161);
            this.bt_like.Name = "bt_like";
            this.bt_like.Size = new System.Drawing.Size(32, 32);
            this.bt_like.TabIndex = 18;
            this.bt_like.UseVisualStyleBackColor = true;
            this.bt_like.Click += new System.EventHandler(this.bt_like_Click);
            // 
            // bt_maakcomment
            // 
            this.bt_maakcomment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_maakcomment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_maakcomment.ImageIndex = 10;
            this.bt_maakcomment.ImageList = this.imagelist_icons22x22;
            this.bt_maakcomment.Location = new System.Drawing.Point(180, 158);
            this.bt_maakcomment.Name = "bt_maakcomment";
            this.bt_maakcomment.Size = new System.Drawing.Size(150, 32);
            this.bt_maakcomment.TabIndex = 17;
            this.bt_maakcomment.Text = "Laat een bericht achter";
            this.bt_maakcomment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_maakcomment.UseVisualStyleBackColor = true;
            this.bt_maakcomment.Click += new System.EventHandler(this.bt_maakcomment_Click);
            // 
            // lb_uploadervar
            // 
            this.lb_uploadervar.AutoSize = true;
            this.lb_uploadervar.Location = new System.Drawing.Point(339, 30);
            this.lb_uploadervar.Name = "lb_uploadervar";
            this.lb_uploadervar.Size = new System.Drawing.Size(0, 13);
            this.lb_uploadervar.TabIndex = 16;
            // 
            // lb_auteur
            // 
            this.lb_auteur.AutoSize = true;
            this.lb_auteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_auteur.Location = new System.Drawing.Point(260, 30);
            this.lb_auteur.Name = "lb_auteur";
            this.lb_auteur.Size = new System.Drawing.Size(62, 13);
            this.lb_auteur.TabIndex = 15;
            this.lb_auteur.Text = "Uploader:";
            // 
            // lb_ratingvar
            // 
            this.lb_ratingvar.AutoSize = true;
            this.lb_ratingvar.Location = new System.Drawing.Point(339, 74);
            this.lb_ratingvar.Name = "lb_ratingvar";
            this.lb_ratingvar.Size = new System.Drawing.Size(0, 13);
            this.lb_ratingvar.TabIndex = 14;
            // 
            // lb_aantaldownloadsvar
            // 
            this.lb_aantaldownloadsvar.AutoSize = true;
            this.lb_aantaldownloadsvar.Location = new System.Drawing.Point(339, 52);
            this.lb_aantaldownloadsvar.Name = "lb_aantaldownloadsvar";
            this.lb_aantaldownloadsvar.Size = new System.Drawing.Size(0, 13);
            this.lb_aantaldownloadsvar.TabIndex = 13;
            // 
            // lb_datumgeuploadvar
            // 
            this.lb_datumgeuploadvar.AutoSize = true;
            this.lb_datumgeuploadvar.Location = new System.Drawing.Point(116, 52);
            this.lb_datumgeuploadvar.Name = "lb_datumgeuploadvar";
            this.lb_datumgeuploadvar.Size = new System.Drawing.Size(0, 13);
            this.lb_datumgeuploadvar.TabIndex = 9;
            // 
            // lb_groottevar
            // 
            this.lb_groottevar.AutoSize = true;
            this.lb_groottevar.Location = new System.Drawing.Point(116, 30);
            this.lb_groottevar.Name = "lb_groottevar";
            this.lb_groottevar.Size = new System.Drawing.Size(0, 13);
            this.lb_groottevar.TabIndex = 8;
            // 
            // lb_beschrijvingvar
            // 
            this.lb_beschrijvingvar.AutoSize = true;
            this.lb_beschrijvingvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_beschrijvingvar.Location = new System.Drawing.Point(116, 8);
            this.lb_beschrijvingvar.Name = "lb_beschrijvingvar";
            this.lb_beschrijvingvar.Size = new System.Drawing.Size(0, 13);
            this.lb_beschrijvingvar.TabIndex = 7;
            // 
            // tb_beschrijving
            // 
            this.tb_beschrijving.BackColor = System.Drawing.Color.White;
            this.tb_beschrijving.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_beschrijving.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_beschrijving.Location = new System.Drawing.Point(9, 98);
            this.tb_beschrijving.Multiline = true;
            this.tb_beschrijving.Name = "tb_beschrijving";
            this.tb_beschrijving.Size = new System.Drawing.Size(499, 52);
            this.tb_beschrijving.TabIndex = 6;
            // 
            // lb_beschrijving
            // 
            this.lb_beschrijving.AutoSize = true;
            this.lb_beschrijving.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_beschrijving.Location = new System.Drawing.Point(5, 74);
            this.lb_beschrijving.Name = "lb_beschrijving";
            this.lb_beschrijving.Size = new System.Drawing.Size(80, 13);
            this.lb_beschrijving.TabIndex = 5;
            this.lb_beschrijving.Text = "Beschrijving:";
            // 
            // lb_rating
            // 
            this.lb_rating.AutoSize = true;
            this.lb_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rating.Location = new System.Drawing.Point(260, 74);
            this.lb_rating.Name = "lb_rating";
            this.lb_rating.Size = new System.Drawing.Size(48, 13);
            this.lb_rating.TabIndex = 4;
            this.lb_rating.Text = "Rating:";
            // 
            // lb_aantaldownloads
            // 
            this.lb_aantaldownloads.AutoSize = true;
            this.lb_aantaldownloads.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_aantaldownloads.Location = new System.Drawing.Point(260, 52);
            this.lb_aantaldownloads.Name = "lb_aantaldownloads";
            this.lb_aantaldownloads.Size = new System.Drawing.Size(73, 13);
            this.lb_aantaldownloads.TabIndex = 3;
            this.lb_aantaldownloads.Text = "Downloads:";
            // 
            // lb_datum
            // 
            this.lb_datum.AutoSize = true;
            this.lb_datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_datum.Location = new System.Drawing.Point(5, 52);
            this.lb_datum.Name = "lb_datum";
            this.lb_datum.Size = new System.Drawing.Size(105, 13);
            this.lb_datum.TabIndex = 2;
            this.lb_datum.Text = "Datum Geupload:";
            // 
            // lb_grootte
            // 
            this.lb_grootte.AutoSize = true;
            this.lb_grootte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_grootte.Location = new System.Drawing.Point(5, 30);
            this.lb_grootte.Name = "lb_grootte";
            this.lb_grootte.Size = new System.Drawing.Size(53, 13);
            this.lb_grootte.TabIndex = 1;
            this.lb_grootte.Text = "Grootte:";
            // 
            // lb_bestandnaam
            // 
            this.lb_bestandnaam.AutoSize = true;
            this.lb_bestandnaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bestandnaam.Location = new System.Drawing.Point(5, 8);
            this.lb_bestandnaam.Name = "lb_bestandnaam";
            this.lb_bestandnaam.Size = new System.Drawing.Size(87, 13);
            this.lb_bestandnaam.TabIndex = 0;
            this.lb_bestandnaam.Text = "Bestandnaam:";
            // 
            // bt_remove
            // 
            this.bt_remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_remove.Enabled = false;
            this.bt_remove.ImageIndex = 2;
            this.bt_remove.ImageList = this.imagelist_icons48x48;
            this.bt_remove.Location = new System.Drawing.Point(583, 12);
            this.bt_remove.Name = "bt_remove";
            this.bt_remove.Size = new System.Drawing.Size(60, 60);
            this.bt_remove.TabIndex = 19;
            this.tooltip.SetToolTip(this.bt_remove, "Bestand Verwijderen");
            this.bt_remove.UseVisualStyleBackColor = true;
            this.bt_remove.Click += new System.EventHandler(this.bt_remove_Click);
            // 
            // bt_download
            // 
            this.bt_download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_download.Enabled = false;
            this.bt_download.ImageIndex = 1;
            this.bt_download.ImageList = this.imagelist_icons48x48;
            this.bt_download.Location = new System.Drawing.Point(451, 12);
            this.bt_download.Name = "bt_download";
            this.bt_download.Size = new System.Drawing.Size(60, 60);
            this.bt_download.TabIndex = 18;
            this.tooltip.SetToolTip(this.bt_download, "Bestand Downloaden");
            this.bt_download.UseVisualStyleBackColor = true;
            this.bt_download.Click += new System.EventHandler(this.bt_download_Click);
            // 
            // bt_verwijdermap
            // 
            this.bt_verwijdermap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_verwijdermap.Enabled = false;
            this.bt_verwijdermap.ImageIndex = 7;
            this.bt_verwijdermap.ImageList = this.imagelist_icons48x48;
            this.bt_verwijdermap.Location = new System.Drawing.Point(781, 12);
            this.bt_verwijdermap.Name = "bt_verwijdermap";
            this.bt_verwijdermap.Size = new System.Drawing.Size(60, 60);
            this.bt_verwijdermap.TabIndex = 17;
            this.tooltip.SetToolTip(this.bt_verwijdermap, "Map Verwijderen");
            this.bt_verwijdermap.UseVisualStyleBackColor = true;
            this.bt_verwijdermap.Click += new System.EventHandler(this.bt_verwijdermap_Click);
            // 
            // bt_nieuwemap
            // 
            this.bt_nieuwemap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_nieuwemap.Enabled = false;
            this.bt_nieuwemap.ImageIndex = 6;
            this.bt_nieuwemap.ImageList = this.imagelist_icons48x48;
            this.bt_nieuwemap.Location = new System.Drawing.Point(715, 12);
            this.bt_nieuwemap.Name = "bt_nieuwemap";
            this.bt_nieuwemap.Size = new System.Drawing.Size(60, 60);
            this.bt_nieuwemap.TabIndex = 9;
            this.tooltip.SetToolTip(this.bt_nieuwemap, "Map Toevoegen");
            this.bt_nieuwemap.UseVisualStyleBackColor = true;
            this.bt_nieuwemap.Click += new System.EventHandler(this.bt_nieuwemap_Click);
            // 
            // bt_clearall
            // 
            this.bt_clearall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_clearall.Enabled = false;
            this.bt_clearall.ImageIndex = 9;
            this.bt_clearall.ImageList = this.imagelist_icons48x48;
            this.bt_clearall.Location = new System.Drawing.Point(913, 12);
            this.bt_clearall.Name = "bt_clearall";
            this.bt_clearall.Size = new System.Drawing.Size(60, 60);
            this.bt_clearall.TabIndex = 8;
            this.tooltip.SetToolTip(this.bt_clearall, "Schoonmaken");
            this.bt_clearall.UseVisualStyleBackColor = true;
            this.bt_clearall.Click += new System.EventHandler(this.bt_clearall_Click);
            // 
            // bt_searchfilename
            // 
            this.bt_searchfilename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_searchfilename.ImageIndex = 3;
            this.bt_searchfilename.ImageList = this.imagelist_icons48x48;
            this.bt_searchfilename.Location = new System.Drawing.Point(13, 12);
            this.bt_searchfilename.Name = "bt_searchfilename";
            this.bt_searchfilename.Size = new System.Drawing.Size(60, 60);
            this.bt_searchfilename.TabIndex = 5;
            this.tooltip.SetToolTip(this.bt_searchfilename, "Zoeken op Bestandnaam");
            this.bt_searchfilename.UseVisualStyleBackColor = true;
            this.bt_searchfilename.Click += new System.EventHandler(this.bt_searchfilename_Click);
            // 
            // bt_searchmapname
            // 
            this.bt_searchmapname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_searchmapname.ImageIndex = 4;
            this.bt_searchmapname.ImageList = this.imagelist_icons48x48;
            this.bt_searchmapname.Location = new System.Drawing.Point(145, 12);
            this.bt_searchmapname.Name = "bt_searchmapname";
            this.bt_searchmapname.Size = new System.Drawing.Size(60, 60);
            this.bt_searchmapname.TabIndex = 4;
            this.tooltip.SetToolTip(this.bt_searchmapname, "Zoeken op Mapnaam");
            this.bt_searchmapname.UseVisualStyleBackColor = true;
            this.bt_searchmapname.Click += new System.EventHandler(this.bt_searchmapname_Click);
            // 
            // bt_searchauthorname
            // 
            this.bt_searchauthorname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_searchauthorname.ImageIndex = 5;
            this.bt_searchauthorname.ImageList = this.imagelist_icons48x48;
            this.bt_searchauthorname.Location = new System.Drawing.Point(79, 12);
            this.bt_searchauthorname.Name = "bt_searchauthorname";
            this.bt_searchauthorname.Size = new System.Drawing.Size(60, 60);
            this.bt_searchauthorname.TabIndex = 3;
            this.tooltip.SetToolTip(this.bt_searchauthorname, "Zoeken op Auteurnaam");
            this.bt_searchauthorname.UseVisualStyleBackColor = true;
            this.bt_searchauthorname.Click += new System.EventHandler(this.bt_searchauthorname_Click);
            // 
            // bt_upload
            // 
            this.bt_upload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_upload.Enabled = false;
            this.bt_upload.ImageIndex = 0;
            this.bt_upload.ImageList = this.imagelist_icons48x48;
            this.bt_upload.Location = new System.Drawing.Point(517, 12);
            this.bt_upload.Name = "bt_upload";
            this.bt_upload.Size = new System.Drawing.Size(60, 60);
            this.bt_upload.TabIndex = 2;
            this.tooltip.SetToolTip(this.bt_upload, "Bestand Uploaden");
            this.bt_upload.UseVisualStyleBackColor = true;
            this.bt_upload.Click += new System.EventHandler(this.bt_upload_Click);
            // 
            // panel_comments
            // 
            this.panel_comments.AutoScroll = true;
            this.panel_comments.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panel_comments.BackColor = System.Drawing.Color.White;
            this.panel_comments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_comments.Location = new System.Drawing.Point(451, 282);
            this.panel_comments.Name = "panel_comments";
            this.panel_comments.Size = new System.Drawing.Size(522, 160);
            this.panel_comments.TabIndex = 17;
            // 
            // listv_files
            // 
            this.listv_files.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listv_files.AutoArrange = false;
            this.listv_files.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listv_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_naam,
            this.column_grootte,
            this.column_rating});
            this.listv_files.FullRowSelect = true;
            this.listv_files.Location = new System.Drawing.Point(451, 78);
            this.listv_files.MultiSelect = false;
            this.listv_files.Name = "listv_files";
            this.listv_files.Size = new System.Drawing.Size(522, 364);
            this.listv_files.SmallImageList = this.imagelist_icons22x22;
            this.listv_files.TabIndex = 20;
            this.listv_files.UseCompatibleStateImageBehavior = false;
            this.listv_files.View = System.Windows.Forms.View.Details;
            this.listv_files.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listv_files_ColumnClick);
            this.listv_files.Click += new System.EventHandler(this.listv_files_Click);
            // 
            // column_naam
            // 
            this.column_naam.Text = "Bestandnaam";
            this.column_naam.Width = 200;
            // 
            // column_grootte
            // 
            this.column_grootte.Text = "Grootte";
            this.column_grootte.Width = 160;
            // 
            // column_rating
            // 
            this.column_rating.Text = "Rating";
            this.column_rating.Width = 160;
            // 
            // Filesharingform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(986, 454);
            this.Controls.Add(this.listv_files);
            this.Controls.Add(this.panel_comments);
            this.Controls.Add(this.bt_remove);
            this.Controls.Add(this.bt_download);
            this.Controls.Add(this.bt_verwijdermap);
            this.Controls.Add(this.panel_filebeschrijving);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.bt_nieuwemap);
            this.Controls.Add(this.bt_clearall);
            this.Controls.Add(this.bt_searchfilename);
            this.Controls.Add(this.bt_searchmapname);
            this.Controls.Add(this.bt_searchauthorname);
            this.Controls.Add(this.bt_upload);
            this.Controls.Add(this.Treeview_categories);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Filesharingform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filesharing";
            this.panel_filebeschrijving.ResumeLayout(false);
            this.panel_filebeschrijving.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_upload;
        private System.Windows.Forms.Button bt_searchauthorname;
        private System.Windows.Forms.Button bt_searchmapname;
        private System.Windows.Forms.Button bt_searchfilename;
        private System.Windows.Forms.Button bt_clearall;
        private System.Windows.Forms.Button bt_nieuwemap;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Panel panel_filebeschrijving;
        private System.Windows.Forms.Label lb_beschrijving;
        private System.Windows.Forms.Label lb_rating;
        private System.Windows.Forms.Label lb_aantaldownloads;
        private System.Windows.Forms.Label lb_datum;
        private System.Windows.Forms.Label lb_grootte;
        private System.Windows.Forms.Label lb_bestandnaam;
        private System.Windows.Forms.Label lb_ratingvar;
        private System.Windows.Forms.Label lb_aantaldownloadsvar;
        private System.Windows.Forms.Label lb_datumgeuploadvar;
        private System.Windows.Forms.Label lb_groottevar;
        private System.Windows.Forms.Label lb_beschrijvingvar;
        private System.Windows.Forms.TextBox tb_beschrijving;
        private System.Windows.Forms.Label lb_uploadervar;
        private System.Windows.Forms.Label lb_auteur;
        private System.Windows.Forms.Button bt_verwijdermap;
        private System.Windows.Forms.Button bt_download;
        private System.Windows.Forms.Button bt_remove;
        private System.Windows.Forms.ToolTip tooltip;
        public System.Windows.Forms.ImageList imagelist_icons48x48;
        public System.Windows.Forms.ImageList imagelist_icons22x22;
        private System.Windows.Forms.Button bt_maakcomment;
        private System.Windows.Forms.ColumnHeader column_naam;
        private System.Windows.Forms.ColumnHeader column_grootte;
        private System.Windows.Forms.ColumnHeader column_rating;
        public System.Windows.Forms.TreeView Treeview_categories;
        public System.Windows.Forms.ListView listv_files;
        private System.Windows.Forms.Button bt_like;
        private System.Windows.Forms.Button bt_dontlike;
        public System.Windows.Forms.Panel panel_comments;
    }
}

