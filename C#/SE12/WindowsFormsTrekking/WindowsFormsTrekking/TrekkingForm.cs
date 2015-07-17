using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsTrekking
{
    public partial class TrekkingForm : Form
    {
        private Trekking trekking;
        private int animationCounter;
        public int teller = 0;
        SoundPlayer fusrodah = new SoundPlayer(WindowsFormsTrekking.Properties.Resources.fusrodah);

        public TrekkingForm()
        {
            InitializeComponent();
            bStop.Enabled = false;
            bTrek.Enabled = false;
            bSorteer.Enabled = false;
            bSerie.Enabled = false;
            bLaatzien.Enabled = false;
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            trekking = null;
            bStop.Enabled = false;
            bStart.Enabled = true;
            bSorteer.Enabled = false;
            bSerie.Enabled = false;
            bTrek.Enabled = false;
            bLaatzien.Enabled = false;
            teller = 0;
            timer1.Stop();
        }

        private void bLaatzien_Click(object sender, EventArgs e)
        {
            animationCounter = 0;
            bLaatzien.Enabled = false;
            timer1.Start();

        }

        private void bSorteer_Click(object sender, EventArgs e)
        {
         

            trekking.Sort();
            lTrekking.Items.Clear();
            for (int i = 0; i < Convert.ToInt32(tAantalgewenst.Text); i++)
            {
                lTrekking.Items.Add(Convert.ToString(trekking.GeefGetal(i)));
            }
        }

        private void bSerie_Click(object sender, EventArgs e)
        {
            bTrek.Enabled = false;
            bLaatzien.Enabled = true;
            bSorteer.Enabled = true;
            bSerie.Enabled = false;
            for (int i = 0; i < Convert.ToInt32(tAantalgewenst.Text); i++)
            {
                trekking.TrekGetal();
                lTrekking.Items.Add(trekkingData());
                teller++;
            }
            MessageBox.Show("Alle gewenste trekkingen zijn uitgevoerd.");
            teller = 0;
        }

        private string trekkingData()
        {
            return trekking.GeefGetal(teller).ToString();
            
        }

        private void bTrek_Click(object sender, EventArgs e)
        {
            if (teller < Convert.ToInt32(tAantalgewenst.Text))
            {
                trekking.TrekGetal();

                bSerie.Enabled = false;

                lTrekking.Items.Add(trekkingData());
                teller++;
            }
            else
            {
                MessageBox.Show ("Alle gewenste trekkingen zijn uitgevoerd.");
                bTrek.Enabled = false;
                bSorteer.Enabled = true;
                bLaatzien.Enabled = true;
            }

        }

        private void bStart_Click(object sender, EventArgs e)
        {
            

            if((Convert.ToInt32(tMaxwaarde.Text) > 90) || (Convert.ToInt32(tAantalgewenst.Text)) > 45)
            {
            MessageBox.Show ("Maxwaarde is maximaal 90.\n Aantalgewenst is maximaal 45.");
            }
            else if((Convert.ToInt32(tMaxwaarde.Text) / Convert.ToInt32(tAantalgewenst.Text))<2)
            {
                MessageBox.Show("Maxwaarde moet minimaal 2* zo groot zijn als Aantalgewenst.");
            }
            else
            {
            bSerie.Enabled = true;
            bStop.Enabled = true;
            bTrek.Enabled = true;
            bStart.Enabled = false;
            trekking = new Trekking (Convert.ToInt32(tMaxwaarde.Text),Convert.ToInt32(tAantalgewenst.Text));
            lTrekking.Items.Clear();
            
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         int getal = trekking.GeefGetal(animationCounter); 
         pTrekking.Image = imageList1.Images[getal]; 
         fusrodah.Play();
         animationCounter++;

         if (animationCounter >= trekking.AantalGetrokken)
         {
             //Vul de rest zelf in
             timer1.Stop();
         }
        }
    }
}
