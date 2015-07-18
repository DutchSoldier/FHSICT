using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseKoppeling
{
    public partial class DatabaseKoppelingForm : Form
    {
        private DataKoppeling dk;
        

        public DatabaseKoppelingForm()
        {
            InitializeComponent();
            dk = new DataKoppeling();
        }

        private void HaalOpAllesBtn_Click(object sender, EventArgs e)
        {
            List<Student> studentenLijst;
            studentenLijst = dk.getInhoudtabel();

            InhoudDbLbx.Items.Clear();
            foreach (Student student in studentenLijst)
            {
                InhoudDbLbx.Items.Add(student);

            }
        }

        private void HaalOpNamen_Click(object sender, EventArgs e)
        {
            
            List<string> namenLijst;
            namenLijst= dk.getNamen();

            InhoudDbLbx.Items.Clear();
            foreach (String naam in namenLijst)
            {
                InhoudDbLbx.Items.Add(naam);
            }
        }

        private void Voegtoe_Click(object sender, EventArgs e)
        {
            int nummer;
            String naam;
            int stpunten;

            if (NaamTbx.Text != "" && NrTbx.Text != "" && studPuntenTbx.Text != "")
            {
                nummer = Convert.ToInt32(NrTbx.Text);
                naam = NaamTbx.Text;
                stpunten = Convert.ToInt32(studPuntenTbx.Text);
                dk.VoegToe(nummer,naam,stpunten);
            }
        }

        private void Aantal_Click(object sender, EventArgs e)
        {
            int aantal = dk.AantalStudenten();
            AantalLbl.Text = Convert.ToString(aantal);

        }

        
    }
}