using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class ChequeStopClass
    {
        public string chs_cmcd { get; set; }
        public decimal chs_chqno { get; set; }
        public string chs_chqdate { get; set; }
        public string chs_reference { get; set; }
        public string chs_refdate { get; set; }
        public string chs_status { get; set; }
        public string chs_date { get; set; }
        public short chs_instcd { get; set; }
        public string chs_remark { get; set; }
        public string mkrid { get; set; }
        public string mkrdt { get; set; }

        public string hasCheckStop(string cmcode, int chqno , int instcode)
        {
            try
            {
                return new SingleEntities().Chequestops.Where(y => y.chs_cmcd == cmcode && y.chs_chqno == chqno && y.chs_instcd == instcode).Select(x => x.chs_status).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}