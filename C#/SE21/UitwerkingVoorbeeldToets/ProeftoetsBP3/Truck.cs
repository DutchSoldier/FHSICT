using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCarAdmin
{
    [Serializable]
    class Truck: RentalCar
    {
        public Truck(int maxPayLoad, int height, int id, string brand, string type, long kilometers, int weight, string registration):base ( id,  brand,  type,  kilometers,  weight,  registration)
        {
            MaxPayLoad = maxPayLoad;
            Height = height;
        }

        public string ToString()
        {
            return base.ToString() + ", " + MaxPayLoad + "," + Height;
        }

        public int MaxPayLoad { get; set; }
        public int Height { get; set; }

    }
}
