using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NSDL.Classes; 

namespace NSDL
{
    public partial class PaymentReciept : System.Web.UI.Page
    {
        #region Global Variables
        SearchEntity objEL = new SearchEntity();
        #endregion

        #region Event Hanndlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnableDisableBackground(true); // Disable background when page loads first time
                FillRecievedInDD();
                FillYearDD();
                FillData();
            }

            //-- Disable Search button load event
            btnSearch.Enabled = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            EnableDisableBackground(false); // Enabled all fields on add button click
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            divGrid.Disabled = false;
        }

        protected void BtnFind_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchDataByVoucherNo();
        }
        #endregion

        #region Methods
        public void EnableDisableBackground(bool status)
        {
                tblUpper.Disabled = status;
                divGrid.Disabled = status;
                tblBottom.Disabled = status;
        }

        public void FillRecievedInDD()
        {
            DataSet ds = null;
            DBHelper objDB = new DBHelper();
            ds = objDB.executeDataSetSP("dbo.GetRecievedIn");
            cmbBank.DataSource = ds;
            cmbBank.DataValueField = "cm_cd";
            cmbBank.DataTextField = "cm_name";
            cmbBank.DataBind();
        }
        public void FillYearDD()
        {
            for (int i = DateTime.Now.Year-1; i <= DateTime.Now.Year + 15; i++)
            {
                ddlYear.Items.Add(Convert.ToString(i));
                ddlYear.DataBind();
            }
        }

        public void FillData()
        { 
            DateTime today = DateTime.Today;

            txtDt.Text = today.ToString("dd/MM/yyyy");
            txtDt.Text = txtDt.Text.Replace("-", "/");
            txtClrDt.Text = today.ToString("dd/MM/yyyy");
            txtClrDt.Text = txtClrDt.Text.Replace("-", "/");

            FillGridView();
        }

        public void SaveData()
        { 
            
        }

        public void FillGridView()
        {
            DataSet ds = null;
            DBHelper objDB = new DBHelper();
            ds = objDB.executeDataSetSP("dbo.getPaymentRecievedData");
            GrdReceipt.DataSource = ds;
            GrdReceipt.DataBind();
        }

        public void SearchDataByVoucherNo()
        {
            if(txtVoucher.Text.Trim() != "")
            {
                DataSet ds = null;
                DBHelper objDB = new DBHelper();
                objDB.AddParameter("@rc_voucherno", txtVoucher.Text.Trim());
                ds = objDB.executeDataSetSP("dbo.getPaymentRecievedData");
                if (ds != null)
                {
                    cmbCom.SelectedValue = "";
                    ddlYear.SelectedValue = "";
                    cmbBank.SelectedValue = "";
                    txtClFrom.Text = "";
                    txtAmount.Text = "";
                    txtParticular.Text = "";
                    txtTotal.Text = "";
                    txtChqNo.Text = "";
                    txtNewBalance.Text = "";
                    txtMicr.Text = "";
                    txtBal_T.Text = "";
                    txtcost.Text = "";
                        //ds.Tables[0].Columns[0].ColumnName;
                }

            }
        }
        #endregion      
    }
}