using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CommonFuncs
/// </summary>
public class CommonFuncs
{
    public void ShowAlertMessage(string error)
    {
        Page page = HttpContext.Current.Handler as Page;

        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }
    //*******************  **********************************************
    // Description       : This method is used to bind drop down list 
    // Input Parameters  : Dropdownlist id, Dataset name, Textfield , value field , default value that 
    //                     should be shown in the drop down list
    //OutPut parameters  : None 
    //**************************************************************************
    public void BindDropDownLists(DropDownList ddl, DataTable ddt, string textfield, string valuefield, string strDefaultValue)
    {


        // if (ds.Tables.Count > 0)
        //{
        // if (ds.Tables[0].Rows.Count > 0)
        // {
        ddl.Items.Clear();
        ddl.DataSource = ddt;
        ddl.DataTextField = textfield;
        ddl.DataValueField = valuefield;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", ""));
        ////ddl.SelectedIndex = 0;
        // }
    }

    //*******************  **********************************************
    // Description       : This method is used to bind drop down list 
    // Input Parameters  : Dropdownlist id, Dataset name, Textfield , value field , default value that 
    //                     should be shown in the drop down list
    //OutPut parameters  : None 
    //**************************************************************************
    public void BindDropDownLists_WithAllOption(DropDownList ddl, DataTable ddt, string textfield, string valuefield, string strDefaultValue)
    {


        // if (ds.Tables.Count > 0)
        //{
        // if (ds.Tables[0].Rows.Count > 0)
        // {
        ddl.Items.Clear();
        ddl.DataSource = ddt;
        ddl.DataTextField = textfield;
        ddl.DataValueField = valuefield;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("ALL", "ALL"));
        ////ddl.SelectedIndex = 0;
        // }
    }
    public void BindCheckLists(CheckBoxList chk, DataTable ddt, string textfield, string valuefield, string strDefaultValue)
    {


        // if (ds.Tables.Count > 0)
        //{
        // if (ds.Tables[0].Rows.Count > 0)
        // {
        chk.Items.Clear();
        chk.DataSource = ddt;
        chk.DataTextField = textfield;
        chk.DataValueField = valuefield;
        chk.DataBind();
        // chk.Items.Insert(0, new ListItem("Select", "0"));
        ////ddl.SelectedIndex = 0;
        // }
    }
    public int GenerateRandomNo()
    {
        int _min = 1000;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }

    public string[] CalculateFinYearandMonth()
    {
        int Year = DateTime.Now.Year;
        int Month = DateTime.Now.Month;
        string[] FinYear = new string[3];
        /*FINANCIAL YEAR - FROM APRIL TO MARCH   
         SO IF MONTH IS APRIL , THEN FINYEAR = CURRENT YEAR - CURRENT YEAR + 1
         ELSE CURRENT YEAR -1 - CURRENT YEAR*/

        //if (Month >= 4)
        //{
        //    FinYear[0] = (Year - 1).ToString() + "-" + (Year).ToString().Substring(2);
        //    FinYear[1] = (Year).ToString() + "-" + (Year + 1).ToString().Substring(2);
        //}
        //else
        //{
        //    FinYear[0] = (Year - 1).ToString() + "-" + (Year).ToString().Substring(2);
        //    FinYear[1] = (Year).ToString() + "-" + (Year + 1).ToString().Substring(2);
        //}
       


        if (Month >= 4)
        {
            FinYear[0] = (Year - 2).ToString() + "-" + (Year-1 ).ToString().Substring(2);
            FinYear[1] = (Year - 1).ToString() + "-" + (Year ).ToString().Substring(2);
            FinYear[2] = (Year).ToString() + "-" + (Year+1).ToString().Substring(2);
        }
        else
        {
            FinYear[0] = (Year -2).ToString() + "-" + (Year-1).ToString().Substring(2);
            FinYear[1] = (Year -1).ToString() + "-" + (Year ).ToString().Substring(2);
            FinYear[2] = (Year ).ToString() + "-" + (Year +1).ToString().Substring(2);
        }
        return FinYear;
    }

    public void BindFinancialYears(DropDownList ddl)
    {
        string[] years = CalculateFinYearandMonth();
        ddl.Items.Clear();
        ddl.DataSource = years;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", ""));
    }

    public string getCurrentFinancialYear()
    {
        int Year = DateTime.Now.Year;
        int Month = DateTime.Now.Month;
        if (Month >= 4)
            return Year.ToString() + "-" + (Year+1).ToString().Substring(2);
        else
           return (Year-1).ToString() + "-" + Year.ToString().Substring(2);
    }
    public string getPrviousFinancialYear()
    {
        int Year = DateTime.Now.Year;
        int Month = DateTime.Now.Month;
        if (Month >= 4)
            return (Year - 1).ToString() + "-" + Year.ToString().Substring(2);          
        else
            return Year.ToString() + "-" + (Year + 1).ToString().Substring(2);
    }

    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    public DateTime Texttodateconverter(string textdate)
    {
        DateTime date = DateTime.Parse(textdate.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        return date;
    }

    public decimal IsNumeric(string value)
    {
       decimal result;
       if(decimal.TryParse(value,out result))
            return result;
        else
            return 0;
    }

    public int IsInteger(string value)
    {
        int result;
        if (int.TryParse(value, out result))
            return result;
        else
            return 0;
    }

}