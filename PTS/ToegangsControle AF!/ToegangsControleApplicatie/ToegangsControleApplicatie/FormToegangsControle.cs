using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Phidgets; // Nodig voor RFID.
using Phidgets.Events; //Nodig voor RFID


namespace ToegangsControleApplicatie
{
    public partial class FormToegangsControle : Form
    {
        int ResNummer;

        public FormToegangsControle()
        {
            InitializeComponent();

            MessageBox.Show("Klik op OK en plug daarna pas de RFID-lezer in de computer.", "Melding", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RFID rfid = new RFID();
            try
            {

                //initialize our Phidgets RFID reader and hook the event handlers
                rfid.Attach += new AttachEventHandler(rfid_Attach);

                rfid.Tag += new TagEventHandler(rfid_Tag);
                rfid.TagLost += new TagEventHandler(rfid_TagLost);
                rfid.open();

                //Wait for a Phidget RFID to be attached before doing anything with 
                //the object
                Console.WriteLine("waiting for attachment...");
                rfid.waitForAttachment();

                //turn on the antenna and the led to show everything is working
                rfid.Antenna = true;
                rfid.LED = true;

                //turn off the led
                rfid.LED = false;

            }
            catch (PhidgetException ex)
            {

                Console.WriteLine(ex.Description);
            } 
        }


        //attach event handler...display the serial number of the attached RFID phidget
        static void rfid_Attach(object sender, AttachEventArgs e)
        {
            Console.WriteLine("RFIDReader {0} attached!",
                                    e.Device.SerialNumber.ToString());
        }

        //detach event handler...display the serial number of the detached RFID phidget
        static void rfid_Detach(object sender, DetachEventArgs e)
        {
            Console.WriteLine("RFID reader {0} detached!",
                                    e.Device.SerialNumber.ToString());
        }

        //Error event handler...display the error description string
        static void rfid_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Description);
        }

        //Print the tag code of the scanned tag
        public void rfid_Tag(object sender, TagEventArgs e)
        {
            Console.WriteLine("Tag {0} scanned", e.Tag);
            Reservering resrv = null;
            try
            {
                resrv = DatabaseKoppeling.GetReservering(e.Tag);
                lbNaam.Text = resrv.Naam;
                lbBedrag.Text = "€ " + Convert.ToString(resrv.Bedrag);
                lbPlaats.Text = resrv.GereserveerdePlaatsen;
                lbRFID.Text = resrv.Rfid;
                ResNummer = resrv.Reserveringsnummer;
                if (resrv.BetalingVoltooid)
                {
                    cbBetaald.Text = "Voltooid";
                }
                if (!resrv.BetalingVoltooid)
                {
                    cbBetaald.Text = "Onvoltooid";
                }


            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Er is iets mis gegaan met het inlezen van de reservering.");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Er bestaat geen reservering bij dit RFID nummer.");
            }
            catch (Exception)
            {
                MessageBox.Show("Algemene Fout.");
            }
        }

        //print the tag code for the tag that was just lost
        public void rfid_TagLost(object sender, TagEventArgs e)
        {
            Console.WriteLine("Tag {0} lost", e.Tag);
        }

        /// <summary>
        /// Verander de status van de reservering naar Betaald / Niet Betaald
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBetaald_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbBetaald.Text == "Voltooid")
                    DatabaseKoppeling.UpdateBetalingStatus(ResNummer, "true");

                if (cbBetaald.Text == "Onvoltooid")
                    DatabaseKoppeling.UpdateBetalingStatus(ResNummer, "false");
            }
            catch (Exception z)
            {

                MessageBox.Show("Algemene Fout: " + z.Message);
            }

        }
    }
}
