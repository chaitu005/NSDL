using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class SecurityStatus
    {
        public string ss_code { get; set; }
        public string ss_description { get; set; }

        public string GetStatus(string code)
        {
            return new SingleEntities().Security_status.Where(y => y.ss_code == code).Select(x => x.ss_description).FirstOrDefault();
        }
    }
}