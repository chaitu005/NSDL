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
    public partial class SettlementAuthorise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cmbfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbfilter.SelectedValue == "E" || cmbfilter.SelectedValue == "T")
            {
                manageDateFilter(true);
            }
            else
            {
                manageDateFilter(false);
            }
        }
        public void manageDateFilter(bool _value)
        {
            txtfilterDate.Visible = _value;
            ImageButton1.Visible = _value;
            txtfiltername.Visible = !_value;
        }
        public void fillGrid()
        {
            List<Classes.InterDepository> objs = new List<Classes.InterDepository>();

        }
        protected void btnfetch_Click(object sender, EventArgs e)
        {
            string filterType = cmbfilter.SelectedValue;
            string userGroup = Session["UserGroup"].ToString();
            string filter = "";
            if (filterType == "S")
            {
                filter = " AND id_settlementno like '%" + txtfiltername.Text.Trim() + "%'";
            }
            else if(filterType =="E" || filterType == "T")
            {
                filter = " AND rtrim(convert(char,convert(datetime,id_trxdate),103)) = '" + txtfilterDate.Text.Trim() + "'";

            }

            string strquery = "select top 10 cc_id,rtrim(ltrim(cc_settle_no)) cc_settle_no,cc_mkt_type,";
            strquery += " rtrim(convert(char,convert(datetime,cc_settle_periodfrom),103)) cc_settle_periodfrom,";
            strquery += " rtrim(convert(char,convert(datetime,cc_settle_periodto),103)) cc_settle_periodto, ";
            strquery += " rtrim(convert(char,convert(datetime,cc_nsdl_deadlinedt),103)) cc_nsdl_deadlinedt, ";
            strquery += " left(cc_nsdl_deadlinett,2)+':'+right(cc_nsdl_deadlinett,2) as cc_nsdl_deadlinett,";
            strquery += " rtrim(convert(char,convert(datetime,cc_payin_dt),103)) cc_payin_dt,";
            strquery += " rtrim(convert(char,convert(datetime,cc_payout_dt),103)) cc_payout_dt,";
            strquery += " mt_description from Market_type inner join Cc_Calender on cc_mkt_type = mt_code where 1=1";


            strquery = "Select cm_name as cname,id_instcd as instcd,"
            + "ltrim(rtrim(id_otherclientid)) + case ltrim(rtrim(id_settlementno))  when '' then '' else ' / ' "
            + "+ id_settlementno end + case ltrim(rtrim(id_otherdpid))  when '' then '' else ' / ' + id_otherdpid end as otherclid,"
            + "id_trxtype as trxtype,id_internalrefno as irn,id_pri_key as prikey,id_trxdate as trxdate,id_clientid as  client,"
            + "id_isin as isin,id_branchcd as  branch,id_qty as qty ,id_allow allow,"
            + "isnull(id_authuserid1,'') authid1, isnull(id_authuserid2,'') authid2,isnull(id_authuserid3,'') authid3,"
            + "sc_isinname as isinname,'' othercmbpid,isnull(id_settlementno,'') stlmnt"
            + ",case isnull(id_authuserid1,'') when '' then (select min(am_amount) from Auth_master where am_code = id_trxtype and ltrim(rtrim(am_group1)) = '01')"
            + "Else case isnull(id_authuserid2,'') when '' then (select min(am_amount) from Auth_master where am_code = id_trxtype and ltrim(rtrim(am_group2)) = '01')"
            + "Else case isnull(id_authuserid3,'') when '' then  (select min(am_amount) from Auth_master where am_code = id_trxtype and ltrim(rtrim(am_group3)) = '01') end end end as minamount, "
            + "case isnull(id_authuserid1,'') when '' then  (select min(am_amount) from Auth_master where am_code = id_trxtype and am_group1 <> '' and "
            + "am_amount > (select max(am_amount) from Auth_master where am_code = id_trxtype and am_group1 =  '01'))"
            + "Else case isnull(id_authuserid2,'') when '' then  (select min(am_amount) from Auth_master where am_code = id_trxtype and am_group2 <> '' and "
            + "am_amount > (select max(am_amount) from Auth_master where am_code = id_trxtype and am_group2 =  '01'))"
            + "Else  case isnull(id_authuserid3,'') when '' then (select min(am_amount) from Auth_master where am_code = id_trxtype and am_group3 <> '' and "
            + "am_amount > (select max(am_amount) from Auth_master where am_code = id_trxtype and am_group3 =  '01'))"
            + "end end end as maxamount, case isnull(id_authuserid1,'') when '' then '1' Else case isnull(id_authuserid2,'') when '' then '2' Else  case isnull(id_authuserid3,'') when '' then '3' end end end as authlevel,(sc_rate * id_qty) as value "
            + "from Interdepository a,Security,Client_master1 where cm_cd = id_clientid and sc_isincode = id_isin and id_trxtype = '925'";


            if (filter != "")
                strquery += filter;
            strquery += " order by id_settlementno";

            //SingleEntities db = new SingleEntities();
            //List<Classes.SettlementGrid> res = db.Database.SqlQuery<Classes.SettlementGrid>(strquery).ToList();

            DBHelper db = new DBHelper();
            DataSet ds = db.executeDataSet(strquery);

            Gridview1.DataSource = ds;
            Gridview1.DataBind();
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {

        }

        protected void btnsignature_Click(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

        }
        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var firstCell = e.Row.Cells[0];
                firstCell.Controls.Clear();
                string code1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "instcd"));
                string code2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "prikey"));
                string url = "SettelmentDetails.aspx?code1=" + code1 + "&code2=" + code2;
                firstCell.Controls.Add(new HyperLink { NavigateUrl = String.Format("javascript:void(window.open('" + url + "','SettelmentDetails','height=300,width=800'));"), Text = firstCell.Text });
            }
        }

    }
}