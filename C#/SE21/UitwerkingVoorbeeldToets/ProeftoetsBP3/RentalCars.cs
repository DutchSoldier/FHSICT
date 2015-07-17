using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace RentalCarAdmin
{
    class RentalCars:IRentalCars
    {
        private List<RentalCar> rentalCars;
        private int nextId;

        public RentalCars()
        {
            rentalCars = new List<RentalCar>();
            nextId = 1000;
        }

        public List<int> GetCarsAvailable()
        {
           List<int> cars = new List<int>();
           foreach (RentalCar c in rentalCars)
           {
               if (!c.Rented) cars.Add(c.Id);
           }
           return cars;
        }

        public List<int> GetCarsRented()
        {
            List<int> cars = new List<int>();
            foreach (RentalCar c in rentalCars)
            {
                if (c.Rented) cars.Add(c.Id);
            }
            return cars;
        }

        public string GetCarDescription(int id)
        {
            string descr = "niet gevonden";
            foreach (RentalCar c in rentalCars)
            {
                if (c.Id == id) descr = c.ToString();
            }
            return descr;
        }

        public long GetCarKilometers(int id)
        {
            long km = -1;
            foreach (RentalCar c in rentalCars)
            {
                if (c.Id == id) km = c.Kilometers;
            }
            return km;
        }

        public bool RentCar(int id)
        {
            foreach (RentalCar c in rentalCars)
            {
                if (c.Id == id && c.Rented == false)
                {
                    c.Rented = true;
                    return true;
                }
            }
            return false;
        }

        public bool ReturnCar(int id, long kilometers)
        {
            foreach (RentalCar c in rentalCars)
            {
                if (c.Id == id)
                {
                    c.Rented = false;
                    c.Kilometers = kilometers;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveRentalCar(int id)
        {
            foreach (RentalCar c in rentalCars)
            {
                if (c.Id == id)
                {
                    rentalCars.Remove(c);
                    return true;
                }
            }
            return false;
        }

        public void AddRegularCar(RegularCar regularcar)
        {
           rentalCars.Add(regularcar);
        }

        public int GetNewId()
        {
            nextId++;
            return nextId;
        }

        public void AddTruck(Truck truck)
        {
            rentalCars.Add(truck);
        }

        public string SaveRentalCars()
        {
            FileStream bestand;          // koppelen bestand op schijf aan applicatie
            BinaryFormatter format;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                DialogResult resultaat = saveFileDialog1.ShowDialog();
                String bestandsNaam = saveFileDialog1.FileName;

                bestand = new FileStream(bestandsNaam, FileMode.Create, FileAccess.Write);
                format = new BinaryFormatter(); // binair koppelen


                format.Serialize(bestand, this.rentalCars);

                bestand.Close();
                return "gelukt";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public string LoadRentalCars()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult resultaat = openFileDialog1.ShowDialog();
            String bestandsNaam = openFileDialog1.FileName;
            FileStream bestand;          // koppelen bestand op schijf aan applicatie
            BinaryFormatter format;
            try
            {
                bestand = new FileStream(bestandsNaam, FileMode.Open, FileAccess.Read);
                format = new BinaryFormatter(); // binair koppelen


                rentalCars = (List<RentalCar>)format.Deserialize(bestand);

                bestand.Close();
                return "gelukt";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }

        }
    }
}
