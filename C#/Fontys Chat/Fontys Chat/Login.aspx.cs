// Login Pagina.

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;

    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            object session = Session[Constants.LOGGED_IN_SESSION];
            if (session != null)
            {
                // Gebruiker is al ingelogd.
                Response.Redirect(Constants.HOME_PAGE, false); // Verbreek sessie niet.
            }
            else
            {
                Page.SetFocus(this.TbEmail); // Zo kan de gebruiker meteen typen.
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnSignup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSignup_Click(object sender, EventArgs e)
        {
            if (this.TbNewPass.Text == this.TbConfirmPass.Text && this.TbNewEmail.Text != string.Empty && this.TbNewPass.Text != string.Empty && this.TbConfirmPass.Text != string.Empty && this.TbName.Text != string.Empty)
            {
                if (DatabaseMethods.DoesEmailExist(this.TbNewEmail.Text, this.TbNewPass.Text) || DatabaseMethods.DoesUsernameExist(this.TbName.Text)) 
                {
                    this.LabelSignUp.Text = "This email or username is already in use!";
                    // TODO - UNIQUE email?
                    return;
                }
                // alle fields kloppen, user wordt in DB gezet en krijgt een mail
                DatabaseMethods.SignUp(this.TbName.Text, this.TbNewPass.Text, this.TbNewEmail.Text);
                //Mail.VerzendMail("252753@student.fontys.nl", this.TbNewEmail.Text, "Signed up to FontysChat", Mail.Mailbody(this.TbName.Text, this.TbNewPass.Text), "smtp1.fontys.nl");
                this.LabelSignUp.Visible = true;
                this.LabelSignUp.Text = "Succesfully signed up! An email has been sent to confirm your signup :D:D";
            }
            else
            {
                if (this.TbNewPass.Text != this.TbConfirmPass.Text)
                {
                    this.LabelSignUp.Visible = true;
                    this.LabelSignUp.Text = "Passwords don't match";
                }
                if (this.TbNewEmail.Text == string.Empty || this.TbNewPass.Text == string.Empty || this.TbConfirmPass.Text == string.Empty || this.TbName.Text == string.Empty)
                {
                    this.LabelSignUp.Visible = true;
                    this.LabelSignUp.Text = "Not all fields are filled in";
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TbEmail.Text) && !string.IsNullOrEmpty(this.TbPass.Text))
            {
                User user = DatabaseMethods.LoadUser(this.TbEmail.Text, this.TbPass.Text);
                if (user != null)
                {
                    DatabaseMethods.SetOnlineStatus(user.Id, true); // Zet de gebruiker online.
                    this.Session[Constants.LOGGED_IN_SESSION] = user; // Als je ((User)Session[Constants.LOGGED_IN_SESSION]) aanroept, kan je aan de gebruiker komen.
                    Response.Redirect(Constants.HOME_PAGE, false);
                }
                else
                {
                    this.LabelLoginFalse.Visible = true;
                }
            }
        }

        /// <summary>
        /// Clears the session.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static string ClearSession()
        {
            HttpContext.Current.Session.Abandon();
            return string.Empty;
        }
    }
}