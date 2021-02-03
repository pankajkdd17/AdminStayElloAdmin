using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.MasterPage
{
    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();

    MasterData md = new MasterData();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                lblmobile.Text = Session["s_MobileNo"].ToString();
                lblName.Text = Session["s_Name"].ToString();
                lbldoj.Text = Session["s_DateOfJoining"].ToString();
                lblMobileprofile.Text = Session["s_MobileNo"].ToString();
                lblnameprofile.Text = Session["s_Name"].ToString();

                //if (Session["s_photoPath"].ToString().Length > 1)
                //{
                //    Image1.ImageUrl = Session["s_photoPath"].ToString();
                //}
                //else
                //{
                //    Image1.ImageUrl = "~/assets/img/myacclogo.jpg";
                //}

                if (Session["propertyvalue"] != null)
                {
                    ddlProperty.DataSource = md.GetDropdown();
                    ddlProperty.DataBind();
                    ddlProperty.DataTextField = "p_name";
                    ddlProperty.DataValueField = "p_id";
                    ddlProperty.DataBind();
                    ddlProperty.SelectedValue = Session["propertyvalue"].ToString();
                }
                else
                {
                    ddlProperty.DataSource = md.GetDropdown();
                    ddlProperty.DataBind();
                    ddlProperty.DataTextField = "p_name";
                    ddlProperty.DataValueField = "p_id";
                    ddlProperty.DataBind();
                    Session["propertyvalue"] = "0";
                    // ddlProperty.SelectedValue = Session["propertyvalue"].ToString();
                }

            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("~/content/login.aspx");
            }
        }

    }

    protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["propertyvalue"] = ddlProperty.SelectedValue;
            string propertyvalue = Session["propertyvalue"].ToString();
            if (contentCallEvent != null)

                contentCallEvent(this, EventArgs.Empty);

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    public event EventHandler contentCallEvent;

    /// <summary>
    /// labal
    /// </summary>
    private void countProperty()
    {
        string sql2 = @"SELECT count(p_id) as countProperty  from Property";
        using (SqlDataReader sdr = SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql2))
        {
            if (sdr.HasRows)
                sdr.Read();
            lblPropertyCount.Text = sdr["countProperty"].ToString();
        }
    }
    protected void lkbtnHome_Click(object sender, EventArgs e)
    {
        Session["propertyvalue"] = "0";
        Response.Redirect("~/Content/Home.aspx");

    }

    protected void lbtnDashboard_Click(object sender, EventArgs e)
    {

        if (Session["propertyvalue"] != null)
        {

            if (Session["propertyvalue"].ToString() == "0")
            {
                //  Session.Remove("propertyvalue");
                Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/dashboard.aspx");
            }
            else
            {
                Response.Redirect("~/Content/dashboard.aspx");
            }
        }
        else
        {
            // Session.Remove("propertyvalue");
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/dashboard.aspx");
        }

    }
    protected void lbtnMyProperties_Click(object sender, EventArgs e)
    {

        if (Session["propertyvalue"] != null)
        {
            if (Session["propertyvalue"].ToString() == "0")
            {
                // Session.Remove("propertyvalue");
                // Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/MyProperties.aspx");
            }
            else
            {
                Response.Redirect("~/Content/MyProperties.aspx");
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/MyProperties.aspx");
        }

    }
    protected void lbtnRooms_Click(object sender, EventArgs e)
    {

        if (Session["propertyvalue"] != null)
        {
            if (Session["propertyvalue"].ToString() == "0")
            {
                Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/Rooms.aspx");
            }
            else
            {
                Response.Redirect("~/Content/Rooms.aspx");
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/Rooms.aspx");
        }
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("~/content/login.aspx");
    }
}
