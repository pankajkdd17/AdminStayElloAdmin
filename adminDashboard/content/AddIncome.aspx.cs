using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddIncome : System.Web.UI.Page
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
                Gf.FillDueType("mop_id", "mop_modeofpayment", "tbl_ModeOfPayment", ddlModeOfPayment, "");
                if (Session["propertyvalue"] != null)
                {
                    if (Session["propertyvalue"].ToString() == "0")
                    {

                        Session["propertyvalue"] = "1";
                    }
                    else
                    {
                    }
                }
                else
                {

                    Session["propertyvalue"] = "1";
                }
                if (Request.QueryString["d_id"] != null)
                {
                    string d_id = Request.QueryString["d_id"].ToString();
                    LoadDues(d_id);

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

    private void LoadDues(string d_id)
    {
        SqlDataReader sdr = ed.GetDues(d_id);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                //select d_id, d_PayeeText, d_PayeeValue, d_RoomNo, d_t_Mobile, d_DuesTypeText, d_DuesTypeValue, d_DuesAmount, convert(varchar, d_DuesDate, 23) as d_DuesDate , d_DuesMonth   ,  d_Remark ,convert(varchar, d_crdate, 23) as d_crdate ,d_mdfydate

                Session["d_PayeeText"] = sdr["d_PayeeText"].ToString();
                Session["d_PayeeValue"] = sdr["d_PayeeValue"].ToString();
                Session["d_RoomNo"] = sdr["d_RoomNo"].ToString();
                Session["d_t_Mobile"] = sdr["d_t_Mobile"].ToString();
                Session["d_DuesTypeText"] = sdr["d_DuesTypeText"].ToString();
                Session["d_DuesTypeValue"] = sdr["d_DuesTypeValue"].ToString();
                Session["d_DuesDate"] = sdr["d_DuesDate"].ToString();
                Session["d_DuesMonth"] = sdr["d_DuesMonth"].ToString();
                Session["d_reciveddate"] = sdr["d_reciveddate"].ToString();
                txtDuesAmount.Text = sdr["d_DuesAmount"].ToString();
                txtRecivedAmount.Text = sdr["d_DuesAmount"].ToString();
                Session["DueAmount"] = txtDuesAmount.Text;
                txtRemark.Text = sdr["d_Remark"].ToString();
                ddlModeOfPayment.SelectedItem.Text = sdr["d_ModeOfPayment"].ToString();
                txtRecivingDate.Text = sdr["d_reciveddate"].ToString(); 
            }
        }
        sdr.Close();
    }

    protected void btnReciveDue_Click(object sender, EventArgs e)
    {
        try
        {
            string d_id = Request.QueryString["d_id"].ToString();
            float DueAmount = float.Parse(txtDuesAmount.Text);
            float DueRecivingAmount = float.Parse(txtRecivedAmount.Text);
            if ((txtDuesAmount.Text.Length > 0) && (txtRecivedAmount.Text.Length > 0))
            {
                if (DueAmount == DueRecivingAmount)
                {
                    uc.UpdateDuesRecived(d_id, txtDuesAmount.Text, txtRecivingDate.Text, ddlModeOfPayment.SelectedItem.Text, txtRemark.Text);
                    SendMsgToPGManager();
                    SendMsgToTenantsForDue();
                    string textmsg = " Dues Recived Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    txtDuesAmount.Text = string.Empty;
                    txtRemark.Text = string.Empty;
                    txtRecivingDate.Text = string.Empty;
                    txtRecivedAmount.Text = string.Empty;
                }
                else if (DueAmount > DueRecivingAmount)
                {
                    float remaingDue = DueAmount - DueRecivingAmount;
                    addDueForRemainingDue(remaingDue);
                    uc.UpdateDuesRecived(d_id, txtRecivedAmount.Text, txtRecivingDate.Text, ddlModeOfPayment.SelectedItem.Text, txtRemark.Text);
                    SendMsgToPGManagerRecivedDue();
                    SendMsgToTenantsForDueRecivedDue();
                    txtDuesAmount.Text = string.Empty;
                    txtRemark.Text = string.Empty;
                    txtRecivingDate.Text = string.Empty;
                    txtRecivedAmount.Text = string.Empty;
                    string textmsg = " Dues Recived Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                }
                else if (DueAmount < DueRecivingAmount)
                {
                    string errormsg = "Recived Amount greater than due amount not accepted";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
                }
            }
            else
            {
                string errormsg = "Please Enter Recived Amount";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
            }
        }
        catch (Exception Ex)
        {
            string errormsg = Ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
        }
    }

    private void addDueForRemainingDue(float remaingDue)
    {
        try
        {
            if (txtRecivedAmount.Text.Length > 0)
            {
                DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                string PropertyName = ddlPropertyName.SelectedItem.Text;
                string PropertyVale = ddlPropertyName.SelectedValue;
                if (PropertyVale != "0")
                {
                    string t_Mobile = Session["d_t_Mobile"].ToString();
                    string mobile = Session["s_MobileNo"].ToString();
                    string RoomNo = Session["d_RoomNo"].ToString();
                    string DueType = Session["d_DuesTypeText"].ToString();
                    string DueValue = Session["d_DuesTypeValue"].ToString();
                    string PayeeName = Session["d_PayeeText"].ToString();
                    string PayeeVale = Session["d_PayeeValue"].ToString();
                    //DateTime TodayDate = System.DateTime.Now;
                    //string DueDate = TodayDate.ToString("dd/MM/yyyy");
                    //string dueMonth = TodayDate.ToString("MMMM-yyyy");
                    string pendingDueDate = Session["d_DuesDate"].ToString();
                    string pendingDueMonth = Session["d_DuesMonth"].ToString();
                    string remaingpendingDue = remaingDue.ToString();
                    //Session["remaingpendingDue"] = remaingDue;
                    uc.AddDues(mobile, PropertyName, PropertyVale, PayeeName, PayeeVale, RoomNo, t_Mobile, DueType, DueValue, remaingpendingDue, pendingDueDate, pendingDueMonth, txtRemark.Text);
                    SendMsgToTenantsForDuePendingAmount(remaingDue);
                    SendMsgToPGManagerForRemaingDue(remaingDue);
                    string textmsg = " Dues pending '" + remaingpendingDue + "' Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                }
                else
                {
                    string errormsg = "Please enter recived amount";
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

    private void SendMsgToPGManagerForRemaingDue(float remainDue)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            string t_Mobile = Session["d_t_Mobile"].ToString();
            string mobile = Session["s_MobileNo"].ToString();
            string RoomNo = Session["d_RoomNo"].ToString();
            string DueType = Session["d_DuesTypeText"].ToString();
            string DueValue = Session["d_DuesTypeValue"].ToString();
            string PayeeName = Session["d_PayeeText"].ToString();
            string PayeeVale = Session["d_PayeeValue"].ToString();
            string mobilePGManager = "9889360887";
            //string mobilePGManager = "7985648892";
            //DateTime TodayDate = System.DateTime.Now;
            //string DueDate = TodayDate.ToString("dd/MM/yyyy");
            //string dueMonth = TodayDate.ToString("MMMM-yyyy");
            string pendingDueDate = Session["d_DuesDate"].ToString();
            string pendingDueMonth = Session["d_DuesMonth"].ToString();
            //float RemaingDueAmount = (float)Session["remaingpendingDue"];
            string sendMsgToUser = "Dear Sir \n  " + PayeeName + " (" + t_Mobile + ") TENANT \n ROOM NO " + RoomNo + " Due Rs." + remainDue + " Due Type " + DueType + "  of month " + pendingDueMonth + " is still pending and Added as pending due";
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

    private void SendMsgToTenantsForDuePendingAmount(float remainDue)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            string t_Mobile = Session["d_t_Mobile"].ToString();
            // string t_Mobile = "8604365781";
            string mobile = Session["s_MobileNo"].ToString();
            string RoomNo = Session["d_RoomNo"].ToString();
            string DueType = Session["d_DuesTypeText"].ToString();
            string DueValue = Session["d_DuesTypeValue"].ToString();
            string PayeeName = Session["d_PayeeText"].ToString();
            string PayeeVale = Session["d_PayeeValue"].ToString();
            //DateTime TodayDate = System.DateTime.Now;
            //string DueDate = TodayDate.ToString("dd/MM/yyyy");
            //string dueMonth = TodayDate.ToString("MMMM-yyyy");
            string pendingDueDate = Session["d_DuesDate"].ToString();
            string pendingDueMonth = Session["d_DuesMonth"].ToString();
            //float RemaingDueAmount = (float)Session["remaingpendingDue"];
            //string RemaingDueAmount = Session["remaingpendingDue"].ToString();
            string sendMsgToUser = "Dear (" + PayeeName + ") \n " + DueType.ToUpper() + " of Rs." + remainDue + " has been added as dues for the month of " + pendingDueMonth + " \n Room no." + RoomNo + " \n Due date " + pendingDueDate + " \n PLEASE PAY DUE ON TIME ";
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
    private void SendMsgToPGManagerRecivedDue()
    {
        try
        {
            string d_PayeeText = Session["d_PayeeText"].ToString();
            string d_RoomNo = Session["d_RoomNo"].ToString();
            string d_t_Mobile = Session["d_t_Mobile"].ToString();
            string d_DuesTypeText = Session["d_DuesTypeText"].ToString();
            string d_DuesDate = Session["d_DuesDate"].ToString();
            string tDuesMonth = Session["d_DuesMonth"].ToString();
            string DueAmount = txtRecivedAmount.Text;
            Random rand = new Random();
            string mobilePGManager = "9889360887";
            // string mobilePGManager = "7985648892";
            string sendMsgToUser = "Dear Sir \n  " + d_PayeeText + " (" + d_t_Mobile + ") TENANT \n ROOM NO " + d_RoomNo + " Due Rs." + DueAmount + " Due Type " + d_DuesTypeText + "  of month " + tDuesMonth + " Mode of payment " + ddlModeOfPayment.SelectedItem.Text + " and date -" + d_DuesDate + "  \n Rceived";
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
    private void SendMsgToPGManager()
    {
        try
        {
            string d_PayeeText = Session["d_PayeeText"].ToString();
            string d_RoomNo = Session["d_RoomNo"].ToString();
            string d_t_Mobile = Session["d_t_Mobile"].ToString();
            string d_DuesTypeText = Session["d_DuesTypeText"].ToString();
            string d_DuesDate = Session["d_DuesDate"].ToString();
            string tDuesMonth = Session["d_DuesMonth"].ToString();
            string DueAmount = txtDuesAmount.Text;
            Random rand = new Random();
            string mobilePGManager = "9889360887";
            string sendMsgToUser = "D Sir \n  " + d_PayeeText + " (" + d_t_Mobile + ") TENANT \n ROOM NO " + d_RoomNo + " Due Rs." + DueAmount + " Due Type " + d_DuesTypeText + "  of month " + tDuesMonth + " Mode of payment " + ddlModeOfPayment.SelectedItem.Text + " and date -" + d_DuesDate + "  \n Rceived";
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
            string d_PayeeText = Session["d_PayeeText"].ToString();
            string d_RoomNo = Session["d_RoomNo"].ToString();
            string d_t_Mobile = Session["d_t_Mobile"].ToString();
            //string d_t_Mobile = "7985648892";
            string d_DuesTypeText = Session["d_DuesTypeText"].ToString();
            string d_RecivedDate = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            string tDuesMonth = Session["d_DuesMonth"].ToString();
            string DueAmount = txtDuesAmount.Text;
            Random rand = new Random();
            string sendMsgToUser = "Dear (" + d_PayeeText + ") \n " + d_DuesTypeText.ToUpper() + " of Rs." + DueAmount + " has been RECEIVED  for the month of " + tDuesMonth + " \n Room no." + d_RoomNo + " \n Mode of payment " + ddlModeOfPayment.SelectedItem.Text + " \n Received date " + d_RecivedDate + " \n THANKING YOU FOR PAYING DUES ";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + d_t_Mobile + "&text=" + sendMsgToUser + "&route=02";
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
    private void SendMsgToTenantsForDueRecivedDue()
    {
        try
        {
            string d_PayeeText = Session["d_PayeeText"].ToString();
            string d_RoomNo = Session["d_RoomNo"].ToString();
            string d_t_Mobile = Session["d_t_Mobile"].ToString();
            string d_DuesTypeText = Session["d_DuesTypeText"].ToString();
            string d_RecivedDate = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            string tDuesMonth = Session["d_DuesMonth"].ToString();
            string DueAmount = txtRecivedAmount.Text;
            Random rand = new Random();
            string sendMsgToUser = "Dear (" + d_PayeeText + ") \n " + d_DuesTypeText.ToUpper() + " of Rs." + DueAmount + " has been RECEIVED  for the month of " + tDuesMonth + " \n Room no." + d_RoomNo + " \n Mode of payment " + ddlModeOfPayment.SelectedItem.Text + " \n Received date " + d_RecivedDate + " \n THANKING YOU FOR PAYING DUES ";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + d_t_Mobile + "&text=" + sendMsgToUser + "&route=02";
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

    protected void btnViewDues_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/Dues.aspx");
    }



    protected void btnUpdateIncome_Click(object sender, EventArgs e)
    {

    }
}