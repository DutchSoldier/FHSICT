using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AppBoekingskantoor
{
    public class Boekingskantoor
    {
        private String naam;        // de naam van dit boekingskantoor
        private List<Spreker> sprekers; // de sprekers van dit boekingskantoor

        // constructor. Deze creeert een boekingskantoor met naam nm
        // en een lege lijst sprekers.
        public Boekingskantoor(String nm)
        {   
            naam = nm;
            sprekers = new List<Spreker>();
        }

        //properties
        public String Naam { get { return naam; } }

        //methoden

        // Returnwaarde is een lijst met alle sprekers,
        public List<Spreker> getAlleSprekers()
        {
            return this.sprekers;
        }
        
        // Indien er een spreker bestaat met naam nm,
        // dan is de returnwaarde gelijk aan die spreker,
        // anders is de returnwaarde gelijk aan null.
        public Spreker getSprekerMetNaam(String nm)
        {
            foreach (Spreker sp in sprekers)
            {
                if (sp.Naam == nm)
                    return sp;
            }
            return null;
        }
        
        // indien er in de list sprekers nog geen spreker voor komt met de opgegeven naam nm,
        // dan wordt een spreker gecreeerd aan de hand van de parameters en toegevoegd aan de list sprekers.
        //     en de returnwaarde is true,
        // anders de returnwaarde is false.
        public bool voegSprekerToe(String nm, String email, int tarief)
        {   //todo, opdracht 2

        }

        // indien er een spreker met de opgegeven naam nm bestaat,
        // dan is aan de topics van die speler het onderwerp topic toegevoegd
        //     en de returnwaarde is true,
        // anders is de returnwaarde gelijk aan false.
        public bool voegTopicAanSprekerToe(String nm, String topic)
        {   //todo, opdracht 2
 
        }

        // returnwaarde is een list met alle sprekers,
        // die een lezing kunnen houden over onderwerp topic.
        public List<Spreker> GetAlleSprekersOver(String topic)
        {   //todo, opdracht 2

        }
    }
}
