using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class InterDepository
    {
        //public string id_instcd { get; set;}
        //public DateTime id_trxdate { get; set;}
        //public string id_trxtype { get; set;}
        //public string id_trxflag { get; set;}
        //public string id_clientid { get; set;}
        //public string id_isin { get; set;}
        //public Decimal id_qty { get; set;}
        //public string id_mkttype { get; set;}
        //public string id_settlementno { get; set;}
        //public DateTime id_executiondate { get; set;}
        //public string id_otherclientid { get; set;}
        //public string id_otherdpid { get; set;}
        //public string id_internalrefno { get; set;}
        //public string id_cc_id { get; set;}
        //public string id_status { get; set;}
        //public string id_allow { get; set;}
        //public string id_othersettlement { get; set;}
        //public string id_authcode1 { get; set;}
        //public string id_authuserid1 { get; set;}
        //public DateTime? id_authdate1 { get; set;}
        //public string id_authcode2 { get; set;}
        //public string id_authuserid2 { get; set;}
        //public DateTime? id_authdate2 { get; set;}
        //public int id_batch_no { get; set;}
        //public int id_pri_key { get; set;}
        //public string id_branchcd { get; set;}
        //public string id_branchbatchcd { get; set;}
        //public string mkrid { get; set;}
        //public DateTime? mkrdt { get; set;}
        //public string id_authcode3 { get; set;}
        //public string id_authuserid3 { get; set;}
        //public DateTime? id_authdt3 { get; set;}
        //public string id_authremarks { get; set;}
        //public int id_scrollno { get; set;}
        //public Decimal id_dqty { get; set;}
        //public int id_lotno { get; set;}
        //public string id_authtm1 { get; set;}
        //public string id_authtm2 { get; set;}
        //public string id_authtm3 { get; set;}
        //public string mkrtm { get; set;}
        //public string id_instreceivemode { get; set;}
        //public string id_recoslipyn { get; set;}
        //public string id_entrymode { get; set;}
        //public string id_remarks { get; set;}
        //public string id_CDSLsettlement { get; set;}

        public string id_instcd { get; set; }
        public System.DateTime id_trxdate { get; set; }
        public string id_trxtype { get; set; }
        public string id_trxflag { get; set; }
        public string id_clientid { get; set; }
        public string id_isin { get; set; }
        public Nullable<decimal> id_qty { get; set; }
        public string id_mkttype { get; set; }
        public string id_settlementno { get; set; }
        public System.DateTime id_executiondate { get; set; }
        public string id_otherclientid { get; set; }
        public string id_otherdpid { get; set; }
        public string id_internalrefno { get; set; }
        public string id_cc_id { get; set; }
        public string id_status { get; set; }
        public string id_allow { get; set; }
        public string id_othersettlement { get; set; }
        public string id_authcode1 { get; set; }
        public string id_authuserid1 { get; set; }
        public Nullable<System.DateTime> id_authdate1 { get; set; }
        public string id_authcode2 { get; set; }
        public string id_authuserid2 { get; set; }
        public Nullable<System.DateTime> id_authdate2 { get; set; }
        public Nullable<int> id_batch_no { get; set; }
        public int id_pri_key { get; set; }
        public string id_branchcd { get; set; }
        public string id_branchbatchcd { get; set; }
        public string mkrid { get; set; }
        public Nullable<System.DateTime> mkrdt { get; set; }
        public string id_authcode3 { get; set; }
        public string id_authuserid3 { get; set; }
        public Nullable<System.DateTime> id_authdt3 { get; set; }
        public string id_authremarks { get; set; }
        public Nullable<decimal> id_scrollno { get; set; }
        public Nullable<decimal> id_dqty { get; set; }
        public Nullable<decimal> id_lotno { get; set; }
        public string id_authtm1 { get; set; }
        public string id_authtm2 { get; set; }
        public string id_authtm3 { get; set; }
        public string mkrtm { get; set; }
        public string id_instreceivemode { get; set; }
        public string id_recoslipyn { get; set; }
        public string id_entrymode { get; set; }
        public string id_remarks { get; set; }
        public string id_CDSLsettlement { get; set; }
        public string cm_name { get; set; }
        public string sc_rate { get; set; }
        public string id_value { get; set; }
        public string id_reasonForTrade { get; set; }

        public string id_type { get; set; }

        public int DeleteInterDP(int intprikey)
        {
            try
            {
                SingleEntities db = new SingleEntities();
                Interdepository obj = db.Interdepositories.Where(x => x.id_pri_key == intprikey).FirstOrDefault();

                Backoffice_audit obj1 = new Backoffice_audit();
                Backoffice_delete obj2 = new Backoffice_delete();
                obj1.ba_branchcd = obj.id_branchcd;
                obj1.ba_computername = "";
                obj1.ba_pri_key = obj.id_pri_key;
                obj1.ba_trx_type = obj.id_trxtype;

                obj2.bd_authcode1 = obj.id_authcode1;
                obj2.bd_authcode2 = obj.id_authcode2;
                obj2.bd_authcode3 = obj.id_authcode3;
                obj2.bd_authdt1 = obj.id_authdate1;
                obj2.bd_authdt2 = obj.id_authdate2;
                obj2.bd_authdt3 = obj.id_authdt3;
                obj2.bd_authremarks = obj.id_authremarks;
                obj2.bd_branchcd = obj.id_branchcd;
                obj2.bd_client_id = obj.id_clientid;
                obj2.bd_execution_date = obj.id_executiondate;
                obj2.bd_instdesc = obj.id_instreceivemode;
                obj2.bd_internal_refno = obj.id_internalrefno;
                obj2.bd_isin = obj.id_isin;
                obj2.bd_trx_type = obj.id_trxtype;
                obj2.bd_trx_date = obj.id_trxdate;
                obj2.bd_trx_allow = obj.id_allow;
                obj2.bd_scrollno = obj.id_scrollno;

                db.Backoffice_audit.Add(obj1);
                db.Backoffice_delete.Add(obj2);
                db.Interdepositories.Remove(obj);
                
                return db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
                
            }
            
        }

    }
}