using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpdrachtDierenasiel1
{
    /// <summary>
    /// Een windows application om inheritance te testen.
    /// Als voorbeeld nemen we de classes Hond en Kat, die erven van de class Huisdier.
    /// </summary>
    public partial class FormDierenasiel : Form
    {
        private Huisdier h;

        /// <summary>
        /// Deze constructor creeert een applicatie. 
        /// <p>De variabele h (van het type Huisdier) is gelijk aan null.</p>
        /// </summary>
        public FormDierenasiel()
        {
            InitializeComponent();
            h = null;
        }

        /// <summary>
        /// Afhankelijk van of de radiobutton "hond" of "kat" is aangevinkt,
        /// wordt "h = new Hond(...);" of  "h = new Kat(...);" uitgevoerd. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaakDier_Click(object sender, EventArgs e)
        {
            //moet je nog maken
            if (rdBtnHond.Checked == true)
            {
                h = new Hond(tbChipnummer.Text, Convert.ToInt32(tbGeboortejaar.Text), tbRoepnaam.Text, cbGereserveerd.Checked, Convert.ToInt32(tbUitlaatdag.Text), Convert.ToInt32(tbUitlaatmaand.Text), Convert.ToInt32(tbUitlaatjaar.Text));
            }
            else if (rdBtnKat.Checked == true)
            {
                h = new Kat(tbChipnummer.Text, Convert.ToInt32(tbGeboortejaar.Text), tbRoepnaam.Text, cbGereserveerd.Checked, tbExtrainfo.Text);
            }
        }

/// <summary>
/// Informatie over huisdier h verschijnt op het scherm.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void btnGeefInfo_Click(object sender, EventArgs e)
        {
            lBinfo.Items.Clear();

            foreach(huisdier h in h)
            {
                lBinfo.Items.Add(h);
            }
            
            
        }

        private void rdBtnHond_CheckedChanged(object sender, EventArgs e)
        {
            lUitlaatdag.Visible = true;
            lUitlaatmaand.Visible = true;
            lUitlaatjaar.Visible = true;
            tbUitlaatdag.Visible = true;
            tbUitlaatmaand.Visible = true;
            tbUitlaatjaar.Visible = true;
            lExtrainfo.Visible = false;
            tbExtrainfo.Visible = false;
        }

        private void rdBtnKat_CheckedChanged(object sender, EventArgs e)
        {
            lUitlaatdag.Visible = false;
            lUitlaatmaand.Visible = false;
            lUitlaatjaar.Visible = false;
            tbUitlaatdag.Visible = false;
            tbUitlaatmaand.Visible = false;
            tbUitlaatjaar.Visible = false;
            lExtrainfo.Visible = true;
            tbExtrainfo.Visible = true;
        }

    }
}