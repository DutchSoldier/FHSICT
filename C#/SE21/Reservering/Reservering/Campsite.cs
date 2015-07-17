using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reservering
{
    class Campsite
    {
        public int number { get; private set; }
        public string type { get; private set; }
        public double price { get; private set; }
        public bool available { get; set; }
        public int maxPersons { get; private set; }

        public Campsite(int Number, string Type, double Price, bool Available, int MaxPersons)
        {
            number = Number;
            type = Type;
            price = Price;
            available = Available;
            maxPersons = MaxPersons;
        }

        public override string ToString()
        {
            return Convert.ToString(number) + " - " + type + " - Price: €" + String.Format("{0:0.00}", price);
        }
    }
}
