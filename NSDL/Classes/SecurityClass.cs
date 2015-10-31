using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class SecurityClass
    {
        public string sc_isincode { get; set; }
        public string sc_nsecurity_code { get; set; }
        public int sc_book_basis { get; set; }
        public string sc_isinname { get; set; }
        public string sc_company_code { get; set; }
        public string sc_company_name { get; set; }
        public string sc_security_type { get; set; }
        public string sc_security_subtype { get; set; }
        public DateTime sc_issue { get; set; }
        public DateTime sc_maturity_date { get; set; }
        public DateTime sc_convert_date { get; set; }
        public decimal sc_face_value { get; set; }
        public decimal sc_convert_amount { get; set; }
        public string sc_agentname { get; set; }
        public string sc_security_status { get; set; }
        public string sc_security_remark { get; set; }
        public string sc_decimal_allow { get; set; }
        public string sc_reg_code { get; set; }
        public string sc_reg_name { get; set; }
        public string sc_bsecd { get; set; }
        public string sc_nsesym { get; set; }
        public string sc_nsesrs { get; set; }
        public string sc_attn { get; set; }
        public string sc_sl_balance { get; set; }
        public float sc_rate { get; set; }
        public string sc_rolling { get; set; }
        public string sc_corporateaction { get; set; }
        public string mkrid { get; set; }
        public DateTime mkrdt { get; set; }
        public string sc_sector { get; set; }

        public string getIsinName(string isincode)
        {
            try
            {
                return new SingleEntities().Securities.Where(y => y.sc_isincode == isincode && y.sc_security_status == "01").Select(x => x.sc_isinname).FirstOrDefault();
                string isinStatus=getIsinStatus(isincode);
                if (isinStatus == "01"){
                    
                }
                else {
                        return new SecurityStatus().GetStatus(isinStatus);
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        public decimal? getIsinRate(string isincode)
        {
            try
            {
                return new SingleEntities().Securities.Where(y => y.sc_isincode == isincode).Select(x => x.sc_rate).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string getIsinStatus(string isincode)
        {
            try
            {
                return new SingleEntities().Securities.Where(y => y.sc_isincode == isincode).Select(x => x.sc_security_status).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    
}