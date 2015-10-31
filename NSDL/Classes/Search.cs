using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class Search
    {
        public DataSet Search_Master(object Parameter)
        {
            //    if( )
            DataSet ds = null;
            //FinancialDatabaseLayer.DataBase objDB = new DataBase(ConfigurationManager.ConnectionStrings["FinancialConnectionString"].ConnectionString);
            DBHelper objDB = new DBHelper();
            SearchEntity objEL = (SearchEntity)Parameter;
            //FinancialEntityLayer.Search objEL = (FinancialEntityLayer.Search)Parameter;

            switch (objEL.Selection.ToString())
            {

                case "Courrier":
                    objDB.AddParameter("@cum_courrier_id ", objEL.Courrier);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    objDB.AddParameter("@cum_courrier_name", objEL.Courrier);
                    ds = objDB.executeDataSetSP("usp_single_Courrier_Master_Search");
                    break;

                case "Client":
                    objDB.AddParameter("@cm_cd", objEL.StrClient);
                    objDB.AddParameter("@cm_name", objEL.StrClient);
                    objDB.AddParameter("@cb_panno", objEL.StrClient);
                    objDB.AddParameter("@cm_lastname", objEL.StrClient);
                    objDB.AddParameter("@cm_opendate", objEL.StrClient);
                    objDB.AddParameter("@bk_off_cd", objEL.StrClient);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_client_master_Search");
                    break;

                case "User":
                    objDB.AddParameter("@um_user_id", objEL.UserId);
                    objDB.AddParameter("@um_user_name", objEL.UserName);
                    //  objDB.AddParameter("@bk_branch", objEL.BK_BRANCH);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_user_master_search");

                    break;

                case "Bank":
                    objDB.AddParameter("@bk_micr", objEL.BK_MICR);
                    objDB.AddParameter("@bk_name", objEL.BK_NAME);
                    objDB.AddParameter("@bk_branch", objEL.BK_BRANCH);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    // objDB.AddParameter("@Selection", objEL.Selection);
                    ds = objDB.executeDataSetSP("usp_Single_Bank_Master_Search");

                    break;
                case "Banned":
                    objDB.AddParameter("@be_panno", objEL.Strpanno);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);

                    // objDB.AddParameter("@Selection", objEL.Selection);
                    ds = objDB.executeDataSetSP("usp_single_banned_enity_Search");

                    break;

                case "Family":
                    objDB.AddParameter("@fm_desc", objEL.strFamilyName);
                    objDB.AddParameter("@fm_cd", objEL.ChrFamilyCode);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_Single_Family_Master_search");

                    break;
                case "BPMaster":
                    objDB.AddParameter("@bp_id", objEL.BpCode);
                    objDB.AddParameter("@bp_name", objEL.StrBpName);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("Usp_Single_BpMaster_Search");
                    break;

                case "GroupMaster":
                    objDB.AddParameter("@gr_desc", objEL.StrGroupName);
                    objDB.AddParameter("@gr_cd", objEL.GroupCode);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_Single_Group_Master_Search");

                    break;

                case "BranchMaster":
                    objDB.AddParameter("@bm_branchname", objEL.StrBrName);
                    objDB.AddParameter("@bm_branchcd", objEL.ChrBrCode);
                    objDB.AddParameter("@bm_contact", objEL.StrBrContact);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_branch_master_search");
                    break;
                case "StateMaster":
                    objDB.AddParameter("@SrNo", objEL.intSrNo);
                    objDB.AddParameter("@State", objEL.StrStateName);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_State_Master_Search");
                    break;
                case "UserGroup":
                    objDB.AddParameter("@ug_cd", objEL.ChrUGCode);
                    objDB.AddParameter("@ug_desc", objEL.StrUG_Desc);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_Single_UserGroup_Search");
                    break;
                case "Region":
                    objDB.AddParameter("@reg_cd", objEL.StrRegCd);
                    objDB.AddParameter("@reg_desc", objEL.StrRegDesc);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_region__master_Search");
                    break;
                //  objDB.AddParameter();
                case "SubBroker":
                    objDB.AddParameter("@rm_cd", objEL.ChrBrokerCd);
                    objDB.AddParameter("@rm_name", objEL.StrBrokerName);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    objDB.AddParameter("@rm_ledgercd", objEL.ChrLedgercd);
                    ds = objDB.executeDataSetSP("Usp_Single_Remisser_Master_Search");
                    break;
                //case "banklist":
                //  objDB.AddParameter("@COLUMN", objEL.Control);
                //objDB.AddParameter("@VALUE", objEL.Value);
                // objDB.AddParameter("@Mode", objEL.BK_Mode);
                //ds = objDB.executeDataSetSP("usp_Single_Bank_Master_Searchs");
                // break;
                case "Isinlist":
                    objDB.AddParameter("@sc_isincode", objEL.strscisincode);
                    objDB.AddParameter("@sc_isinname", objEL.strscisinname);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_Single_Isin_Search");
                    break;
                case "NominationMaster":
                    objDB.AddParameter("@nd_regno", objEL.strndregno);
                    objDB.AddParameter("@nd_name", objEL.strndname);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_nominee_master_search");
                    break;
                case "Beneficiary":
                    objDB.AddParameter("@bs_code", objEL.chrbs_code);
                    objDB.AddParameter("@bs_description", objEL.strbs_description);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_beneficary_search");
                    break;
                case "Settlementcalender":
                    objDB.AddParameter("@cc_id", objEL.chrcc_id);
                    objDB.AddParameter("@cc_settle_no", objEL.chrcc_settle_no);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_settlement_calender_search");
                    break;
                case "POA":
                    objDB.AddParameter("@cpd_poaid", objEL.Strcpd_poaid);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_POA_search");
                    break;
                case "ChargesMaster":
                    objDB.AddParameter("@cg_code", objEL.chrcg_code);
                    objDB.AddParameter("@cg_name", objEL.strcg_name);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_charges_master_search");
                    break;
                case "BatchDetail":
                    objDB.AddParameter("@bd_type", objEL.chrbd_type);
                    objDB.AddParameter("@bd_batchno", objEL.decbd_batchno);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_batchdetails_search");
                    break;
                case "BpStatus":
                    objDB.AddParameter("@bps_code", objEL.chrbps_code);
                    objDB.AddParameter("@bps_description", objEL.strbps_description);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_bpstatus_search");
                    break;
                case "MarketType":
                    objDB.AddParameter("@mt_code", objEL.chrmt_code);
                    objDB.AddParameter("@mt_description", objEL.strmt_description);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_markettype_search");
                    break;
                case "Narration":
                    objDB.AddParameter("@nr_code", objEL.chrnr_code);
                    objDB.AddParameter("@nr_description", objEL.strnr_description);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_narration_search");
                    break;
                case "AccountNarration":
                    objDB.AddParameter("@an_cd", objEL.intan_cd);
                    objDB.AddParameter("@an_desc", objEL.stran_desc);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_accountnarration_search");
                    break;
                case "CostcenterMaster":
                    objDB.AddParameter("@co_cd", objEL.chrco_cd);
                    objDB.AddParameter("@co_desc", objEL.strco_desc);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_costcenter_search");
                    break;
                case "BankAccount":
                    objDB.AddParameter("@ba_code", objEL.chrba_code);
                    objDB.AddParameter("@ba_description", objEL.strba_description);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_Bankaccount_type_search");
                    break;
                case "Reasonmaster":
                    objDB.AddParameter("@rm_code", objEL.strrm_code);
                    objDB.AddParameter("@rm_description", objEL.strrm_description);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_reason_master_search");
                    break;
                case "ObjectionReason":
                    objDB.AddParameter("@or_code", objEL.stror_code);
                    objDB.AddParameter("@or_name", objEL.stror_name);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_Objection_reason_search");
                    break;
                case "Status_of_Transaction":
                    objDB.AddParameter("sx_code", objEL.strsx_code);
                    objDB.AddParameter("sx_description", objEL.strsx_description);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_Statusof_trx_search");
                    break;
                case "Othersubmaster":
                    objDB.AddParameter("@cs_code", objEL.chrcs_code);
                    objDB.AddParameter("@cs_desc", objEL.strcs_desc);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_single_master_Clientsub_master_search");
                    break;
                case "ShortClient":
                    objDB.AddParameter("@cm_cd", objEL.strClient_code);
                    objDB.AddParameter("@cm_name", objEL.strClient_name);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_client_master_Search_c");
                    break;

                case "InterDPSearch":
                    objDB.AddParameter("@internal_ref_no", objEL.str_internal_ref_no);
                    objDB.AddParameter("@scroll_no", objEL.str_scroll_no);
                    objDB.AddParameter("@Mode", objEL.BK_Mode);
                    ds = objDB.executeDataSetSP("usp_search_interdp");
                    break;
            }
            return ds;
        }

    }
}