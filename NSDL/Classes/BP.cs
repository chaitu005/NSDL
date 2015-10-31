using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class BP
    {
        public string bp_id { get; set; }
        public string bp_role { get; set; }
        public string bp_add1 { get; set; }
        public string bp_add2 { get; set; }
        public string bp_add3 { get; set; }
        public string bp_add4 { get; set; }
        public string bp_pin { get; set; }
        public string bp_phone { get; set; }
        public string bp_fax { get; set; }
        public string bp_assd_cc_id { get; set; }
        public string bp_assd_dp_id { get; set; }
        public string bp_assd_cc_cmid { get; set; }
        public string bp_category { get; set; }
        public string bp_name { get; set; }
        public string bp_stat { get; set; }

        public string getBPName(string BPID)
        {
            try
            {
                if (!new Validate().isEmpty(BPID))
                {
                    return new SingleEntities().Bpmasters.Where(y => y.bp_id == BPID).Select(x => x.bp_name).FirstOrDefault();
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    
}