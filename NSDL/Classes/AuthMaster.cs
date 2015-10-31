using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class AuthMaster
    {
        public string am_code { get; set; }
        public decimal am_amount { get; set; }
        public string am_group1 { get; set; }
        public string am_group2 { get; set; }
        public string am_group3 { get; set; }
        public string mkrid { get; set; }
        public Nullable<System.DateTime> mkrdt { get; set; }

        public int Authorise(decimal amount, string instype)
        {
            try
            {
                return new SingleEntities().Auth_master.Where(x => x.am_code == instype && x.am_amount < amount).Count();
                
            }
            catch (Exception)
            {
               
                return 0;
            }            
        }
    }
}