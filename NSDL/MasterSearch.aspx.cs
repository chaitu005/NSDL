using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NSDL.Classes;

namespace NSDL
{
    public partial class MasterSearch : System.Web.UI.Page
    {
        //FinancialBusinessLayer.Search objBL = new FinancialBusinessLayer.Search();
        //FinancialEntityLayer.Search objEL = new FinancialEntityLayer.Search();
        
        DataSet ds;
        SearchEntity objEL = new SearchEntity();
        Search objBL = new Search();
        Utilities objUL = new Utilities();
        BankSearch objSl = new BankSearch();

        //Financial_Application.Utiltiy.Utilities objUL = new Financial_Application.Utiltiy.Utilities();
        //Financial_Application.SearchUtility.BankSearch objSl = new Financial_Application.SearchUtility.BankSearch();

        protected void Page_Load(Object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                switch (Request.QueryString["From"].Trim().ToString())
                {
                    case "Courieer":
                        cmbsort1.Items.Add("Courrier Code");
                        cmbsort1.Items.Add("Courrier Name");
                        break;
                    case "Beneficiary_occupation":
                        cmbsort1.Items.Add("BenOccupationCode");
                        cmbsort1.Items.Add("BenOccupationDescription");
                        break;
                    case "Beneficiary_category":
                        cmbsort1.Items.Add("BenCategoryCode");
                        cmbsort1.Items.Add("BenCategoryDescription");
                        break;
                    case "Beneficiary_status":
                        cmbsort1.Items.Add("BenStatusCode");
                        cmbsort1.Items.Add("BenStatusDescription");
                        break;
                    case "Beneficiary_type":
                        cmbsort1.Items.Add("BenTypeCode");
                        cmbsort1.Items.Add("BenTypeDescription");
                        break;
                    case "Vendor":
                        cmbsort1.Items.Add("Vendor Code");
                        cmbsort1.Items.Add("Vendor Name");
                        break;
                    case "ND":
                        cmbsort1.Items.Add("Registration No");
                        cmbsort1.Items.Add("Nominee Name");
                        break;

                    case "ClientMaster":
                        cmbsort1.Items.Add("Client Code");
                        cmbsort1.Items.Add("Client Name");
                        cmbsort1.Items.Add("Pan");
                        cmbsort1.Items.Add("Short Name");
                        cmbsort1.Items.Add("Opening Date");
                        cmbsort1.Items.Add("BK Off Cd");
                        break;

                    case "SB":
                        cmbsort1.Items.Add("Broker Code");
                        cmbsort1.Items.Add("Broker Name");
                        cmbsort1.Items.Add("Ledger Code");
                        // this.Title += Request.QueryString["Title"].Trim().ToString();
                        break;
                    case "Rg":
                        cmbsort1.Items.Add("Region Code");

                        cmbsort1.Items.Add("Region Name");
                        // cmbsort1.Items.Add("Family Name");
                        // this.Title += Request.QueryString["Title"].Trim().ToString();
                        break;

                    case "FA": //cmbsort1.Items.Add("BPCode");

                        cmbsort1.Items.Add("Family Code");
                        cmbsort1.Items.Add("Family Name");
                        //this.Title += Request.QueryString["Title"].Trim().ToString();
                        break;
                    case "BK":
                        cmbsort1.Items.Add("MICR");
                        cmbsort1.Items.Add("IFSC");
                        cmbsort1.Items.Add("NAME");
                        //this.Title += Request.QueryString["Title"].Trim().ToString(); 
                        // this.btnSearch1.Type = "BKE";
                        break;
                    case "BE":
                        cmbsort1.Items.Add("PAN");
                        // this.Title += Request.QueryString["Title"].Trim().ToString(); 

                        break;
                    case "BP":
                        cmbsort1.Items.Add("BP Code");
                        cmbsort1.Items.Add("BP Name");
                        //  this.Title += Request.QueryString["Title"].Trim().ToString(); 

                        break;

                    case "BR":
                        cmbsort1.Items.Add("Branch-Code");
                        //  this.Title += Request.QueryString["Title"].Trim().ToString(); 

                        break;
                    case "G":
                        cmbsort1.Items.Add("Group Code");
                        cmbsort1.Items.Add("Group Name");
                        //   this.Title += Request.QueryString["Title"].Trim().ToString(); 

                        break;
                    case "Branch":
                        cmbsort1.Items.Add("Branch Code");
                        cmbsort1.Items.Add("Branch Name");
                        //cmbsort1.Items.Add("Contact Person");
                        //this.Title += Request.QueryString["Title"].Trim().ToString();

                        break;
                    case "SM":
                        cmbsort1.Items.Add("State Code");
                        cmbsort1.Items.Add("State Name");
                        //     cmbsort1.Items.Add("");
                        // this.Title += Request.QueryString["Title"].Trim().ToString();
                        break;
                    case "UG":
                        cmbsort1.Items.Add("UG Code");
                        cmbsort1.Items.Add("UG Name");
                        //     cmbsort1.Items.Add("");  
                        //  this.Title += Request.QueryString["Title"].Trim().ToString();
                        break;
                    case "User":
                        cmbsort1.Items.Add("User Code");
                        cmbsort1.Items.Add("User Name");
                        break;
                    case "Isinlist":
                        cmbsort1.Items.Add("ISIN Code");
                        cmbsort1.Items.Add("ISIN Name");
                        break;
                    case "Settlementcalender":
                        cmbsort1.Items.Add("ExchangeID");
                        cmbsort1.Items.Add("SettlementNo");
                        break;
                    case "POA":
                        cmbsort1.Items.Add("POAID");
                        break;
                    case "ChargesMaster":
                        cmbsort1.Items.Add("chargecode");
                        cmbsort1.Items.Add("chargename");
                        break;
                    case "BatchDetail":
                        cmbsort1.Items.Add("fmcode");
                        cmbsort1.Items.Add("batch");
                        break;
                    case "BpStatus":
                        cmbsort1.Items.Add("BPcode");
                        cmbsort1.Items.Add("BPdescription");
                        break;
                    case "MarketType":
                        cmbsort1.Items.Add("MTcode");
                        cmbsort1.Items.Add("MTdsescription");
                        break;
                    case "Narration":
                        cmbsort1.Items.Add("NR code");
                        cmbsort1.Items.Add("NR DESC");
                        break;
                    case "AccountNarration":
                        cmbsort1.Items.Add("AccNarr code");
                        cmbsort1.Items.Add("AccNarr desc");
                        break;
                    case "CostcenterMaster":
                        cmbsort1.Items.Add("costcode");
                        cmbsort1.Items.Add("costdesc");
                        break;
                    case "BankAccount":
                        cmbsort1.Items.Add("Bank code");
                        cmbsort1.Items.Add("Bank desc");
                        break;
                    case "Reasonmaster":
                        cmbsort1.Items.Add("Reasonmaster code");
                        cmbsort1.Items.Add("Reasonmaster desc");
                        break;
                    case "Reasonfortrade":
                        cmbsort1.Items.Add("Reasontrade code");
                        cmbsort1.Items.Add("Reasontrade desc");
                        break;
                    case "ObjectionReason":
                        cmbsort1.Items.Add("Objection code");
                        cmbsort1.Items.Add("Objection name");
                        break;
                    case "Status_of_Transaction":
                        cmbsort1.Items.Add("Stastuscode");
                        cmbsort1.Items.Add("Stastusdesc");
                        break;
                    case "Othersubmaster":
                        cmbsort1.Items.Add("submaster code");
                        cmbsort1.Items.Add("submaster desc");
                        break;
                    case "ClientShortMaster":
                        cmbsort1.Items.Add("Client_Code");
                        cmbsort1.Items.Add("Client_Name");
                        break;
                    case "InterDPSearch":
                        cmbsort1.Items.Add("Internal Reference No");
                        cmbsort1.Items.Add("Scroll No");
                        break;
                }
            }
        }

        private void Load_Data_For_Bind()
        {
            ds = objBL.Search_Master(objEL);
            objUL.BindGridView(GridView1, ds);

        }

        protected void btngo_Click(object sender, EventArgs e)
        {

            switch (cmbsort1.SelectedItem.ToString())
            {

                case "POA":
                    objEL.Strcpd_poaid = txtlike.Text.Trim().ToString();
                    objEL.Selection = "POA";
                    objEL.BK_Mode = "POAID";
                    break;
                case "Courrier Code":
                    objEL.Courrier = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Courrier";
                    objEL.BK_Mode = "Courrier Code";
                    break;
                case "Courrier Name":
                    objEL.Courrier = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Courrier";
                    objEL.BK_Mode = "Courrier Name";
                    break;
                case "BenTypeCode":
                    objEL.chrbs_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "Beneficiary";
                    objEL.BK_Mode = "BenTypeCode";
                    break;
                case "BenTypeDescription":
                    objEL.strbs_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Beneficiary";
                    objEL.BK_Mode = "BenTypeDescription";
                    break;
                case "BenStatusCode":
                    objEL.chrbs_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "Beneficiary";
                    objEL.BK_Mode = "BenStatusCode";
                    break;
                case "BenStatusDescription":
                    objEL.strbs_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Beneficiary";
                    objEL.BK_Mode = "BenStatusDescription";
                    break;
                case "BenCategoryCode":
                    objEL.chrbs_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "Beneficiary";
                    objEL.BK_Mode = "BenCategoryCode";
                    break;
                case "BenCategoryDescription":
                    objEL.strbs_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Beneficiary";
                    objEL.BK_Mode = "BenCategoryDescription";
                    break;
                case "BenOccupationCode":
                    objEL.chrbs_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "Beneficiary";
                    objEL.BK_Mode = "BenOccupationCode";
                    break;
                case "BenOccupationDescription":
                    objEL.strbs_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Beneficiary";
                    objEL.BK_Mode = "BenOccupationDescription";
                    break;
                case "Client Code":
                    objEL.StrClient = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Client";
                    objEL.BK_Mode = "Code";
                    break;

                case "Client Name":
                    objEL.StrClient = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Client";
                    objEL.BK_Mode = "Name";
                    break;
                case "Client_Code":
                    objEL.strClient_code = txtlike.Text.Trim().ToString();
                    objEL.Selection = "ShortClient";
                    objEL.BK_Mode = "Code";
                    break;

                case "Client_Name":
                    objEL.strClient_name = txtlike.Text.Trim().ToString();
                    objEL.Selection = "ShortClient";
                    objEL.BK_Mode = "Name";
                    break;
                case "Pan":
                    objEL.StrClient = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Client";
                    objEL.BK_Mode = "Pan";
                    break;

                case "Opening Date":
                    objEL.StrClient = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Client";
                    objEL.BK_Mode = "Open";
                    break;
                case "BK Off Cd":
                    objEL.StrClient = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Client";
                    objEL.BK_Mode = "BkOff";
                    break;

                case "Registration No":
                    objEL.strndregno = txtlike.Text.Trim().ToString();
                    objEL.Selection = "NominationMaster";
                    objEL.BK_Mode = "NDRegno";
                    break;
                case "Nominee Name":
                    objEL.strndname = txtlike.Text.Trim().ToString();
                    objEL.Selection = "NominationMaster";
                    objEL.BK_Mode = "NDName";
                    break;


                case "Vendor Code":
                    objEL.Chrvmcd = txtlike.Text.Trim().ToString();
                    objEL.Strvmname = "".ToString();
                    objEL.Selection = "VendorMaster";
                    objEL.BK_Mode = "VendorCode";
                    break;

                case "Vendor Name":
                    objEL.Strvmname = txtlike.Text.Trim().ToString();
                    objEL.Chrvmcd = "";
                    objEL.Selection = "VendorMaster";
                    objEL.BK_Mode = "VendorName";
                    break;

                case "Ledger Code":
                    objEL.ChrLedgercd = txtlike.Text.Trim().ToString();
                    objEL.Selection = "SubBroker";
                    objEL.BK_Mode = "RMCode";

                    break;
                case "Broker Name":
                    objEL.StrBrokerName = txtlike.Text.Trim();
                    objEL.Selection = "SubBroker";
                    objEL.BK_Mode = "RMName";

                    break;
                case "Broker Code":
                    objEL.ChrBrokerCd = txtlike.Text.Trim();
                    objEL.Selection = "SubBroker";
                    objEL.BK_Mode = "RMCode";

                    break;

                case "Region Code":
                    objEL.StrRegCd = txtlike.Text.Trim().Trim().ToString();
                    objEL.StrRegDesc = " ".ToString();
                    objEL.Selection = "Region";
                    objEL.BK_Mode = "RegCode";

                    break;
                case "Region Name":
                    objEL.StrRegCd = " ".ToString();
                    objEL.StrRegDesc = txtlike.Text.Trim().Trim().ToString();
                    objEL.Selection = "Region";
                    objEL.BK_Mode = "RegDesc";
                    break;
                case "Family Code":
                    objEL.ChrFamilyCode = txtlike.Text.Trim();
                    objEL.strFamilyName = " ".ToString();
                    objEL.Selection = "Family";
                    objEL.BK_Mode = "code";
                    break;
                case "Family Name":
                    objEL.strFamilyName = txtlike.Text.Trim().ToString();
                    objEL.ChrFamilyCode = "N";
                    objEL.Selection = "Family";
                    objEL.BK_Mode = "Name";
                    break;
                case "MICR":
                    objEL.BK_MICR = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Bank";
                    objEL.BK_Mode = "MICR";
                    break;
                case "IFSC":
                    objEL.BK_BRANCH = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Bank";
                    objEL.BK_Mode = "IFSC";
                    break;
                case "NAME":
                    objEL.BK_NAME = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Bank";
                    objEL.BK_Mode = "Name";
                    break;
                case "PAN":
                    objEL.Strpanno = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Banned";
                    objEL.BK_Mode = "Pan";
                    break;
                case "BP Name":
                    objEL.BpCode = " ";
                    objEL.StrBpName = txtlike.Text.Trim().ToString();
                    objEL.Selection = "BPMaster";
                    objEL.BK_Mode = "BPName";
                    break;
                case "BP Code":
                    objEL.BpCode = txtlike.Text;                 //  objEL.StrBpName = txtlike.Text.Trim().ToString();
                    objEL.Selection = "BPMaster";
                    objEL.BK_Mode = "BPCode";
                    break;
                case "Group Code":
                    objEL.GroupCode = txtlike.Text;                 //  objEL.StrBpName = txtlike.Text.Trim().ToString();
                    objEL.StrGroupName = " ".ToString();
                    objEL.Selection = "GroupMaster";
                    objEL.BK_Mode = "GroupCode";
                    break;
                case "Group Name":
                    objEL.GroupCode = " ";
                    objEL.StrGroupName = txtlike.Text.Trim().ToString();                 //  objEL.StrBpName = txtlike.Text.Trim().ToString();
                    objEL.Selection = "GroupMaster";
                    objEL.BK_Mode = "GroupName";
                    break;

                case "Branch Code":
                    objEL.ChrBrCode = txtlike.Text.Trim();
                    objEL.Selection = "BranchMaster";
                    objEL.BK_Mode = "branchcd";
                    break;
                case "Branch Name":
                    objEL.ChrBrCode = " ";
                    objEL.StrBrName = txtlike.Text.Trim().ToString();
                    objEL.Selection = "BranchMaster";
                    objEL.BK_Mode = "branchname";
                    break;
                case "Contact Person":
                    objEL.StrBrContact = txtlike.Text.Trim().ToString();
                    objEL.ChrBrCode = " ";
                    objEL.Selection = "BranchMaster";
                    objEL.BK_Mode = "contact";
                    break;
                case "State Code":
                    objEL.intSrNo = Convert.ToInt16(txtlike.Text.Trim());
                    objEL.StrStateName = " ";
                    objEL.Selection = "StateMaster";
                    objEL.BK_Mode = "StateCode";
                    break;
                case "State Name":

                    objEL.intSrNo = Convert.ToInt32(" ");
                    objEL.StrStateName = txtlike.Text.Trim();
                    objEL.Selection = "StateMaster";
                    objEL.BK_Mode = "StateName";

                    break;
                case "UG Code":
                    objEL.ChrUGCode = txtlike.Text.Trim();
                    objEL.Selection = "UserGroup";

                    objEL.BK_Mode = "UGCode";

                    break;
                case "UG Name":
                    objEL.ChrUGCode = " ";
                    objEL.StrUG_Desc = txtlike.Text.Trim().ToString();
                    objEL.Selection = "UserGroup";
                    objEL.BK_Mode = "UGName";

                    break;
                case "ISIN Code":
                    objEL.strscisincode = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Isinlist";
                    objEL.BK_Mode = "IsinCode";
                    break;
                case "ISIN Name":
                    objEL.strscisinname = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Isinlist";
                    objEL.BK_Mode = "IsinName";
                    break;
                case "ExchangeID":
                    objEL.chrcc_id = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "Settlementcalender";
                    objEL.BK_Mode = "ExchangeID";
                    break;
                case "SettlementNo":
                    objEL.chrcc_settle_no = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "Settlementcalender";
                    objEL.BK_Mode = "SettlementNo";
                    break;
                case "chargecode":
                    objEL.chrcg_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "ChargesMaster";
                    objEL.BK_Mode = "chargecode";
                    break;
                case "chargename":
                    objEL.strcg_name = txtlike.Text.Trim().ToString();
                    objEL.Selection = "ChargesMaster";
                    objEL.BK_Mode = "chargename";
                    break;
                case "fmcode":
                    objEL.chrbd_type = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "BatchDetail";
                    objEL.BK_Mode = "fmcode";
                    break;
                case "batch":
                    objEL.decbd_batchno = Convert.ToDecimal(txtlike.Text.Trim());
                    objEL.Selection = "BatchDetail";
                    objEL.BK_Mode = "batch";
                    break;
                case "BPcode":
                    objEL.chrbps_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "BpStatus";
                    objEL.BK_Mode = "BPcode";
                    break;
                case "BPdescription":
                    objEL.strbps_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "BpStatus";
                    objEL.BK_Mode = "BPdescription";
                    break;
                case "MTcode":
                    objEL.chrmt_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "MarketType";
                    objEL.BK_Mode = "MTcode";
                    break;
                case "MTdsescription":
                    objEL.strmt_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "MarketType";
                    objEL.BK_Mode = "MTdsescription";
                    break;
                case "NR code":
                    objEL.chrnr_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "Narration";
                    objEL.BK_Mode = "NR code";
                    break;
                case "NR DESC":
                    objEL.strnr_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "MarketType";
                    objEL.BK_Mode = "NR DESC";
                    break;
                case "AccNarr code":
                    objEL.intan_cd = Convert.ToInt32(txtlike.Text.Trim());
                    objEL.Selection = "AccountNarration";
                    objEL.BK_Mode = "AccNarr code";
                    break;
                case "AccNarr desc":
                    objEL.stran_desc = txtlike.Text.Trim().ToString();
                    objEL.Selection = "AccountNarration";
                    objEL.BK_Mode = "AccNarr desc";
                    break;
                case "costcode":
                    objEL.chrco_cd = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "CostcenterMaster";
                    objEL.BK_Mode = "costcode";
                    break;
                case "costdesc":
                    objEL.strco_desc = txtlike.Text.Trim().ToString();
                    objEL.Selection = "CostcenterMaster";
                    objEL.BK_Mode = "costdesc";
                    break;
                case "Bank code":
                    objEL.chrba_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "BankAccount";
                    objEL.BK_Mode = "Bank code";
                    break;
                case "Bank desc":
                    objEL.strba_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "BankAccount";
                    objEL.BK_Mode = "Bank desc";
                    break;
                case "Reasonmaster code":
                    objEL.strrm_code = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Reasonmaster";
                    objEL.BK_Mode = "Reasonmaster code";
                    break;
                case "Reasonmaster desc":
                    objEL.strrm_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Reasonmaster";
                    objEL.BK_Mode = "Reasonmaster desc";
                    break;
                case "Reasontrade code":
                    objEL.strrm_code = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Reasonmaster";
                    objEL.BK_Mode = "Reasontrade code";
                    break;
                case "Reasontrade desc":
                    objEL.strrm_code = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Reasonmaster";
                    objEL.BK_Mode = "Reasontrade desc";
                    break;
                case "Objection code":
                    objEL.stror_code = txtlike.Text.Trim().ToString(); ;
                    objEL.Selection = "ObjectionReason";
                    objEL.BK_Mode = "Objection code";
                    break;
                case "Objection name":
                    objEL.stror_name = txtlike.Text.Trim().ToString(); ;
                    objEL.Selection = "ObjectionReason";
                    objEL.BK_Mode = "Objection name";
                    break;
                case "Stastuscode":
                    objEL.strsx_code = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Status_of_Transaction";
                    objEL.BK_Mode = "Stastuscode";
                    break;
                case "Stastusdesc":
                    objEL.strsx_description = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Status_of_Transaction";
                    objEL.BK_Mode = "Stastusdesc";
                    break;
                case "submaster code":
                    objEL.chrcs_code = txtlike.Text.Trim().ToCharArray();
                    objEL.Selection = "Othersubmaster";
                    objEL.BK_Mode = "submaster code";
                    break;
                case "submaster desc":
                    objEL.strcs_desc = txtlike.Text.Trim().ToString();
                    objEL.Selection = "Othersubmaster";
                    objEL.BK_Mode = "submaster desc";
                    break;
                case "Internal Reference No":
                    objEL.str_internal_ref_no = txtlike.Text.Trim().ToString();
                    objEL.Selection = "InterDPSearch";
                    objEL.BK_Mode = "Internal Reference No";
                    break;
                case "Scroll No":
                    objEL.str_scroll_no = txtlike.Text.Trim().ToString();
                    objEL.Selection = "InterDPSearch";
                    objEL.BK_Mode = "Scroll No";
                    break;
            }
            Load_Data_For_Bind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowIndex;
            if (e.CommandName.Equals("HyperLink1"))
            {
                GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                RowIndex = gvr.RowIndex;
            }
        }

        protected void GridView1_RowDataBounds(Object sender, GridViewRowEventArgs e)
        {
            BankSearch objSl = new BankSearch();
            objSl.BuildLookupValueReturnControl(e.Row, "HyperLink1");
            e.Row.Cells[1].Visible = false;

        }

    }
}