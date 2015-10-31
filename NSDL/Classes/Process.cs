using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using NSDL.Classes;
using System.Data;

namespace NSDL.Classes
{
    public class Process
    {
        public void AddStockEntry(Stock obj)
        {
            try
            {

                Stock_master objStock = new Stock_master();
                objStock.stm_instcd = obj.intInstrumentCode;
                objStock.stm_vmcd = obj.intVendorCode;
                objStock.stm_vmrefno = obj.strRef;
                objStock.stm_date = obj.strRefDt;
                objStock.stm_fromno = obj.intSlipNoFrom;
                objStock.stm_tono = obj.intSlipTo;
                objStock.stm_booksize = obj.intSize;
                objStock.stm_noofbooks = obj.intBooks;
                objStock.stm_bookfromno = obj.intBookFrom;
                objStock.stm_booktono = obj.intBookTo;
                objStock.mkrid = HttpContext.Current.Session["UserId"].ToString();
                objStock.mkrdt = DateTime.Now.ToString("yyyyMMdd");
                //objStock.mkrid = GetMakerID(obj.intVendorCode);
                SingleEntities dbContext = new SingleEntities();
                dbContext.Stock_master.Add(objStock);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void AddCheque(ChequeMaster obj)
        {
            try
            {
                Chequemaster objCheque = new Chequemaster();
                objCheque.chm_cmcd = obj.companyCode;
                objCheque.chm_chqno = obj.chequeNo;
                objCheque.chm_instcd = obj.instrumentCode;
                objCheque.chm_booksize = obj.bookSize;
                objCheque.chm_refno = obj.refNo;
                objCheque.chm_refdate = obj.refDate;
                objCheque.chm_status = obj.status;
                objCheque.chm_issuedate = obj.issueDate;
                objCheque.chm_remarks = obj.remarks;
                objCheque.chm_branchcd = obj.branchCode;
                objCheque.mkrid = HttpContext.Current.Session["UserId"].ToString();
                objCheque.mkrdt = obj.makerDate;
                objCheque.chm_fromno = obj.chequeFromNo;
                objCheque.chm_tono = obj.chequeToNo;
                SingleEntities db = new SingleEntities();
                db.Chequemasters.Add(objCheque);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void GetRecievvedIn()
        {
            try 
	        {
                SingleEntities db = new SingleEntities();
                
	        }
	        catch (Exception ex)
	        {
		
		        throw ex;
	        }
        }

        public ChequeMaster GetCheque(int slipNo, int instrNo)
        {
            try
            {
                SingleEntities db = new SingleEntities();
                Chequemaster objCheque = new Chequemaster();
                var obj1 = db.Chequemasters.Where(x => x.chm_fromno == slipNo && x.chm_instcd == instrNo)
                            .Join(db.Client_master1, ch => ch.chm_cmcd, cl => cl.cm_cd, (ch, cl) => new { ch, cl })
                            .FirstOrDefault();
                if (obj1 != null)
                {
                    objCheque = obj1.ch;
                    ChequeMaster obj = new ChequeMaster();
                    obj.companyCode = objCheque.chm_cmcd;
                    obj.companyName = obj1.cl.cm_name;
                    obj.secondName = obj1.cl.cm_sech_name;
                    obj.thirdName = obj1.cl.cm_thih_name;
                    obj.chequeNo = Convert.ToInt32(objCheque.chm_chqno);
                    obj.instrumentCode = objCheque.chm_instcd;
                    obj.bookSize = objCheque.chm_booksize;
                    obj.refNo = objCheque.chm_refno;
                    obj.refDate = objCheque.chm_refdate;
                    obj.status = objCheque.chm_status;
                    obj.issueDate = objCheque.chm_issuedate;
                    obj.remarks = objCheque.chm_remarks;
                    obj.branchCode = objCheque.chm_branchcd;
                    obj.makerDate = objCheque.mkrdt;
                    obj.chequeFromNo = Convert.ToInt32(objCheque.chm_fromno);
                    obj.chequeToNo = Convert.ToInt32(objCheque.chm_tono);
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AddLotSize(LotSize obj)
        {
            try
            {
                Lot_size objLot = new Lot_size();
                objLot.lz_lotno = obj.lz_lotno;
                objLot.lz_size = obj.lz_size;
                objLot.lz_type = obj.lz_type;
                objLot.lz_status = obj.lz_status;
                objLot.mkrid = obj.mkrid;
                objLot.mkrdt = obj.mkrdt;
                objLot.lz_branchcd = obj.lz_branchcd;
                SingleEntities db = new SingleEntities();
                db.Lot_size.Add(objLot);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateLotSize(LotSize obj)
        {
            try
            {
                SingleEntities db = new SingleEntities();
                Lot_size objLot = db.Lot_size.First(x => x.lz_lotno == obj.lz_lotno && x.lz_type == obj.lz_type);
                //objLot.lz_status = obj.lz_status;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public LotSize GetLotSize(decimal lotNo, int instrNo)
        {
            try
            {
                SingleEntities db = new SingleEntities();
                Lot_size objCheque = new Lot_size();
                string insType = getInstype(instrNo);
                var obj = db.Lot_size.Where(x => x.lz_lotno == lotNo && x.lz_type == insType).FirstOrDefault();
                if (obj != null)
                {
                    LotSize obj1 = new LotSize();
                    obj1.lz_lotno = obj.lz_lotno;
                    obj1.lz_size = obj.lz_size;
                    obj1.lz_type = obj.lz_type;
                    obj1.lz_status = obj.lz_status;
                    obj1.mkrid = obj.mkrid;
                    obj1.mkrdt = obj.mkrdt;
                    obj1.lz_branchcd = obj.lz_branchcd;
                    return obj1;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int AddInwardEntry(Inward obj)
        {
            try
            {
                Inward_entry objInw = new Inward_entry();
                objInw.ie_lotno = obj.ie_lotno;
                objInw.ie_trxtype = obj.ie_trxtype.Trim();
                objInw.ie_instno = obj.ie_instno.Trim();
                objInw.ie_slipno = obj.ie_slipno.Trim();
                objInw.ie_cmcd = obj.ie_cmcd.Trim();
                objInw.ie_dt = obj.ie_dt;
                objInw.ie_execdt = obj.ie_execdt;
                objInw.ie_nooftrx = obj.ie_nooftrx;
                objInw.ie_noofcert = obj.ie_noofcert;
                objInw.ie_rejected = obj.ie_rejected;
                objInw.mkrid = obj.mkrid;
                objInw.mkrdt = obj.mkrdt;
                objInw.ie_charge = obj.ie_charge;
                objInw.ie_mode = obj.ie_mode;
                objInw.ie_remark = obj.ie_remark.Trim();
                objInw.ie_pri_key = obj.ie_pri_key;
                objInw.ie_branchcd = obj.ie_branchcd;
                SingleEntities db = new SingleEntities();
                db.Inward_entry.Add(objInw);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int UpdateInwardEntry(Inward obj)
        {
            try
            {
                SingleEntities db = new SingleEntities();
                Inward_entry objInw = db.Inward_entry.Where(x=>x.ie_scrollno == obj.ie_scrollno).First();
                objInw.ie_lotno = obj.ie_lotno;
                objInw.ie_trxtype = obj.ie_trxtype.Trim();
                objInw.ie_instno = obj.ie_instno.Trim();
                objInw.ie_slipno = obj.ie_slipno.Trim();
                objInw.ie_cmcd = obj.ie_cmcd.Trim();
                objInw.ie_dt = obj.ie_dt;
                objInw.ie_execdt = obj.ie_execdt;
                objInw.ie_nooftrx = obj.ie_nooftrx;
                objInw.ie_noofcert = obj.ie_noofcert;
                objInw.ie_rejected = obj.ie_rejected;
                objInw.mkrid = obj.mkrid.Trim();
                objInw.mkrdt = obj.mkrdt;
                objInw.ie_charge = obj.ie_charge;
                objInw.ie_mode = obj.ie_mode.Trim();
                objInw.ie_remark = obj.ie_remark.Trim();
                objInw.ie_pri_key = obj.ie_pri_key;
                objInw.ie_branchcd = obj.ie_branchcd.Trim();
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Inward GetInwardEntry(int scrollNo)
        {
            try
            {
                Inward_entry obj = new Inward_entry();
                
                SingleEntities db = new SingleEntities();
                obj = db.Inward_entry.Where(x => x.ie_scrollno == scrollNo).FirstOrDefault();
                if (obj != null)
                {
                    Inward objInw = new Inward();
                    objInw.ie_lotno = obj.ie_lotno;
                    objInw.ie_trxtype = obj.ie_trxtype;
                    objInw.ie_instno = obj.ie_instno;
                    objInw.ie_slipno = obj.ie_slipno;
                    objInw.ie_cmcd = obj.ie_cmcd;
                    objInw.ie_dt = obj.ie_dt;
                    objInw.ie_execdt = obj.ie_execdt;
                    objInw.ie_nooftrx = obj.ie_nooftrx;
                    objInw.ie_noofcert = obj.ie_noofcert;
                    objInw.ie_rejected = obj.ie_rejected;
                    objInw.ie_scrollno = obj.ie_scrollno;
                    objInw.mkrid = obj.mkrid;
                    objInw.mkrdt = obj.mkrdt;
                    objInw.ie_charge = obj.ie_charge;
                    objInw.ie_mode = obj.ie_mode;
                    objInw.ie_remark = obj.ie_remark;
                    objInw.ie_pri_key = obj.ie_pri_key;
                    objInw.ie_branchcd = obj.ie_branchcd;
                    return objInw;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int DeleteInward(int scrollNo)
        {
            SingleEntities db = new SingleEntities();
            int result = 0;
            Inward_entry obj = db.Inward_entry.Where(x => x.ie_scrollno == scrollNo).FirstOrDefault();
            if (obj != null) {
                db.Inward_entry.Remove(obj);
                result =  db.SaveChanges();
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public int CheckInwardExists(int slipNo)
        {
                return new SingleEntities().Inward_entry.Where(x => x.ie_slipno == slipNo.ToString()).Count();
        }

        public string GetMakerID(Int16 vendorCode)
        {
            try
            {
                return new SingleEntities().Vendor_master.Where(y => y.vm_cd == vendorCode).Select(x => x.mkrid).First().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
   
        public DataSet GetSearchResult(string strModule, string strKey)
        {

            SingleEntities db = new SingleEntities();
            DataSet dsResult = new DataSet();
            switch (strModule)
            {
                case "ClientID":
                    //dsResult = db.Client_master1.Select(x => {x.cm_cd , x.cm_na}).ToList();
                    break;
                case "ClientName":
                    break;
            }
            return dsResult;
        }

        public int AddInterDP(List<InterDepository> objs)
        {
            try
            {
                SingleEntities db = new SingleEntities();
                foreach (InterDepository obj in objs)
                {
                    Interdepository objIndp = new Interdepository();
                    objIndp.id_instcd = obj.id_instcd;
                    objIndp.id_trxdate = obj.id_trxdate;
                    objIndp.id_trxtype = obj.id_trxtype;
                    objIndp.id_trxflag = obj.id_trxflag;
                    objIndp.id_clientid = obj.id_clientid;
                    objIndp.id_isin = obj.id_isin;
                    objIndp.id_qty = obj.id_qty;
                    objIndp.id_mkttype = obj.id_mkttype;
                    objIndp.id_settlementno = obj.id_settlementno;
                    objIndp.id_executiondate = obj.id_executiondate;
                    objIndp.id_otherclientid = obj.id_otherclientid;
                    objIndp.id_otherdpid = obj.id_otherdpid;
                    objIndp.id_internalrefno = obj.id_internalrefno;
                    objIndp.id_cc_id = obj.id_cc_id;
                    objIndp.id_status = obj.id_status;
                    objIndp.id_allow = obj.id_allow;
                    objIndp.id_othersettlement = obj.id_othersettlement;
                    objIndp.id_authcode1 = obj.id_authcode1;
                    objIndp.id_authuserid1 = obj.id_authuserid1;
                    objIndp.id_authdate1 = obj.id_authdate1;
                    objIndp.id_authcode2 = obj.id_authcode2;
                    objIndp.id_authuserid2 = obj.id_authuserid2;
                    objIndp.id_authdate2 = obj.id_authdate2;
                    objIndp.id_batch_no = obj.id_batch_no;
                    //objIndp.id_pri_key = obj.id_pri_key;
                    objIndp.id_branchcd = obj.id_branchcd;
                    objIndp.id_branchbatchcd = obj.id_branchbatchcd;
                    objIndp.mkrid = obj.mkrid;
                    objIndp.mkrdt = obj.mkrdt;
                    objIndp.id_authcode3 = obj.id_authcode3;
                    objIndp.id_authuserid3 = obj.id_authuserid3;
                    objIndp.id_authdt3 = obj.id_authdt3;
                    objIndp.id_authremarks = obj.id_authremarks;
                    objIndp.id_scrollno = obj.id_scrollno;
                    objIndp.id_dqty = obj.id_dqty;
                    objIndp.id_lotno = obj.id_lotno;
                    objIndp.id_authtm1 = obj.id_authtm1;
                    objIndp.id_authtm2 = obj.id_authtm2;
                    objIndp.id_authtm3 = obj.id_authtm3;
                    objIndp.mkrtm = obj.mkrtm;
                    objIndp.id_instreceivemode = obj.id_instreceivemode;
                    objIndp.id_recoslipyn = obj.id_recoslipyn;
                    objIndp.id_entrymode = obj.id_entrymode;
                    objIndp.id_remarks = obj.id_remarks;
                    objIndp.id_CDSLsettlement = obj.id_CDSLsettlement;
                    db.Interdepositories.Add(objIndp);
                }
                
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public InterDepository GETInterDP(int int_pri_key)
        {
            try
            {
                SingleEntities db = new SingleEntities();
                Interdepository obj = db.Interdepositories.Where(x=>x.id_pri_key == int_pri_key).FirstOrDefault();
                InterDepository objIndp = new InterDepository();
                if(obj != null)
                {
                    objIndp.id_instcd = obj.id_instcd;
                    objIndp.id_trxdate = obj.id_trxdate;
                    objIndp.id_trxtype = obj.id_trxtype;
                    objIndp.id_trxflag = obj.id_trxflag;
                    objIndp.id_clientid = obj.id_clientid;
                    objIndp.id_isin = obj.id_isin;
                    objIndp.id_qty = obj.id_qty;
                    objIndp.id_mkttype = obj.id_mkttype;
                    objIndp.id_settlementno = obj.id_settlementno;
                    objIndp.id_executiondate = obj.id_executiondate;
                    objIndp.id_otherclientid = obj.id_otherclientid;
                    objIndp.id_otherdpid = obj.id_otherdpid;
                    objIndp.id_internalrefno = obj.id_internalrefno;
                    objIndp.id_cc_id = obj.id_cc_id;
                    objIndp.id_status = obj.id_status;
                    objIndp.id_allow = obj.id_allow;
                    objIndp.id_othersettlement = obj.id_othersettlement;
                    objIndp.id_authcode1 = obj.id_authcode1;
                    objIndp.id_authuserid1 = obj.id_authuserid1;
                    objIndp.id_authdate1 = obj.id_authdate1;
                    objIndp.id_authcode2 = obj.id_authcode2;
                    objIndp.id_authuserid2 = obj.id_authuserid2;
                    objIndp.id_authdate2 = obj.id_authdate2;
                    objIndp.id_batch_no = obj.id_batch_no;
                    //objIndp.id_pri_key = obj.id_pri_key;
                    objIndp.id_branchcd = obj.id_branchcd;
                    objIndp.id_branchbatchcd = obj.id_branchbatchcd;
                    objIndp.mkrid = obj.mkrid;
                    objIndp.mkrdt = obj.mkrdt;
                    objIndp.id_authcode3 = obj.id_authcode3;
                    objIndp.id_authuserid3 = obj.id_authuserid3;
                    objIndp.id_authdt3 = obj.id_authdt3;
                    objIndp.id_authremarks = obj.id_authremarks;
                    objIndp.id_scrollno = obj.id_scrollno;
                    objIndp.id_dqty = obj.id_dqty;
                    objIndp.id_lotno = obj.id_lotno;
                    objIndp.id_authtm1 = obj.id_authtm1;
                    objIndp.id_authtm2 = obj.id_authtm2;
                    objIndp.id_authtm3 = obj.id_authtm3;
                    objIndp.mkrtm = obj.mkrtm;
                    objIndp.id_instreceivemode = obj.id_instreceivemode;
                    objIndp.id_recoslipyn = obj.id_recoslipyn;
                    objIndp.id_entrymode = obj.id_entrymode;
                    objIndp.id_remarks = obj.id_remarks;
                    objIndp.id_CDSLsettlement = obj.id_CDSLsettlement;
                }

                return objIndp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetInterDP(TrxbackofficeClass obj)
        {
            try
            {
                Trxbackoffice objTrxBO = new Trxbackoffice();
                objTrxBO.tb_pri_key = obj.tb_pri_key;
                objTrxBO.tb_internal_refno = obj.tb_internal_refno;
                objTrxBO.tb_instcd = obj.tb_instcd;
                objTrxBO.tb_trx_type = obj.tb_trx_type;
                objTrxBO.tb_trx_date = obj.tb_trx_date;
                objTrxBO.tb_trx_flag = obj.tb_trx_flag;
                objTrxBO.tb_client_id = obj.tb_client_id;
                objTrxBO.tb_isin = obj.tb_isin;
                objTrxBO.tb_qty = obj.tb_qty;
                objTrxBO.tb_market_type = obj.tb_market_type;
                objTrxBO.tb_settlement = obj.tb_settlement;
                objTrxBO.tb_exchangeid = obj.tb_exchangeid;
                objTrxBO.tb_chid = obj.tb_chid;
                objTrxBO.tb_other_dp_id = obj.tb_other_dp_id;
                objTrxBO.tb_other_client_id = obj.tb_other_client_id;
                objTrxBO.tb_other_cmbp_id = obj.tb_other_cmbp_id;
                objTrxBO.tb_other_markettype = obj.tb_other_markettype;
                objTrxBO.tb_other_settle_no = obj.tb_other_settle_no;
                objTrxBO.tb_br_code = obj.tb_br_code;
                objTrxBO.tb_reference = obj.tb_reference;
                objTrxBO.tb_irre_code1 = obj.tb_irre_code1;
                objTrxBO.tb_irre_code2 = obj.tb_irre_code2;
                objTrxBO.tb_irre_code3 = obj.tb_irre_code3;
                objTrxBO.tb_irre_code4 = obj.tb_irre_code4;
                objTrxBO.tb_br_pri_key = obj.tb_br_pri_key;
                objTrxBO.tb_status = obj.tb_status;
                objTrxBO.tb_trx_allow = obj.tb_trx_allow;
                objTrxBO.tb_authcode1 = obj.tb_authcode1;
                objTrxBO.tb_authuserid1 = obj.tb_authuserid1;
                objTrxBO.tb_authdt1 = obj.tb_authdt1;
                objTrxBO.tb_authcode2 = obj.tb_authcode2;
                objTrxBO.tb_authuserid2 = obj.tb_authuserid2;
                objTrxBO.tb_authdt2 = obj.tb_authdt2;
                objTrxBO.tb_batch_no = obj.tb_batch_no;
                objTrxBO.tb_branchcd = obj.tb_branchcd;
                objTrxBO.tb_branchbatchcd = obj.tb_branchbatchcd;
                objTrxBO.tb_cash = obj.tb_cash;
                objTrxBO.tb_reasfortrade = obj.tb_reasfortrade;
                objTrxBO.tb_rejreason = obj.tb_rejreason;
                objTrxBO.mkrid = obj.mkrid;
                objTrxBO.mkrdt = obj.mkrdt;
                objTrxBO.tb_authcode3 = obj.tb_authcode3;
                objTrxBO.tb_authuserid3 = obj.tb_authuserid3;
                objTrxBO.tb_authdt3 = obj.tb_authdt3;
                objTrxBO.tb_authremarks = obj.tb_authremarks;
                objTrxBO.tb_scrollno = obj.tb_scrollno;
                objTrxBO.tb_obligationid = obj.tb_obligationid;
                objTrxBO.tb_serialno = obj.tb_serialno;
                objTrxBO.tb_tradeno = obj.tb_tradeno;
                objTrxBO.tb_exec_date = obj.tb_exec_date;
                objTrxBO.tb_remark = obj.tb_remark;
                objTrxBO.mkrtm = obj.mkrtm;
                objTrxBO.tb_authtm1 = obj.tb_authtm1;
                objTrxBO.tb_authtm2 = obj.tb_authtm2;
                objTrxBO.tb_authtm3 = obj.tb_authtm3;
                objTrxBO.tb_instreceivemode = obj.tb_instreceivemode;
                objTrxBO.tb_recoslipyn = obj.tb_recoslipyn;
                objTrxBO.tb_entrymode = obj.tb_entrymode;
                objTrxBO.tb_lotno = obj.tb_lotno;
                SingleEntities db = new SingleEntities();
                db.Trxbackoffices.Add(objTrxBO);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FillInstrumentDropDown(DropDownList ddl)
        {
            ddl.DataSource = new SingleEntities().Instrument_master.Where(x => x.im_defaultyn == "Y").Select(y => new { y.im_instcd, y.im_desc }).ToList();
            ddl.DataTextField = "im_desc";
            ddl.DataValueField = "im_instcd";
            ddl.Items.Insert(0, new ListItem("- select -", "0"));
            ddl.DataBind();
            
        }

        public void FillLotSizeDropDown(DropDownList ddl)
        {
            ddl.DataSource = new DropDowns().LotSizeList();
            ddl.DataTextField = "lz_size";
            ddl.DataValueField = "lz_size";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("- select -", "0"));
        }
        
        public void FillLotNoDropDown(DropDownList ddl,int insCode=0)
        {
            string insType = getInstype(insCode);
            ddl.DataSource = new DropDowns().LotSizeList()
                            .Where(x => (insCode == 0 || x.lz_type == insType));
            ddl.DataTextField = "lz_lotno";
            ddl.DataValueField = "lz_lotno";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("- select -", "0"));
        }

        public void FillReasonfortradeDropDown(DropDownList ddl)
        {
            ddl.DataSource  = new SingleEntities().Reasonfortrades.ToList();
            //ddl.DataSource = new DropDowns().LotSizeList();
            ddl.DataTextField = "rt_desc";
            ddl.DataValueField = "rt_code";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("- select -", "0"));
        }
        public void ShowEmptyGridColumns(GridView grdvw)
        {
            grdvw.DataSource = null;
            grdvw.DataBind();
        }
        
        public string getInstype(int insCode)
        {
            try
            {
                return new SingleEntities().Instrument_master.Where(x => x.im_instcd == insCode).Select(y => y.im_trtype).First().ToString();
            }
            catch (Exception ex)
            {                
                throw;
            }
        }

        public void sendHome()
        {
            HttpContext.Current.Response.Redirect("../Home.aspx");
        }

        public string GetSystemParameter(string paramCode)
        {
            try
            {
                return new SingleEntities().Sysparameters.Where(y => y.sp_parmcd == paramCode).Select(x => x.sp_sysvalue).First();
            }
            catch (Exception)
            {
                return "";
            }
            
        }

        public int AddBackOffice(BackOffice Obj)
        {
            try
            {
                
                Trxbackoffice ObjBO = new Trxbackoffice();
                ObjBO.tb_pri_key = Obj.tb_pri_key ;
                ObjBO.tb_internal_refno = Obj.tb_internal_refno ;
                ObjBO.tb_instcd = Obj.tb_instcd ;
                ObjBO.tb_trx_type = Obj.tb_trx_type ;
                ObjBO.tb_trx_date = Obj.tb_trx_date ;
                ObjBO.tb_trx_flag = Obj.tb_trx_flag ;
                ObjBO.tb_client_id = Obj.tb_client_id ;
                ObjBO.tb_isin = Obj.tb_isin ;
                ObjBO.tb_qty = Obj.tb_qty ;
                ObjBO.tb_market_type = Obj.tb_market_type ;
                ObjBO.tb_settlement = Obj.tb_settlement ;
                ObjBO.tb_exchangeid = Obj.tb_exchangeid ;
                ObjBO.tb_chid = Obj.tb_chid ;
                ObjBO.tb_other_dp_id = Obj.tb_other_dp_id ;
                ObjBO.tb_other_client_id = Obj.tb_other_client_id ;
                ObjBO.tb_other_cmbp_id = Obj.tb_other_cmbp_id ;
                ObjBO.tb_other_markettype = Obj.tb_other_markettype ;
                ObjBO.tb_other_settle_no = Obj.tb_other_settle_no ;
                ObjBO.tb_br_code = Obj.tb_br_code ;
                ObjBO.tb_reference = Obj.tb_reference ;
                ObjBO.tb_irre_code1 = Obj.tb_irre_code1 ;
                ObjBO.tb_irre_code2 = Obj.tb_irre_code2 ;
                ObjBO.tb_irre_code3 = Obj.tb_irre_code3 ;
                ObjBO.tb_irre_code4 = Obj.tb_irre_code4 ;
                ObjBO.tb_br_pri_key = Obj.tb_br_pri_key ;
                ObjBO.tb_status = Obj.tb_status ;
                ObjBO.tb_trx_allow = Obj.tb_trx_allow ;
                ObjBO.tb_authcode1 = Obj.tb_authcode1 ;
                ObjBO.tb_authuserid1 = Obj.tb_authuserid1 ;
                ObjBO.tb_authdt1 = Obj.tb_authdt1 ;
                ObjBO.tb_authcode2 = Obj.tb_authcode2 ;
                ObjBO.tb_authuserid2 = Obj.tb_authuserid2 ;
                ObjBO.tb_authdt2 = Obj.tb_authdt2 ;
                ObjBO.tb_batch_no = Obj.tb_batch_no ;
                ObjBO.tb_branchcd = Obj.tb_branchcd ;
                ObjBO.tb_branchbatchcd = Obj.tb_branchbatchcd ;
                ObjBO.tb_cash = Obj.tb_cash ;
                ObjBO.tb_reasfortrade = Obj.tb_reasfortrade ;
                ObjBO.tb_rejreason = Obj.tb_rejreason ;
                ObjBO.mkrid = Obj.mkrid ;
                ObjBO.mkrdt = Obj.mkrdt ;
                ObjBO.tb_authcode3 = Obj.tb_authcode3 ;
                ObjBO.tb_authuserid3 = Obj.tb_authuserid3 ;
                ObjBO.tb_authdt3 = Obj.tb_authdt3 ;
                ObjBO.tb_authremarks = Obj.tb_authremarks ;
                ObjBO.tb_scrollno = Obj.tb_scrollno ;
                ObjBO.tb_obligationid = Obj.tb_obligationid ;
                ObjBO.tb_serialno = Obj.tb_serialno ;
                ObjBO.tb_tradeno = Obj.tb_tradeno ;
                ObjBO.tb_exec_date = Obj.tb_exec_date ;
                ObjBO.tb_remark = Obj.tb_remark ;
                ObjBO.mkrtm = Obj.mkrtm ;
                ObjBO.tb_authtm1 = Obj.tb_authtm1 ;
                ObjBO.tb_authtm2 = Obj.tb_authtm2 ;
                ObjBO.tb_authtm3 = Obj.tb_authtm3 ;
                ObjBO.tb_instreceivemode = Obj.tb_instreceivemode ;
                ObjBO.tb_recoslipyn = Obj.tb_recoslipyn ;
                ObjBO.tb_entrymode = Obj.tb_entrymode ;
                ObjBO.tb_lotno = Obj.tb_lotno ;
                SingleEntities db = new SingleEntities();
                db.Trxbackoffices.Add(ObjBO);
                return db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        

    }
    public class Stock
    {
        public string strdt { get; set; }
        public short intVendorCode { get; set; }
        public string strSlipsr { get; set; }
        public short intInstrumentCode { get; set; }
        public string strRefDt { get; set; }
        public string strRef { get; set; }
        public short intSize { get; set; }
        public int intBooks { get; set; }
        public int intBookFrom { get; set; }
        public int intBookTo { get; set; }
        public int intSlipNoFrom { get; set; }
        public int intSlipTo { get; set; }
    }
    public class ChequeMaster
    {
        public string companyCode { get; set; }
        public string companyName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public int chequeNo { get; set; }
        public Int16 instrumentCode { get; set; }
        public Int16 bookSize { get; set; }
        public string refNo { get; set; }
        public DateTime? refDate { get; set; }
        public string status { get; set; }
        public DateTime? issueDate { get; set; }
        public string remarks { get; set; }
        public string branchCode { get; set; }
        public string makerID { get; set; }
        public DateTime? makerDate { get; set; }
        public int chequeFromNo { get; set; }
        public int chequeToNo { get; set; }
    }
    public class Inward
    {
        public decimal? ie_lotno { get; set; }
        public string ie_trxtype { get; set; }
        public string ie_instno { get; set; }
        public string ie_slipno { get; set; }
        public string ie_cmcd { get; set; }
        public DateTime? ie_dt { get; set; }
        public DateTime? ie_execdt { get; set; }
        public int? ie_nooftrx {get; set; }
        public int? ie_noofcert { get; set; }
        public int? ie_rejected { get; set; }
        public int ie_scrollno { get; set; }
        public string mkrid { get; set; }
        public DateTime? mkrdt { get; set; }
        public decimal? ie_charge { get; set; }
        public string ie_mode { get; set; }
        public string ie_remark { get; set; }
        public decimal? ie_pri_key { get; set; }
        public string ie_branchcd { get; set; }

    }
}