using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSDL.Classes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using NSDL.UserControls;

namespace NSDL.Instruction
{
    public partial class InstructionInward : System.Web.UI.Page
    {
        public string dateFormat = "yyyy-MM-dd";        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtnoofcert.Enabled = false;
                RevertFields(false);
                ManageButtons("Load");
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ManageButtons("Add");
            RevertFields(true);
            fillDetails();
        }   
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(Session["UserId"].ToString()))
            {
                Inward obj = getInwardDetails();
                if (obj != null)
                {
                    int _result = new Process().AddInwardEntry(obj);
                    if (_result > 0)
                    {
                        InstructionGrid1.LoadGrid();
                        ClearFields();
                        RevertFields(false);
                        showError("Inward added successfully");
                        ManageButtons("Load");
                    }
                    else
                        showError("Some error occured! Please try again.");
                }

            }
            else
            {

            }
        }
        protected void btnfind_Click(object sender, EventArgs e)
        {
            ManageButtons("Find");
            fetchInward(GetScrollNo());
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ManageButtons("Edit");
            RevertFields(true);
            ddlstInstmnt.Enabled = false;
            ddllotNo.Enabled = false;
            txtSrNo.Enabled = false;
        }
        protected void Btnupdate_Click(object sender, EventArgs e)
        {
            ManageButtons("Update");
            Inward obj = getInwardDetails();
            if (obj != null)
            {
                obj.ie_scrollno = GetScrollNo();
                int result = new Process().UpdateInwardEntry(obj);
                if (result > 0)
                {
                    ClearFields();
                    RevertFields(false);
                    InstructionGrid1.LoadGrid();
                    showError("Record updated successfully.");
                }

                else
                    showError("Error occured. Please try again.");
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ManageButtons("Load");
            ClearFields();
            RevertFields(false);
        }
        protected void Btnclose_Click(object sender, EventArgs e)
        {
            new Process().sendHome();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (new Process().DeleteInward(GetScrollNo())>0){
                InstructionGrid1.LoadGrid();
                ClearFields();
                ManageButtons("Load");
                showError("Successfully Deleted");
            }
            else
                showError("Error Occured. Try again.");
        }
        protected void ddlstInstmnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstInstmnt.SelectedItem.Text == "Demat")
            {
                txtnoofcert.Enabled = true;
            }
            else
            {
                txtnoofcert.Enabled = false;
            }
            new Process().FillLotNoDropDown(ddllotNo, Convert.ToInt32(ddlstInstmnt.SelectedValue));
            txtlotsize.Text = "";
        }
        protected void txtSlip_TextChanged(object sender, EventArgs e)
        {
            Validate _validate = new Validate();
            if (_validate.isNotNumber(txtSrNo.Text))
                showError("Invalid Slip No");
            else {
                int count = new Process().CheckInwardExists(Convert.ToInt32(txtSrNo.Text));
                if (count > 0)
                {
                    txtClid1.Text = "";
                    txtClid2.Text = "";
                    txtSrNo.Text = "";
                    showError("Entry is already done for entered slip ");
                }
                else
                {
                    GetCompanyName();
                }
            }           
            
        }
        protected void ddllotNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLotSize();
        }
        public Inward getInwardDetails()
        {
            Validate _validate = new Validate();
            Boolean isAllOk = true;
            Inward obj = new Inward();
            obj.mkrid = Session["UserId"].ToString();
            obj.mkrdt = DateTime.Now;

            if (_validate.isValidInput(txtDt, 10))
                obj.ie_dt = DateTime.ParseExact(txtDt.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            else
            {
                isAllOk = false;
                showError("Invalid Date");
            }

            if (!_validate.isNotSelected(ddlstInstmnt))
            {
                obj.ie_instno = ddlstInstmnt.Text.Trim();
                obj.ie_trxtype = new Process().getInstype(_validate.convertNumber(ddlstInstmnt.Text.Trim()));
            }
            else
            {
                isAllOk = false;
                showError("Select Instruction");
            }

            if (!_validate.isNotSelected(ddllotNo))
                obj.ie_lotno = _validate.convertNumber(ddllotNo.Text);
            else
            {
                isAllOk = false;
                showError("Select Lot");
            }


            if (!_validate.isEmpty(txtlotsize))
            { }

            else
            {
                isAllOk = false;
                showError("Invalid Lotsize");
            }

            if (_validate.isNotNumber(txtSrNo))
            {
                isAllOk = false;
                showError("Invalid Slipno");
            }

            else
            {
                obj.ie_slipno = txtSrNo.Text.Trim();
            }


            if (_validate.isValidInput(txtClid1))
                obj.ie_cmcd = txtClid1.Text;
            else
            {
                isAllOk = false;
                showError("Invalid ClientID");
            }


            if (_validate.isNotNumber(txtinst))
            {
                isAllOk = false;
                showError("Invalid Instructions");
            }
            else
                obj.ie_nooftrx = _validate.convertNumber(txtinst.Text.Trim());

            if (ddlstInstmnt.SelectedItem.Text == "Demat")
            {
                if (_validate.isNotNumber(txtnoofcert))
                {
                    isAllOk = false;
                    showError("Invalid No of certificates");
                }
                else
                {
                    obj.ie_noofcert = _validate.convertNumber(txtnoofcert.Text);
                }
            }
            obj.ie_execdt = DateTime.ParseExact(txtexecdt.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (_validate.isNotDecimal(txtcharges))
            {
                isAllOk = false;
                showError("Invalid Charge");
            }

            else
                obj.ie_charge = _validate.ConvertDecimal(txtcharges.Text.Trim());

            if (!_validate.isEmpty(txtremarks))
                obj.ie_remark = txtremarks.Text.Trim();

            if (_validate.isNotSelected(ddl_mode_delivery))
            {
                isAllOk = false;
                showError("Select Mode of delivery");
            }

            else
                obj.ie_mode = ddl_mode_delivery.SelectedValue;

            if (isAllOk)
                return obj;
            else
                return null;
        }
        public void fillDetails()
        {
            txtDt.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            txtexecdt.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            //FillInstrumentDropDown(ddlstInstmnt);
            new Process().FillInstrumentDropDown(ddlstInstmnt);
            //txtlotsize.Text = (new DropDowns().LotSizeList().Max(x => x.lz_size) + 1).ToString();
        }
        public void FillInstrumentDropDown(DropDownList ddl)
        {
            ddl.DataSource = new DropDowns().InstrumentList().Where(x => x.im_defaultyn == "Y");
            ddl.DataTextField = "name";
            ddl.DataValueField = "id";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("- select -", "0"));
        }
        public void GetCompanyName()
        {
            Validate _validate = new Validate();
            int slipNo = 0;
            int instrNo = 0;
            bool isAllOk = true;

            if (_validate.isNotSelected(ddlstInstmnt))
            {
                isAllOk = false;
                showError("Select Instrument");
            }
            else
            {
                instrNo = _validate.convertNumber(ddlstInstmnt.Text);
            }

            if (_validate.isNotNumber(txtSrNo))
            {
                isAllOk = false;
                showError("Enter Valid Slip Number");
            }
            else
            {
                slipNo = _validate.convertNumber(txtSrNo.Text);
            }



            if (isAllOk)
            {
                ChequeMaster obj = new Process().GetCheque(slipNo, instrNo);
                
                if (obj == null)
                {
                    txtClid1.Text = "";
                    txtClid2.Text = "";
                    txtSrNo.Text = "";
                    showError("Invalid Slip Number / Instruction ");
                }
                else
                {
                    txtClid1.Text = obj.companyCode;
                    txtClid2.Text = obj.companyName;
                }
            }
        }
        public void GetLotSize()
        {
            Validate _validate = new Validate();
            int lotNo = 0;
            int instrNo = 0;
            bool isAllOk = true;
            if (_validate.isNotSelected(ddlstInstmnt))
            {
                isAllOk = false;
                showError("Select Instrument");
            }
            else
            {
                instrNo = _validate.convertNumber(ddlstInstmnt.SelectedValue);
            }

            if (_validate.isNotSelected(ddllotNo))
            {
                isAllOk = false;
                showError("Select Lot");
            }
            else
            {
                lotNo = _validate.convertNumber(ddllotNo.SelectedValue);
            }



            if (isAllOk)
            {
                LotSize obj = new Process().GetLotSize(lotNo, instrNo);
                if (obj != null)
                {
                    txtlotsize.Text = obj.lz_size.ToString();
                }
                else
                {
                    txtlotsize.Text = "";
                    showError("Invalid Lot / Instruction ");
                }
            }
        }              
        public void showError(string message)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + message + "');", true);
        }
        public void RevertFields(Boolean value)
        {
            txtDt.Enabled = value;
            txtDateCalendar.Enabled = value;
            ddlstInstmnt.Enabled = value;
            ddllotNo.Enabled = value;
            txtlotsize.Enabled = value;
            txtSrNo.Enabled = value;
            lbldrcr.Enabled = value;
            txtinst.Enabled = value;
            txtexecdt.Enabled = value;
            txtcharges.Enabled = value;
            txtremarks.Enabled = value;
            ddl_mode_delivery.Enabled = value;
            txtScroll.Enabled = !value;
        }
        public void ClearFields()
        {
            txtDt.Text = "";
            txtScroll.Text = "";
            ddlstInstmnt.Items.Clear();
            ddllotNo.Items.Clear();
            txtlotsize.Text = "";
            txtSrNo.Text = "";
            txtClid1.Text = "";
            txtClid2.Text = "";
            txtinst.Text = "";
            txtexecdt.Text = "";
            txtcharges.Text = "";
            txtremarks.Text = "";
            ddl_mode_delivery.SelectedValue = "0";
        }
        public int GetScrollNo()
        {
            Validate _validate = new Validate();
            if (_validate.isNotNumber(txtScroll))
            {
                showError("Invalid Scroll No!");
                return 0;
            }
            else
            {
                return _validate.convertNumber(txtScroll.Text.Trim());
            }

        }
        public void fetchInward(int scrollNo)
        {

            Inward obj = new Process().GetInwardEntry(scrollNo);
            if (obj != null)
            {                
                txtexecdt.Text = Convert.ToDateTime(obj.ie_execdt).ToString(dateFormat);
                txtDt.Text = Convert.ToDateTime(obj.ie_dt).ToString(dateFormat);
                new Process().FillInstrumentDropDown(ddlstInstmnt);
                ddlstInstmnt.SelectedValue = obj.ie_instno;
                new Process().FillLotNoDropDown(ddllotNo, Convert.ToInt32(ddlstInstmnt.SelectedValue));
                ddllotNo.SelectedValue = obj.ie_lotno.ToString();
                GetLotSize();
                txtSrNo.Text = obj.ie_slipno;
                GetCompanyName();
                txtinst.Text = obj.ie_nooftrx.ToString();
                txtcharges.Text = obj.ie_charge.ToString();
                txtremarks.Text = obj.ie_remark;
                ddl_mode_delivery.SelectedValue = obj.ie_mode;
                RevertFields(false);
                txtScroll.Enabled = false;
            }
            else
            {
                showError("Invalid Scroll No");
                ManageButtons("Load");
            }
        }
        public void ManageButtons(string evnt)
        {
            //btnAdd
            //Btnupdate
            //btnEdit
            //btnfind
            //btnDelete
            //btnSave
            //btnCancel

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
                    Btnupdate.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
                case "Find":
                    btnAdd.Enabled = false;
                    btnSave.Enabled = false;
                    btnfind.Enabled = false;
                    btnEdit.Enabled = true;
                    Btnupdate.Enabled = false;
                    btnDelete.Enabled = true;
                    break;                   
                case "Edit":
                    btnAdd.Enabled = false;
                    btnSave.Enabled = false;
                    btnfind.Enabled = false;
                    btnEdit.Enabled = false;
                    Btnupdate.Enabled = true;
                    btnDelete.Enabled = false;
                    break;
            }
        }        

    }
}