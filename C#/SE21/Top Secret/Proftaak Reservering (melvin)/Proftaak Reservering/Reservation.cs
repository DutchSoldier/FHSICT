using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proftaak_Reservering
{
    class Reservation
    {
        // The attributes
        string AmountOfPeople;
        string Cost;
        string ReservationNumber;
        bool Reserved;
        int Price;
        List<Person> PersonPerReservation = new List<Person>();

        // The methods
        private void addPerson(Person p)
        {
            PersonPerReservation.Add(p);
        }

        private void createReservation()
        {
            if (Convert.ToInt32 (AmountOfPeople) < PersonPerReservation.Count)
            {
                MessageBox.Show("You heve chosen a spot that is too small.");
            }

            if (Reserved == true)
            {
                MessageBox.Show("Your chosen spot had already been Reserved.");
            }

            // maakt reservering aan met personen, kampeerplaatsgegevens, bedrag betaald,
        }

        private void getInfoCampingSpot(int amountOfPeople, string info, string spotNumber)
        {
            amountOfPeople = Convert.ToInt32(AmountOfPeople);

            // Vraagt de informatie van een gekozen plek op en geeft deze weer
        }

        private void calculateCost()
        {
            PersonPerReservation.Count * Price;
        }
    }
}
