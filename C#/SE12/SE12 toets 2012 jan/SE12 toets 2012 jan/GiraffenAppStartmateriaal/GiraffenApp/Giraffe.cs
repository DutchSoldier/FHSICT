using System;
using System.Collections.Generic;
using System.Text;

namespace GiraffenApp
{
    class Giraffe
    {
        // kenmerken
        private String naam;  // de naam van deze giraffe.
        private int geboortejaar;  // jaar, waarin deze giraffe geboren is
        private String naamVader;  // de naam van de vader van deze giraffe, indien bekend;
                                   // anders de tekst "onbekend"
        private String naamMoeder; // de naam van de moeder van deze giraffe, indien bekend;
                                   // anders de tekst "onbekend"
       
        //constructor.
        // Creert een giraffe met opgegeven naam en geboortejaar,
        //naam van de vader is "onbekend" en ook
        //naam van de moeder is "onbekend". 
        public Giraffe(String naam, int geboortejaar)
        {
            this.naam = naam;
            this.geboortejaar = geboortejaar;
            this.naamVader = "onbekend";
            this.naamMoeder = "onbekend";
        }

        //properties
        public String Naam
        {
            get { return naam; }
        }
        public int Geboortejaar
        {
            get { return geboortejaar; }
        }
        public String NaamVader
        {
            get { return naamVader; }
            set { naamVader = value; }
        }
        public String NaamMoeder
        {
            get { return naamMoeder; }
            set { naamMoeder = value; }

        }

        //methoden

        //returnwaarde is een string met daarin achtereenvolgens
        //de naam van deze giraffe, het geboortejaar,
        //de naam van de vader en de naam van de moeder;
        //allen gescheiden door scheidingstekens (kies zelf welke).
        public String AlsString()
        {
            // plaats hier de gevraagde code voor opdracht 1

        }
    }
}
