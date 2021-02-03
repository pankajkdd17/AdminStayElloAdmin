using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Bookings : System.Web.UI.Page
{
    Dashboard dd = new Dashboard();
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
                        LoaddataByProperty();
                        showBooking();

                    }
                    else
                    {
                        LoaddataByProperty();
                        showBooking();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    LoaddataByProperty();
                    showBooking();
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

    private void showBooking()
    {
        if (Session["propertyvalue"] != null)
        {
            string PropertyVale = Session["propertyvalue"].ToString();
            rptBooking.DataSource = uc.GetBookings(PropertyVale);
            rptBooking.DataBind();
            LoaddataByProperty();

        }
        else
        {
            Session["propertyvalue"] = "0";
            string PropertyVale = Session["propertyvalue"].ToString();
            rptBooking.DataSource = uc.GetBookings(PropertyVale);
            rptBooking.DataBind();
            LoaddataByProperty();
        }
    }



    private void LoaddataByProperty()
    {
        try
        {


            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();

                SqlDataReader sdr = dd.getCountTotalBooking(PropertyVale);
                if (sdr.HasRows)
                {
                    sdr.Read();
                    lblTotalBookings.Text = sdr["totalBookNow"].ToString();
                }

                SqlDataReader sdr1 = dd.getCountTotalVisiting(PropertyVale);
                if (sdr1.HasRows)
                {
                    sdr1.Read();
                    lblotalVisiting.Text = sdr1["totalVisiting"].ToString();
                }

                SqlDataReader sdr2 = dd.getCountSignup();
                if (sdr2.HasRows)
                {
                    sdr2.Read();
                    lblSignup.Text = sdr2["totalsignup"].ToString();
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
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyVale = ddlPropertyName.SelectedValue;
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            rptBooking.DataSource = uc.GetBookings(PropertyVale);
            rptBooking.DataBind();
            LoaddataByProperty();
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
    protected void lbtSearchBooking_Click(object sender, EventArgs e)
    {
        try
        {
            string propertyvalue = Session["propertyvalue"].ToString();
            rptBooking.DataSource = uc.getBookingsSetBySearch(propertyvalue , txtSearch.Text);
            rptBooking.DataBind();
            LoaddataByProperty();
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
            string propertyvalue = Session["propertyvalue"].ToString();
            rptBooking.DataSource = uc.getBookingsSetBySearch(propertyvalue, txtSearch.Text);
            rptBooking.DataBind();
            LoaddataByProperty();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}