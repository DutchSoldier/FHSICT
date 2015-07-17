// Chat pagina.

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    /// <summary>
    /// The home page.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        private User user;

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
                if (this.user == null)
                {
                    this.user = (User)session;
                    if (this.user.CurrentChat == null)
                    {
                        this.user.CurrentChat = new Chat(1, "Main Chat");
                    }
                    this.Label1.Text = this.user.CurrentChat.Name + " - " + this.user.Name;
                }
            }
            else
            {
                Response.Redirect(Constants.LOGIN_PAGE, true); // Dit moet true zijn.
            }
        }

        /// <summary>
        /// Handles the Tick event of the Timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            this.ListView1.DataBind();
        }

        /// <summary>
        /// Handles the Click event of the Button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                if (this.TextBox1.Text.Length <= 100)
                {
                    this.user.SubmitText(TextBox1.Text);
                    this.TextBox1.Text = string.Empty;
                    this.Label2.Text = string.Empty;
                }
                else
                {
                    this.Label2.Text = "The maximum amount of characters is 100.";
                }
            }
        }
    }
}