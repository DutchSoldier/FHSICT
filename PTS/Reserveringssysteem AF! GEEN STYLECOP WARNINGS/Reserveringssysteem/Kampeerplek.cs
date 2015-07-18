//Kampeerplek

namespace Reserveringssysteem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Kampeerplek
    {
        //Datavelden
        private string plaatsNummer;
        private string opmerking;
        private int x;
        private int y;
        private int prijs;

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

        //Properties
        public string PlaatsNummer
        {
            get
            {
                return this.plaatsNummer;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
        }

        public int Prijs
        {
            get
            {
                return this.prijs;
            }
        }

        /// <summary>
        /// Dit is de informatie die weergegeven wordt op de tooltips bij de kampeerplaatsknoppen.
        /// </summary>
        /// <returns></returns>
        public string PlekInfo()
        {
            string plekString = "Plaats: " + this.plaatsNummer + "\n\n" + "Opmerking: \n" + this.opmerking + "\n\n" + "Prijs: " + this.prijs.ToString();
            return plekString;
        }
    }
}
