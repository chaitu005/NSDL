using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NSDL.Classes;

namespace NSDL.UserControls
{
    public partial class MenuControl : System.Web.UI.UserControl
    {
        Bussiness objBL = new Bussiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillmfgtreeview();
            }
        }
        public void fillmfgtreeview()
        {
            DataSet ds1;
            ds1 = objBL.getMenu_On_groupid(Session["UserId"].ToString());
           
                DataView dvMasterMenu = new DataView(ds1.Tables[0]);
                dvMasterMenu.RowFilter = "WMN_LEVEL='0'";
                DataTable dtMaster = dvMasterMenu.ToTable();
                foreach (DataRow row in dtMaster.Rows)
                {
                    string str = row["WMN_MODULECD"].ToString();
                    char C =Convert.ToChar( str.Substring(0, 1));
                    MenuItem node = new MenuItem();
                    node.Text = row["WMN_DESC"].ToString(); ;
                    node.Target = "_parent";
                    int j = 0;
                   
                    //DataSet childNodes;// = objBLmanu.getChind_ID_Name();
                    DataView dv = new DataView(ds1.Tables[0]);
                    dv.RowFilter = "WMN_MODULECD like '" + C + "%' and WMN_LEVEL=1";
                    DataTable dt = dv.ToTable();
                    foreach (DataRow child in dt.Rows)
                    {
                        string str1 = child["WMN_DESC"].ToString();
                        string strcd = child["WMN_MODULECD"].ToString();
                     string strlevel3 = strcd.Substring(0, 3);
                     MenuItem childNode = new MenuItem();
                     childNode.Text = child["WMN_DESC"].ToString();
                     childNode.NavigateUrl ="~/"+ child["WMN_FORMNAME"].ToString();
                     childNode.Target = "_parent";
                     

                     DataView dvLevel3 = new DataView(ds1.Tables[0]);
                     dvLevel3.RowFilter = "WMN_MODULECD like '" + strlevel3 + "%' and WMN_LEVEL=2";
                     DataTable dtlevel3 = dvLevel3.ToTable();
                     foreach (DataRow Subchild in dtlevel3.Rows)
                     {
                         // string str1= row["WMN_DESC"].ToString();
                         MenuItem Subchilds = new MenuItem();
                         Subchilds.Text = Subchild["WMN_DESC"].ToString();
                         Subchilds.NavigateUrl = "~/" + Subchild["WMN_FORMNAME"].ToString();
                         Subchilds.Target = "_parent";
                         childNode.ChildItems.Add(Subchilds);
                     }
                     node.ChildItems.Add(childNode);

                    }
                    Menu1.Items.Add(node); //TreeView.Nodes.Add(node);
            }

        }
    }
}