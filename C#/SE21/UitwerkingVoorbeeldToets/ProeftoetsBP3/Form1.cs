using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RentalCarAdmin
{
    public partial class Form1 : Form
    {
        private RentalCars cars;
        public Form1()
        {
            InitializeComponent();
            cars = new RentalCars();
        }

        private void btMaakCars_Click(object sender, EventArgs e)
        {
            int id = cars.GetNewId();
            cars.AddRegularCar(new RegularCar(5, id, "Opel", "Zafira", 12222, 1500, "09-SF-FG"));
            cars.RentCar(id);
            cars.AddRegularCar(new RegularCar(5, cars.GetNewId(), "Opel", "Zafira", 12345, 1500, "09-HJ-VV"));
            cars.AddRegularCar(new RegularCar(5, cars.GetNewId(), "Opel", "Zafira", 42222, 1500, "09-HY-PP"));
            cars.AddTruck(new Truck(5000, 245, cars.GetNewId(), "DAF", "FACF", 182222, 2570, "VV-23-44"));
            cars.AddTruck(new Truck(5000, 245, cars.GetNewId(), "DAF", "FACF", 185622, 2570, "VK-67-44"));

            updateList();

        }

        private void updateList()
        {
            lbCars.Items.Clear();
            foreach (int cId in cars.GetCarsAvailable())
            {
                lbCars.Items.Add(cars.GetCarDescription(cId));
            }
            foreach (int cId in cars.GetCarsRented())
            {
                lbCars.Items.Add(cars.GetCarDescription(cId));
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string melding = cars.SaveRentalCars();
            MessageBox.Show(melding);
           
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            string melding = cars.LoadRentalCars();
            MessageBox.Show(melding);
            updateList();
        }

        private void btCarKilometers_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32( tbId.Text);
            tbResultaat.Text = cars.GetCarKilometers(id)+"" ;
        }

        private void btHire_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbId.Text);
            bool gelukt = cars.RentCar(id);
            if (gelukt) tbResultaat.Text = "gelukt";
            else tbResultaat.Text = "foutje";
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            this.updateList();
        }

        private void btReturnCar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbId.Text);
            int km = Convert.ToInt32(tbKm.Text);
            bool gelukt = cars.ReturnCar(id,km);
            if (gelukt) tbResultaat.Text = "gelukt";
            else tbResultaat.Text = "foutje";
        }


    }
}
