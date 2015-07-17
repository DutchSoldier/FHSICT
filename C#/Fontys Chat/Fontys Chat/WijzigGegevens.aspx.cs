// Wijziging gegevens app.

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class WijzigGegevens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object session = Session[Constants.LOGGED_IN_SESSION];
            if (session == null) 
            {
                Response.Redirect(Constants.LOGIN_PAGE, true); // Dit moet true zijn.
            }
        }

        protected void BtnSignup_Click(object sender, EventArgs e)
        {
            if (this.TbNewPass.Text == this.TbConfirmPass.Text && this.TbNewPass.Text != string.Empty && this.TbConfirmPass.Text != string.Empty && this.TbName.Text != string.Empty)
            {
                
                // alle fields kloppen, user wordt in DB gezet
                DatabaseMethods.ChangeAccount(this.TbName.Text, this.TbNewPass.Text, ((User)Session[Constants.LOGGED_IN_SESSION]).Id);
                this.LabelSignUp.Visible = true;
                this.LabelSignUp.Text = "Succesfully changed your account information.";
            }
            else
            {
                if (this.TbNewPass.Text != this.TbConfirmPass.Text)
                {
                    this.LabelSignUp.Visible = true;
                    this.LabelSignUp.Text = "Passwords don't match";
                }
                if (this.TbNewPass.Text == string.Empty || this.TbConfirmPass.Text == string.Empty || this.TbName.Text == string.Empty)
                {
                    this.LabelSignUp.Visible = true;
                    this.LabelSignUp.Text = "Not all fields are filled in";
                }
            }
        }
    }
}