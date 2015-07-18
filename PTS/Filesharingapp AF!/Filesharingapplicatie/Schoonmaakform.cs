using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filesharingapplicatie
{
    public partial class Schoonmaakform : Form
    {
        Filesharingform parent;

        public Schoonmaakform(Filesharingform parent)
        {
            InitializeComponent();
            bt_accept.Image = parent.imagelist_icons48x48.Images[9];
            this.parent = parent;
        }   // Constructor

        private void tb_RFID_MouseClick(object sender, MouseEventArgs e)
        {
            tb_RFID.Text = "";
            tb_RFID.ForeColor = Color.Black;
        }   // verzorgt de opmaak van tb_RFID

        private void bt_accept_Click(object sender, EventArgs e)
        {
            if (dtp_vanaf.Value > dtp_tot.Value)
            {
                MessageBox.Show("De eerste datum kan niet later zijn dan de tweede datum.");
                return;
            }
            if (!rb_gebruiker.Checked)
            {
                tb_RFID.Text = "";
            }
            if (!rb_extensie.Checked)
            {
                tb_extensie.Text = "";
            }

            try
            {
                foreach (string url in DatabaseKoppeling.clear(dtp_vanaf.Value, dtp_tot.Value, tb_extensie.Text, tb_RFID.Text))
                {
                    ServerKoppeling.deleteFile(url);
                }

                parent.listv_files.Items.Clear();
                if (parent.Treeview_categories.SelectedNode.Text == "Mijn Bestanden")
                {
                    parent.listv_files.Items.AddRange(DatabaseKoppeling.searchUserFiles(parent.RFID).ToArray());
                }
                else if (parent.folder_selection != null)
                {
                    parent.listv_files.Items.AddRange(DatabaseKoppeling.getFiles(parent.folder_selection.Map_id).ToArray());
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // verwijderd alle files uit de database en van de server die aan de ingevoerde parameters voldoen
    }
}
