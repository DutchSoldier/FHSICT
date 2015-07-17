using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GiraffenApp
{
    class Stamboom
    {
        // data
        private String naam;  //de naam van de stamboom.
        private List<Giraffe> giraffen; //een lijst met giraffen

        //constructor
        // Creert een stamboom met opgegeven naam nm
        // en een lege lijst giraffen is gecreeerd.
        public Stamboom(String nm)
        {
            // plaats hier de gevraagde code voor opdracht 2a
            giraffen = new List<Giraffe>();
            naam = nm;
 
        }

        //properties
        public String Naam {
            get { return naam; }
        }
        public List<Giraffe> Giraffen {
            get { return giraffen; }
        }
        //methoden

        //returns de giraffe op index i in de list
        //gelden moet natuurlijk 0<= i < giraffen.Count
        public Giraffe GetGiraffe(int i)
        {
            return giraffen[i];
        }

   
        // Zoekt in deze stamboom een giraffe,
        // waarvan de naam gelijk is aan nm.
        // Indien zo'n giraffe-object bestaat,
        // dan is de returnwaarde gelijk aan dat giraffe-object,
        // anders is de returnwaarde gelijk aan null.
        public Giraffe GetGiraffe(String nm)
        {
            // plaats hier de gevraagde code voor opdracht 2b
            foreach (Giraffe g in giraffen)
            {
                if (g.Naam == nm) return g;
            }
            return null;
  
        }


        // Indien nog geen giraffe bestaat met de opgegeven naam en
        // de opgegeven naam is ongelijk aan "onbekend",
        // dan wordt deze gecreeerd  met opgegeven naam en geboortejaar (en onbekende ouders) en
        // toegevoegd en
        // is de returnwaarde gelijk aan true.
        //
        // Indien er al een giraffe bestaat met de opgegeven naam,
        // dan is niets toegevoegd en de returnwaarde is false.
        public bool AddGiraffe(String naam, int geboortejaar)
        {
            
                // plaats hier de gevraagde code voor opdracht 2c
                if (naam !="onbekend"&& GetGiraffe(naam) == null)
                {
                    giraffen.Add(new Giraffe(naam, geboortejaar));
                    return true;
                }
         
            return false;
 
        }

        // De list giraffen wordt gevuld met de test-gegevens
        public void VuMetTestGegevens()
        {
            String[] s = File.ReadAllLines("data.txt"); this.naam = s[0]; Giraffe gir;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != "")
                {
                    String[] ss = s[i].Split();
                    gir = new Giraffe(ss[0], Convert.ToInt32(ss[1]));
                    gir.NaamVader = ss[2]; gir.NaamMoeder = ss[3];
                    giraffen.Add(gir);
                }
            }
        }

    }
}
