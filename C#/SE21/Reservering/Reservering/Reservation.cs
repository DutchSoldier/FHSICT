using System;
using System.Collections.Generic;
using System.Linq;


namespace Reservering
{
    class Reservation
    {
        private List<Person> persons;
        private List<RentalObject> rentalObjects;
        private List<Campsite> availableCampsites;
        public Campsite selectedCampsite;
        public DataConnection dataConnection { get; private set; }

        public Reservation()
        {
            persons = new List<Person>();
            rentalObjects = new List<RentalObject>();
            availableCampsites = new List<Campsite>();
            dataConnection = new DataConnection();
        }

        public void getAvailableRentalObjects()
        {
            rentalObjects = dataConnection.getRentalObjects();
        }

        public void getAvailableCampsites()
        {
            availableCampsites = dataConnection.getCampsites();
        }


        //lijsten returnen
        public List<Campsite> returnAvailableCampsites()
        {
            return availableCampsites;
        }

        public List<RentalObject> returnRentalObjects()
        {
            return rentalObjects;
        }

        //objecten reserveren
        public void reserveRentalObject(RentalObject r, int amount, bool alterStock)
        {
            r.reserveItem(amount, alterStock);
        }

        public void addPerson(Person person)
        {
            persons.Add(person);
        }

        public void removePerson(Person person)
        {
            persons.Remove(person);
        }

        public List<Person> getPersons()
        {
            return persons;
        }

        public void clearPersons()
        {
            persons.Clear();
        }

        public void AlterReservedRentalObjects(List<RentalObject> ReservedRentalObjects)
        {
            foreach (RentalObject r in rentalObjects)
            {
                Console.WriteLine(Convert.ToString(r.rentalObjectNumber));
            }
            foreach (RentalObject r in rentalObjects)
            {
                foreach (RentalObject rr in ReservedRentalObjects)
                {
                    if (r.rentalObjectNumber == rr.rentalObjectNumber)
                    {
                        r.reserveItem(rr.amountsOfObjectsReserved, false);
                    }
                }
            }

       
        }

        public Campsite selectCampsite(int number)
        {
            foreach (Campsite c in availableCampsites)
            {
                if (c.number == number)
                {
                    return c;
                }
            }
            return null;
        }

        public void confirmReservation()
        {
            string rfid;
            int customerNumber = 0;
            int reservationNumber = 0;
            int primaryCustomerNumber = 0;
            int firstPerson = 1;

            dataConnection.reserveCampsite(selectedCampsite.number);
            reservationNumber = dataConnection.getNewReservationNumber() + 1;
            dataConnection.addReservation(selectedCampsite.number, reservationNumber);
            //werkt!
            foreach (Person p in persons)
            {
                Console.WriteLine(p.name);
                rfid = dataConnection.getFirstAvailableRFID();
                dataConnection.setRfidUnavailable(rfid);
                p.rfid = rfid;
                dataConnection.addPerson(p);       
                customerNumber = dataConnection.getNewCustomerNumber() + 1;
                Console.WriteLine(customerNumber);
                dataConnection.addCustomer(p, customerNumber, firstPerson);
                dataConnection.addCustomerToReservation(reservationNumber, customerNumber);

                if (firstPerson == 1)
                {
                    firstPerson = 0;
                    primaryCustomerNumber = customerNumber;
                }
            }

            //WERKT
            foreach (RentalObject r in rentalObjects)
            {
                if (r.amountsOfObjectsReserved > 0)
                {
                    Console.WriteLine(r.description);
                    dataConnection.addRentalObject(primaryCustomerNumber, r.rentalObjectNumber, r.amountsOfObjectsReserved);
                    dataConnection.updateStock(r.rentalObjectNumber, r.amountOfObjectsAvailable);
                }
            }
            

            

        }

        public void modifyReservation()
        {

        }

        public void getExistingReservation(string RFID)
        {

        }


    }
}
