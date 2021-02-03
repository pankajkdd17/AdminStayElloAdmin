using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_ScheduleVisits : System.Web.UI.Page
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
                        showdata();
                        showVisitedRecord();
                    }
                    else
                    {
                        showdata();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    showdata();
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

    private void showVisitedRecord()
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
                    lblBookings.Text = sdr["totalBookNow"].ToString();
                }

                SqlDataReader sdr1 = dd.getCountTotalVisiting(PropertyVale);
                if (sdr1.HasRows)
                {
                    sdr1.Read();
                    lblTotalScheduleVisits.Text = sdr1["totalVisiting"].ToString();
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


    protected void showdata()
    {
        if (Session["propertyvalue"] != null)
        {
            string PropertyVale = Session["propertyvalue"].ToString();
            ListView1.DataSource = uc.GetScheduleVisit(PropertyVale);
            ListView1.DataBind();
        }
        else
        {
            Session["propertyvalue"] = "0";
            string PropertyVale = Session["propertyvalue"].ToString();
            ListView1.DataSource = uc.GetScheduleVisit(PropertyVale);
            ListView1.DataBind();
        }

    }
    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyVale = ddlPropertyName.SelectedValue;
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            if (Session["propertyvalue"] != null)
            {
                showVisitedRecord();
                ListView1.DataSource = uc.GetScheduleVisit(PropertyVale);
                ListView1.DataBind();


            }
            else
            {
                Session["propertyvalue"] = "0";
                showVisitedRecord();
                ListView1.DataSource = uc.GetScheduleVisit(PropertyVale);
                ListView1.DataBind();

            }
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
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        //SqlDataReader sdr = uc.getBookingsSet(txtSearch.Text);
        //if (sdr.HasRows)
        //{
        //    if (sdr.Read())
        //    {
        //        Session["propertyvalue"] = sdr["v_id"].ToString();
        //        string propertyvalue = Session["propertyvalue"].ToString();
        //        showVisitedRecord();
        //        ListView1.DataSource = uc.GetScheduleVisit(propertyvalue);
        //        ListView1.DataBind();
        //    }
        //    sdr.Close();
        //}
        //else
        //{
        //    string text = "Record Not Found";
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        //}
    }
    protected void lbtSearchSchedule_Click(object sender, EventArgs e)
    {
        //SqlDataReader sdr = uc.getBookingsSet(txtSearch.Text);
        //if (sdr.HasRows)
        //{
        //    if (sdr.Read())
        //    {
        //        Session["propertyvalue"] = sdr["v_id"].ToString();
        //        string propertyvalue = Session["propertyvalue"].ToString();
        //        showVisitedRecord();
        //        ListView1.DataSource = uc.GetScheduleVisit(propertyvalue);
        //        ListView1.DataBind();
        //    }
        //    sdr.Close();
        //}
        //else
        //{
        //    string text = "Record Not Found";
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        //}
    }
}