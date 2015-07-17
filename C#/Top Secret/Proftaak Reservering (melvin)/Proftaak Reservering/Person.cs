using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proftaak_Reservering
{
    class Person
    {
        // The attributes
        string Name;
        string Address;
        string PhoneNumber;
        string Email;
        string EmergencyNumber;
        public string RFID;

        // The methods

        private void CreatePerson(string Name, string Address, string PhoneNumber, string Email, string EmergencyNumber)
        {
            // voeg persoon met ingevoerde gegevens in in database

            // ken persoon automatisch een RFID code toe door te wissen uit tabel (RFID) en toe te voegen als attribuut van Person
        }
    }
}
