using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddDues : System.Web.UI.Page
{
    EditData ed = new EditData();
    AddUsers uc = new AddUsers();
    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (Session["s_MobileNo"] != null)
            {
                Gf.FillDueType("d_id", "d_name", "tbl_DueType", ddlDuesType, "");
                if (Session["propertyvalue"] != null)
                {
                    
                    if (Session["propertyvalue"].ToString() == "0")
                    {
                        Session["propertyvalue"] = "1";
                        string PropertyVale = Session["propertyvalue"].ToString();
                        Gf.FillPayee("t_id", "t_name", "Tenants", ddlPayee, "", PropertyVale);
                    }
                    else
                    {
                        string PropertyVale = Session["propertyvalue"].ToString();
                        Gf.FillPayee("t_id", "t_name", "Tenants", ddlPayee, "", PropertyVale);
                    }
                }
                else
                {
                    Session["propertyvalue"] = "1";
                }
                btnDues.Visible = true;
                btnSaveChenges.Visible = false;
                if (Request.QueryString["d_id"] != null)
                {
                    string d_id = Request.QueryString["d_id"].ToString();
                    LoadDues(d_id);
                    btnDues.Visible = false;
                    btnSaveChenges.Visible = true;
                }
            }
            else
            {
               
                Response.Redirect("~/content/login.aspx");
            }
        }
        
    }

    private void LoadDues(string d_id)
    {

        SqlDataReader sdr = ed.GetDues(d_id);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                
                ddlPayee.SelectedItem.Text = sdr["d_PayeeText"].ToString();
                ddlPayee.SelectedItem.Value = sdr["d_PayeeValue"].ToString();
                txtRoomNoMobile.Text = sdr["d_RoomNo"].ToString();
                string mobile = sdr["d_t_Mobile"].ToString();
                ddlDuesType.SelectedItem.Text = sdr["d_DuesTypeText"].ToString();
                ddlDuesType.SelectedItem.Value = sdr["d_DuesTypeValue"].ToString();
                txtDuesAmount.Text = sdr["d_DuesAmount"].ToString();
                txtDuesDate.Text = sdr["d_DuesDate"].ToString();
                txtDuesMonth.Text = sdr["d_DuesMonth"].ToString();
                txtRemark.Text = sdr["d_Remark"].ToString();
                btnDues.Visible = false;
                btnSaveChenges.Visible = true;
                ddlPayee.Attributes.Add("disabled", "disabled");
            }
        }
        sdr.Close();
    }


    protected void btnDues_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlPayee.SelectedItem.Value != "0")
            {
                DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                string PropertyName = ddlPropertyName.SelectedItem.Text;
                string PropertyVale = ddlPropertyName.SelectedValue;
                if (PropertyVale != "0")
                {
                    string t_Mobile = Session["t_MobileNo"].ToString();
                    string mobile = Session["s_MobileNo"].ToString();
                    txtRoomNoMobile.Text = Session["t_RoomNo"].ToString();
                    DateTime DueMonth = Convert.ToDateTime(txtDuesMonth.Text);
                    string dueMonth = DueMonth.ToString("MMMM-yyyy");
                    uc.AddDues(mobile, PropertyName, PropertyVale, ddlPayee.SelectedItem.Text, ddlPayee.SelectedItem.Value, txtRoomNoMobile.Text, t_Mobile, ddlDuesType.SelectedItem.Text, ddlDuesType.SelectedItem.Value, txtDuesAmount.Text, txtDuesDate.Text, dueMonth, txtRemark.Text);
                    SendMsgToTenantsForDue();
                    SendMsgToPGManager();
                    string textmsg = " Dues Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    ddlPayee.SelectedIndex = 0;
                    txtRoomNoMobile.Text = string.Empty;
                    ddlDuesType.SelectedIndex = 0;
                    txtDuesAmount.Text = string.Empty;
                    txtDuesDate.Text = string.Empty;
                    txtDuesMonth.Text = string.Empty;
                    txtRemark.Text = string.Empty;
                    btnDues.Visible = true;
                    btnSaveChenges.Visible = false;
                }
                else
                {
                    string errormsg = "Please Select property name";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
                }

            }
        }
        catch (Exception Ex)
        {
            string errormsg = Ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
        }
    }
    private void SendMsgToPGManager()
    {
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            string t_Mobile = Session["t_MobileNo"].ToString();
            DateTime DueMonth = Convert.ToDateTime(txtDuesMonth.Text);
            string dueMonth = DueMonth.ToString("MMMM-yyyy");
            Random rand = new Random();
            string mobilePGManager = "9889360887";
            string sendMsgToUser = "DEAR Sir \n  " + ddlPayee.SelectedItem.Text + " TENANT \n ROOM NO " + txtRoomNoMobile.Text + " Due Rs."+ txtDuesAmount.Text + " Due Type " + ddlDuesType.SelectedItem.Text + "  of month "+ dueMonth + "  Added";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + mobilePGManager + "&text=" + sendMsgToUser + "&route=02";
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);

        }
    }
    private void SendMsgToTenantsForDue()
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            string t_Mobile = Session["t_MobileNo"].ToString();
            DateTime DueMonth = Convert.ToDateTime(txtDuesMonth.Text);
            string dueMonth = DueMonth.ToString("MMMM-yyyy");
            string Addeddate = DateTime.Now.ToString("dd/MM/yyyy");
            Random rand = new Random();
            string sendMsgToUser = "Dear (" + ddlPayee.SelectedItem.Text + ") \n " + ddlDuesType.SelectedItem.Text.ToUpper() + " of Rs." + txtDuesAmount.Text +" has been added as dues for the month of "+ dueMonth + " \n Room no." + txtRoomNoMobile.Text + " \n Due date " + Addeddate + " \n PLEASE PAY DUE ON TIME ";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + t_Mobile + "&text=" + sendMsgToUser + "&route=02";
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);

        }
    }

    protected void ddlPayee_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPayee.SelectedItem.Value != "0")
        {

            SqlDataReader sdr = uc.GetNameroomNo(ddlPayee.SelectedItem.Value);
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    string RoomNo = sdr["t_RoomNo"].ToString();
                    string Mobile = sdr["t_MobileNo"].ToString();
                    Session["t_MobileNo"] = sdr["t_MobileNo"].ToString();
                    txtRoomNoMobile.Text = RoomNo + " (" + Mobile + ")";
                    Session["t_RoomNo"] = sdr["t_RoomNo"].ToString();
                    ddlDuesType.SelectedItem.Text = "Room Rent";
                    ddlDuesType.SelectedItem.Value = "1";
                    txtDuesAmount.Text = sdr["t_RentMoney"].ToString();
                    DateTime DateNow = System.DateTime.Now;
                    txtDuesDate.Text = DateNow.ToString("yyyy-MM-dd");
                    txtDuesMonth.Text = DateNow.ToString("yyyy-MM");
                }
            }
            sdr.Close();
        }
    }
    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedValue;
        Gf.FillPayee("t_id", "t_name", "Tenants", ddlPayee, "", PropertyVale);
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }
    protected void btnViewDues_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Dues.aspx");
    }
    protected void btnSaveChenges_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlPayee.SelectedItem.Value != "0")
            {
                string d_id = Request.QueryString["d_id"].ToString();
                DateTime DueMonth = Convert.ToDateTime(txtDuesMonth.Text);
                string dueMonth = DueMonth.ToString("MMMM-yyyy");
                ed.UpdateDues(d_id, ddlPayee.SelectedItem.Text, ddlPayee.SelectedItem.Value, txtRoomNoMobile.Text, ddlDuesType.SelectedItem.Text, ddlDuesType.SelectedItem.Value, txtDuesAmount.Text, txtDuesDate.Text, dueMonth, txtRemark.Text);
                string textmsg = " Dues Added Successfully";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                ddlPayee.SelectedItem.Text = string.Empty;
                txtRoomNoMobile.Text = string.Empty;
                ddlDuesType.SelectedIndex = 0;
                txtDuesAmount.Text = string.Empty;
                txtDuesDate.Text = string.Empty;
                txtDuesMonth.Text = string.Empty;
                txtRemark.Text = string.Empty;
                btnDues.Visible = false;
                btnSaveChenges.Visible = true;
            }
            else
            {
                string errormsg = "Please Select property name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
            }


        }
        catch (Exception Ex)
        {
            string errormsg = Ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
        }

    }


    protected void ddlDuesType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlDuesType.SelectedItem.Value=="1")
        {
            SqlDataReader sdr = uc.GetNameroomNo(ddlPayee.SelectedItem.Value);
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    if(ddlDuesType.SelectedItem.Value == "1")
                    {
                        ddlDuesType.SelectedItem.Text = "Room Rent";
                        ddlDuesType.SelectedItem.Value = "1";
                        txtDuesAmount.Text = sdr["t_RentMoney"].ToString();
                    }
                   
                }
            }
            sdr.Close();
        }
        else
        {
            txtDuesAmount.Text = string.Empty;
        }
        
    }
}