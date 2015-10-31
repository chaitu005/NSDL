using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;

namespace NSDL.Classes
{
    public class RateMaster
    {
        public string rm_isin_code { get; set; }
        public System.DateTime rm_trx_date { get; set; }
        public decimal rm_rate { get; set; }
        public decimal? getRate(string isin)
        {
            System.DateTime sysdate = System.DateTime.Now.Date;
            return new SingleEntities().Rate_master.Where(y => y.rm_isin_code == isin && y.rm_trx_date == sysdate).Select(x => x.rm_rate).FirstOrDefault();
        }
    }
}