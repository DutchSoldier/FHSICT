using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCarAdmin
{
    [Serializable]
    class RegularCar: RentalCar
    {
        public RegularCar(int doors, int id, string brand, string type, long kilometers, int weight, string registration)
            : base(id, brand, type, kilometers, weight, registration)
        {
            Doors = doors;
        }
        public string ToString()
        {
            return base.ToString() + ", " + Doors;
        }
        public int Doors { get; set; }
    }
}
