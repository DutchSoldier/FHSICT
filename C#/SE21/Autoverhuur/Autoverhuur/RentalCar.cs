using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCarAdminstration
{
    abstract class RentalCar
    {
        public string info;
        public string Brand { get; set; }
        public string Type { get; set; }
        public long Kilom { get; set; }
        public int Weight { get; set; }
        public string Reg { get; set; }
        public int Doors { get; set; }
        public int MaxPL { get; set; }
        public int Height { get; set; }
        public int id { get; set; }
        public bool available { get; set; }
    
        private string ToString(RentalCar car)
        {
            info = "Brand: " + Brand + " , Type: " + Type + " , Kilometers: " + Kilom + " , Weight: " + Weight + " , Register: " + Reg + " , Doors: " + Doors + " , MaxPL: " + MaxPL + " , Height: " + Height;
            return info;
        }
    }
}
