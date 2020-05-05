using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_DL;
using System.Data;
using System.Web.Security;
using Seed_BE;

public partial class Admin_CropMaster : System.Web.UI.Page
{
    Masters objm = new Masters();
    CommonFuncs objCommon = new CommonFuncs();
    string UserName = "", conkey;
    SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
    Master_BE ObjBe = new Master_BE();
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        if (Session["UsrName"] == null || Session["UsrName"].ToString() != "Admin")
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            conkey = Session["ConnKey"].ToString();
        }
        if (!IsPostBack)
        {
            random();
            viewdata();
            btn_Update.Visible = false;
        }
    }
    protected void BindSchemes()
    {
        dt = new DataTable();
        ObjBe.Action = "Schemes";
        ObjBe.sectionid = Session["Section"].ToString();
        dt = objm.GetDetails(ObjBe, conkey);
    }

    private void viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            ObjBe.Action = "R";
            dt1 = objm.Crop_IUDR(ObjBe,conkey);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        viewdata();        
    }
    protected void GridView1_RowCancelling(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = -1;
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();
                UserName = Session["UsrName"].ToString();
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblCpcode = (Label)gvrow.FindControl("lblcropcode");
                Label lblCpnm = (Label)gvrow.FindControl("lblCpnm");
                ObjBe.CropId = lblcpcode.Text;
                ObjBe.Action = "D";
                dt = objm.Crop_IUDR(ObjBe, conkey);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        string aa = "Deleted Successfully";
                        objCommon.ShowAlertMessage(aa);
                        viewdata();
                    }
                    else
                    {
                        string aa = "Deleted Failure";
                        objCommon.ShowAlertMessage(aa);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        viewdata();        
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        viewdata();       
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
        ImageButton btnsubmit = sender as ImageButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        txtslno.Text = ((Label)(gRow.FindControl("lblslno"))).Text;
        lblcpcode.Text = ((Label)(gRow.FindControl("lblcropcode"))).Text;
        txtCropName.Text = ((Label)(gRow.FindControl("lblCpnm"))).Text;
        txttype.Text = ((Label)(gRow.FindControl("lbltype"))).Text;
        txtArea.Text = ((Label)(gRow.FindControl("lblarea"))).Text;        
        txtqty.Text = ((Label)(gRow.FindControl("lblqty"))).Text;
        btn_Update.Visible = true;
        btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            check();
            if (PageValidate())
            {
                ObjBe.CropName = txtCropName.Text.Trim();
                ObjBe.type = txttype.Text.Trim();
                ObjBe.no_of_acres = txtArea.Text.Trim();
                ObjBe.qty = txtqty.Text.Trim();
                ObjBe.slno = Convert.ToInt32(txtslno.Text.Trim());
                ObjBe.CropId = lblcpcode.Text;
                ObjBe.Action = "I";
                dt = objm.Crop_IUDR(ObjBe, conkey);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                        objCommon.ShowAlertMessage("Crop Not Saved");
                    else
                    {
                        objCommon.ShowAlertMessage("Crop Saved");
                        txtCropName.Text = "";
                        txttype.Text = "";
                        txtslno.Text = "";
                        txtqty.Text = "";
                    }
                }
                viewdata();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            ObjBe.CropName = txtCropName.Text.Trim();
            ObjBe.type = txttype.Text.Trim();
            ObjBe.no_of_acres = txtArea.Text.Trim();
            ObjBe.qty = txtqty.Text.Trim();
            ObjBe.slno = Convert.ToInt32(txtslno.Text.Trim());
            ObjBe.CropId = lblcpcode.Text;
            ObjBe.Action = "U";
            dt = objm.Crop_IUDR(ObjBe, conkey);
            if (dt.Rows.Count > 0)
                objCommon.ShowAlertMessage("Update Failed");
            else
            {
                string aa = "Updated Successfully";
                objCommon.ShowAlertMessage(aa);
                btn_Save.Visible = true;
                txtCropName.Text = "";
                txttype.Text = "";
                txtslno.Text = "";
                txtqty.Text = "";
                btn_Update.Visible = false;
            }
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected bool PageValidate()
    {
        if (txtCropName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Crop Name");
            txtCropName.Focus();
            return false;
        }
        if (txtCropName.Text != "")
        {
            bool val;
            val = obj.CheckInput_new(txtCropName.Text);
            if (val == true)
            {
                Response.Redirect("~/Error.aspx");
                return false;
            }
            else
                return true;
        }
        if (txttype.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Crop Name");
            txttype.Focus();
            return false;
        }
        if (txttype.Text != "")
        {
            bool val;
            val = obj.CheckInput_new(txttype.Text);
            if (val == true)
            {
                Response.Redirect("~/Error.aspx");
                return false;
            }
            else
                return true;
        }
        if (txtArea.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Area in Acres");
            txttype.Focus();
            return false;
        }
        if (txtArea.Text != "")
        {
            bool val;
            val = obj.CheckInput_new(txtArea.Text);
            if (val == true)
            {
                Response.Redirect("~/Error.aspx");
                return false;
            }
            else
                return true;
        }
        if (txtqty.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Quantity Kgs");
            txttype.Focus();
            return false;
        }
        if (txtqty.Text != "")
        {
            bool val;
            val = obj.CheckInput_new(txtqty.Text);
            if (val == true)
            {
                Response.Redirect("~/Error.aspx");
                return false;
            }
            else
                return true;
        }
        else
            return true;
    }
  
   


    public void random()
    {
        try
        {
            string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string num = "";
            Random rm = new Random();
            for (int i = 0; i < 16; i++)
            {
                int randomcharindex = rm.Next(0, strString.Length);
                char randomchar = strString[randomcharindex];
                num += Convert.ToString(randomchar);
            }

            Response.Cookies.Add(new HttpCookie("ASPFIXATION2", num));
            hf.Value = num;
            Session["ASPFIXATION2"] = num;
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    public void check()
    {
        try
        {
            string cookie_value = null;
            string session_value = null;
            //cookie_value = System.Web.HttpContext.Current.Request.Cookies["ASPFIXATION2"].Value;
            cookie_value = hf.Value;
            session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
            if (cookie_value != session_value)
            {
                System.Web.HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.Redirect("~/Error.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
}