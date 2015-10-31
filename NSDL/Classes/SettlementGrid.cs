using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class SettlementGrid
    {
        public string cc_settle_no { get; set; }
        public string cc_id { get; set; }
        public string cc_mkt_type { get; set; }
        public string cc_settle_periodfrom { get; set; }
        public string cc_settle_periodto { get; set; }
        public string cc_nsdl_deadlinedt { get; set; }
        public string cc_nsdl_deadlinett { get; set; }
        public string cc_payin_dt { get; set; }
        public string cc_payout_dt { get; set; }
        public string mt_description { get; set; }
    }
}