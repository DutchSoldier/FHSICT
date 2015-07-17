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


        private void btnHaalOp_Click(object sender, EventArgs e)
        {
            List<Student> studentenLijst;
            studentenLijst = dk.GetAlleStudenten();

            listbox1.Items.Clear();
            foreach (Student student in studentenLijst)
            {
                listbox1.Items.Add(student.toonInfo());
            }
        }

        private void btnVoegtoe_Click(object sender, EventArgs e)
        {
            int nummer;
            String naam;
            int stpunten;

            if (tbNaam.Text != "" && tbNummer.Text != "" && tbStudPunten.Text != "")
            {
                nummer = Convert.ToInt32(tbNummer.Text);
                naam = tbNaam.Text;
                stpunten = Convert.ToInt32(tbStudPunten.Text);
                dk.VoegToe(nummer, naam, stpunten);
            }
        }

        private void btnAantalRecords_Click(object sender, EventArgs e)
        {
            int aantal = dk.AantalStudenten();
            label1.Text = Convert.ToString(aantal);
        }
       
    }
}