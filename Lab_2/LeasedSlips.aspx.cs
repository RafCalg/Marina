using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Lab_2
{
    public partial class LeasedSlips : System.Web.UI.Page
    {
        public List<int> slipIDList = new List<int>();
        public int slipID;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID"] != null)
            {
                //lblInfo.Text = "Customer ID:" + Session["ID"].ToString() + ". Your lease history:";
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }

        protected void gvSelectedDockSlips_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = gvSelectedDockSlips.SelectedRow;
            slipID = Convert.ToInt32(gr.Cells[0].Text);
            Session["SlipID"] = slipID;
            foreach (GridViewRow row in gvSelectedDockSlips.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
            }
            gr.BackColor = System.Drawing.Color.LightBlue;
        }

        protected void selectSlipButton_Click(object sender, EventArgs e)
        {
                slipID = (int)Session["SlipID"];

            Code.SlipDB.UpdateSlip(slipID);

            
            Code.LeaseDB.AddLease(slipID);

            gvSelectedDockSlips.DataBind();
            GridView1.DataBind();
        }

        protected void dockDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}