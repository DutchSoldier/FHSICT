using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Hilversum
{
  public partial class GeluidsfragmentForm : Form
  {
    /******** datavelden ******************************************************/
    private BGExperience bgExperience;
      private Geluidsfragment test;
      

    /******** constructor *****************************************************/
    public GeluidsfragmentForm()
    {
      InitializeComponent();
      bgExperience = new BGExperience();
      test = new Geluidsfragment(1, @"C:\Users\Remi\Downloads\SE12-week 6-startmateriaalGeluidsfragment\SE12-PracticumopgaveGeluidsfragment\GeluidsfragmentProject\wav\evil_laf.wav", "1", 60, 45);
        
    }

    /******** methoden : event handlers ***************************************/


    private void btMaakAan_Click(object sender, EventArgs e)
    {
      //TODO
        


        if (tbTitel.Text == null)
        {
            MessageBox.Show("Geef een titel weer!");
        }

        else if (tbBestandsnaam == null)
        {
            MessageBox.Show("Geef een bestandsnaam weer!");
        }

        else if (Convert.ToInt32(tbMin.Text) < 0 || Convert.ToInt32(tbSec.Text) < 0 || Convert.ToInt32(tbSec.Text) > 60)
        {
            MessageBox.Show("Tijd waarden zijn niet geldig!");
        }
        else
        {
            bgExperience.AddFragment(Convert.ToInt32(tbNr.Text), tbBestandsnaam.Text, tbTitel.Text, Convert.ToInt32(tbMin.Text), Convert.ToInt32(tbSec.Text));
         }
    }

    
    //Speel het juiste geluidsfragment af
    private void bntSpeel_Click(object sender, EventArgs e)
    {
      //TODO
        List<Geluidsfragment> lgf;
        lgf = bgExperience.GetAlleFragmenten();


        Geluidsfragment gf;
        gf = bgExperience.GetFragment(lgf, Convert.ToInt32(textBox2.Text));
        try
        {
            gf.Play();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btBrowse_Click(object sender, EventArgs e)
    {
      openFileDialog1.ShowDialog();
      tbBestandsnaam.Text = openFileDialog1.FileName;
    }


    private void bUpdate_Click(object sender, EventArgs e)
    {
        lbInfo.Items.Clear();
        List<Geluidsfragment> lgf;
        lgf = bgExperience.GetAlleFragmenten();
        foreach (Geluidsfragment gf in lgf)
        {
            lbInfo.Items.Add(gf.AlsString());
          //  lbInfo.Items.Add(gf);
        }
    }

  /*  private void bVerwijder_Click(object sender, EventArgs e)
    {
        object i = lbInfo.SelectedItem;
        i.
        lbInfo.Items.RemoveAt(i);
        bgExperience.Remove(i);
    }*/

   /* private void bInfo_Click(object sender, EventArgs e)
    {
        lbInfo.Items.Clear();
        foreach (Geluidsfragment gf in bgExperience.GetAlleFragmenten())
        {
            lbInfo.Items.Add(gf.AlsString());
        }
    }*/



  }
}