using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class CCCalender
    {
        public string cc_id { get; set; }
        public string cc_mkt_type { get; set; }
        public string cc_settle_no { get; set; }
        public System.DateTime cc_settle_periodfrom { get; set; }
        public System.DateTime cc_settle_periodto { get; set; }
        public System.DateTime cc_nsdl_deadlinedt { get; set; }
        public string cc_nsdl_deadlinett { get; set; }
        public System.DateTime cc_payin_dt { get; set; }
        public System.DateTime cc_payout_dt { get; set; }

        public int isValidStlmntNo(string settleNo, bool hasDateValidation = false)
        {
            try
            {
                if (hasDateValidation)
                {
                    return new SingleEntities().Cc_calender.Where(y => y.cc_settle_no == settleNo && (DateTime.Now.Date >= y.cc_settle_periodfrom && DateTime.Now.Date <= y.cc_settle_periodto)).Count();
                }
                else
                {
                    return new SingleEntities().Cc_calender.Where(y => y.cc_settle_no == settleNo).Count();
                }
                
            }
            catch (Exception)
            {                
                throw;
            }
        }
        
    }
}