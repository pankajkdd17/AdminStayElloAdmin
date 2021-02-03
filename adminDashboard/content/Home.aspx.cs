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

public partial class Home : System.Web.UI.Page
{

    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
    Dashboard dd = new Dashboard();
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
                        
                        LoadData();
                    }
                    else
                    {
                        Session["propertyvalue"] = "1";
                        Response.Redirect("~/Content/dashboard.aspx");
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    LoadData();
                }
            }
            else
            {
                Response.Redirect("~/content/login.aspx");
            }
        }
    }
    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {

            if (Session["s_MobileNo"] != null)
            {
                if (Session["propertyvalue"] != null)
                {
                    if (Session["propertyvalue"].ToString() != "0")
                    {
                        Response.Redirect("~/content/dashboard.aspx");
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        Session["propertyvalue"] = "0";
                        LoadData();
                    }
                }
                else
                {

                    Session["propertyvalue"] = "0";
                    LoadData();
                }
            }
            else
            {
                Response.Redirect("~/content/login.aspx");
                Context.ApplicationInstance.CompleteRequest();
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
    private void LoadData()
    {
        try
        {
            //DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            //string PropertyName = ddlPropertyName.SelectedItem.Text;
            //string propertyvalue = ddlPropertyName.SelectedItem.Value;
             string propertyvalue = Session["propertyvalue"].ToString();
            SqlDataReader sdr7 = dd.getProperty();
            if (sdr7.HasRows)
            {
                sdr7.Read();
                lblproperty.Text = sdr7["Property"].ToString();
            }
            sdr7.Close();

            SqlDataReader sdr01 = dd.getCollection(propertyvalue);
            if (sdr01.HasRows)
            {
                if (sdr01.Read())
                {
                    string roomrent = sdr01["RentMoney"].ToString();
                    string securitymoney = sdr01["SecurityMoney"].ToString();
                    if ((roomrent != "") && (securitymoney != ""))
                    {
                        lblroomrent.Text = roomrent;
                        lblSecurityMoney.Text = securitymoney;
                    }
                    else
                    {
                        lblroomrent.Text = "0";
                        lblSecurityMoney.Text = "0";
                    }
                }
            }
            sdr01.Close();

            SqlDataReader sdr1 = dd.getCountRooms();
            if (sdr1.HasRows)
            {
                sdr1.Read();
                lblTotalRoom.Text = sdr1["Room"].ToString();
            }
            sdr1.Close();
            SqlDataReader sdr11 = dd.getCountTotalBed();
            if (sdr11.HasRows)
            {
                sdr11.Read();
                string Total = sdr11["r_BedsValue"].ToString();
                if (Total != "")
                {
                    lblTotalBeds.Text = sdr11["r_BedsValue"].ToString();
                }
                else
                {
                    lblTotalBeds.Text = "0";
                }
                Session["TotalBeds"] = lblTotalBeds.Text;
            }
            sdr11.Close();
            SqlDataReader sdr12 = dd.getCountTotalBedsOccupied();
            if (sdr12.HasRows)
            {
                sdr12.Read();
                lblBedsOccupied.Text = sdr12["totaltenatns"].ToString();
                Session["OccupiedBeds"] = lblBedsOccupied.Text;
            }
            sdr12.Close();
            if ((Session["TotalBeds"].ToString().Length > 0) && (Session["OccupiedBeds"].ToString().Length > 0))
            {
                int vacant = (Convert.ToInt16(Session["TotalBeds"]) - Convert.ToInt16(Session["OccupiedBeds"]));
                lblBedsVacant.Text = vacant.ToString();
            }
            else
            {
                lblBedsVacant.Text = "0";
            }
            SqlDataReader sdr5 = dd.getCountTotalTenants();
            if (sdr5.HasRows)
            {
                sdr5.Read();
                lblTotalTenants.Text = sdr5["countTenants"].ToString();
            }
            sdr5.Close();
            SqlDataReader sdr13 = dd.getCountTotalSignup();
            if (sdr13.HasRows)
            {
                sdr13.Read();
                lblSignup.Text = sdr13["totalsignup"].ToString();
            }
            sdr13.Close();
            SqlDataReader sdr14 = dd.getCountTotalBooking();
            if (sdr14.HasRows)
            {
                sdr14.Read();
                lblBookings.Text = sdr14["totalBookNow"].ToString();
            }
            sdr14.Close();
            SqlDataReader sdr15 = dd.getCountTotalSchedule();
            if (sdr15.HasRows)
            {
                sdr15.Read();
                lblSchedules.Text = sdr15["totalScheduleVisit"].ToString();
            }
            sdr15.Close();
            SqlDataReader sdr16 = dd.getTotalLeads();
            if (sdr16.HasRows)
            {
                sdr16.Read();
                lbltotalLeads.Text = sdr16["totalleads"].ToString();
            }
            sdr16.Close();
            SqlDataReader sdr17 = dd.getTotalDues();
            if (sdr17.HasRows)
            {
                sdr17.Read();
                lblcountdues.Text = sdr17["CountDues"].ToString();
                lblTotalDues.Text = sdr17["TotalDuesAmount"].ToString();
                Session["TotalDues"] = lblTotalDues.Text;
            }
            sdr17.Close();
            DateTime duedate = System.DateTime.Now;
            string month = duedate.ToString("MMMM-yyyy");
            SqlDataReader sdr19 = dd.getTotalIncome(month);
            if (sdr19.HasRows)
            {
                sdr19.Read();
                lblCountIncome.Text = sdr19["CountIncome"].ToString();
                string TotalRecvedAmount = sdr19["Totald_recivedAmount"].ToString();
                Session["Totald_recivedAmount"] = TotalRecvedAmount;
            }

            sdr19.Close();

            SqlDataReader sdr18 = dd.getTotalExpence();
            if (sdr18.HasRows)
            {
                sdr18.Read();
                lblcountExpence.Text = sdr18["Counte_Amount"].ToString();
                lblTotalExpenses.Text = sdr18["Totale_Amount"].ToString();
                Session["TotalExpenses"] = lblTotalExpenses.Text;
            }

            sdr18.Close();

            if ((Session["Totald_recivedAmount"].ToString().Length > 0) && (Session["TotalExpenses"].ToString().Length > 0))
            {
                Int64 Totald_recivedAmount = Convert.ToInt64(Session["Totald_recivedAmount"].ToString());
                Int64 TotalExpenses = Convert.ToInt64(Session["TotalExpenses"].ToString());
                Int64 TotalIncome = (Totald_recivedAmount - TotalExpenses);
                lblTotalIncome.Text = TotalIncome.ToString();
            }
            else
            {
                lblTotalIncome.Text = Session["Totald_recivedAmount"].ToString();
            }


            SqlDataReader sdr8 = dd.getNewComplaints();
            if (sdr8.HasRows)
            {
                sdr8.Read();
                lblNew.Text = sdr8["NewComplaints"].ToString();
            }
            sdr8.Close();
            SqlDataReader sdr9 = dd.getSolvedComplaints();
            if (sdr9.HasRows)
            {
                sdr9.Read();
                lblSolved.Text = sdr9["SolvedComplaints"].ToString();
            }
            sdr9.Close();
            SqlDataReader sdr10 = dd.getOnGoingComplaints();
            if (sdr10.HasRows)
            {
                sdr10.Read();
                lblOngoing.Text = sdr10["OnGoingComplaints"].ToString();
            }
            sdr10.Close();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }


    protected void lbtnProperties_Click(object sender, EventArgs e)
    {
        if (Session["propertyvalue"] != null)
        {

            if (Session["propertyvalue"].ToString() == "0")
            {
                Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/MyProperties.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Content/MyProperties.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/MyProperties.aspx");
            Context.ApplicationInstance.CompleteRequest();
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
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Content/Rooms.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/Rooms.aspx");
        }

    }
    protected void lbtnDues_Click(object sender, EventArgs e)
    {
        if (Session["propertyvalue"] != null)
        {

            if (Session["propertyvalue"].ToString() == "0")
            {

                Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/Dues.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Content/Dues.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/Dues.aspx");
            Context.ApplicationInstance.CompleteRequest();
        }

    }
    protected void lbtnExpences_Click(object sender, EventArgs e)
    {
        if (Session["propertyvalue"] != null)
        {

            if (Session["propertyvalue"].ToString() == "0")
            {
                Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/Expenses.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Content/Expenses.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/Expenses.aspx");
            Context.ApplicationInstance.CompleteRequest();
        }

    }
    protected void lbtnBookings_Click(object sender, EventArgs e)
    {
        if (Session["propertyvalue"] != null)
        {

            if (Session["propertyvalue"].ToString() == "0")
            {
                Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/Bookings.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Content/Bookings.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/Bookings.aspx");
            Context.ApplicationInstance.CompleteRequest();
        }

    }
    protected void lbtnLeads_Click(object sender, EventArgs e)
    {
        if (Session["propertyvalue"] != null)
        {

            if (Session["propertyvalue"].ToString() == "0")
            {
                Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/Leads.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Content/Leads.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/Leads.aspx");
            Context.ApplicationInstance.CompleteRequest();
        }

    }
    protected void lbtnScheduleVisits_Click(object sender, EventArgs e)
    {
        if (Session["propertyvalue"] != null)
        {

            if (Session["propertyvalue"].ToString() == "0")
            {
                Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/ScheduleVisits.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Content/ScheduleVisits.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/ScheduleVisits.aspx");
            Context.ApplicationInstance.CompleteRequest();
        }

    }
    protected void lbtnUserData_Click(object sender, EventArgs e)
    {
        if (Session["propertyvalue"] != null)
        {

            if (Session["propertyvalue"].ToString() == "0")
            {
                Session["propertyvalue"] = "0";
                Response.Redirect("~/Content/UserData.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Content/UserData.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {

            Session["propertyvalue"] = "0";
            Response.Redirect("~/Content/UserData.aspx");
            Context.ApplicationInstance.CompleteRequest();
        }

    }
    protected void lbtnTenants_Click(object sender, EventArgs e)
    {
        if (Session["propertyvalue"] != null)
        {

            if (Session["propertyvalue"].ToString() == "0")
            {
                Session["propertyvalue"] = "1";
                Response.Redirect("~/Content/Tenants.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Content/Tenants.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        else
        {
            Session["propertyvalue"] = "1";
            Response.Redirect("~/Content/Tenants.aspx");
            Context.ApplicationInstance.CompleteRequest();
        }

    }
}