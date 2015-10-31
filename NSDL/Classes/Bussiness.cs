using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace NSDL.Classes
{
    public class Bussiness
    {
        public DataSet getMenu_On_groupid(string strUser)
        {
            DataSet j = null;
            try
            {
                DBHelper db = new DBHelper();
                j = db.executeDataSet("USP_FINAPP_MENU_MASTER_SELECT_MENU_TO_DISPLAY '" + db.getSessionValue("UserId") + "'");
            }
            catch
            {

                j = null;
            }
            return j;
        }
        public int savedatatoBankMaster(object Parameter)
        {
            int j = 0;
            try
            {
                //FinancialDatabaseLayer.DataBase objDB = new DataBase(ConfigurationManager.ConnectionStrings["FinancialConnectionString"].ConnectionString);
                ELBankMaster objEL = (ELBankMaster)Parameter;

                DBHelper objDB = new DBHelper();

                objDB.AddParameter("@bk_micr", objEL.BK_MICR);
                objDB.AddParameter("@bk_name", objEL.BK_NAME);
                objDB.AddParameter("@bk_branch", objEL.BK_BRANCH);
                objDB.AddParameter("@bk_add1", objEL.BK_ADD1);
                objDB.AddParameter("@bk_add2", objEL.BK_ADD2);
                objDB.AddParameter("@bk_add3", objEL.BK_ADD3);
                objDB.AddParameter("@bk_city", objEL.BK_CITY);
                objDB.AddParameter("@bk_state", objEL.BK_STATE);
                objDB.AddParameter("@bk_country", objEL.BK_COUNTRY);
                objDB.AddParameter("@bk_pin", objEL.BK_PIN);
                objDB.AddParameter("@bk_tele1", objEL.BK_TELE1);
                objDB.AddParameter("@bk_tele2", objEL.BK_TELE2);
                objDB.AddParameter("@bk_fax", objEL.BK_FAX);
                objDB.AddParameter("@bk_email", objEL.BK_EMAIL);
                objDB.AddParameter("@bk_conname", objEL.BK_CONNAME);
                objDB.AddParameter("@bk_condesg", objEL.BK_CONDESG);
                objDB.AddParameter("@Mode", objEL.BK_Mode);
                j = objDB.executeNonQuerySP("usp_Finapp_Single_Bank_Master_Insert_Update_Select");
            }
            catch
            {
                j = 0;
            }
            return j;
        }
        public DataSet Search_Master(object Parameter)
        {
            DataSet ds;
            DBHelper objDB = new DBHelper();
            ELBankMaster objEL = new ELBankMaster();
            objDB.AddParameter("@bk_micr", objEL.BK_MICR);
            objDB.AddParameter("@bk_name", objEL.BK_NAME);
            objDB.AddParameter("@bk_branch", objEL.BK_BRANCH);
            objDB.AddParameter("@Mode", objEL.BK_Mode);
            ds = objDB.executeDataSetSP("usp_Single_Bank_Master_Search");
            return ds;
        }

        public object Search_Duplicate_Micr(object Parameter)
        {
            // DataSet ds;
            object j;
            try
            {
                DBHelper objDB = new DBHelper();
                ELBankMaster objEL = new ELBankMaster();
                objDB.AddParameter("@bk_micr", objEL.BK_MICR);
                objDB.AddParameter("@Mode", objEL.BK_Mode);
                // objDB.AddParameter("@bk_micr", objEL.BK_MICR);
                objDB.AddParameter("@bk_name", objEL.BK_NAME);
                objDB.AddParameter("@bk_branch", objEL.BK_BRANCH);
                objDB.AddParameter("@bk_add1", objEL.BK_ADD1);
                objDB.AddParameter("@bk_add2", objEL.BK_ADD2);
                objDB.AddParameter("@bk_add3", objEL.BK_ADD3);
                objDB.AddParameter("@bk_city", objEL.BK_CITY);
                objDB.AddParameter("@bk_state", objEL.BK_STATE);
                objDB.AddParameter("@bk_country", objEL.BK_COUNTRY);
                objDB.AddParameter("@bk_pin", objEL.BK_PIN);
                objDB.AddParameter("@bk_tele1", objEL.BK_TELE1);
                objDB.AddParameter("@bk_tele2", objEL.BK_TELE2);
                objDB.AddParameter("@bk_fax", objEL.BK_FAX);
                objDB.AddParameter("@bk_email", objEL.BK_EMAIL);
                objDB.AddParameter("@bk_conname", objEL.BK_CONNAME);
                objDB.AddParameter("@bk_condesg", objEL.BK_CONDESG);

                j = objDB.executeScalar("usp_Finapp_Single_Bank_Master_Insert_Update_Select");
            }
            catch
            {
                j = null;
            }
            //j = objDB.ExecuteDataSet();
            return j;

        }
        public DataSet SelectState_MasteForLoad()
        {
            DataSet ds;
            DBHelper objDB = new DBHelper();
            // FinancialEntityLayer.ComboElement objEL = (ComboElement) Parameter;
            // objDB.AddParameter(("",objEL.intselectedvalue);
            ds = objDB.executeDataSetSP("usp_FinnacApp_State_Master_Select");
            return ds;
        }
        public DataSet Select_BK_Name_Micr_IFSC()
        {
            DataSet ds = null; ;
            try
            {
                DBHelper objDB = new DBHelper();
                ds = objDB.executeDataSetSP("usp_FinnaceApp_Bank_Select_bkname_micr_ifsc");

            }
            catch
            {
                ds = null;
            }
            return ds;
        }

        public DbDataReader Select_All_Bank_Master_Update(object parameter)
        {
            DbDataReader ds = null; ;
            try
            {
                DBHelper objDB = new DBHelper();
                ELBankMaster objEL = new ELBankMaster();
                objDB.AddParameter("@bk_micr", objEL.BK_MICR);
                ds = objDB.ExecuteReaderSP("usp_Finapp_Single_Bank_Master_Select");
            }
            catch
            {
                ds = null;
            }
            return ds;

        }


        public DataSet Select_BK_Name(object parameter)
        {
            DataSet ds = null; ;
            try
            {
                DBHelper objDB = new DBHelper();
                ELBankMaster objEL = new ELBankMaster();
                objDB.AddParameter("@bank_name", objEL.BK_NAME);
                ds = objDB.executeDataSetSP("usp_FinnaceApp_Bank_Select_bkname");

            }
            catch
            {
                ds = null;
            }
            return ds;
        }

        public DataSet Select_code_desc()
        {
            DataSet ds = null; ;
            try
            {
                DBHelper objDB = new DBHelper();
                //  FinancialEntityLayer.ELBankMaster objEL = (ELBankMaster)parameter;
                // objDB.AddParameter("", objEL.BK_NAME);

                ds = objDB.executeDataSetSP("usp_Single_User_Group_Select");

            }
            catch
            {
                ds = null;
            }
            return ds;
        }



        public SqlDataReader select_BK_for_Update(object parameter)
        {
            SqlDataReader dr = null;
            try
            {
                DBHelper objDB = new DBHelper();
                ELBankMaster objEL = new ELBankMaster();
                objDB.AddParameter("@Mode", objEL.BK_Mode);
                objDB.AddParameter("@bank_micr", objEL.BK_MICR);

                dr = (SqlDataReader)objDB.ExecuteReaderSP("FinancaApp_Bank_Master_Bank_Select");

            }
            catch
            {
                dr = null;
            }

            return dr;
        }
    }
}