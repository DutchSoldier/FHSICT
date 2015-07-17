// Vriendenlijst.

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class FriendsList : System.Web.UI.UserControl
    {
        private User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = string.Empty;
        }

        protected void SqlDataSource1_Init(object sender, EventArgs e)
        {
            object session = Session[Constants.LOGGED_IN_SESSION];
            if (session != null)
            {
                if (this.user == null)
                {
                    this.user = ((User)session);
                    this.SqlDataSource1.SelectParameters["userId"].DefaultValue = this.user.Id.ToString();
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            this.GridView1.DataBind();
            this.SqlDataSource1.SelectParameters["userId"].DefaultValue = this.user.Id.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = this.user.Id;
            string username = this.user.Name;
            User friend = DatabaseMethods.NewFriend(this.TextBox1.Text);
            if (friend != null)
            {
                DatabaseMethods.AddFriend(id, friend.Id);
                try
                {
                    Mail.VerzendMail("252753@student.fontys.nl", friend.Email, "Vriend toegevoegd", Mail.FriendMailBody(username), "smtp1.fontys.nl");
                }
                catch (Exception ex)
                {
                    this.Label1.Text = ex.Message;
                }
                this.GridView1.DataBind();
            }
            else
            {
                this.Label1.Text = "This friend does not exist!";
            }
        }
    }
}