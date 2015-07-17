using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reservering
{
    class RentalObject
    {
        public int rentalObjectNumber { get; private set; }
        public string description { get; private set; }
        public double pricePerItem { get; private set; }
        public int amountOfObjectsAvailable { get; private set; }
        public int amountsOfObjectsReserved { get; private set; }

        public RentalObject(int RentalObjectNumber, string Description, double PricePerItem, int AmountOfObjectsAvailable, int AmountsOfObjectsReserved)
        {
            rentalObjectNumber = RentalObjectNumber;
            description = Description;
            pricePerItem = PricePerItem;
            amountOfObjectsAvailable = AmountOfObjectsAvailable;
            amountsOfObjectsReserved = AmountsOfObjectsReserved;
        }

        public void reserveItem(int amount, bool alterStock)
        {
            amountsOfObjectsReserved += amount;
            if (alterStock)
            {
                amountOfObjectsAvailable -= amount;
            } 
        }

        public override string ToString()
        {
            return description + " ("+ amountsOfObjectsReserved +")";
        }




    }
}
