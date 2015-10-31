using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSDL.Classes;
using System.Web.Services;
using System.ComponentModel;

namespace NSDL.Instruction
{
    public partial class InterDP : System.Web.UI.Page
    {
        public string dateFormat = "yyyy-MM-dd";
        public List<InterDepository> objs = new List<InterDepository>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ManageButtons("Load");
                ManageFields1(false);
                ManageFields2(false);
                fillDetails();
            }

            if (Request.QueryString["do"] != null && Request.QueryString["do"] == "fetchInterDP")
            {
                getFillDetailsOnSearch(Convert.ToInt32(Request.QueryString["val"]));
            }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //if (new Validate().isNotNumber(txtInternalRefNo))
            //{
            //    showError("Please enter reference number");
            //}
            //else
            //{
            //    ClearFields2("");
            //   //ManageFields2(true);
            //    ManageButtons("Add");
            //    Session["Index"] = null;
            //}
            //ClearFields2("");
            ManageFields1(true);
            ManageFields2(true);
            ManageButtons("Add");
            
            Session["Index"] = null;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            getDetails();
            //ManageButtons("Load");
            ManageFields1(false);
            ManageFields2(false);
            ManageButtons("Update");
            //ManageFields2(false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields1("");
            ClearFields2("");
            ManageFields1(false);
            ManageFields2(false);
            ManageButtons("Load");
            fillDetails();
        }
        protected void btnFind_Click(object sender, EventArgs e)
        {
            txtslipno.Enabled = true;
            txtInternalRefNo.Enabled = true;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            
            //ManageFields1(true);
            ManageFields2(true);
            ManageButtons("Edit");
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            new Process().sendHome();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            new InterDepository().DeleteInterDP(1);
        }

        protected void ddlstInstmnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCompanyName();
        }

        public void getDetails(int index = 0)
        {
            try
            {
                Boolean isAllOk = true;
                Validate _validate = new Validate();
                InterDepository obj = new InterDepository();
                if (_validate.isValidInput(txtExecutionDt, 10))
                {
                    obj.id_executiondate = _validate.convertDatetime(txtExecutionDt.Text.Trim());
                }
                else
                {
                    isAllOk = false;
                    showError("Invalid Execution date");
                }

                if (_validate.isValidInput(txtTransactionDt, 10))
                {
                    obj.id_trxdate = _validate.convertDatetime(txtTransactionDt.Text.Trim());
                }
                else
                {
                    isAllOk = false;
                    showError("Invalid Transction date");
                }

                if (_validate.isNotNumber(txtInternalRefNo))
                {
                    isAllOk = false;
                    showError("Invalid Internal number");
                }
                else
                {
                    obj.id_internalrefno = txtInternalRefNo.Text.Trim();
                }

                if (_validate.isNotNumber(txtslipno))
                {
                    isAllOk = false;
                    showError("Invalid slip number");
                }
                else
                {
                    obj.id_settlementno = txtslipno.Text.Trim();
                }

                if (_validate.isNotSelected(cmbInstructionType))
                {
                    isAllOk = false;
                    showError("Invalid Instruction selection");
                }

                else
                {
                    obj.id_instcd = cmbInstructionType.SelectedValue;
                }


                if (_validate.isNotNumber(txtlotno))
                {
                    isAllOk = false;
                    showError("Invalid Lot No");
                }
                else
                {
                    obj.id_lotno = Convert.ToInt32(txtlotno.Text.Trim());
                }

                if (_validate.isEmpty(txtClientId))
                {
                    isAllOk = false;
                    showError("Invalid Client ID");
                }
                else
                {
                    obj.id_clientid = txtClientId.Text.Trim();
                    obj.id_otherclientid = txtClientId.Text.Trim();
                }

                if (_validate.isNotSelected(cmbReceiptMode))
                {
                    isAllOk = false;
                    showError("Invalid Recieving mode");
                }
                else
                {
                    obj.id_instreceivemode = cmbReceiptMode.SelectedValue;
                }

                if (_validate.isEmpty(txtdpid))
                {
                    isAllOk = false;
                    showError("Invalid DP ID");
                }
                else
                {
                    obj.id_otherdpid = txtdpid.Text.Trim();
                }
                if (_validate.isEmpty(txtSettNo))
                {
                    isAllOk = false;
                    showError("Invalid Settlemtnt No");
                }
                else
                {
                    obj.id_settlementno = txtSettNo.Text.Trim();
                }


                if (_validate.isNotSelected(ddlType))
                {
                    isAllOk = false;
                    showError("Invalid Type");
                }
                else
                {
                    obj.id_type = ddlType.SelectedValue;
                }


                if (_validate.inValidString(txtbocmid.Text.Trim(),8))
                {
                    isAllOk = false;
                    showError("Invalid bocmid");
                }

                else
                {
                    obj.id_branchbatchcd = txtbocmid.Text.Trim();
                }


                if (_validate.isEmpty(txtcdslstlmnt))
                {
                    isAllOk = false;
                    showError("Invalid CD SL settlement");
                }

                else
                {
                    obj.id_CDSLsettlement = txtcdslstlmnt.Text.Trim();
                }


                if (_validate.isEmpty(txtisinCode_TXT_POSTBACK))
                {
                    isAllOk = false;
                    showError("Invalid ISIN Number");
                }

                else
                {
                    obj.id_isin = txtisinCode_TXT_POSTBACK.Text.Trim();
                }


                if (_validate.isNotNumber(txtqty))
                {
                    isAllOk = false;
                    showError("Invalid Quantity");
                }

                else
                {
                    obj.id_qty = Convert.ToInt32(txtqty.Text.Trim());
                }

                if (_validate.isNotSelected(cmbReason))
                {
                    isAllOk = false;
                    showError("Invalid Reason");
                }
                else
                {
                    obj.id_reasonForTrade = cmbReason.SelectedValue;
                }
                if (_validate.isEmpty(txtRemark))
                {
                    isAllOk = false;
                    showError("Invalid Remarks");
                }
                else
                {
                    obj.id_remarks = txtRemark.Text.Trim();
                }


                if (isAllOk == true)
                {
                    AuthMaster objj = new AuthMaster();
                    int level = new AuthMaster().Authorise(Convert.ToDecimal(obj.id_value),obj.id_instcd);
                    showError("Authorization level is : "+ level.ToString());
                    
                    obj.id_trxdate = _validate.convertDatetime(DateTime.Now.ToString("yyyy-MM-dd"));
                    obj.id_trxtype = "925";
                    obj.id_trxflag = "";
                    obj.id_allow = "S";
                    obj.id_mkttype = "";
                    obj.id_status = "6";
                    obj.sc_rate = txtrate.Text;
                    obj.id_value = txtValue.Text;
                    obj.id_authtm1 = "00:00:00";
                    obj.id_authtm2 = "00:00:00";
                    obj.id_authtm3 = "00:00:00";
                    obj.id_instreceivemode = "S";
                    obj.id_recoslipyn = "N";
                    obj.id_entrymode = "C";
                    //obj.id_pri_key = 0;
                    obj.id_othersettlement = "";

                    obj.id_branchcd = new Process().GetSystemParameter("BRCODE");

                    if (Session["obj"] != null)
                        objs = (List<InterDepository>)Session["obj"];
                    if (Session["Index"] == null)
                    {
                        objs.Add(obj);
                    }
                    else
                    {
                        objs[Convert.ToInt32(Session["Index"])] = obj;
                        Session["Index"] = null;
                    }
                    Session["obj"] = objs;
                    GrdOnMarket.DataSource = objs;
                    GrdOnMarket.DataBind();
                    ClearFields2("");
                    
                }

            }
            catch (Exception ex)
            {

            }


        }

        public void SaveData()
        {
            objs = (List<InterDepository>)Session["obj"];
            int _result = new Process().AddInterDP(objs);
            if (_result > 0)
            {
                Session["obj"] = null;
                ClearFields1("");
                ClearFields2("");
                ManageFields1(false);
                ManageFields2(false);
                ManageButtons("Load");
                GrdOnMarket.DataSource = null;
                GrdOnMarket.DataBind();
                showError("Record added successfully!");
                
            }
            else
            {
                showError("Some error occured. Please try again");
            }
        }
        public void GetCompanyName()
        {
            Classes.Validate _validate = new Classes.Validate();
            int slipNo = 0;
            int instrNo = 0;
            bool isAllOk = true;

            if (_validate.isNotSelected(cmbInstructionType))
            {
                isAllOk = false;
                showError("Select Instrument");
            }
            else
            {
                instrNo = _validate.convertNumber(cmbInstructionType.SelectedValue);
            }

            if (_validate.isNotNumber(txtslipno))
            {
                isAllOk = false;
                showError("Enter Valid Slip Number");
            }
            else
            {
                slipNo = _validate.convertNumber(txtslipno.Text);
            }



            if (isAllOk)
            {

                ChequeMaster obj = new Process().GetCheque(slipNo, instrNo);
                if (obj != null)
                {
                    txtClientId.Text = obj.companyCode;
                    txtClientName.Text = obj.companyName;
                    txtjntholder1.Text = obj.secondName;
                    txtlblJH2.Text = obj.thirdName;
                }
                else
                {
                    txtClientName.Text = "";
                    txtClientName.Text = "";
                    showError("Invalid Slip Number / Instruction ");
                }
            }
        }
        public void showError(string message)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + message + "');", true);
        }

        public void fillDetails()
        {
            txtTransactionDt.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtExecutionDt.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            new Process().FillInstrumentDropDown(cmbInstructionType);
            cmbInstructionType.SelectedValue = "103";
            //dds.FillLotSizeDropDown(txtlotno);
            //txtlotno.Text = (new DropDowns().LotSizeList().Max(x => x.lz_size) + 1).ToString();

        }
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public void fillformWithObj(InterDepository obj)
        {
            try
            {

               //Button myButton = 
                txtdpid.Text = obj.id_clientid;
                //GetDpName();
                txtSettNo.Text = obj.id_settlementno;
                ddlType.SelectedValue = obj.id_type;
                txtbocmid.Text = obj.id_branchbatchcd;
                txtcdslstlmnt.Text = obj.id_CDSLsettlement;
                txtrate.Text = obj.sc_rate;
                txtisinCode_TXT_POSTBACK.Text = obj.id_isin;
                //GetISINName();
                txtqty.Text = obj.id_qty.ToString(); ;
                txtValue.Text = obj.id_value;
                cmbReason.SelectedValue = obj.id_reasonForTrade;
                txtRemark.Text = obj.id_remarks;
            }
            catch (Exception ex)
            {
                
            }

            
        }
        public void fetchInward(int scrollNo)
        {

            Inward obj = new Process().GetInwardEntry(scrollNo);
            if (obj != null)
            {
                txtTransactionDt.Text = Convert.ToDateTime(obj.ie_execdt).ToString(dateFormat);
                txtExecutionDt.Text = Convert.ToDateTime(obj.ie_dt).ToString(dateFormat);
                new Process().FillInstrumentDropDown(cmbInstructionType);
                cmbInstructionType.SelectedValue = obj.ie_instno;
                txtlotno.Text = obj.ie_lotno.ToString();
                txtslipno.Text = obj.ie_slipno;
                GetCompanyName();

                //txtcharges.Text = obj.ie_charge.ToString();
                //txtremarks.Text = obj.ie_remark;
                cmbReceiptMode.SelectedValue = obj.ie_mode;
                new Process().FillReasonfortradeDropDown(cmbReason);
                //RevertFields(false);
                txtInternalRefNo.Enabled = false;
            }
            else
            {
                showError("Invalid Scroll No");
                ManageButtons("Load");
            }
        }

        public void ManageButtons(string evnt)
        {
            switch (evnt)
            {
                case "Load":
                    btnAdd.Enabled = true;
                    btnSave.Enabled = false;
                    btnfind.Enabled = true;
                    btnEdit.Enabled = false;
                    Btnupdate.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
                case "Add":
                    btnAdd.Enabled = false;
                    btnSave.Enabled = true;
                    btnfind.Enabled = false;
                    btnEdit.Enabled = false;
                    Btnupdate.Enabled = true;
                    btnDelete.Enabled = false;
                    break;
                case "Find":
                    btnAdd.Enabled = true;
                    btnSave.Enabled = false;
                    btnfind.Enabled = false;
                    btnEdit.Enabled = false;
                    Btnupdate.Enabled = false;
                    btnDelete.Enabled = true;
                    break;
                case "Edit":
                    btnAdd.Enabled = false;
                    btnSave.Enabled = false;
                    btnfind.Enabled = false;
                    btnEdit.Enabled = false;
                    Btnupdate.Enabled = true;
                    btnDelete.Enabled = true;
                    break;
                case "Update":
                    btnAdd.Enabled = true;
                    btnSave.Enabled = true;
                    btnfind.Enabled = false;
                    btnEdit.Enabled = false;
                    Btnupdate.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
                case "Select":
                    btnAdd.Enabled = true;
                    btnSave.Enabled = true;
                    btnfind.Enabled = false;
                    btnEdit.Enabled = true;
                    Btnupdate.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
            }
        }

        public void ManageFields1(bool _value)
        {
            txtTransactionDt.Enabled = _value;
            txtExecutionDt.Enabled = _value;
            cal_extender1.Enabled = _value;
            cal_extender2.Enabled = _value;
            txtInternalRefNo.Enabled = _value;
            txtslipno.Enabled = _value;
            cmbInstructionType.Enabled = _value;
            txtlotno.Enabled = _value;
            txtClientId.Enabled = _value;
            search_client_control.Enabled = _value;
            txtBalance.Enabled = _value;
            txtjntholder1.Enabled = _value;
            txtlblJH2.Enabled = _value;
            cmbReceiptMode.Enabled = _value;
            txtReceiptMode.Enabled = _value;
            chkLateFees.Enabled = _value;
            txtLateFees.Enabled = _value;
        }
        public void ManageFields2(bool _value)
        {
            txtdpid.Enabled = _value;
            txtdpname.Enabled = _value;
            SearchControl2.Enabled = _value;
            txtSettNo.Enabled = _value;
            SearchControl1.Enabled = _value;
            ddlType.Enabled = _value;
            txtbocmid.Enabled = _value;
            txtcdslstlmnt.Enabled = _value;
            SearchControl4.Enabled = _value;
            txtrate.Enabled = _value;
            txtisinCode_TXT_POSTBACK.Enabled = _value;
            txtisinName.Enabled = _value;
            SearchControl5.Enabled = _value;
            txtqty.Enabled = _value;
            txtValue.Enabled = _value;
            cmbReason.Enabled = _value;
            txtRemark.Enabled = _value;

        }

        public void ClearFields1(string _value)
        {
            txtTransactionDt.Text = _value;
            txtExecutionDt.Text = _value;
            
            txtInternalRefNo.Text = _value;
            txtslipno.Text = _value;
            cmbInstructionType.SelectedValue="103";
            txtlotno.Text = _value;
            txtClientId.Text = _value;
            txtClientName.Text = _value;
            txtBalance.Text = _value;
            txtjntholder1.Text = _value;
            txtlblJH2.Text = _value;
            cmbReceiptMode.SelectedValue = "0";
            txtReceiptMode.Text = _value;
            chkLateFees.Text = _value;
            txtLateFees.Text = _value;
        }
        public void ClearFields2(string _value)
        {
            txtdpid.Text = _value;
            txtdpname.Text = _value;
            txtSettNo.Text = _value;
            ddlType.SelectedValue = "0";
            txtbocmid.Text = _value;
            txtcdslstlmnt.Text = _value;
            txtrate.Text = _value;
            txtisinCode_TXT_POSTBACK.Text = _value;
            txtisinName.Text = _value;
            txtqty.Text = _value;
            txtValue.Text = _value;
            cmbReason.SelectedValue = "0";
            txtRemark.Text = _value;

        }

        protected void txtisinCode_TXT_POSTBACK_TextChanged(object sender, EventArgs e)
        {
            GetISINName();
        }

        protected void txtdpid_TextChanged(object sender, EventArgs e)
        {
            GetDpName();
        }

        protected void GrdOnMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objs = (List<InterDepository>)Session["obj"];
                Session["Index"] = ((System.Web.UI.WebControls.GridView)(sender)).SelectedIndex;
                fillformWithObj(objs[Convert.ToInt32(Session["Index"])]);
                ManageButtons("Update");
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        protected void GrdOnMarket_SelectedIndexChanging(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void GetDpName()
        {
            if (!new Validate().isEmpty(txtdpid))
            {
                
                string _result = new BP().getBPName(txtdpid.Text.Trim());
                if (!string.IsNullOrWhiteSpace(_result))
                {
                    txtdpname.Text = _result;
                }
                else
                {
                    txtdpname.Text = "";
                    txtdpid.Text = "";
                }
            }
        }
        
        public void GetISINName()
        {
            if (!new Validate().isEmpty(txtisinCode_TXT_POSTBACK))
            {
                string isinStatus = new SecurityClass().getIsinStatus(txtisinCode_TXT_POSTBACK.Text.Trim());
                if (isinStatus == "01")
                {
                    string _result1 = new SecurityClass().getIsinName(txtisinCode_TXT_POSTBACK.Text.Trim());
                    Decimal? _result2 = new RateMaster().getRate(txtisinCode_TXT_POSTBACK.Text.Trim());
                    if (!string.IsNullOrWhiteSpace(_result1) && _result2 != 0)
                    {
                        txtisinName.Text = _result1;
                        txtrate.Text = _result2.ToString();
                    }
                    else
                    {
                        txtisinName.Text = "";
                        txtisinCode_TXT_POSTBACK.Text = "";
                        txtrate.Text = "";
                    }
                }
                else
                {
                    string _msg = new SecurityStatus().GetStatus(isinStatus);
                    if (string.IsNullOrWhiteSpace(_msg)) {
                        showError(_msg);
                    }
                    
                }

                
                
            }
        }
        
        protected void txtqty_TextChanged(object sender, EventArgs e)
        {
            if (!new Validate().isNotNumber(txtqty))
            {
                int val1 = Convert.ToInt32(txtqty.Text);
                Decimal val2 = Convert.ToDecimal(txtrate.Text);
                //int result = val1 * val2;
                txtValue.Text = (val1 * val2).ToString();
            }
        }
        
        protected void txtSettNo_TextChanged(object sender, EventArgs e)
        {
            if (!new Validate().isEmpty(txtSettNo))
            {
                if (new CCCalender().isValidStlmntNo(txtSettNo.Text.Trim()) == 0)
                {
                    txtSettNo.Text = "";
                }
                else {
                    showError("Invalid Sett No");
                }
            }
        }
        
        protected void txtcdslstlmnt_TextChanged(object sender, EventArgs e)
        {
            if (!new Validate().isEmpty(txtcdslstlmnt))
            {
                if (new CCCalender().isValidStlmntNo(txtcdslstlmnt.Text.Trim(),true) == 0)
                {
                    txtcdslstlmnt.Text = "";
                }
                else
                {
                    showError("Invalid Sett No");
                }
            }
        }

        protected void txtInternalRefNo_TextChanged(object sender, EventArgs e)
        {
            if (new Validate().isNotNumber(txtInternalRefNo))
            {
                showError("Please enter reference number");
            }
            else
            {
                fetchInward(Convert.ToInt32(txtInternalRefNo.Text));
                ManageButtons("Find");
            }
        }

        protected void txtClientId_TextChanged(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public void getFillDetailsOnSearch(int int_pri_key)
        {
            InterDepository obj = new Process().GETInterDP(int_pri_key);
            if (obj != null)
                fillformWithObj(obj);
            txtdpid.Text = "1231321";
        }

        protected void search_interdp_Click(object sender, EventArgs e)
        { 
        
        }
    }
}