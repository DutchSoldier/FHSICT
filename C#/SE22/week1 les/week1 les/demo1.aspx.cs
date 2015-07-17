//homos
namespace Week1_les
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Demo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Remi_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text == null)
            {
               this.Label1.Text = "Voer een naam en geslacht in";
            }
            else if (this.TextBox1.Text != null)
            {
                if (this.RadioButton1.Checked == true)
                {
                    this.Label1.Text = "Hallo meneer: " + TextBox1.Text;
                    this.DropDownList1.Items.Add("Man: " + TextBox1.Text);
                }
                else if (this.RadioButton2.Checked == true)
                {
                    this.Label1.Text = "Hallo mevrouw: " + TextBox1.Text;
                    this.DropDownList1.Items.Add("Vrouw: " + TextBox1.Text);
                }
            }
        }
    }
}