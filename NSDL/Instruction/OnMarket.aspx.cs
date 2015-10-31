using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSDL.Classes;

namespace NSDL.Instruction
{
    public partial class OnMarket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new Process().ShowEmptyGridColumns(GrdOnMarket);
        }
        protected void cmbfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
                            
        }

        protected void btnfetch_Click(object sender, EventArgs e)
        {

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {

        }

        protected void btnsignature_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

        }
        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Gridview1_RowDataBound(object sender, EventArgs e)
        {

        }
        public void manageDateFilter(bool _value)
        {
            
        }
        protected void txtInternalRef_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtClientId_TextChanged(object sender, EventArgs e)
        {

        }
        protected void chkLateFees_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void GrdOnMarket_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txtcdslstlmnt_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtbocmid_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txtisinCode_TXT_POSTBACK_TextChanged(object sender, EventArgs e)
        {

        }
        
        protected void GrdOnMarket_SelectedIndexChanging(object sender, EventArgs e)
        {

        }
         
        public void fillGrid() {
            

        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        protected void BtnEdit_Click(object sender, EventArgs e)
        {

        }
        protected void BtnFind_Click(object sender, EventArgs e)
        {

        }
        
        protected void BtnClear_Click(object sender, EventArgs e)
        {

        }
        protected void btnSignature_Click(object sender, EventArgs e)
        {

        }
        protected void btnimport_Click(object sender, EventArgs e)
        {

        }
        

        public void ManageButtons(string evnt)
        {
            switch (evnt)
            {
                case "Load":
                    BtnAdd.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnFind.Enabled = true;
                    BtnEdit.Enabled = false;
                    btnUpdate.Enabled = false;
                    BtnDelete.Enabled = false;
                    break;
                case "Add":
                    BtnAdd.Enabled = false;
                    BtnSave.Enabled = true;
                    BtnFind.Enabled = false;
                    BtnEdit.Enabled = false;
                    btnUpdate.Enabled = true;
                    BtnDelete.Enabled = false;
                    break;
                case "Find":
                    BtnAdd.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnFind.Enabled = false;
                    BtnEdit.Enabled = false;
                    btnUpdate.Enabled = false;
                    BtnDelete.Enabled = true;
                    break;
                case "Edit":
                    BtnAdd.Enabled = false;
                    BtnSave.Enabled = false;
                    BtnFind.Enabled = false;
                    BtnEdit.Enabled = false;
                    btnUpdate.Enabled = true;
                    BtnDelete.Enabled = true;
                    break;
                case "Update":
                    BtnAdd.Enabled = true;
                    BtnSave.Enabled = true;
                    BtnFind.Enabled = false;
                    BtnEdit.Enabled = false;
                    btnUpdate.Enabled = false;
                    BtnDelete.Enabled = false;
                    break;
                case "Select":
                    BtnAdd.Enabled = true;
                    BtnSave.Enabled = true;
                    BtnFind.Enabled = false;
                    BtnEdit.Enabled = true;
                    btnUpdate.Enabled = false;
                    BtnDelete.Enabled = false;
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
            //search_client_control.Enabled = _value;
            txtBalance.Enabled = _value;
            txtjntholder1.Enabled = _value;
            txtlblJH2.Enabled = _value;
            cmbReceiptMode.Enabled = _value;
            //txtReceiptMode.Enabled = _value;
            chkLateFees.Enabled = _value;
            txtLateFees.Enabled = _value;
        }
        public void ManageFields2(bool _value) { 
        
        }

    }
}