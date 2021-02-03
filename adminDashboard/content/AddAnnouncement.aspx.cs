using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddAnnouncement : System.Web.UI.Page
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

                Gf.FillAnnouncementTo("t_id", "t_Name", "Tenants", ddlAnnouncementTo, "");
                btnAddAnnouncement.Visible = true;
                btnSaveChenges.Visible = false;


                if (Request.QueryString["a_id"] != null)
                {
                    string a_id = Request.QueryString["a_id"].ToString();
                    LoadAnnouncement(a_id);
                    btnAddAnnouncement.Visible = false;
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

    private void LoadAnnouncement(string a_id)
    {

        SqlDataReader sdr = ed.GetAnnouncement(a_id);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                ddlAnnouncementTo.SelectedItem.Text = sdr["a_Text"].ToString();
                txtAnnouncementToMobile.Text = sdr["a_mobile"].ToString();
                txtAnnouncement.Text = sdr["a_Details"].ToString();
                btnAddAnnouncement.Visible = false;
                btnSaveChenges.Visible = true;

            }
        }
        sdr.Close();
    }
    protected void btnAddAnnouncement_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtAnnouncement.Text.Length > 0)
            {
                if (ddlAnnouncementTo.SelectedIndex == 0)
                {
                    DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                    string PropertyName = ddlPropertyName.SelectedItem.Text;
                    string PropertyVale = ddlPropertyName.SelectedValue;
                    if (PropertyVale != "0")
                    {
                        ddlAnnouncementTo.SelectedItem.Text = "all";
                        ddlAnnouncementTo.SelectedItem.Value = "0";
                        string mobile = Session["s_MobileNo"].ToString();
                        uc.AddAnnouncement(mobile, PropertyName, PropertyVale, ddlAnnouncementTo.SelectedItem.Text, ddlAnnouncementTo.SelectedItem.Value, txtAnnouncementToMobile.Text, txtAnnouncement.Text);
                        string textmsg = " Announcement Added Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                        ddlAnnouncementTo.ClearSelection();
                        txtAnnouncementToMobile.Text = string.Empty;
                        txtAnnouncement.Text = string.Empty;
                        btnAddAnnouncement.Visible = true;
                        btnSaveChenges.Visible = false;
                    }
                    else
                    {
                        string errormsg = "Please Select property name";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
                    }
                }
                else
                {
                    DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                    string PropertyName = ddlPropertyName.SelectedItem.Text;
                    string PropertyVale = ddlPropertyName.SelectedValue;
                    if (PropertyVale != "0")
                    {
                        string mobile = Session["s_MobileNo"].ToString();
                        uc.AddAnnouncement(mobile, PropertyName, PropertyVale, ddlAnnouncementTo.SelectedItem.Text, ddlAnnouncementTo.SelectedItem.Value, txtAnnouncementToMobile.Text, txtAnnouncement.Text);
                        string textmsg = " Announcement Added Successfully";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                        ddlAnnouncementTo.ClearSelection();
                        txtAnnouncementToMobile.Text = string.Empty;
                        txtAnnouncement.Text = string.Empty;
                    }
                    else
                    {
                        string errormsg = "Please Select property name";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
                    }
                }
            }
            else
            {
                string exrmsg = "Please Enter Announcement Details";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + exrmsg + "')</script>", false);
            }
        }
        catch (Exception ex)
        {
            string exrmsg = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + exrmsg + "')</script>", false);
        }
    }
    protected void btnViewAnnouncement_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Announcement.aspx");
    }
    protected void ddlAnnouncementTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlAnnouncementTo.SelectedIndex != 0)
            {
                SqlDataReader sdr = uc.GetUserMobile(ddlAnnouncementTo.SelectedItem.Text, ddlAnnouncementTo.SelectedItem.Value);
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtAnnouncementToMobile.Text = sdr["t_MobileNo"].ToString();
                    }
                }
                sdr.Close();
            }
        }
        catch (Exception ex)
        {
            string exrmsg = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + exrmsg + "')</script>", false);
        }
    }
    protected void btnSaveChenges_Click(object sender, EventArgs e)
    {

        try
        {
            string a_id = Request.QueryString["a_id"].ToString();
            ed.UpdateAnnouncement(a_id, ddlAnnouncementTo.SelectedItem.Text, ddlAnnouncementTo.SelectedItem.Value, txtAnnouncementToMobile.Text, txtAnnouncement.Text);
            string textmsg = " Announcement Added Successfully";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
            ddlAnnouncementTo.SelectedIndex = 0;
            txtAnnouncement.Text = string.Empty;
            btnAddAnnouncement.Visible = false;
            btnSaveChenges.Visible = true;
        }
        catch (Exception ex)
        {
            string exrmsg = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + exrmsg + "')</script>", false);
        }

    }
}