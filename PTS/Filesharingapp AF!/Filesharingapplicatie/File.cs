using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Filesharingapplicatie
{
    public class File : ListViewItem
    {
        //Datavelden
        private int bestand_id;
        private string naam;
        private int rating;
        private int map_id;
        private string beschrijving;
        private string rfid;
        private string pad;
        private string extensie;
        private long grootte;
        private int gedownload;
        private DateTime datum;
        private int imageindex;
        //

        //Properties
        public int Bestand_id
        {
            get
            {
                return bestand_id;
            }
        }

        public string Naam
        {
            get
            {
                return naam;
            }
        }

        public int Rating
        {
            get
            {
                return rating;
            }
        }

        public int Map_id
        {
            get
            {
                return map_id;
            }
        }

        public string Beschrijving
        {
            get
            {
                return beschrijving;
            }
        }

        public string Rfid
        {
            get
            {
                return rfid;
            }
        }

        public string Pad
        {
            get
            {
                return pad;
            }
        }

        public string Extensie
        {
            get
            {
                return extensie;
            }
        }

        public long Grootte
        {
            get
            {
                return grootte;
            }
        }

        public int Gedownload
        {
            get
            {
                return gedownload;
            }
        }

        public DateTime Datum
        {
            get
            {
                return datum;
            }
        }

        public int Imageindex
        {
            get
            {
                return imageindex;
            }
        }
        //

        //Constructor
        public File(int bestand_id, int map_id, string naam, string beschrijving, string extensie, long grootte, string rfid, DateTime datum, int gedownload, int rating, string pad, int imageindex)
        {
            this.bestand_id = bestand_id;
            this.naam = naam;
            this.rating = rating;
            this.map_id = map_id;
            this.beschrijving = beschrijving;
            this.rfid = rfid;
            this.pad = pad;
            this.extensie = extensie;
            this.grootte = grootte;
            this.gedownload = gedownload;
            this.datum = datum;
            this.imageindex = imageindex;

            ImageIndex = imageindex;
            Text = naam;
            SubItems.Add(FileHelper.getGrootte(grootte));
            SubItems.Add(rating.ToString());
        }
        //

        // methoden
        public void DownloadsOneUp()
        {
            gedownload += 1;
        }   // verhoogt het aantal downloads met 1

        public void EditRating(int score)
        {
            rating += score;
        }   // verhoogt of verlaagt de rating met 1
    }
}
