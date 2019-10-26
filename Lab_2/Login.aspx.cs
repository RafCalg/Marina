using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_2
{
    public partial class Login : System.Web.UI.Page
    {
        string username;
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text.Trim();
            password = txtPassword.Text.Trim();

            //try
            //{
                int n = CustomerDB.getCustomer(username, password);

                if (n >= 0)
                {
                    loginCheckResult.Text = "Logged in. " + " Customer ID is: " + n.ToString();
                    Session["ID"] = n;
                    Session["logged"] = true;
                    Response.Redirect("LeasedSlips.aspx");
                    
                }
                else
                {
                    loginCheckResult.Enabled = true;
                    loginCheckResult.Text = "User does not exist";
                    Session["logged"] = false;

                }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
    }
}
