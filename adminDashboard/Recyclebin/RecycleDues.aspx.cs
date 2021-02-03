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

public partial class Recyclebin_RecycleDues : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();
    Delete dt = new Delete();
    Dashboard dd = new Dashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                duesautoGenrate();

                if (Session["propertyvalue"] != null)
                {
                    if (Session["propertyvalue"].ToString() == "0")
                    {
                        showDues();
                        showDuesCount();
                    }
                    else
                    {
                        showDues();
                        showDuesCount();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    showDues();
                    showDuesCount();
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

    private void duesautoGenrate()
    {
        try
        {

            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();
            if (dy == "01")
            {
                if (checktenantsDues() == false)
                {

                    DataSet ds = ed.GetTenants();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string mobile = Session["s_MobileNo"].ToString();
                        string PropertyName = dr["t_PropertyName"].ToString();
                        string PropertyVale = dr["t_PropertyVale"].ToString();
                        string tname = dr["t_Name"].ToString();
                        string tmobile = dr["t_MobileNo"].ToString();
                        string troomNo = dr["t_RoomNo"].ToString();
                        string tDuesType = "Room Rent";
                        string tDuesAmount = dr["t_RentMoney"].ToString();
                        DateTime duedate = System.DateTime.Now;
                        string DueDate = duedate.ToString("dd/MM/yyyy");
                        string tDuesMonth = duedate.ToString("MMMM-yyyy");
                        string tRemark = "Rent of this month";
                        uc.AddTenantsDues(mobile, PropertyName, PropertyVale, tname, tmobile, troomNo, tDuesType, tDuesAmount, DueDate, tDuesMonth, tRemark);
                        string textmsg = "Tenants " + tmobile + " Room " + troomNo + " Dues added Successfully !";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    }
                }
                else
                {
                    string text = "This Dues Already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                }
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }


    private bool checktenantsDues()
    {
        bool result = false;
        String DateToday = DateTime.Now.ToString("MM/dd/yyyy"); ;
        SqlDataReader sdr3 = uc.getDuesDublicate(DateToday);
        if (sdr3.HasRows)
        {
            if (sdr3.Read())
            {
                result = true;
            }
        }
        return result;
    }


    private void showDuesCount()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();

                SqlDataReader sdr7 = dd.getCountTotalDues(PropertyVale);
                if (sdr7.HasRows)
                {
                    sdr7.Read();
                    lblTotalDues.Text = sdr7["DuesTotalCount"].ToString();
                }

                SqlDataReader sdr1 = dd.getCountTotalExpence(PropertyVale);
                if (sdr1.HasRows)
                {
                    sdr1.Read();
                    lblClearDues.Text = sdr1["DuesClearCount"].ToString();
                }
                SqlDataReader sdr = dd.getCountPendingDues(PropertyVale);
                if (sdr.HasRows)
                {
                    sdr.Read();
                    lblPendingDues.Text = sdr["DuesPendingCount"].ToString();
                }
            }
            else
            {
                Session["propertyvalue"] = "0";
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        ListView1.DataSource = uc.getDeletedDues(PropertyVale);
        ListView1.DataBind();
        showDuesCount();
        // This Method will be Called.
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }

    private void showDues()
    {
        try
        {

            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.getDeletedDues(PropertyVale);
                ListView1.DataBind();
            }
            else
            {
                Session["propertyvalue"] = "1";
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnAddNewDues_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddDues.aspx");
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Restore")
            {
                int d_id = Convert.ToInt32(e.CommandArgument);
                dt.DeleteRestoreDues(d_id);
                string textmsg = "" + d_id + " Record Restore Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                showDues();
            }
            else if (e.CommandName == "Dlt")
            {
                //int d_id = Convert.ToInt32(e.CommandArgument);
                //dt.DeleteDues(d_id);
                //string textmsg = "" + d_id + " Record Deleted Successfully !";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                showDues();
            }
            else if (e.CommandName == "ReceivedDue")
            {
                string d_id = e.CommandArgument.ToString();
                Response.Redirect("AddIncome.aspx?d_id=" + d_id + "");
            }
        }
        catch (Exception ex)
        {
            //string text = ex.Message.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            ListView1.DataSource = uc.getSerchDeletedDuesBytext(txtSearch.Text, PropertyVale);
            ListView1.DataBind();
            //showDuesCount();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void lbtSearchDues_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            ListView1.DataSource = uc.getSerchDeletedDuesBytext(txtSearch.Text, PropertyVale);
            ListView1.DataBind();
            // showDuesCount();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        SendOtp();
        PopupControlExtender.Show();
    }
    public void SendOtp()
    {

        string numbers = "9889360887";
        Random rand = new Random();
        string sentOtp = (rand.Next(100000, 999999)).ToString();
        string sentOtpText = "" + sentOtp + " is your OTP to delete due";
        string senders = "STAYLO";
        String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + numbers + "&text=" + sentOtpText + "&route=02";
        ViewState["OTP"] = sentOtp;
        try
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
            lblmessage.Text = "OTP Sent Successfully";
            lblmessage.ForeColor = System.Drawing.Color.Green;
            lblmessage.Visible = true;
            txtOtp.Visible = true;
            txtOtp.Text = string.Empty;
           
        }
        catch (Exception ex)
        {
            lblmessage.Text = ex.Message.ToString();
            lblmessage.ForeColor = System.Drawing.Color.Blue;
            txtOtp.Text = string.Empty;
            lblmessage.Visible = true;
        }

    }
    protected void btnVerifyDelete_Click(object sender, EventArgs e)
    {
        PopupControlExtender.Show();
        try
        {
            if (ViewState["OTP"] != null)
            {
                if (ViewState["OTP"].ToString() == txtOtp.Text)
                {

                    Label lbld_id = ListView1.Items[0].FindControl("lbld_id") as Label;
                    Label lbld_PayeeText = ListView1.Items[0].FindControl("lbld_PayeeText") as Label;
                    string PayeName = lbld_PayeeText.Text;
                    string d_id  = lbld_id.Text;
                    dt.DeleteDues(d_id);
                    string textmsg = "" + d_id + " "+ PayeName + " Due Record Deleted Successfully !";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                    showDues();
                    PopupControlExtender.Hide();
                }
            }
            else
            {
                lblmessage.Text = "OTP does not matches";
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch(Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }


}