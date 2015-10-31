using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class BackofficeDelete
    {
        public string bd_instdesc { get; set; }
        public string bd_trx_type { get; set; }
        public System.DateTime bd_trx_date { get; set; }
        public string bd_client_id { get; set; }
        public string bd_isin { get; set; }
        public Nullable<decimal> bd_qty { get; set; }
        public string bd_market_type { get; set; }
        public string bd_settlement { get; set; }
        public System.DateTime bd_execution_date { get; set; }
        public string bd_other_dp_id { get; set; }
        public string bd_other_client_id { get; set; }
        public string bd_other_cmbp_id { get; set; }
        public string bd_internal_refno { get; set; }
        public string bd_other_markettype { get; set; }
        public string bd_other_settle_no { get; set; }
        public string bd_lock_release_code { get; set; }
        public Nullable<System.DateTime> bd_lock_release_date { get; set; }
        public string bd_cc_id1 { get; set; }
        public string bd_cc_id2 { get; set; }
        public string bd_status { get; set; }
        public string bd_trx_allow { get; set; }
        public int bd_pri_key { get; set; }
        public string bd_authcode1 { get; set; }
        public string bd_authuserid1 { get; set; }
        public Nullable<System.DateTime> bd_authdt1 { get; set; }
        public string bd_authcode2 { get; set; }
        public string bd_authuserid2 { get; set; }
        public Nullable<System.DateTime> bd_authdt2 { get; set; }
        public string bd_branchcd { get; set; }
        public string bd_branchbatchcd { get; set; }
        public string mkrid { get; set; }
        public Nullable<System.DateTime> mkrdt { get; set; }
        public string bd_authcode3 { get; set; }
        public string bd_authuserid3 { get; set; }
        public Nullable<System.DateTime> bd_authdt3 { get; set; }
        public string bd_authremarks { get; set; }
        public Nullable<decimal> bd_scrollno { get; set; }
        public Nullable<int> bd_totalcertificate { get; set; }
        public string bd_computername { get; set; }
        public string mkrtm { get; set; }
        public decimal bd_unique { get; set; }
        public string mkrtmold { get; set; }
        public string mkridold { get; set; }
        public string bd_authtm1 { get; set; }
        public string bd_authtm2 { get; set; }
        public string bd_authtm3 { get; set; }
        public Nullable<System.DateTime> mkrdtold { get; set; }

        public void add(BackofficeDelete obj)
        {
            Backoffice_delete obj1 = new Backoffice_delete();
            obj1.bd_instdesc = obj.bd_instdesc;
            obj1.bd_trx_type = obj.bd_trx_type;
            obj1.bd_trx_date = obj.bd_trx_date;
            obj1.bd_client_id = obj.bd_client_id;
            obj1.bd_isin = obj.bd_isin;
            obj1.bd_qty = obj.bd_qty;
            obj1.bd_market_type = obj.bd_market_type;
            obj1.bd_settlement = obj.bd_settlement;
            obj1.bd_execution_date = obj.bd_execution_date;
            obj1.bd_other_dp_id = obj.bd_other_dp_id;
            obj1.bd_other_client_id = obj.bd_other_client_id;
            obj1.bd_other_cmbp_id = obj.bd_other_cmbp_id;
            obj1.bd_internal_refno = obj.bd_internal_refno;
            obj1.bd_other_markettype = obj.bd_other_markettype;
            obj1.bd_other_settle_no = obj.bd_other_settle_no;
            obj1.bd_lock_release_code = obj.bd_lock_release_code;
            obj1.bd_lock_release_date = obj.bd_lock_release_date;
            obj1.bd_cc_id1 = obj.bd_cc_id1;
            obj1.bd_cc_id2 = obj.bd_cc_id2;
            obj1.bd_status = obj.bd_status;
            obj1.bd_trx_allow = obj.bd_trx_allow;
            obj1.bd_pri_key = obj.bd_pri_key;
            obj1.bd_authcode1 = obj.bd_authcode1;
            obj1.bd_authuserid1 = obj.bd_authuserid1;
            obj1.bd_authdt1 = obj.bd_authdt1;
            obj1.bd_authcode2 = obj.bd_authcode2;
            obj1.bd_authuserid2 = obj.bd_authuserid2;
            obj1.bd_authdt2 = obj.bd_authdt2;
            obj1.bd_branchcd = obj.bd_branchcd;
            obj1.bd_branchbatchcd = obj.bd_branchbatchcd;
            obj1.mkrid = obj.mkrid;
            obj1.mkrdt = obj.mkrdt;
            obj1.bd_authcode3 = obj.bd_authcode3;
            obj1.bd_authuserid3 = obj.bd_authuserid3;
            obj1.bd_authdt3 = obj.bd_authdt3;
            obj1.bd_authremarks = obj.bd_authremarks;
            obj1.bd_scrollno = obj.bd_scrollno;
            obj1.bd_totalcertificate = obj.bd_totalcertificate;
            obj1.bd_computername = obj.bd_computername;
            obj1.mkrtm = obj.mkrtm;
            obj1.bd_unique = obj.bd_unique;
            obj1.mkrtmold = obj.mkrtmold;
            obj1.mkridold = obj.mkridold;
            obj1.bd_authtm1 = obj.bd_authtm1;
            obj1.bd_authtm2 = obj.bd_authtm2;
            obj1.bd_authtm3 = obj.bd_authtm3;
            obj1.mkrdtold = obj.mkrdtold;
            SingleEntities db = new SingleEntities();
            db.Backoffice_delete.Add(obj1);
            db.SaveChanges();
        }
    }
}