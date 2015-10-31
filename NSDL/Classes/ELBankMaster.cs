using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSDL.Classes
{
    public class ELBankMaster
    {
        string strMode;
        string strBK_MICR;
        string strBK_NAME;
        string strBK_ADD1;
        string strBK_ADD2;
        string strBK_ADD3;
        string strBK_CITY;
        string strBK_STATE;
        string strBK_COUNTRY;
        string strBK_PIN;
        string strBK_TELE1;
        string strBK_TELE2;
        string strBK_FAX;
        string strBK_EMAIL;
        string strBK_CONNAME;
        string strBK_CONDESG;
        string strUR_Code;
        string strUR_Desc;
        public string Code
        {
            get { return strUR_Code; }
            set { strUR_Code = value; }
        }
        public string Desc
        {
            get { return strUR_Desc; }
            set { strUR_Desc = value; }
        }

        public string BK_Mode
        {
            get
            {
                return strMode;
            }
            set { strMode = value; }
        }
        public string BK_CONDESG
        {
            get { return strBK_CONDESG; }
            set { strBK_CONDESG = value; }
        }
        public string BK_CONNAME
        {
            get { return strBK_CONNAME; }
            set { strBK_CONNAME = value; }
        }
        public string BK_EMAIL
        {
            get { return strBK_EMAIL; }
            set { strBK_EMAIL = value; }
        }
        public string BK_FAX
        {
            get { return strBK_FAX; }
            set { strBK_FAX = value; }
        }
        public string BK_TELE2
        {
            get { return strBK_TELE2; }
            set { strBK_TELE2 = value; }
        }

        public string BK_TELE1
        {
            get { return strBK_TELE1; }
            set { strBK_TELE1 = value; }
        }

        public string BK_PIN
        {
            get { return strBK_PIN; }
            set { strBK_PIN = value; }
        }

        public string BK_COUNTRY
        {
            get { return strBK_COUNTRY; }
            set { strBK_COUNTRY = value; }
        }

        public string BK_STATE
        {
            get { return strBK_STATE; }
            set { strBK_STATE = value; }
        }

        public string BK_CITY
        {
            get { return strBK_CITY; }
            set { strBK_CITY = value; }
        }

        public string BK_ADD3
        {
            get { return strBK_ADD3; }
            set { strBK_ADD3 = value; }
        }

        public string BK_ADD2
        {
            get { return strBK_ADD2; }
            set { strBK_ADD2 = value; }
        }

        public string BK_ADD1
        {
            get { return strBK_ADD1; }
            set { strBK_ADD1 = value; }
        }

        public string BK_NAME
        {
            get { return strBK_NAME; }
            set { strBK_NAME = value; }
        }
        public string BK_MICR
        {
            get { return strBK_MICR; }
            set { strBK_MICR = value; }
        }
        string strBK_BRANCH;

        public string BK_BRANCH
        {
            get { return strBK_BRANCH; }
            set { strBK_BRANCH = value; }
        }

    }
}