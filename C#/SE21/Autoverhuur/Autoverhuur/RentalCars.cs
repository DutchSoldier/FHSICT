using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.ComponentModel;
using System.Drawing;


namespace RentalCarAdminstration
{
    class RentalCars : IRentalCars
    {
        
        RentalCar rc;
        private int i = 0;
        public List<int> GetCarsAvailable = new List<int>();
        public List<int> GetCarsRented = new List<int>();
        public List<RentalCar> rentalcars = new List<RentalCar>();


        public string GetCarDescription(int id)
        {
            return rc.info;
        }

        public long GetCarKilometers(int id)
        { 
            return rc.Kilom;
        }

        public bool RentCar(int id)
        {
            foreach (RentalCar rc in rentalcars)
            { 
                if(rc.available ==true && rc.id == id )
                {
                    rc.available = false;
                    return true;
                }
                
            }
            return false;
        }

        public bool ReturnCar(int id, long kilometers)
        {
            foreach (RentalCar rc in rentalcars)
            {
                if (rc.available == false && rc.id == id)
                {
                    rc.available = true;
                    rc.Kilom = kilometers;
                    return true;
                }
            }
                return false;
        }

        public bool RemoveRentalCar(int id)
        {
            foreach (RentalCar rc in rentalcars)
            {
                if (rc.available == true && rc.id == id)
                {

                    rentalcars.Remove(rc);
                    return true;
                }
            }
            return false;
        }

        public void AddRegularCar(RegularCar regularcar)
        {
            regularcar = new RegularCar();
        }

        public int GetNewId()
        {
            foreach (RentalCar rac in rentalcars)
            {
                if (i != rac.id)
                {
                    rac.id = i;

                }
                else
                {
                    i++;
                }
            }
            return rc.id;
        }

        public void AddTruck(Truck truck)
        { 
            truck = new Truck();
        }

        public string SaveRentalCars(object sender, EventArgs e)
        {
            try
            {
                int i = GetCarsAvailable.Count();
                int p = GetCarsRented.Count();

                object[] obj = new object[i];
                object[] obje = new object[p];

                i = obj.Length;
                p = obje.Length;

                FileDialog oDialog = new SaveFileDialog();

                oDialog.DefaultExt = "log";

                oDialog.FileName = "Lijst met dieren";

                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@oDialog.FileName))
                    {
                        for (int w = 0; w < 1; w++)
                        {
                            file.WriteLine("Niet gereserveerd");
                            foreach (string line in obj)
                            {
                                file.WriteLine(line);
                            }
                            {
                                file.WriteLine("Gereserveerd");
                                foreach (string regel in obje)
                                {
                                    file.WriteLine(regel);
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception exp)
            {
                Console.WriteLine("" + exp);
            }
        }

        public string LoadRentalCars()
        { 
            
            FileStream fs = new FileStream("C:\\Text.txt", FileMode.OpenOrCreate ,FileAccess.ReadWrite);
            fs.Close();
            StreamWriter sw=new StreamWriter("C:\\Text.txt", true, Encoding.ASCII);
            string NextLine= rc.info;
            sw.Write(NextLine);
            sw.Close();

        }
    }
}
