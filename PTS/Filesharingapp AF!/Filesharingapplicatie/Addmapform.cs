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
    public partial class Addmapform : Form
    {
        Categorie selected_map;
        Filesharingform parent; 

        public Addmapform(Filesharingform parent, Categorie selected_map)
        {
            InitializeComponent();
            bt_accept.Image = parent.imagelist_icons48x48.Images[6];
            this.parent = parent;
            this.selected_map = selected_map;
        }   // Constructor

        private void bt_accept_Click(object sender, EventArgs e)
        {
            try
            {
                ServerKoppeling.createFolder(selected_map.FullPath + "\\" + tb_mapnaam.Text);
                selected_map.Nodes.Add(DatabaseKoppeling.newFolder(tb_mapnaam.Text, selected_map.Map_id));
                if (!selected_map.IsExpanded)
                {
                    selected_map.Expand();
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ongeldige actie. \nEr heeft zich een restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // slaat de informatie van de nieuwe map op in de database, maakt deze aan op de server, en ververst de Filesharingform
    }
}
