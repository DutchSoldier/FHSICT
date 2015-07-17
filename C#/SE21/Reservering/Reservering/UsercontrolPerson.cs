using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reservering
{
    public partial class UsercontrolPerson : UserControl
    {
        public string name { get; private set; }
        public string password { get; private set; }
        public string email { get; private set; }
        public string zipCode { get; private set; }
        public string houseNumber { get; private set; }
        public string phoneNumber { get; private set; }
        public string emergencyNumber { get; private set; }

        public UsercontrolPerson()
        {
            InitializeComponent();
        }

        public UsercontrolPerson(Person person)
        {
            InitializeComponent();
            tbName.Text = person.name;
            tbPassword.Text = person.password;
            tbEmail.Text = person.email;
            tbZipCode.Text = person.zipCode;
            tbHouseNumber.Text = person.houseNumber;
            tbPhoneNumber.Text = person.phoneNumber;
            tbEmergencyNumber.Text = person.emergencyNumber;
        }

        public bool validateUserInput()
        {
            if (tbName.Text.Length > 0 &&
                tbPassword.Text.Length > 4 &&
                tbEmail.Text.Length > 0 &&
                tbZipCode.Text.Length > 0 &&
                tbHouseNumber.Text.Length > 0 &&
                tbPhoneNumber.Text.Length > 0 &&
                tbEmergencyNumber.Text.Length > 0)
            {
                name = tbName.Text;
                password = tbPassword.Text;
                email = tbEmail.Text;
                zipCode = tbZipCode.Text;
                houseNumber = tbHouseNumber.Text;
                phoneNumber = tbPhoneNumber.Text;
                emergencyNumber = tbEmergencyNumber.Text;
                return true;
            }
            return false;
        }

        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tbEmergencyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tbEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '@' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void tbZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tbHouseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
