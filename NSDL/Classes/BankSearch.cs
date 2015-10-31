using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web;
namespace NSDL.Classes
{
    public class BankSearch
    {
        //Financial_Application.SearchUtility.BankSearch objSl = new SearchUtility.BankSearch();

        public void BuildLookupValueReturnControl(GridViewRow e, string LinkControlId)
        {
            string js;
            string txt;
            HyperLink h1;
            // Label lblMessage;
            //string type;
            if (e.RowType == DataControlRowType.DataRow)
            {
                h1 = (HyperLink)e.FindControl(LinkControlId);
                txt = (string)h1.Text;
                // lblMessage = (Label)e.FindControl(Status);
                // txt1 = (string)lblMessage.Text;
                if (HttpContext.Current.Request.QueryString["setLookupValueToControlID1"] == "")
                {


                    if (HttpContext.Current.Request.QueryString["PostBackParentForm"] != String.Empty)
                    {


                        js = BuildJS_ReturnLookupValue(HttpContext.Current.Request.QueryString["setLookupValueToControlID"], txt, HttpContext.Current.Request.QueryString["PostBackParentForm"], "", "");


                    }
                    else
                    {
                        js = BuildJS_ReturnLookupValue(HttpContext.Current.Request.QueryString["setLookupValueToControlID"], txt, "true", "", "");


                    }
                }
                else
                {
                    if (HttpContext.Current.Request.QueryString["PostBackParentForm"] != String.Empty)
                    {


                        js = BuildJS_ReturnLookupValue(HttpContext.Current.Request.QueryString["setLookupValueToControlID"], txt, HttpContext.Current.Request.QueryString["PostBackParentForm"], HttpContext.Current.Request.QueryString["setLookupValueToControlID1"], e.Cells[2].Text);


                    }
                    else
                    {

                        js = BuildJS_ReturnLookupValue(HttpContext.Current.Request.QueryString["setLookupValueToControlID"], txt, "true", HttpContext.Current.Request.QueryString["setLookupValueToControlID1"], e.Cells[2].Text);

                    }
                    h1.NavigateUrl = "javascript://";
                    //h1.NavigateUrl = 
                    h1.Attributes.Add("onclick", js);

                }
            }
        }
        public string BuildJS_ReturnLookupValue(string controlID, string valueToSet, string PostBackParentForm, string controlID1, string valueToSet1)
        {
            string s;

            if (HttpContext.Current.Request.QueryString["setLookupValueToControlID1"] == "")
            {
                s = "winOpener=window.self.opener;winOpener.document.getElementById('" + controlID + "').value='" + valueToSet.Trim() + "';";

                if (PostBackParentForm == "true")
                {
                     s = s + " winOpener.document.getElementById('ctl00$ContentPlaceHolder1$Button1').click();window.close();";
                    //   s = s + "if(window.opener.document.getElementById('ctl00$ContentPlaceHolder1$btnHidden').click;self.close();";
                }

                else
                {
                    s = s + "window.close();";

                }
            }
            else
            {
                s = "winOpener=window.self.opener;" +
                             "winOpener.document.getElementById('" + controlID + "').value='" + valueToSet.Trim() + "';";

                if(controlID1!=null)

                {
                 s=s+"winOpener.document.getElementById('" + controlID1 + "').value='" + valueToSet1.Trim() + "';";
                }
                    if (PostBackParentForm == "true")
                {
                 
                    // s = s + "window.opener.document.getElementById('ctl00_ContentPlaceHolder1_Button1').click();window.close();";
                    //   s = s + "if(window.opener.document.getElementById('ctl00$ContentPlaceHolder1$btnHidden').click;self.close();";
                    s = s + "window.close();";
                }
                else
                {
                    s = s + "window.close();";
                }
            }
            return s;


        }
    }
}

