using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using NSDL.Classes;

namespace NSDL
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Click(object sender, EventArgs e)
        {
            Validate validate = new Validate();
            string user="",password="";
            if (validate.isValidInput(UserName, 3))
                user = UserName.Text.Trim();
            else
                showMessage("Invalid User Name");

            if (validate.isValidInput(Password, 3))
                password = Password.Text.Trim();
            else
                showMessage("Invalid Password");
            int res = new ValidateUser().isValidUser(user,password);
            if (res > 0)
            {
                string strUser = "select um_user_id,um_passwd,um_loginflag,um_brcode,um_user_name,convert(char,um_valid_to,112) um_valid_to,"
                                + "um_logstat,um_special,um_group_id,um_email,um_lastresetday,datediff(d, um_lastresetday, getdate()) as intDay,"
                                + "um_resetpwddays, um_locked, um_poaforpayin,um_status from User_master where um_user_id ='" + user + "'";

                DBHelper db = new DBHelper();
                DataTable dt = db.executeQuery(strUser);

                db.setSessionValue("UserId", user);
                db.setSessionValue("Password", password);
                db.setSessionValue("UserGroup", db.GetDtValue(dt, "um_group_id"));
                Response.Redirect("~/Home.aspx");
                db.setSessionValue("LoginPage","~/Login.aspx");
            }
            else {
                showMessage("Invalid User Name / Password");
            }

        }
        public void showMessage(string message)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + message + "');", true);
        }
    }
}