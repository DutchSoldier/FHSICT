using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCarAdmin
{
    [Serializable]
    abstract class RentalCar
    {
        public RentalCar(int id, string brand, string type, long kilometers, int weight, string registration)
        {
    
            Id = id;
            Brand = brand;
            Type = type;
            Kilometers = kilometers;
            Weight = weight;
            Registration = registration;
        }

        public string ToString()
        {
            return Id + ", " + Brand + ","+ Registration+ ", rented:"+ Rented;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public long Kilometers { get; set; }
        public int Weight { get; set; }
        public string Registration { get; set; }
        public bool Rented { get; set; }

    }

}
