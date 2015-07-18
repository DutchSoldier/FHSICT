using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Filesharingapplicatie
{
    class Opmerking : Panel
    {
        //Datavelden
        private string rfid;
        private int bestand_id;
        private string opmerking_text;
        private DateTime datum;
        private long opmerking_id;

        private Label author;
        private Label date;
        private TextBox opmerking;
        //

        //Properties
        public string Rfid
        {
            get
            {
                return rfid;
            }
        }

        public int Bestand_id
        {
            get
            {
                return bestand_id;
            }
        }

        public string Opmerking_text
        {
            get 
            {
                return opmerking_text;
            }
        }

        public DateTime Datum
        {
            get 
            {
                return datum;
            }
        }

        public long Opmerking_id
        {
            get
            {
                return opmerking_id;
            }
        }
        //

        //Constructor
        public Opmerking(string rfid, int bestand_id, string opmerking_text, DateTime datum, long opmerking_id, Point location)
        {
            this.rfid = rfid;
            this.bestand_id = bestand_id;
            this.opmerking_text = opmerking_text;
            this.datum = datum;
            this.opmerking_id = opmerking_id;

            this.Location = location;
            this.BackColor = Color.WhiteSmoke;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Height = 87;
            this.Width = 482;

            author = new Label();
            author.Text = rfid;
            author.Location = new Point(5, 8);
            author.Font = new Font(author.Font, FontStyle.Bold);
            this.Controls.Add(author);

            date = new Label();
            date.Text = datum.ToString();
            date.Location = new Point(375, 8);
            this.Controls.Add(date);

            opmerking = new TextBox();
            opmerking.Text = opmerking_text;
            opmerking.Location = new Point(10, 31);
            opmerking.Enabled = false;
            opmerking.BackColor = Color.White;
            opmerking.ForeColor = Color.Gray;
            opmerking.Multiline = true;
            opmerking.Height = 45;
            opmerking.Width = 460;
            this.Controls.Add(opmerking);
        }
    }
}
