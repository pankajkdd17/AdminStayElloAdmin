using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddTenants : System.Web.UI.Page
{
    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            if (Session["s_MobileNo"] != null)
            {
                if (Session["propertyvalue"] != null)
                {
                    Gf.FillLockinPeriod("tl_Id", "tl_LockinName", "tbl_TenantLockin", ddlLockinPeriod , "");
                    if (Session["propertyvalue"].ToString() != "0")
                    {

                        string PropertyVale = Session["propertyvalue"].ToString();
                        Gf.FillRooms("r_id", "r_roomNo", "Rooms", ddlRoomNo, "", PropertyVale);
                    }
                    else
                    {
                        Session["propertyvalue"] = "1";
                    }
                }
                else
                {
                    Session["propertyvalue"] = "1";
                    string PropertyVale = Session["propertyvalue"].ToString();
                    Gf.FillRooms("r_id", "r_roomNo", "Rooms", ddlRoomNo, "", PropertyVale);
                }



                btnTenants.Visible = true;
                btnSaveChenges.Visible = false;


                if (Request.QueryString["t_id"] != null)
                {
                    string t_id = Request.QueryString["t_id"].ToString();
                    Session["t_id"] = Request.QueryString["t_id"].ToString();
                    LoadTenants(t_id);
                    btnTenants.Visible = false;
                    btnSaveChenges.Visible = true;
                }
            }
            else
            {
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                Response.Redirect("~/content/login.aspx");
            }
        }

    }


    private void LoadTenants(string t_id)
    {
        try
        {
            SqlDataReader sdr = ed.GetTenants(t_id);
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    //t_LockinPeriodValue , t_LockinPeriodText ,
                    ddlLockinPeriod.SelectedItem.Text = sdr["t_LockinPeriodText"].ToString();
                    ddlLockinPeriod.SelectedItem.Value = sdr["t_LockinPeriodValue"].ToString();
                    txtName.Text = sdr["t_Name"].ToString();
                    txtMobileNo.Text = sdr["t_MobileNo"].ToString();
                    ddlRoomNo.SelectedItem.Text = sdr["t_RoomNo"].ToString();
                    txtRoomType.Text = sdr["t_BedsText"].ToString();
                    txtSecurityMoney.Text = sdr["t_SecurityMoney"].ToString();
                    txtRentMoney.Text = sdr["t_RentMoney"].ToString();
                    txtDateOfJoining.Text = sdr["t_DateOfJoining"].ToString();
                    txtRentDate.Text = sdr["t_RentDate"].ToString();
                    txtDetails.Text = sdr["t_Details"].ToString();
                    Session["t_BedsValue"] = sdr["t_BedsValue"].ToString();
                    btnTenants.Visible = false;
                    btnSaveChenges.Visible = true;
                }
            }
            sdr.Close();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void btnTenants_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRoomNo.SelectedIndex != 0)
            {
                if ((checkDublicateRoomNO() == false) && (checkRoomOccupency() == true))
                {
                    string mobile = Session["s_MobileNo"].ToString();
                    DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                    string PropertyName = ddlPropertyName.SelectedItem.Text;
                    string PropertyVale = ddlPropertyName.SelectedItem.Value;
                    string bedValue = Session["r_BedsValue"].ToString();
                    uc.AddTenants(mobile, PropertyName, PropertyVale, txtName.Text, txtMobileNo.Text, ddlRoomNo.SelectedItem.Text, txtRoomType.Text, bedValue, txtSecurityMoney.Text, txtRentMoney.Text, txtDateOfJoining.Text, txtRentDate.Text, ddlLockinPeriod.SelectedItem.Value , ddlLockinPeriod.SelectedItem.Text , txtDetails.Text);
                    string textmsg = "Tenants " + txtName.Text + " Room " + ddlRoomNo.SelectedItem.Text + " Aloted Successfully !";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    SendMsgToTenants();
                    SendMsgToPGManager();
                    AddDues();
                    AddSecurityAsDue();
                    txtName.Text = string.Empty;
                    txtMobileNo.Text = string.Empty;
                    txtSecurityMoney.Text = string.Empty;
                    txtRentMoney.Text = string.Empty;
                    txtDateOfJoining.Text = string.Empty;
                    txtRentDate.Text = string.Empty;
                    txtDetails.Text = string.Empty;
                }
            }
            else
            {
                string text = "Room Not selected Or not Found";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    private void AddSecurityAsDue()
    {
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedValue;
            if (PropertyVale != "0")
            {
                string mobile = Session["s_MobileNo"].ToString();
                DateTime DueMonth = System.DateTime.Now;
                string dueMonth = DueMonth.ToString("MMMM-yyyy");
                string DuesType = "Security Deposit";
                string DuesTypeValue = "3";
                String sDate = txtDateOfJoining.Text;
                DateTime Duedate = System.DateTime.Now;
                DateTime DueDateNow = Convert.ToDateTime(txtDateOfJoining.Text);
                string Duesdate = DueDateNow.ToString("dd/MM/yyyy");
                string Remark = "Security Deposit";
                SendMsgToTenantsForSecurity();
                SendMsgToPGManagerForSecurity();
                uc.AddDues(mobile, PropertyName, PropertyVale, txtName.Text, txtName.ID, ddlRoomNo.SelectedItem.Text, txtMobileNo.Text, DuesType, DuesTypeValue, txtSecurityMoney.Text , Duesdate, dueMonth, Remark);
                string textmsg = " Dues Added Successfully";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
            }
        }
        catch (Exception Ex)
        {
            string errormsg = Ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
        }
    }

    private void SendMsgToPGManagerForSecurity()
    {
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            DateTime DueMonth = System.DateTime.Now;
            string dueMonth = DueMonth.ToString("MMMM-yyyy");
            DateTime DueDateNow = Convert.ToDateTime(txtDateOfJoining.Text);
            string Addeddate = DueDateNow.ToString("dd/MM/yyyy");
            string mobilePGManager = "9889360887";
            string sendMsgToUser = "Dear sir \n  " + txtName.Text + " TENANT \n ROOM NO " + ddlRoomNo.SelectedItem.Text + " Security Deposit Rs." + txtSecurityMoney.Text + "  of month " + dueMonth + "  Added";
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

    private void SendMsgToTenantsForSecurity()
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            // string t_Mobile = Session["t_MobileNo"].ToString();
            DateTime DueMonth = System.DateTime.Now;
            string dueMonth = DueMonth.ToString("MMMM-yyyy");
            DateTime DueDateNow = Convert.ToDateTime(txtDateOfJoining.Text);
            string Addeddate = DueDateNow.ToString("dd/MM/yyyy");
            string rentAmount = Session["RentAmount"].ToString();
            Random rand = new Random();
            string sendMsgToUser = "Dear (" + txtName.Text + ") \n Security Deposit of Rs." + txtSecurityMoney.Text + " has been added as Security Deposit for the month of " + dueMonth + " \n Room no." + ddlRoomNo.SelectedItem.Text + " \n Security Deposit date " + Addeddate + " \n PLEASE PAY SECURITY DEPOSIT ON TIME ";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + txtMobileNo.Text + "&text=" + sendMsgToUser + "&route=02";
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

    private void AddDues()
    {
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedValue;
            if (PropertyVale != "0")
            {
                // string t_Mobile = Session["t_MobileNo"].ToString();
                string mobile = Session["s_MobileNo"].ToString();
                DateTime DueMonth = System.DateTime.Now;
                string dueMonth = DueMonth.ToString("MMMM-yyyy");
                string DuesType = "Room Rent";
                string DuesTypeValue = "1";
                String sDate = txtDateOfJoining.Text;
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
                String dy = datevalue.Day.ToString();
                String mn = datevalue.Month.ToString();
                String yy = datevalue.Year.ToString();
                string TotalDay  =  DateTime.DaysInMonth(Convert.ToInt32(yy), Convert.ToInt32(mn)).ToString();
                Int64 dayInMonth = Convert.ToInt64(TotalDay);

                if (dayInMonth == 31)
                {
                    float Totaldays = (dayInMonth - float.Parse(dy))+1;
                    float oneDayAmount = (float.Parse(txtRentMoney.Text) / 30);
                    float rentAmountNow = oneDayAmount * (Totaldays);
                    string rentAmount = rentAmountNow.ToString();
                    Session["RentAmount"] = rentAmount;
                    DateTime DueDateNow = Convert.ToDateTime(txtDateOfJoining.Text);
                    string Duesdate = DueDateNow.ToString("dd/MM/yyyy");
                    string Remark = "Room rent";
                    SendMsgToTenantsForDue();
                    SendMsgToPGManagerForDue();
                    uc.AddDues(mobile, PropertyName, PropertyVale, txtName.Text, txtName.ID, ddlRoomNo.SelectedItem.Text, txtMobileNo.Text, DuesType, DuesTypeValue, rentAmount, Duesdate, dueMonth, Remark);
                    string textmsg = " Dues Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                }
                else if (dayInMonth == 29)
                {
                    float Totaldays = (dayInMonth - float.Parse(dy)) + 3;
                    float oneDayAmount = (float.Parse(txtRentMoney.Text) / 30);
                    float rentAmountNow = oneDayAmount * (Totaldays);
                    string rentAmount = rentAmountNow.ToString();
                    Session["RentAmount"] = rentAmount;
                    DateTime DueDateNow = Convert.ToDateTime(txtDateOfJoining.Text);
                    string Duesdate = DueDateNow.ToString("dd/MM/yyyy");
                    string Remark = "Room rent";
                    SendMsgToTenantsForDue();
                    SendMsgToPGManagerForDue();
                    uc.AddDues(mobile, PropertyName, PropertyVale, txtName.Text, txtName.ID, ddlRoomNo.SelectedItem.Text, txtMobileNo.Text, DuesType, DuesTypeValue, rentAmount, Duesdate, dueMonth, Remark);
                    string textmsg = " Dues Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                }
                else if (dayInMonth == 28)
                {
                    float Totaldays = (dayInMonth - float.Parse(dy)) + 4;
                    float oneDayAmount = (float.Parse(txtRentMoney.Text) / 30);
                    float rentAmountNow = oneDayAmount * (Totaldays);
                    string rentAmount = rentAmountNow.ToString();
                    Session["RentAmount"] = rentAmount;
                    DateTime DueDateNow = Convert.ToDateTime(txtDateOfJoining.Text);
                    string Duesdate = DueDateNow.ToString("dd/MM/yyyy");
                    string Remark = "Room rent";
                    SendMsgToTenantsForDue();
                    SendMsgToPGManagerForDue();
                    uc.AddDues(mobile, PropertyName, PropertyVale, txtName.Text, txtName.ID, ddlRoomNo.SelectedItem.Text, txtMobileNo.Text, DuesType, DuesTypeValue, rentAmount, Duesdate, dueMonth, Remark);
                    string textmsg = " Dues Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                }
                else if (dayInMonth == 30)
                {
                    float Totaldays = (dayInMonth - float.Parse(dy)) + 2;
                    float oneDayAmount = (float.Parse(txtRentMoney.Text) / 30);
                    float rentAmountNow = oneDayAmount * (Totaldays);
                    string rentAmount = rentAmountNow.ToString();
                    Session["RentAmount"] = rentAmount;
                    DateTime DueDateNow = Convert.ToDateTime(txtDateOfJoining.Text);
                    string Duesdate = DueDateNow.ToString("dd/MM/yyyy");
                    string Remark = "Room rent";
                    SendMsgToTenantsForDue();
                    SendMsgToPGManagerForDue();
                    uc.AddDues(mobile, PropertyName, PropertyVale, txtName.Text, txtName.ID, ddlRoomNo.SelectedItem.Text, txtMobileNo.Text, DuesType, DuesTypeValue, rentAmount, Duesdate, dueMonth, Remark);
                    string textmsg = " Dues Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                }
            }

        }
        catch (Exception Ex)
        {
            string errormsg = Ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
        }
    }

    private void SendMsgToPGManagerForDue()
    {
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            // string t_Mobile = Session["t_MobileNo"].ToString();
            DateTime DueMonth = System.DateTime.Now;
            string dueMonth = DueMonth.ToString("MMMM-yyyy");
            DateTime DueDateNow = Convert.ToDateTime(txtDateOfJoining.Text);
            string Addeddate = DueDateNow.ToString("dd/MM/yyyy");
            string rentAmount = Session["RentAmount"].ToString();
            //Random rand = new Random();
            string mobilePGManager = "9889360887";
            string sendMsgToUser = "Dear sir \n  " + txtName.Text + " TENANT \n ROOM NO " + ddlRoomNo.SelectedItem.Text + " Due Rs." + rentAmount + " Due Type Room rent  of month " + dueMonth + "  Added";
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
            // string t_Mobile = Session["t_MobileNo"].ToString();
            DateTime DueMonth = System.DateTime.Now;
            string dueMonth = DueMonth.ToString("MMMM-yyyy");
            DateTime DueDateNow = Convert.ToDateTime(txtDateOfJoining.Text);
            string Addeddate = DueDateNow.ToString("dd/MM/yyyy");
            string rentAmount = Session["RentAmount"].ToString();
            Random rand = new Random();
            string sendMsgToUser = "Dear (" + txtName.Text + ") \n Room rent of Rs." + rentAmount + " has been added as dues for the month of " + dueMonth + " \n Room no." + ddlRoomNo.SelectedItem.Text + " \n Due date " + Addeddate + " \n PLEASE PAY DUES ON TIME ";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + txtMobileNo.Text + "&text=" + sendMsgToUser + "&route=02";
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
    private void SendMsgToTenants()
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            Random rand = new Random();
            string sendMsgToUser = "Dear " + txtName.Text.ToUpper() + "\nWELCOME AT STAYELLO\nYou are added as TENANT at " + PropertyName + " in ROOM NO " + ddlRoomNo.SelectedItem.Text + " Room Type " + txtRoomType.Text + " \n Please Signup / Login   with your registered mobile no." + txtMobileNo.Text + " mobile no at https://www.stayello.com  to view your details";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + txtMobileNo.Text + "&text=" + sendMsgToUser + "&route=02";
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
    private void SendMsgToPGManager()
    {
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            Random rand = new Random();
            string mobilePGManager = "9889360887";
            string sendMsgToUser = "DEAR Sir \n  " + txtName.Text + " TENANT added at " + PropertyName + " in ROOM NO " + ddlRoomNo.SelectedItem.Text + " Room Type " + txtRoomType.Text + " , \n Room rent Rs." + txtRentMoney.Text + " and security Rs." + txtSecurityMoney.Text + " ";
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
    private bool checkDublicateRoomNO()
    {
        bool result = false;

        SqlDataReader sdr = uc.CheckDublicateTenent(txtMobileNo.Text);
        if (sdr.HasRows)
        {
            sdr.Read();
            string roomNo = sdr["t_RoomNo"].ToString();
            string t_name = sdr["t_name"].ToString();
            string t_MobileNo = sdr["t_MobileNo"].ToString();
            result = true;
            string text = "This Tenants  " + t_name + "  and  " + t_MobileNo + " Already Aloted Room No " + roomNo + " ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
        sdr.Close();
        return result;
    }

    private bool checkRoomOccupency()
    {
        bool result = false;
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedValue;
        SqlDataReader sdr2 = uc.CheckOccupency1(PropertyVale, ddlRoomNo.SelectedItem.Text);

        if (sdr2.HasRows)
        {
            sdr2.Read();
            Session["r_BedsValue"] = Convert.ToInt32(sdr2["r_BedsValue"]);
        }
        sdr2.Close();
        SqlDataReader sdr = uc.CheckOccupency(PropertyVale, ddlRoomNo.SelectedItem.Text);

        if (sdr.HasRows)
        {
            sdr.Read();

            Int32 tenantsCount = Convert.ToInt32(sdr["countTen"]);
            int r_BedsValue = Convert.ToInt32(Session["r_BedsValue"]);
            Session["r_BedsValue"] = r_BedsValue.ToString();
            if (r_BedsValue > tenantsCount)
            {
                result = true;
            }

            else
            {
                result = false;
                string text = "This  " + ddlRoomNo.SelectedItem.Text + "  olny   " + r_BedsValue + " capacity  so sorry this room already full ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
            }
            sdr.Close();
        }
        else
        {
            result = true;
        }
        return result;
    }


    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        Gf.FillRooms("r_id", "r_roomNo", "Rooms", ddlRoomNo, "", PropertyVale);
        // This Method will be Called.
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Tenants.aspx");
    }
    protected void txtMobileNo_TextChanged(object sender, EventArgs e)
    {
        SqlDataReader sdr = ed.CheckTenantsExist(txtMobileNo.Text);

        if (sdr.HasRows)
        {
            sdr.Read();
            string roomNo = sdr["t_RoomNo"].ToString();
            string t_name = sdr["t_name"].ToString();
            string t_MobileNo = sdr["t_MobileNo"].ToString();
            string text = "This Tenants  " + t_name + "  and  " + t_MobileNo + " Already Aloted Room No " + roomNo + " ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
        sdr.Close();
    }
    protected void ddlRoomNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRoomNo.SelectedItem.Value != "0")
            {
                DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                string PropertyName = ddlPropertyName.SelectedItem.Text;
                string PropertyVale = ddlPropertyName.SelectedValue;
                SqlDataReader sdr = uc.GetBedType(PropertyVale, ddlRoomNo.SelectedItem.Text);
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtRoomType.Text = sdr["r_BedsText"].ToString();
                        Session["bedValue"] = sdr["r_BedsValue"].ToString();
                    }
                }
                sdr.Close();
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void btnSaveChenges_Click(object sender, EventArgs e)
    {
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedValue;
            SqlDataReader sdr = uc.GetBedType(PropertyVale, ddlRoomNo.SelectedItem.Text);
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    txtRoomType.Text = sdr["r_BedsText"].ToString();
                    Session["bedValue"] = sdr["r_BedsValue"].ToString();
                }
            }
            sdr.Close();

            string t_id = Session["t_id"].ToString();

            string bedvalue = Session["bedValue"].ToString();
            if (bedvalue != null)
            {
                string bedValue = Session["bedValue"].ToString();
                ed.UpdateTenants(t_id, txtName.Text, txtMobileNo.Text, ddlRoomNo.SelectedItem.Text, txtRoomType.Text, bedValue, txtSecurityMoney.Text, txtRentMoney.Text, txtDateOfJoining.Text, txtRentDate.Text, ddlLockinPeriod.SelectedItem.Value , ddlLockinPeriod.SelectedItem.Text , txtDetails.Text);
                string textmsg = "Tenants " + txtName.Text + " Room " + ddlRoomNo.SelectedItem.Text + " Updated Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                txtName.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                txtSecurityMoney.Text = string.Empty;
                txtRentMoney.Text = string.Empty;
                txtDateOfJoining.Text = string.Empty;
                txtRentDate.Text = string.Empty;
                txtDetails.Text = string.Empty;
            }
            else
            {
                string text = "Room No Not selected";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);

                //string bedValue = Session["t_BedsValue"].ToString();
                //ed.UpdateTenants(t_id, txtName.Text, txtMobileNo.Text, ddlRoomNo.SelectedItem.Text, txtRoomType.Text, bedValue, txtSecurityMoney.Text, txtRentMoney.Text, txtDateOfJoining.Text, txtRentDate.Text, txtDetails.Text);
                //string textmsg = "Tenants " + txtName.Text + " Room " + ddlRoomNo.SelectedItem.Text + " Updated Successfully !";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                //txtName.Text = string.Empty;
                //txtMobileNo.Text = string.Empty;
                //txtSecurityMoney.Text = string.Empty;
                //txtRentMoney.Text = string.Empty;
                //txtDateOfJoining.Text = string.Empty;
                //txtRentDate.Text = string.Empty;
                //txtDetails.Text = string.Empty;
            }


        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}