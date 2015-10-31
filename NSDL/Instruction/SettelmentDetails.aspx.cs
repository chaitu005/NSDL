using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSDL.Classes;
using System.Data;

namespace NSDL.Instruction
{
    public partial class SettelmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrWhiteSpace(Session["UserId"] as string))
                {
                    Response.Redirect("~/Login.aspx");
                }
                else { 
                string code1 = Request.QueryString["code1"];
                string code2 = Request.QueryString["code2"];
                if (!string.IsNullOrWhiteSpace(code1) && !string.IsNullOrWhiteSpace(code2))
                {
                    string strUser = " select id_trxdate,id_scrollno,id_instcd,id_lotno,'' lotsize,"
                                    +" id_settlementno,id_cc_id,cm_name,id_dqty,id_qty,id_executiondate,id_remarks,id_entrymode"
                                    +" from Interdepository left join Client_master1 on id_cc_id = Client_master1.cm_cd"
                                    + " where id_instcd=" + code1 + " and id_pri_key=" + code2 ;

                    DBHelper db = new DBHelper();
                    DataTable dt = db.executeQuery(strUser);
                    lbl_set_date.Text = db.GetDtValue(dt, "id_trxdate");
                    lbl_set_scrollNo.Text = db.GetDtValue(dt, "id_scrollno");
                    lbl_set_insType.Text = db.GetDtValue(dt, "id_instcd");
                    lbl_set_avblLot.Text = db.GetDtValue(dt, "id_lotno");
                    lbl_set_lotSize.Text = db.GetDtValue(dt, "lotsize");
                    lbl_set_slipNo.Text = db.GetDtValue(dt, "id_settlementno");
                    lbl_set_clientCode.Text = db.GetDtValue(dt, "id_cc_id");
                    lbl_set_clientName.Text = db.GetDtValue(dt, "cm_name");
                    lbl_set_instructions.Text = db.GetDtValue(dt, "id_dqty");
                    lbl_set_noofcerts.Text = db.GetDtValue(dt, "id_qty");
                    lbl_set_execDate.Text = db.GetDtValue(dt, "id_executiondate");
                    lbl_set_charges.Text ="";
                    lbl_set_remarks.Text = db.GetDtValue(dt, "id_remarks");
                    lbl_set_mod.Text = db.GetDtValue(dt, "id_entrymode");
                }
                }
            }

        }
    }
}