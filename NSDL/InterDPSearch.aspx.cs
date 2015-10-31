using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

namespace NSDL.Instruction
{
    public partial class InterDPSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public void getInterDP(string _item, string _value)
        {
            //SingleEntities db = new SingleEntities();
            string query = "SELECT  id_pri_key Code, id_internalrefno,id_scrollno FROM  Interdepository  WHERE id_trxtype = '925' AND ";
            if(_item=="1")
                query += " id_internalrefno ";
            else
                query += " id_scrollno ";
            query += "LIKE '%" + _value + "%'";

            DataSet ds = new Classes.DBHelper().executeDataSet(query);            
            grd_Search.DataSource = ds;
            grd_Search.DataBind();

        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            string _item = optSelect.SelectedValue;
            string _value = txtSearch.Text.Trim();
            getInterDP(_item, _value);
        }

        protected void grd_Search_RowDataBounds(object sender, GridViewRowEventArgs e)
        {
            HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink1");
            if (h1 != null) {
                h1.NavigateUrl = "javascript://";
                string txt = h1.Text;
                string s = "winOpener=window.self.opener;";
                //s = s + " PageMethods.getFillDetailsOnSearch(" + txt + "); ";
                //s = s + " winOpener.document.getElementById('ClientID').value = '123' ;";
                s = s + " window.close();";
                s = s + "window.location.href='Instruction/InterDP.aspx?do=fetchInterDP&val=" + txt + "'";
                h1.Attributes.Add("onclick", s);
            }
            
        }

        protected void grd_Search_RowCommand(object sender, GridViewCommandEventArgs e )
        {
            string res = grd_Search.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;

            string close = @"<script type='text/javascript'> document.window.close(); document.window.location.href='Instruction/InterDP.aspx?do=fetchInterDP&val=" + res + "'  </script>";
            //base.Response.Write(close);
            //Application.Current.Windows[0].Close();
            //Server.Transfer("Instruction/InterDP.aspx?do=fetchInterDP&val=" + res,true);
            
        }
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static void FetchInterDP(string val)
        {
            //new InterDP().getFillDetailsOnSearch(Convert.ToInt32(val));

            string redirectUrl = "InterDP.aspx?id ="+ val;
            //ScriptManager.RegisterStartupScript(this,  GetType(), "Redirect", "window.parent.location = " + redirectUrl, true);
        }
    }
}