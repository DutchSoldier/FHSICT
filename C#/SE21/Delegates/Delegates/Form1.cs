using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delegates
{
    public partial class Form1 : Form
    {
        Persoon Flupke;
        GetNaamMethod GetNaam;
        public delegate String GetNaamMethod();

        public Form1()
        {
            InitializeComponent();
            Flupke = new Persoon("Bert", "van", "Gestel", "L.F.M.");
        }

        private void Btn_Naam1_Click(object sender, EventArgs e)
        {
            GetNaam = new GetNaamMethod(Flupke.GetNaam1);
        }

        private void Btn_Naam2_Click(object sender, EventArgs e)
        {
            GetNaam = new GetNaamMethod(Flupke.GetNaam2);
        }

        private void Btn_Naam3_Click(object sender, EventArgs e)
        {
            GetNaam = new GetNaamMethod(Flupke.GetNaam3);
        }

        private void Btn_LaatZien_Click(object sender, EventArgs e)
        {
            lb_Namen.Items.Add(GetNaam());
        }


    }
}
