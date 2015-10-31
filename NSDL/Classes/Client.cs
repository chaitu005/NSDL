using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class Client
    {
        public string getClientName(string clientID)
        {
            try
            {
                return new SingleEntities().Client_master1.Where(y => y.cm_cd == clientID).Select(x => x.cm_name).FirstOrDefault();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


    }
}