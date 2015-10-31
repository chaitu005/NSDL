using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSDL
{
    public partial class NSDL : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null && !string.IsNullOrEmpty(Session["UserId"].ToString()))
            {
                lblUser.Text = Session["UserId"].ToString();
                lblDate.Text = System.DateTime.Today.ToShortDateString();
                lblCompany.Text = "XYZ SECURITIES LTD".ToString();
                //lblCompany.Text = Convert.ToString(objBLLogin.GetCompanyName());
            }
            else
            {
                Response.Redirect("~/Login.aspx");
                
            }


        }
        protected void imgbtnLogOut_Click(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

    }
}