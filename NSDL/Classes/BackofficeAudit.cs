using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class BackofficeAudit
    {
        public string ba_trx_type { get; set; }
        public int ba_pri_key { get; set; }
        public string ba_branchcd { get; set; }
        public string ba_field { get; set; }
        public string ba_oldvalue { get; set; }
        public string ba_newvalue { get; set; }
        public string mkrid { get; set; }
        public System.DateTime mkrdt { get; set; }
        public string ba_computername { get; set; }
        public string mkrtm { get; set; }
        public decimal ba_delunique { get; set; }
        public string mkrtmold { get; set; }
        public string mkridold { get; set; }
        public Nullable<System.DateTime> mkrdtold { get; set; }


        public void add(BackofficeAudit obj)
        {
            Backoffice_audit obj1 = new Backoffice_audit();
            obj1.ba_trx_type = obj.ba_trx_type;
            obj1.ba_pri_key = obj.ba_pri_key;
            obj1.ba_branchcd = obj.ba_branchcd;
            obj1.ba_field = obj.ba_field;
            obj1.ba_oldvalue = obj.ba_oldvalue;
            obj1.ba_newvalue = obj.ba_newvalue;
            obj1.mkrid = obj.mkrid;
            obj1.mkrdt = obj.mkrdt;
            obj1.ba_computername = obj.ba_computername;
            obj1.mkrtm = obj.mkrtm;
            obj1.ba_delunique = obj.ba_delunique;
            obj1.mkrtmold = obj.mkrtmold;
            obj1.mkridold = obj.mkridold;
            obj1.mkrdtold = obj.mkrdtold;       
            SingleEntities db = new SingleEntities();
            db.Backoffice_audit.Add(obj1);
            db.SaveChanges();
        }

    }
}