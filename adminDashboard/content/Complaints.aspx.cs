using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Complaints : System.Web.UI.Page
{
    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
    AddUsers uc = new AddUsers();
    MasterData md = new MasterData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                if (Session["propertyvalue"] != null)
                {
                    if (Session["propertyvalue"].ToString() == "0")
                    {
                        // Session.Remove("propertyvalue");
                        ShowNewcomplaints();
                        ShowOngoingcomplaints();
                        ShowResolvedcomplaints();
                    }
                    else
                    {
                        ShowNewcomplaints();
                        ShowOngoingcomplaints();
                        ShowResolvedcomplaints();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    ShowNewcomplaints();
                    ShowOngoingcomplaints();
                    ShowResolvedcomplaints();
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

    private void ShowResolvedcomplaints()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string tc_PropertyVal = Session["propertyvalue"].ToString();
                ListView3.DataSource = uc.GetResolvedComplaints(tc_PropertyVal);
                ListView3.DataBind();
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
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            ShowNewcomplaints();
            ShowOngoingcomplaints();
            ShowResolvedcomplaints();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }

    private void ShowOngoingcomplaints()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string tc_PropertyVal = Session["propertyvalue"].ToString();
                ListView2.DataSource = uc.GetOngoingComplaints(tc_PropertyVal);
                ListView2.DataBind();
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

    private void ShowNewcomplaints()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string tc_PropertyVal = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.GetNewComplaints(tc_PropertyVal);
                ListView1.DataBind();
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
    protected void btnAddNewComplaints_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/ComplaintsMaster.aspx");
    }

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

        try
        {
            DropDownList ddlcomplaints = (e.Item.FindControl("ddlcomplaints") as DropDownList);
            ddlcomplaints.DataSource = md.GetCompLaints(); ;
            ddlcomplaints.DataTextField = "cp_name";
            ddlcomplaints.DataValueField = "cp_id";
            ddlcomplaints.DataBind();
            ddlcomplaints.Items.Insert(0, new ListItem { Text = "--Select--", Value = "0" });
            Label lbltc_id = (e.Item.FindControl("lbltc_id") as Label);
            SqlDataReader sdr = uc.getStatus(lbltc_id.Text);
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    DropDownList ddlcomplaint = (e.Item.FindControl("ddlcomplaints") as DropDownList);
                    ddlcomplaint.SelectedItem.Text = sdr["tc_status"].ToString();
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
    protected void ListView2_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            DropDownList ddlcomplaints = (e.Item.FindControl("ddlcomplaints") as DropDownList);
            ddlcomplaints.DataSource = md.GetCompLaints();
            ddlcomplaints.DataTextField = "cp_name";
            ddlcomplaints.DataValueField = "cp_id";
            ddlcomplaints.DataBind();
            ddlcomplaints.Items.Insert(0, new ListItem { Text = "--Select--", Value = "0" });

            Label lbltc_id = (e.Item.FindControl("lbltc_id") as Label);
            SqlDataReader sdr = uc.getStatus(lbltc_id.Text);
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    DropDownList ddlcomplaint = (e.Item.FindControl("ddlcomplaints") as DropDownList);
                    ddlcomplaint.SelectedItem.Text = sdr["tc_status"].ToString();
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

    protected void ddlcomplaints_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlListFind = (DropDownList)sender;
            ListViewItem item1 = (ListViewItem)ddlListFind.NamingContainer;
            DropDownList ddlcomplaints = (DropDownList)item1.FindControl("ddlcomplaints");
            if (ddlcomplaints.SelectedItem.Text != "Resolved")
            {
                Label tc_id = (Label)item1.FindControl("lbltc_id");
                string tc_PropertyVal = Session["propertyvalue"].ToString();
                SqlDataReader sdr1 = uc.GetOngoingComplaintsMsg(tc_PropertyVal);
                if (sdr1.HasRows)
                {
                    if (sdr1.Read())
                    {
                        Session["tc_Name"] = sdr1["tc_Name"].ToString();
                        Session["tc_RoomNo"] = sdr1["tc_RoomNo"].ToString();
                        Session["tc_Mobile"] = sdr1["tc_Mobile"].ToString();
                        Session["tc_MainIssueText"] = sdr1["tc_MainIssueText"].ToString();
                        Session["tc_issueText"] = sdr1["tc_issueText"].ToString();
                        Session["tc_subCatIssueText"] = sdr1["tc_subCatIssueText"].ToString();
                        Session["tc_message"] = sdr1["tc_message"].ToString();
                        Session["tc_status"] = ddlcomplaints.SelectedItem.Text;
                    }
                    sdr1.Close();
                }
                uc.UpdateStatusComplaints(tc_id.Text, ddlcomplaints.SelectedItem.Text);
                SendMsgToTenantsComplaints();
                SendMsgToManagerComplaints();
            }
            else
            {
                Label tc_id = (Label)item1.FindControl("lbltc_id");
                string tc_PropertyVal = Session["propertyvalue"].ToString();
                SqlDataReader sdr1 = uc.GetResolvedComplaintsMsg(tc_PropertyVal);
                if (sdr1.HasRows)
                {
                    if (sdr1.Read())
                    {
                        Session["tc_Name"] = sdr1["tc_Name"].ToString();
                        Session["tc_RoomNo"] = sdr1["tc_RoomNo"].ToString();
                        Session["tc_Mobile"] = sdr1["tc_Mobile"].ToString();
                        Session["tc_MainIssueText"] = sdr1["tc_MainIssueText"].ToString();
                        Session["tc_issueText"] = sdr1["tc_issueText"].ToString();
                        Session["tc_subCatIssueText"] = sdr1["tc_subCatIssueText"].ToString();
                        Session["tc_message"] = sdr1["tc_message"].ToString();
                        Session["tc_status"] = ddlcomplaints.SelectedItem.Text;
                    }
                    sdr1.Close();
                }
                uc.UpdateStatusComplaints(tc_id.Text, ddlcomplaints.SelectedItem.Text);
                SendMsgToTenantsresolveComplaints();
                SendMsgToManagerComplaints();
            }
            ShowNewcomplaints();
            ShowOngoingcomplaints();
            ShowResolvedcomplaints();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void ddlcomplaints_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlListFind = (DropDownList)sender;
            ListViewItem item1 = (ListViewItem)ddlListFind.NamingContainer;
            DropDownList ddlcomplaints = (DropDownList)item1.FindControl("ddlcomplaints");
            Label tc_id = (Label)item1.FindControl("lbltc_id");
            string tc_PropertyVal = Session["propertyvalue"].ToString();
            SqlDataReader sdr1 = uc.GetNewComplaintsMsg(tc_PropertyVal);
            if (sdr1.HasRows)
            {
                if (sdr1.Read())
                {
                    Session["tc_Name"] = sdr1["tc_Name"].ToString();
                    Session["tc_RoomNo"] = sdr1["tc_RoomNo"].ToString();
                    Session["tc_Mobile"] = sdr1["tc_Mobile"].ToString();
                    Session["tc_MainIssueText"] = sdr1["tc_MainIssueText"].ToString();
                    Session["tc_issueText"] = sdr1["tc_issueText"].ToString();
                    Session["tc_subCatIssueText"] = sdr1["tc_subCatIssueText"].ToString();
                    Session["tc_message"] = sdr1["tc_message"].ToString();
                    //Session["tc_status"] = sdr1["tc_status"].ToString();
                    Session["tc_status"] = ddlcomplaints.SelectedItem.Text;
                    
                }
                sdr1.Close();
            }
            uc.UpdateStatusComplaints(tc_id.Text, ddlcomplaints.SelectedItem.Text);
            SendMsgToTenantsComplaints();
            SendMsgToManagerComplaints();
            ShowNewcomplaints();
            ShowOngoingcomplaints();
            ShowResolvedcomplaints();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    private void SendMsgToManagerComplaints()
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            string tc_Name = Session["tc_Name"].ToString();
            string tc_RoomNo = Session["tc_RoomNo"].ToString();
            string tc_Mobile = Session["tc_Mobile"].ToString();
            string pgmMobile = "9889360887";
            string tc_MainIssueText = Session["tc_MainIssueText"].ToString();
            string tc_issueText = Session["tc_issueText"].ToString();
            string tc_subCatIssueText = Session["tc_subCatIssueText"].ToString();
            string tc_message = Session["tc_message"].ToString();
            string tc_status = Session["tc_status"].ToString();
            string sendMsgToUser = "Dear Sir \n A complaint has been "+ tc_status + " in "+ PropertyVale + " , Room no "+ tc_RoomNo + " ,  Tenant name: " + tc_Name + "  , Mobile No :"+ tc_Mobile + "  \n Please have a look!";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + pgmMobile + "&text=" + sendMsgToUser + "&route=02";
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

    private void SendMsgToTenantsComplaints()
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            string tc_Name = Session["tc_Name"].ToString();
            string tc_RoomNo = Session["tc_RoomNo"].ToString();
            string tc_Mobile = Session["tc_Mobile"].ToString();
            string tc_MainIssueText = Session["tc_MainIssueText"].ToString();
            string tc_issueText = Session["tc_issueText"].ToString();
            string tc_subCatIssueText = Session["tc_subCatIssueText"].ToString();
            string tc_message = Session["tc_message"].ToString();
            string tc_status = Session["tc_status"].ToString();
            string sendMsgToUser = "Dear " + tc_Name.ToUpper() + " \n Your complaint has been "+ tc_status + " \n Room No: "+ tc_RoomNo + "\n  Complaint details :\n -> " + tc_MainIssueText + " \n -> " + tc_issueText + " \n  -> " + tc_subCatIssueText + " ";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + tc_Mobile + "&text=" + sendMsgToUser + "&route=02";
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

    private void SendMsgToTenantsresolveComplaints()
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            string tc_Name = Session["tc_Name"].ToString();
            string tc_RoomNo = Session["tc_RoomNo"].ToString();
            string tc_Mobile = Session["tc_Mobile"].ToString();
            string tc_MainIssueText = Session["tc_MainIssueText"].ToString();
            string tc_issueText = Session["tc_issueText"].ToString();
            string tc_subCatIssueText = Session["tc_subCatIssueText"].ToString();
            string tc_message = Session["tc_message"].ToString();
            string tc_status = Session["tc_status"].ToString();
            string sendMsgToUser = "Dear " + tc_Name.ToUpper() + " \n Your complaint has been " + tc_status + " \n Room No: " + tc_RoomNo + "\n  Complaint details :\n -> " + tc_MainIssueText + " \n -> " + tc_issueText + " \n  -> " + tc_subCatIssueText + " \n  You can re-raise a complaint if not satisfied!";
            string senders = "STAYLO";
            String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + tc_Mobile + "&text=" + sendMsgToUser + "&route=02";
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
    protected void lbtSearchComplaints_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string tc_PropertyVal = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.GetNewComplaintsbySearch(tc_PropertyVal, txtSearch.Text);
                ListView1.DataBind();
                ListView2.DataSource = uc.GetOngoingComplaintsbySearch(tc_PropertyVal, txtSearch.Text);
                ListView2.DataBind();
                ListView3.DataSource = uc.GetResolvedComplaintsbySearch(tc_PropertyVal, txtSearch.Text);
                ListView3.DataBind();
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
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string tc_PropertyVal = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.GetNewComplaintsbySearch(tc_PropertyVal, txtSearch.Text);
                ListView1.DataBind();
                ListView2.DataSource = uc.GetOngoingComplaintsbySearch(tc_PropertyVal, txtSearch.Text);
                ListView2.DataBind();
                ListView3.DataSource = uc.GetResolvedComplaintsbySearch(tc_PropertyVal, txtSearch.Text);
                ListView3.DataBind();
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
}