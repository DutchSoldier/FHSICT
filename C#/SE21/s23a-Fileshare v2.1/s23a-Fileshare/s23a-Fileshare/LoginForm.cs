using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace s23a_Fileshare
{
    public partial class LoginForm : Form
    {
        FileshareForm GUI;
        Database DATA; 

        string RFIDnumber;
        string Password;

        bool isAdmin;
        bool isBanned;

        string FetchedRFID; 
        string FetchedPassword;

        public LoginForm()
        {
            InitializeComponent();
        }
        #region //Event Methods
        private void tbPassword_Enter(object sender, EventArgs e)
        {
            tbPassword.Text = "";
            tbPassword.PasswordChar = '*';
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                LogIn();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        #endregion

        private void LogIn()
        {

            RFIDnumber = tbUsernumber.Text;
            Password = tbPassword.Text;

            isAdmin = false;
            GUI = new FileshareForm(RFIDnumber, isAdmin, this); //Temp until connected to database
            /*
            DATA = new Database(RFIDnumber);
            isAdmin = checkIsAdmin(RFIDnumber);
            isBanned = checkBanned(RFIDnumber);
            
            try
            {
                if (checkLoginInfo(RFIDnumber, Password))
                {
                    if (!isBanned)
                    {
                        GUI = new FileshareForm(RFIDnumber, isAdmin);
                        this.Close();
                    }
                }
            }
            catch
            {
                if (RFIDnumber != FetchedRFID)
                {
                    MessageBox.Show("Your login number is not registered.", "Login Error");
                }
                else if(isBanned)
                {
                    MessageBox.Show("You have been banned from the complex, please contact the administrative desk.", "Unauthorised");
                }
                else if (Password != FetchedPassword)
                {
                    MessageBox.Show("Your password is incorrect.", "Login error");
                }
            }
             */
        }

        /// <summary>
        /// Checks if the user input(LoginNumber and Password) match
        /// the ones retrieved from the database.
        /// </summary>
        /// <param name="rfidnumber">textbox input for LoginNumber</param>
        /// <param name="password">textbox input for Password</param>
        /// <returns>true if can login, false if info doesn't match.</returns>
        private bool checkLoginInfo(string rfidnumber, string password)
        {
            List<String> userDetails = DATA.checkPassword(rfidnumber);

            FetchedRFID = userDetails[0];
            FetchedPassword = userDetails[1];
            
            if (FetchedPassword != null) // is null if no password was returned (only when RFID doesn't exist in DB)
            {
                if (password == FetchedPassword)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the user's RFID is on the banned list in the database.
        /// </summary>
        /// <param name="rfidnumber"></param>
        /// <returns></returns>
        private bool checkBanned(string rfidnumber)
        {
            if(DATA.checkBanned(rfidnumber))
            { return true; }
            else return false;
        }
        /// <summary>
        /// Checks if the user's RFID is on the admin list in the database.
        /// </summary>
        /// <param name="rfidnumber"></param>
        /// <returns></returns>
        private bool checkIsAdmin(string rfidnumber)
        {
            List<String> Admins = DATA.checkAdmin(rfidnumber);
            if (Admins.Contains(rfidnumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
