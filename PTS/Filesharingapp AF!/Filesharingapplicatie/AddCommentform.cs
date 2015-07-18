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
    public partial class AddCommentform : Form
    {
        Filesharingform parent;

        public AddCommentform(Filesharingform parent)
        {
            InitializeComponent();
            this.parent = parent;
            bt_maakcomment.ImageList = parent.imagelist_icons22x22;
            bt_maakcomment.ImageIndex = 10;
            lb_naam.Text = parent.RFID;
            lb_datum.Text = DateTime.Now.ToString();
        }   // Constructor; zorgt voor de lay-out van de form

        private void bt_maakcomment_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_opmerking.Text != "")
                {
                    DatabaseKoppeling.newComment(parent.RFID, tb_opmerking.Text, parent.file_selection.Bestand_id, new Point(0, 0));
                    parent.panel_comments.Controls.Clear();
                    parent.panel_comments.Controls.AddRange(DatabaseKoppeling.getComments(parent.file_selection.Bestand_id).ToArray());
                    this.Close();
                }
                else 
                { 
                    MessageBox.Show("Een opmerking mag niet leeg zijn.", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                }
            }
            catch
            {
                MessageBox.Show("Ongeldige database actie. \nEr heeft zich een database restrictie voorgedaan of de connectie is verbroken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   // Slaat een nieuwe Opmerking op in de database en ververst alle Opmerkingen in de Filesharingform      
    }
}
