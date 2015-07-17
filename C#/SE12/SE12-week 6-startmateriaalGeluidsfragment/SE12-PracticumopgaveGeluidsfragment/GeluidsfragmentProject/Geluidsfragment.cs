using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace Hilversum
{

    public class Geluidsfragment
    {
        /******** datavelden ******************************************************/
        private int nr;
        private String titel;
        private int tijdsduur; //tijdsduur in seconden
        private String bestandsnaam;

        /******** constructoren ***************************************************/
        //na uitvoering van deze constructor dient een Geluidsfragment object 
        //te zijn aangemaakt met nummer nr,als titel de waarde titel, een tijdsduur
        //van min minuten en sec seconden en als bestandsnaam de meegegeven waarde
        public Geluidsfragment(int nr, String bestandsnaam, String titel, int min, int sec)
        {
            //TODO
            this.nr = nr;
            this.titel = titel;
            this.bestandsnaam = bestandsnaam;
            this.tijdsduur = min * 60 + sec;
        }

        //na uitvoering van deze constructor dient een Geluidsfragment object 
        //te zijn aangemaakt met nummer nr, als titel de waarde "onbekend", een tijdsduur
        //van 0 seconden en als bestandsnaam de meegegeven waarde
        public Geluidsfragment(int nr, String bestandsnaam)
        {
            //TODO
            this.nr = nr;
            this.titel = "onbekend";
            this.bestandsnaam = bestandsnaam;
            this.tijdsduur = 0;

        }




        /******** properties ********************************************************/

        //alleen een getter
        //de getter retourneert het nummer van het geluidsfragment
        public int Nr
        {
            //TODO
            get 
            {
                return nr;
            }
        }

        //zowel een getter als setter
        //de getter retourneert de titel van het geluidsfragment
        //de setter zet de titel van het geluidsfragment op de aangeleverde waarde
        public String Titel
        {
            //TODO
            get
            {
                return titel;
            }
            set
            {
                titel = value;
            }
        }

        //zowel een getter als setter
        //de getter retourneert de tijdsduur in een aantal seconden
        //de setter zorgt ervoor dat het opgegeven aantal seconden wordt gezet
        //mits dit getal niet negatief is. Is dat toch het geval, dan wordt
        //als default waarde de waarde 0 gegeven
        public int Tijdsduur
        {
            get
            {
                return tijdsduur;
            }
            set
            {
                if (value > 0)
                {
                    tijdsduur = value;
                }
                else
                {
                    tijdsduur = 0;
                }
            }
        }

        //alleen een getter, geen setter
        //de getter retourneert de tijdsduur als string gerepresenteerd. De string
        //ziet er als volgt uit: "<min>:<sec>" waarbij <min> moet worden vervangen
        //door het aantal minuten en <sec> door het aantal seconden dat het fragment
        //duurt. Een fragment van 135 seconden wordt dus "2:15"
        public string TijdsduurString
        {
            //TODO
            //TIP: een deling van twee integergetallen mbv het / teken, levert het geheel
            //     aantal keer dat de deling lukt. Dus 73/20 levert het integer getal 3 op
            get
            {
                int min = tijdsduur / 60;
                int sec = tijdsduur % 60;
                return min + ":" + sec;
            }

        }

        //zowel getter als setter
        //get retourneert de bestandsnaam (inclusief pad)
        //set zet de bestandsnaam (inclusief pad) 
        //er hoeft niet op het bestaan van de bestandsnaam te worden gecontroleerd
        public string Bestandsnaam
        {
            //TODO
            get
            {
                return bestandsnaam;
            }
            set
            {
                bestandsnaam = value;
            }
        }

        /******** methoden ********************************************************/

        // deze methode retourneert een string van de vorm:
        // "Nr <nr>: <titel> - <min>:<sec>"
        // Bij voorbeeld:
        // "Nr 54: Het grote smurfenlied - 3:18"
        public String AlsString()
        {
            //TODO
            return "Nr " + nr + ": " + titel + " - " + TijdsduurString + " - " + bestandsnaam;
        }

        //deze methode speelt het geluidsfragment (indien mogelijk) af
        //als het afspelen gelukt is wordt boolean waarde true geretourneerd
        //anders wordt false geretourneerd
        public bool Play()
        {
            try
            {
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = Titel ;
                myPlayer.Play();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }


}
