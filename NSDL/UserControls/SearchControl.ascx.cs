using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSDL.UserControls
{
    public partial class SearchControl : System.Web.UI.UserControl
    {
        public string url
        {
            get
            {
                return this.ViewState["url"].ToString();
            }
            set
            {
                ViewState["url"] = value;
            }
        }

        public string LookupWindowName
        {
            get
            {
                return this.ViewState["LookupWindowName"].ToString();
            }
            set
            {
                ViewState["LookupWindowName"] = value;
            }
        }
        public string Height
        {
            get
            {
                return this.ViewState["Height"].ToString();
            }

            set
            {
                ViewState["Height"] = value;
            }
        }
        public string Width
        {
            get
            {
                return this.ViewState["Width"].ToString();
            }
            set
            {
                ViewState["Width"] = value;
            }
        }
        public string ReturnToControlID
        {
            get
            {
                return this.ViewState["ReturnToControlID"].ToString();
            }
            set
            {
                ViewState["ReturnToControlID"] = value;
            }
        }
        public string ReturnToControlID1
        {
            get
            {
                if (ViewState["ReturnToControlID1"] == null)
                {
                    return null;
                }
                else
                {
                    return this.ViewState["ReturnToControlID1"].ToString();
                }
            }

            set
            {
                ViewState["ReturnToControlID1"] = value;
            }
        }
        public String From
        {
            get
            {
                return this.ViewState["From"].ToString();
            }
            set
            {

                ViewState["From"] = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["Enable"]);
            }

            set
            {
                this.ViewState["Enable"] = value;
            }
        }
        public string PostBack
        {
            get
            {
                return this.ViewState["PostBackParentForm"].ToString();
            }

            set
            {
                ViewState["PostBackParentForm"] = value;
            }

        }



        protected void Page_Load(object sender, EventArgs e)
        {

            string sJS = "";

            if (string.IsNullOrEmpty(ReturnToControlID1))
            {
                sJS = "javascript:w=window.open(" + "\"" + ResolveClientUrl(this.url) + "?setLookupValueToControlID=" + this.Parent.FindControl(this.ReturnToControlID).ClientID + "&From=" + this.From + "&Enable=" + this.Enabled + "&PostBackParentForm=" + this.PostBack + "\" ," + "\"" + this.LookupWindowName + "\"," + "\"" + "location=0,status=0,scrollbars=yes,resizable=no," + "width=" + this.Width + ",height=" + this.Height + "\"" + ");";
            }
            else
            {
                sJS = "javascript:w=window.open(" + "\"" + ResolveClientUrl(this.url);
                sJS += "?setLookupValueToControlID=" + this.Parent.FindControl(this.ReturnToControlID).ClientID;
                sJS += "&setLookupValueToControlID1=" + this.Parent.FindControl(this.ReturnToControlID1).ClientID;
                sJS += "&From=" + this.From + "&Enable=" + this.Enabled + "&PostBackParentForm=";
                sJS += this.PostBack + "\"," + "\"" + this.LookupWindowName + "\"," + "\"";
                sJS += "location=0,status=0,scrollbars=yes,resizable=no," + "width=" + this.Width + ",height=";
                sJS += this.Height + "\"" + ");";
            }
            this.ctlLink.NavigateUrl = "javascript://";
            this.ctlLink.Attributes.Add("onclick", sJS);
            ctlLink.Enabled = Enabled;

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}