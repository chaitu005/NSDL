using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Globalization;

namespace NSDL.Classes
{
    public class Validate
    {
        public bool isEmpty(string str)
        {
            return string.IsNullOrEmpty(str.Trim());
        }
        public bool isNotNumber(string str)
        {
            int num;
            if (int.TryParse(str.Trim(), out num))
                return false;
            else
                return true;
        }
        public bool inValidString(string str, int maxLength)
        {
            if (str.Length <= maxLength)
                return true;
            else
                return false;
        }
        public bool isNotSelected(string selected)
        {
            return (selected == "0" || selected == "-1");
        }

        public int convertNumber(string str)
        {
            return Convert.ToInt32(str);
        }

        public bool isNotDecimal(TextBox control)
        {
            if (Regex.IsMatch(control.Text, @"\d+(\.\d{2,2})"))
                return false;
            else
                return true;
        }
        public decimal ConvertDecimal(string str)
        {
            return Convert.ToDecimal(str);
        }

        public bool isEmpty(TextBox control)
        {
            string value = control.Text.Trim();
            if (string.IsNullOrEmpty(value))
                return true;
            else
                return false;
        }

        public bool isNotSelected(DropDownList control)
        {
            string value = control.SelectedValue;
            if (string.IsNullOrEmpty(value) || value == "0" || value == "-1")
                return true;
            else
                return false;
        }

        public bool isValidInput(TextBox control, int noOfChars=1)
        {
            string value = control.Text.Trim();
            if (isEmpty(control))
                return false;
            else if (value.Length < noOfChars)
                return false;
            else
                return true;
        }

        public bool isNotNumber(TextBox control)
        {
            string value = control.Text.Trim();
            if (isEmpty(control))
                return true;
            else if (isNotNumber(value))
                return true;
            else
                return false;
        }

        public DateTime convertDatetime(string strdate)
        {
            return DateTime.ParseExact(strdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        
    }
}