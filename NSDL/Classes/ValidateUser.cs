using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NSDL.Classes;

namespace NSDL.Classes
{
    public class ValidateUser
    {
        public int isValidUser(string user,string password)
        {
            try 
            {
                string strQuery = "select count(um_user_id) from User_master where um_user_id ='" + user + "' and um_passwd='" + password + "'";
                DBHelper db = new DBHelper();
                //string result = db.executeScalar(strQuery);
                int res = Convert.ToInt32(db.executeScalar(strQuery));
                if (res > 0)
                    db.setSessionValue("UserId", user.Trim());
                return res; 
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}