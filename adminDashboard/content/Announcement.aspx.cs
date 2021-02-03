using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Announcement : System.Web.UI.Page
{
    EditData ed = new EditData();
    Delete dt = new Delete();
    AddUsers uc = new AddUsers();
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
                        dashCaount();
                        showAnnouncment();
                    }
                    else
                    {
                        string propertyval = Session["propertyvalue"].ToString();
                        dashCaount();
                        showAnnouncment();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    dashCaount();
                    showAnnouncment();
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

    private void dashCaount()
    {
        try
        {
            SqlDataReader sdr = ed.TotalAnnouncement();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    lblTotalAnnouncement.Text = sdr["TotalAnnouncement"].ToString();
                }
            }
            sdr.Close();

            SqlDataReader sdr1 = ed.TotalAnnouncementToUser();
            if (sdr1.HasRows)
            {
                if (sdr1.Read())
                {
                    lblUserAnnouncement.Text = sdr1["TotalUserAnnouncement"].ToString();
                }
            }
            sdr1.Close();

            SqlDataReader sdr2 = ed.TotalAnnouncementToAll();
            if (sdr2.HasRows)
            {
                if (sdr2.Read())
                {
                    lblAlluserAnnouncement.Text = sdr2["TotalUserAnnouncement"].ToString();
                }
            }
            sdr2.Close();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    private void showAnnouncment()
    {
        try
        {
            string propertyval = Session["propertyvalue"].ToString();
            GridView1.DataSource = uc.getAnouncement(propertyval);
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void btnAddNewAnnouncement_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddAnnouncement.aspx");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string a_id = e.CommandArgument.ToString();
                Response.Redirect("AddAnnouncement.aspx?a_id=" + a_id + "");
            }
            else if (e.CommandName == "Dlt")
            {
                int a_id = Convert.ToInt32(e.CommandArgument);
                dt.DeleteAnnouncment(a_id);
                string textmsg = "" + a_id + " Record Deleted Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                showAnnouncment();
            }
        }
        catch (Exception ex)
        {
            //string text = ex.Message.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        GridView1.DataSource = uc.getAnouncementByProperty(PropertyVale);
        GridView1.DataBind();
        // This Method will be Called.
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }

    protected void lbtSearchAnouncement_Click(object sender, EventArgs e)
    {
        
        try
        {
            string PropertyVale = Session["propertyvalue"].ToString();
            GridView1.DataSource = uc.getAnouncementBySearch(PropertyVale , txtSearch.Text);
            GridView1.DataBind();
        }
        catch(Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }

    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string PropertyVale = Session["propertyvalue"].ToString();
            GridView1.DataSource = uc.getAnouncementBySearch(PropertyVale, txtSearch.Text);
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}