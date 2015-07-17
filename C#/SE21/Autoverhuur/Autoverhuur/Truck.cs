using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCarAdminstration
{
    class Truck : RentalCar
    {
        public string Truck;
        
        public string ToString(RentalCar truck)
        {
            Truck = truck.info + id;
            return Truck;
        }

        int MaxPayLoad(int x)
        { 
        
        }

        int Height(int y)
        { 
        
        }
    }
}
