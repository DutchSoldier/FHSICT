using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reservering
{
    public partial class Form1 : Form
    {
        #region fields
        private Reservation reservation;
        private List<UsercontrolPerson> usercontrolPersons;
        public enum Status
        {
            MainMenu,
            PlaceReservation,
            Login,
            ModifyReservation
        }
        private Status currentStatus;
        private int numberOfPeople;
        private string rfidPrimaryCustomer;
        #endregion

        #region Properties
        public Status CurrentStatus
        {
            get
            {
                return currentStatus;
            }
            set
            {
                if (value != currentStatus)
                {
                    currentStatus = value;
                    updateInterface();
                }
            }
        }
        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }
            set
            {
                if (value != numberOfPeople)
                {
                    numberOfPeople = value;
                    updateAvailableCampsites();
                }
            }
        }
        #endregion

        
        public Form1()
        {
            InitializeComponent();
            usercontrolPersons = new List<UsercontrolPerson>();
            lboxAvailableItems.DisplayMember = "description";
        }

        #region persons
        private void addPersonPage()
        {
            if (tabControlPerson.TabPages.Count < 10)
            {
            //usercontrol init
            UsercontrolPerson usercontrol = new UsercontrolPerson();
            usercontrolPersons.Add(usercontrol);

            //tabpage init
            TabPage page = new TabPage("Person " + (tabControlPerson.TabPages.Count + 1).ToString());
            page.Name = ("tabPagePerson" + (tabControlPerson.TabPages.Count + 1).ToString());
            page.UseVisualStyleBackColor = true;
            page.Controls.Add(usercontrol);

            //add tabpage to control
            tabControlPerson.TabPages.Add(page);
            }
            else
            {
                MessageBox.Show("You can't add more people to your reservation");
            }
        }

        private void addPersonPage(Person p)
        {
            if (tabControlPerson.TabPages.Count < 10)
            {
                //usercontrol init
                UsercontrolPerson usercontrol = new UsercontrolPerson(p);
                usercontrolPersons.Add(usercontrol);

                //tabpage init
                TabPage page = new TabPage("Person " + (tabControlPerson.TabPages.Count + 1).ToString());
                page.Name = ("tabPagePerson" + (tabControlPerson.TabPages.Count + 1).ToString());
                page.UseVisualStyleBackColor = true;
                page.Controls.Add(usercontrol);

                //add tabpage to control
                tabControlPerson.TabPages.Add(page);
            }
            else
            {
                MessageBox.Show("You can't add more people to your reservation");
            }
        }

        private void removePersonPage()
        {
            if (tabControlPerson.TabPages.Count > 1)
            {
                //delete selected tabpage and usercontrol
                int selectedIndex = tabControlPerson.SelectedIndex;
                tabControlPerson.TabPages.RemoveAt(selectedIndex);
                usercontrolPersons.RemoveAt(selectedIndex);

                //rename remaining pages
                foreach (TabPage t in tabControlPerson.TabPages)
                {
                    t.Name = "TabPagePerson" + (tabControlPerson.TabPages.IndexOf(t) + 1).ToString();
                    t.Text = "Person " + (tabControlPerson.TabPages.IndexOf(t) + 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("A reservation needs at least 1 person.");
            }
        }

        private bool confirmPersons()
        {
            reservation.clearPersons();
            foreach (UsercontrolPerson u in usercontrolPersons)
            {
                if (u.validateUserInput())
                {
                    reservation.addPerson(new Person(u.name, u.password, u.email, u.zipCode, u.houseNumber, u.phoneNumber, u.emergencyNumber));
                }
                else
                {
                    return false;
                }
            }
            NumberOfPeople = tabControlPerson.TabCount;
            return true;
        }

        //events
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            addPersonPage();
            tabControlPerson.SelectTab(tabControlPerson.TabCount - 1);
        }

        private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            removePersonPage();
            confirmPersons();
        }

        private void btnConfirmPerson_Click(object sender, EventArgs e)
        {
            if (confirmPersons())
            {
                MessageBox.Show("Persons added to reservation");
                if (!validateCampsite())
                {
                    lbSelectedCampsiteNumber.Visible = false;
                    lbSelectedCampsiteNumberText.Visible = false;
                    lbSelectedCampsitePrice.Visible = false;
                    lbSelectedCampsitePriceText.Visible = false;
                    lbSelectedCampsiteType.Visible = false;
                    lbSelectedCampsiteTypeText.Visible = false;
                    MessageBox.Show("The campsite you've selected is not big enough for the amount of people. Please choose a new campsite");
                }
                tabControl.SelectTab(1);
            }
            else
            {
                MessageBox.Show("Invalid input. Please make sure all the passwords are atleast 6 characters and that all fields are filled");
            }
        }
        #endregion

        #region campsites
        private void getAvailableCampsites()
        {
            reservation.getAvailableCampsites();
            updateAvailableCampsites();
        }

        private void updateAvailableCampsites()
        {
            lboxAvailableCampsites.Items.Clear();
            foreach (Campsite c in reservation.returnAvailableCampsites())
            {
                if (c.available && c.maxPersons >= NumberOfPeople)
                {
                    lboxAvailableCampsites.Items.Add(c);
                }
            }
        }

        private bool validateCampsite()
        {
            if (reservation.selectedCampsite != null)
            {
                if (reservation.selectedCampsite.maxPersons < NumberOfPeople)
                {
                    reservation.selectedCampsite = null;
                    return false;
                }
            }
            return true;
        }

        private void confirmCampsite(Campsite c)
        {
            if (c != null)
            {
                if (reservation.selectedCampsite != null)
                {
                    reservation.selectedCampsite.available = true;
                }

                reservation.selectedCampsite = c;
                c.available = false;
                lbSelectedCampsiteNumber.Text = Convert.ToString(c.number);
                lbSelectedCampsitePrice.Text = "€" + String.Format("{0:0.00}", c.price);
                lbSelectedCampsiteType.Text = c.type;

                lbSelectedCampsiteNumber.Visible = true;
                lbSelectedCampsiteNumberText.Visible = true;
                lbSelectedCampsitePrice.Visible = true;
                lbSelectedCampsitePriceText.Visible = true;
                lbSelectedCampsiteType.Visible = true;
                lbSelectedCampsiteTypeText.Visible = true;

                updateAvailableCampsites();
            }

        }

        //events
        private void btnConfirmCampsite_Click(object sender, EventArgs e)
        {
            Campsite c = (Campsite)lboxAvailableCampsites.SelectedItem;
            confirmCampsite(c);
        }
        #endregion

        #region rentalObjects
        private void getAvailableRentalObjects()
        {
            reservation.getAvailableRentalObjects();
            foreach (RentalObject r in reservation.returnRentalObjects())
            {
                if (r.amountOfObjectsAvailable > 0)
                {
                    lboxAvailableItems.Items.Add(r);
                }
            }
        }

        public void updateAvailableRentalObjects()
        {
            //update listbox available and labels
            RentalObject r = (RentalObject)lboxAvailableItems.SelectedItem;
            if (r != null)
            {
                if (r.amountOfObjectsAvailable < 1)
                {
                    lboxAvailableItems.Items.Remove(r);
                    lbPrice.Text = "";
                    lbStock.Text = "";
                }
                else
                {
                    nudAmountToMove.Value = 1;
                    lbStockText.Text = "Stock";
                    lbPrice.Text = "€" + String.Format("{0:0.00}", r.pricePerItem);
                    lbStock.Text = Convert.ToString(r.amountOfObjectsAvailable);
                    nudAmountToMove.Maximum = (r.amountOfObjectsAvailable);
                }
            }
            else
            {
                lbPrice.Text = "";
                lbStock.Text = "";
            }
        }

        public void updateReservedRentalObjects()
        {
            double price = 0;
            lboxReservedItems.Items.Clear();
            foreach (RentalObject r in reservation.returnRentalObjects())
            {
                if (r.amountsOfObjectsReserved > 0)
                {
                    lboxReservedItems.Items.Add(r);
                    price += r.pricePerItem * r.amountsOfObjectsReserved;
                }
            }

            lbTotalPriceRentalObjects.Text = "Total Price Rental Objects: €" + String.Format("{0:0.00}", price);
        }

        public void updateReservedRentalObjectsLabels()
        {
            RentalObject r = (RentalObject)lboxReservedItems.SelectedItem;
            if (r != null)
            {
                nudAmountToMove.Value = 1;
                lbStockText.Text = "Amount Reserved";
                lbPrice.Text = "€" + String.Format("{0:0.00}", r.pricePerItem);
                lbStock.Text = Convert.ToString(r.amountsOfObjectsReserved);
                nudAmountToMove.Maximum = (r.amountsOfObjectsReserved);
            }
        }

        public void removeSelectedItem()
        {
            RentalObject r = (RentalObject)lboxReservedItems.SelectedItem;
            if (r != null)
            {
                int amount = (int)nudAmountToMove.Value;
                if (r.amountOfObjectsAvailable < 1 && amount > 0)
                {
                    lboxAvailableItems.Items.Add(r);
                }
                r.reserveItem(-amount, true);
                updateReservedRentalObjects();
            }
        }

        //events
        private void lboxAvailableItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateAvailableRentalObjects();
        }

        private void lboxReservedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateReservedRentalObjectsLabels();
        }

        private void btnAddRentalObjectToReservation_Click(object sender, EventArgs e)
        {
            RentalObject r = (RentalObject)lboxAvailableItems.SelectedItem;
            if (r != null)
            {
                int amount = (int)nudAmountToMove.Value;
                reservation.reserveRentalObject(r, amount, true);
                updateAvailableRentalObjects();
                updateReservedRentalObjects();
            }
        }

        private void btnRemoveRentalObjectFromReservation_Click(object sender, EventArgs e)
        {
            removeSelectedItem();
        }

        private void lboxAvailableItems_MouseClick(object sender, MouseEventArgs e)
        {
            lboxReservedItems.SelectedItem = null;
        }

        private void lboxReservedItems_MouseClick(object sender, MouseEventArgs e)
        {
            lboxAvailableItems.SelectedItem = null;
        }
        #endregion

        public void updateInterface()
        {
            if (currentStatus != Status.MainMenu && currentStatus != Status.Login)
            {
                btnPlaceReservation.Visible = false;
                btnModifyReservation.Visible = false;
                panelLogin.Visible = false;
                tabControl.Visible = true;
            }

            if (currentStatus == Status.PlaceReservation)
            {
                    getAvailableRentalObjects();
                    getAvailableCampsites();
            }

            if (currentStatus == Status.Login)
            {
                panelLogin.Visible = true;
                btnPlaceReservation.Visible = false;
                btnModifyReservation.Visible = false;

            }



            if (currentStatus == Status.ModifyReservation)
            {
                btnAddPerson.Visible = false;
                btnRemovePerson.Visible = false;

                reservation = new Reservation();
                getAvailableRentalObjects();
                getAvailableCampsites();
                reservation.getExistingReservation(rfidPrimaryCustomer);


                foreach (Person p in reservation.getPersons())
                {
                    addPersonPage(p);
                }
                
            }
        }

        private void btnPlaceReservation_Click(object sender, EventArgs e)
        {
            reservation = new Reservation();
            addPersonPage();
            CurrentStatus = Status.PlaceReservation;
        }

        private void btnModifyReservation_Click(object sender, EventArgs e)
        {
            CurrentStatus = Status.Login;
            reservation = new Reservation();
          
            //test objecten hieronder
            //Person person1 = new Person("test", "tes2223t", "test", "test", "test", "test", "test");
            //Person person2 = new Person("test", "tes2223t", "test", "test", "test", "test", "test");
            //reservation.addPerson(person1);
            //reservation.addPerson(person2);

            //confirmCampsite(reservation.selectCampsite(400));

            //List<RentalObject> reservedObjects = new List<RentalObject>();
            //reservedObjects.Add(new RentalObject(100,"",0,0,5));
            //reservedObjects.Add(new RentalObject(600,"",0,0,5));

            //reservation.AlterReservedRentalObjects(reservedObjects);
            //updateReservedRentalObjects();


            //enum update
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (reservation.selectedCampsite != null && reservation.getPersons() != null)
            {
                reservation.confirmReservation();
                btnConfirm.Enabled = false;
                MessageBox.Show("Reservation completed");
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = tbPassword.Text;
            string rfid = tbRFID.Text;

            if (!string.IsNullOrEmpty(rfid) && !string.IsNullOrEmpty(password))
            {
                if (reservation.dataConnection.login(rfid, password))
                {
                    rfidPrimaryCustomer = rfid;
                    CurrentStatus = Status.ModifyReservation;
                }
                else
                {
                    MessageBox.Show("Invalid RFID or password");
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter your RFID and Password");
            }
        }
    }
}
