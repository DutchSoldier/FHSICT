using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Filesharingapplicatie
{
    public partial class Filesharingform : Form
    {
        // data
        public string RFID;
        type_gebruiker type;
        public Categorie folder_selection;
        public File file_selection;

        // constructor
        public Filesharingform()
        {
            InitializeComponent();
            Inlogform form = new Inlogform();
            form.ShowDialog();
            this.RFID = form.RFID;
            this.type = form.type;
            if (type == type_gebruiker.Medewerker)
            {
                bt_clearall.Enabled = true;
            }
            Treeview_categories.Nodes.Add(new Categorie(0, "Root", 0));
            File[] files = null;
            try
            {
                files = DatabaseKoppeling.searchUserFiles(RFID).ToArray();
            }
            catch
            {
                MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listv_files.Items.AddRange(files);
        }

        // methoden
        private void bt_searchfilename_Click(object sender, EventArgs e)
        {
            try
            {
                listv_files.Visible = true;
                listv_files.Items.Clear();
                File[] files = DatabaseKoppeling.searchFileNameDesc(tb_search.Text).ToArray();
                listv_files.Items.AddRange(files);
            }
            catch
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // haalt uit de database alle bestanden die in de naam en/of beschrijving het sleutelwoord bevatten en laat deze netjes zien

        private void bt_searchauthorname_Click(object sender, EventArgs e)
        {
            try
            {
                listv_files.Visible = true;
                listv_files.Items.Clear();
                File[] files = DatabaseKoppeling.searchUserFiles(tb_search.Text).ToArray();
                listv_files.Items.AddRange(files);
            }
            catch
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // haalt uit de database alle bestanden die als auteur het sleutelwoord hebben en laat deze netjes zien

        private void bt_searchmapname_Click(object sender, EventArgs e)
        {
            try
            {
                listv_files.Visible = true;
                listv_files.Items.Clear();
                File[] files = DatabaseKoppeling.searchCategories(tb_search.Text).ToArray();
                listv_files.Items.AddRange(files);
            }
            catch
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // haalt uit de database alle bestanden waarvan de namen van de mappen waarin ze zitten het sleutelwoord bevatten

        private void bt_download_Click(object sender, EventArgs e)
        {
            try
            {
                Thread processThread = new Thread(ServerKoppeling.requestFile);
                processThread.Start(file_selection.Pad);
                Loadingform loadingform = new Loadingform(processThread);
                loadingform.ShowDialog();
                ServerKoppeling.requestFile(file_selection.Pad);
                DatabaseKoppeling.downloadsOneUp(file_selection.Bestand_id);
                file_selection.DownloadsOneUp();
                lb_aantaldownloadsvar.Text = file_selection.Gedownload.ToString();
            }
            catch
            {
                MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // begin met het downloaden van de geselecteerde file en verhoogt het aantal_downloads van de file in de database met 1

        private void bt_upload_Click(object sender, EventArgs e)
        {
            Addfileform addfileform = new Addfileform(this);
            addfileform.ShowDialog();
        }   // roept een instance van de Addfileform op

        private void bt_remove_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseKoppeling.deleteFile(file_selection.Bestand_id);
                ServerKoppeling.deleteFile(file_selection.Pad);
                listv_files.Visible = true;
                bt_download.Enabled = false;
                bt_remove.Enabled = false;
                if (folder_selection != null)
                {
                    if (type == type_gebruiker.Medewerker)
                    {
                        bt_nieuwemap.Enabled = true;
                        bt_verwijdermap.Enabled = true;
                    }
                    bt_upload.Enabled = true;
                }
                file_selection.Remove();
            }
            catch
            {
                MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // verwijderd het geselecteerde bestand van de server en uit de database

        private void bt_nieuwemap_Click(object sender, EventArgs e)
        {
            Addmapform addmapform = new Addmapform(this, folder_selection);
            addmapform.ShowDialog();
        }   // roept een instance van de Addmapform op

        private void bt_verwijdermap_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseKoppeling.deleteFolder(folder_selection.Map_id);
                ServerKoppeling.deleteFolder(folder_selection.FullPath);
                Treeview_categories.Nodes.Remove(folder_selection);
                listv_files.Items.Clear();
                bt_verwijdermap.Enabled = false;
                bt_nieuwemap.Enabled = false;
                bt_upload.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // verwijderd de geselecteerde map van de server en uit de database

        private void bt_clearall_Click(object sender, EventArgs e)
        {
            Schoonmaakform schoonmaakform = new Schoonmaakform(this);
            schoonmaakform.ShowDialog();
        }   // roept een instance van de Schoonmaakform op

        private void bt_maakcomment_Click(object sender, EventArgs e)
        {
            AddCommentform commentform = new AddCommentform(this);
            commentform.ShowDialog();
        }   // roept een instance van de AddCommentform op

        private void Treeview_categories_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e) // haalt uit de database alle submappen en files in de geselecteerde map en laat deze netjes zien
        {
            try
            {
                // root gedeelte
                if (e.Node.Text == "Mijn Bestanden")
                {
                    File[] files = DatabaseKoppeling.searchUserFiles(RFID).ToArray();
                    listv_files.Items.Clear();
                    listv_files.Items.AddRange(files);
                    bt_verwijdermap.Enabled = false;
                    bt_nieuwemap.Enabled = false;
                    bt_upload.Enabled = false;
                }
                else
                {
                    Categorie current = e.Node as Categorie;
                    current.Nodes.Clear();
                    Categorie[] lijst = DatabaseKoppeling.getFolders(current.Map_id).ToArray();
                    current.Nodes.AddRange(lijst);
                    current.Expand();
                    folder_selection = current;
                    if (type == type_gebruiker.Medewerker)
                    {
                        bt_nieuwemap.Enabled = true;
                        if (current.Map_id != 0)
                        {
                            bt_verwijdermap.Enabled = true;
                        }
                        else
                        {
                            bt_verwijdermap.Enabled = false;
                        }
                    }
                    bt_upload.Enabled = true;
                    //

                    // files gedeelte
                    File[] files = DatabaseKoppeling.getFiles(current.Map_id).ToArray();
                    listv_files.Items.Clear();
                    listv_files.Items.AddRange(files);
                }

                // general gedeelte
                listv_files.Visible = true;
                bt_download.Enabled = false;
                bt_remove.Enabled = false;
                //
            }
            catch
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_search_Click(object sender, EventArgs e)
        {
            tb_search.ForeColor = Color.Black;
            tb_search.Clear();
        }   // verzorgt de opmaak van tb_search

        private void listv_files_Click(object sender, EventArgs e)
        {
            File file = listv_files.SelectedItems[0] as File;
            file_selection = file;

            bt_like.Enabled = true;
            bt_dontlike.Enabled = true;

            listv_files.Visible = false;
            bt_download.Enabled = true;
            if (file_selection.Rfid == RFID || type == type_gebruiker.Medewerker)
            {
                bt_remove.Enabled = true;
            }
            bt_nieuwemap.Enabled = false;
            bt_upload.Enabled = false;
            bt_verwijdermap.Enabled = false;
            
            lb_aantaldownloadsvar.Text = file.Gedownload.ToString();
            lb_beschrijvingvar.Text = file.Naam;
            tb_beschrijving.Text = file.Beschrijving;
            lb_datumgeuploadvar.Text = file.Datum.ToString();
            lb_groottevar.Text = FileHelper.getGrootte(file.Grootte);
            lb_ratingvar.Text = file.Rating.ToString();
            lb_uploadervar.Text = file.Rfid;


            panel_comments.Controls.Clear();
            try
            {
                foreach (Opmerking comment in DatabaseKoppeling.getComments(file_selection.Bestand_id))
                {
                    panel_comments.Controls.Add(comment);
                }
            }
            catch
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // laat alle informatie van de geselecteerde file zien en laad alle bijbehorende opmerkingen uit de database

        private void bt_like_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseKoppeling.ratingOneUp(1, file_selection.Bestand_id);
                bt_like.Enabled = false;
                bt_dontlike.Enabled = false;
                file_selection.EditRating(1);
                lb_ratingvar.Text = file_selection.Rating.ToString();
            }
            catch
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // verhoogt de rating van de geselecteerde file in de database met 1

        private void bt_dontlike_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseKoppeling.ratingOneUp(-1, file_selection.Bestand_id);
                bt_like.Enabled = false;
                bt_dontlike.Enabled = false;
                file_selection.EditRating(-1);
                lb_ratingvar.Text = file_selection.Rating.ToString();
            }
            catch
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // verlaagt de rating van de geselecteerde file in de database met 1

        private void listv_files_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            List<File> help_a = new List<File>();
            foreach (File file in listv_files.Items)
            {
                help_a.Add(file);
            }
            listv_files.Items.Clear();

            if (e.Column == 0)
            {
                help_a.Sort(new fileComparer_naam());
            }
            else if (e.Column == 1)
            {
                help_a.Sort(new fileComparer_grootte());
            }
            else if (e.Column == 2)
            {
                help_a.Sort(new fileComparer_rating());
            }

            listv_files.Items.AddRange(help_a.ToArray());
        }   
    }
}
