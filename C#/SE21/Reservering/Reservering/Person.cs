using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reservering
{
    public class Person
    {
        public string rfid { get; set; }
        public string name { get; private set; }
        public string password { get; private set; }
        public string email { get; private set; }
        public string zipCode { get; private set; }
        public string houseNumber { get; private set; }
        public string phoneNumber { get; private set; }
        public string emergencyNumber { get; private set; }

        public Person(string Name, string Password, string Email, string ZipCode, string HouseNumber, String PhoneNumber, string EmergencyNumber)
        {
            name = Name;
            password = Password;
            email = Email;
            zipCode = ZipCode;
            houseNumber = HouseNumber;
            phoneNumber = PhoneNumber;
            emergencyNumber = EmergencyNumber;
        }
    }
}
