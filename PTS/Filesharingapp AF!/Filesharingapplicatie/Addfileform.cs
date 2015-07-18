using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Filesharingapplicatie
{
    public partial class Addfileform : Form
    {
        FileInfo info;
        Filesharingform parent;

        public Addfileform(Filesharingform parent)
        {
            InitializeComponent();
            bt_browse.Image = parent.imagelist_icons22x22.Images[0];
            bt_accept.Image = parent.imagelist_icons48x48.Images[0];
            this.parent = parent;
        }   // Constructor

        private void bt_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tb_url.ForeColor = Color.Black;
                tb_url.Text = dialog.FileName;
                info = new FileInfo(dialog.FileName);
            }
        }   // Opent een FileDialog zodat de gebruiker het bestand kan kiezen die hij wilt uploaden

        private void tb_beschrijving_MouseClick(object sender, MouseEventArgs e)
        {
            tb_beschrijving.Text = "";
            tb_beschrijving.ForeColor = Color.Black;
        }   // Beheert de opmaak van tb_beschrijving

        private void bt_accept_Click(object sender, EventArgs e)
        {
            try
            {
                if (info != null)
                {
                    this.Visible = false;

                    ThreadStart ts = delegate() { ServerKoppeling.sendFile(info.FullName, parent.folder_selection.FullPath); };
                    Thread t = new Thread(ts);
                    t.Start();
                    Loadingform loadingform = new Loadingform(t);
                    loadingform.ShowDialog();
                    parent.listv_files.Items.Add(DatabaseKoppeling.newFile(parent.folder_selection.Map_id, tb_beschrijving.Text, info.Length, parent.RFID, parent.folder_selection.FullPath + "\\" + info.Name));
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // Slaat de informatie van het gekozen bestand op in de database en upload het bestand naar de server
    }
}
