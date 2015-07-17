using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCarAdminstration
{
    class RegularCar : RentalCar
    {
        public string RegularCar;

        public string ToString(RentalCar regularCar)
        {
            RegularCar = regularCar.info + id;
            return RegularCar;
        }

        int Doors(int x)
        { 
        
        }
    }
}
