using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reserveringssysteem
{
    class Kampeerplek
    {
        //Datavelden
        private string plaatsNummer;
        private string opmerking;
        private int x;
        private int y;
        private int prijs;
        //

        //Properties
        public string PlaatsNummer
        {
            get
            {
                return plaatsNummer;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public int Prijs
        {
            get
            {
                return prijs;
            }
        }
        //

        //Methodes
        /// <summary>
        /// Deze constructor wordt gebruikt voor het ophalen van een kampeerplaats uit de database.
        /// </summary>
        /// <param name="plaatsNummer"></param>
        /// <param name="opmerking"></param>
        /// <param name="x">X-coordinaat van de kampeerplaats op de plattegrond.</param>
        /// <param name="y">Y-coordinaat van de kampeerplaats op de plattegrond.</param>
        /// <param name="prijs"></param>
        public Kampeerplek(string plaatsNummer, string opmerking, int x, int y, int prijs)
        {
            this.plaatsNummer = plaatsNummer;
            this.opmerking = opmerking;
            this.x = x;
            this.y = y;
            this.prijs = prijs;
        }

        /// <summary>
        /// Deze constructor wordt gebruikt voor het opslaan van kampeerplaatsen in de gereserveerde kampeerplaatsen lijst op het ReserveringForm.
        /// </summary>
        /// <param name="plaatsNummer"></param>
        /// <param name="prijs"></param>
        public Kampeerplek(string plaatsNummer, int prijs)
        {
            this.plaatsNummer = plaatsNummer;
            this.prijs = prijs;
        }

        /// <summary>
        /// Dit is de informatie die weergegeven wordt op de tooltips bij de kampeerplaatsknoppen.
        /// </summary>
        /// <returns></returns>
        public string PlekInfo()
        {
            string plekString = "Plaats: " + plaatsNummer + "\n\n" + "Opmerking: \n" + opmerking + "\n\n" + "Prijs: " + prijs.ToString();
            return plekString;
        }
        //
    }
}
