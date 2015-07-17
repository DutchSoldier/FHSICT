using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppBoekingskantoor
{
    public class Spreker
    {
        //kenmerken
        private String naam;    // naam van de spreker
        private String email;   // e-mail-adres van de spreker
        private int tarief;     // tarief van de spreker, in hele euro's
        private List<String> topics;  // de onderwerpen, waarover deze spreker een toespraak kan houden

        //constructor

        // deze constructor creeert een Spreker met naam, e-mail en tarief 
        // zoals in de parameters is aangegeven.
        // Deze spreker heeft geen topics.
        public Spreker(String naam, String email, int tarief)
        {   //todo
            this.naam = naam;
            this.email = email; 
            this.tarief = tarief;
            this.topics = new List<String>();
        }


        //properties

        public String Naam { get { return naam; } }
        public String Email { get { return email; } }
        public int Tarief { get { return tarief; } }
        
        //methoden

        // Returnwaarde is een lijst met alle topics,
        public List<String> getAlleTopics()
        {
            return this.topics;
        }
        
        // Returnwaarde is een string met daarin achtereenvolgend de kenmerken van deze
        // spreker, gescheiden door "; ". De onderlinge topics zijn gescheiden door komma's.
        public String alsString()
        {   
            String s = "naam: " + this.naam + "; e-mail: " + this.email +
                   "; tarief: " + this.tarief.ToString() + "; topics: ";
            bool firstTopic = true;
            foreach (String top in topics)
            {
                if (firstTopic)
                {
                    s = s + top; firstTopic = false;
                }
                else
                {
                    s = s + ", " + top;
                }
            }
            return s;
        }

        // Voegt het onderwerp newTopic toe aan topics
        public void voegTopicToe(String newTopic)
        {   //todo
            topics.Add(newTopic);
        }

        // Indien t voor komt onder de strings in de list topics,
        // dan is de returnwaarde gelijk aan true,
        // anders is de returnwaarde gelijk aan fale.
        public bool kanSprekenOver(String t)
        {   //todo
            return topics.Contains(t);
        }

    }
}
