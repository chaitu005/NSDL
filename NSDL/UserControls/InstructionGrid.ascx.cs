using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSDL.Classes;
using System.Data;

namespace NSDL.UserControls
{
    public partial class InstructionGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            //select  ie_lotno,ie_slipno,ie_cmcd,ie_execdt,ie_nooftrx,ie_noofcert,ie_rejected,ie_trxtype,ie_instno,ie_mode,ie_remark,ie_charge,ie_pri_key from Inward_entry
            string Str_Query = "select ie_lotno,ie_slipno,ie_cmcd,ie_execdt,ie_nooftrx,ie_noofcert,ie_rejected,ie_trxtype,ie_instno,ie_mode,ie_remark,ie_charge,ie_pri_key from Inward_entry";
            DBHelper db = new DBHelper();
            DataSet ds = db.executeDataSet(Str_Query);
            grdReceipts.DataSource = ds;
            grdReceipts.DataBind();
            

        }
    }
}