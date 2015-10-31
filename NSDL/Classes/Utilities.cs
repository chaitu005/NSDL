using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace NSDL.Classes
{
    public class Utilities
    {


        /* BindGridview Informtion */

        public void BindGridView(GridView gv, DataSet ds)
        {


            gv.DataSource = ds;
            gv.DataBind();



        }

        public void BindGridView(GridView gv, DataTable dt)
        {


            gv.DataSource = dt;
            gv.DataBind();



        }




        /* Drop Down List Fillup Code */
        public void LoadCombo(DataSet ds, DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.DataSource = ds;
            if (ds != null)
            {
                ddl.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                ddl.DataTextField = ds.Tables[0].Columns[1].ColumnName;
            }
            ddl.DataBind();
            ddl.Items.Insert(0, li);
        }

        public void LoadCombo(DataTable dt, DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.DataSource = dt;
            if (dt != null)
            {
                ddl.DataValueField = dt.Columns[0].ColumnName;
                ddl.DataTextField = dt.Columns[1].ColumnName;
            }
            ddl.DataBind();
            ddl.Items.Insert(0, li);
        }
        public void LoadCombosingle(DataSet ds, DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.DataSource = ds;
            if (ds != null)
            {
                ddl.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                ddl.DataTextField = ds.Tables[0].Columns[1].ColumnName;
            }
            ddl.DataBind();
            ddl.Items.Insert(0, li);
        }


        public void LoadComboAll(DataSet ds, DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--All-";
            li.Value = "0";
            ddl.DataSource = ds;
            if (ds != null)
            {
                ddl.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                ddl.DataTextField = ds.Tables[0].Columns[1].ColumnName;
            }
            ddl.DataBind();
            ddl.Items.Insert(0, li);
        }
        public void LoadComboBlank(DataSet ds, DropDownList ddl)
        {
            //ListItem li = new ListItem();
            //li.Text = "--Select--";
            //li.Value = "0";
            ddl.DataSource = ds;
            if (ds != null)
            {
                ddl.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                ddl.DataTextField = ds.Tables[0].Columns[1].ColumnName;
            }
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            //ddl.Items.Insert(1, li);
        }






        public void BindGridViewWithoutCheckBox(GridView gv, DataSet ds)
        {

            gv.DataSource = ds;
            gv.DataBind();

            if (ds.Tables[0].Rows.Count == 0)
            {

                ShowNoResultFound(ds.Tables[0], gv);


            }


        }
        public Boolean IsNumeric(string strText)
        {

            const string ALL_NUMERIC_PATTERN = "[a-z|A-Z]";
            Regex All_Numeric_Regex = new Regex(ALL_NUMERIC_PATTERN);
            if (All_Numeric_Regex.IsMatch(strText))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        //public void LoadCombo(DataSet ds, DropDownList ddl)
        //{
        //    ListItem li = new ListItem();
        //    li.Text = "--Select--";
        //    li.Value = "0";
        //    ddl.DataSource = ds;
        //    if (ds != null)
        //    {
        //        ddl.DataValueField = ds.Tables[0].Columns[0].ColumnName;
        //        ddl.DataTextField = ds.Tables[0].Columns[1].ColumnName;
        //    }
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, li);
        //}

        //public void LoadComboAll(DataSet ds, DropDownList ddl)
        //{
        //    ListItem li = new ListItem();
        //    li.Text = "--All--";
        //    li.Value = "0";
        //    ddl.DataSource = ds;
        //    if (ds != null)
        //    {
        //        ddl.DataValueField = ds.Tables[0].Columns[0].ColumnName;
        //        ddl.DataTextField = ds.Tables[0].Columns[1].ColumnName;
        //    }
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, li);
        //}
        //public void LoadComboBlank(DataSet ds, DropDownList ddl)
        //{
        //    //ListItem li = new ListItem();
        //    //li.Text = "--Select--";
        //    //li.Value = "0";
        //    ddl.DataSource = ds;
        //    if (ds != null)
        //    {
        //        ddl.DataValueField = ds.Tables[0].Columns[0].ColumnName;
        //        ddl.DataTextField = ds.Tables[0].Columns[1].ColumnName;
        //    }
        //    ddl.DataSource = ds.Tables[0];
        //    ddl.DataBind();
        //    //ddl.Items.Insert(1, li);
        //}




        public void LoadComboTextField(DataSet ds, DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.DataSource = ds;
            if (ds != null)
            {
                //ddl.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                ddl.DataTextField = ds.Tables[0].Columns[0].ColumnName;
            }
            ddl.DataBind();
            ddl.Items.Insert(0, li);
        }
        public void LoadCheckBox(DataSet ds, CheckBoxList chk)
        {

            //  ListItem li = new ListItem();

            chk.DataSource = ds;
            if (ds != null)
            {
                chk.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                chk.DataTextField = ds.Tables[0].Columns[1].ColumnName;
            }
            chk.DataSource = ds.Tables[0];
            chk.DataBind();
            // chk.Items.Insert(1, li);

        }





        public void ShowNoResultFound(DataTable source, GridView gv)
        {

            source.Rows.Add(source.NewRow()); // create a new blank row to the DataTable

            // Bind the DataTable which contain a blank row to the GridView

            gv.DataSource = source;

            gv.DataBind();

            // Get the total number of columns in the GridView to know what the Column Span should be

            int columnsCount = gv.Columns.Count;

            gv.Rows[0].Cells.Clear();// clear all the cells in the row

            gv.Rows[0].Cells.Add(new TableCell()); //add a new blank cell

            gv.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell



            //You can set the styles here

            gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;

            gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;

            gv.Rows[0].Cells[0].Font.Bold = true;

            //set No Results found to the new added cell

            gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";

        }

        public string Encode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Encode " + e.Message);
            }
        }
        public string Decode(string data)
        {
            try
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode " + e.Message);
            }
        }

        public byte[] BmpToBytes(System.Drawing.Image bmp)
        {
            MemoryStream ms = null;
            byte[] bmpBytes = null;
            try
            {
                ms = new MemoryStream();
                // Save to memory using the Jpeg format
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                // read to end
                bmpBytes = ms.GetBuffer();
            }
            catch
            {
                return null;
            }
            finally
            {
                bmp.Dispose();
                if (ms != null)
                {
                    ms.Close();
                }
            }
            return bmpBytes;
        }


        public void LoadCombo(DataTable dt, CheckBoxList ddl)
        {


            ddl.DataSource = dt;
            if (dt != null)
            {
                ddl.DataValueField = dt.Columns[0].ColumnName;
                ddl.DataTextField = dt.Columns[1].ColumnName;
            }
            ddl.DataBind();

        }


    }
}