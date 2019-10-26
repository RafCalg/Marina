using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;

namespace Lab_2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Customer newCustomer = new Customer();

                newCustomer.FirstName   = txtFirstName.Text.Trim();
                newCustomer.LastName    = txtLastName.Text.Trim();
                newCustomer.Phone       = txtPhone.Text.Trim();
                newCustomer.City        = txtCity.Text.Trim();
                newCustomer.Username    = txtUsername.Text.Trim();
                newCustomer.Password    = txtPassword.Text.Trim();

                CustomerDB.InsertCustomer(newCustomer);

                registerCheckResult.Text = CustomerDB.getCustomer(txtUsername.Text, txtPassword.Text).ToString();

                Session["ID"] = CustomerDB.getCustomer(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                Session["logged"] = true;
            }
            catch(Exception ex)
            {
                registerCheckResult.Text = ex.Message;
            }

        }

    }
}