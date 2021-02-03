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

public partial class dashboard : System.Web.UI.Page
{

    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
    Dashboard dd = new Dashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                if (Session["propertyvalue"] != null)
                {
                    if (Session["propertyvalue"].ToString() != "0")
                    {
                        LoadData();
                    }
                    else
                    {
                        Session["propertyvalue"] = "0";
                        Response.Redirect("~/Content/Home.aspx");
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {

                    Session["propertyvalue"] = "1";
                    LoadData();
                }
            }
            else
            {
                Response.Redirect("~/content/login.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
        }

    }

    private void LoadData()
    {
        try
        {

            //DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            // string PropertyName = ddlPropertyName.SelectedItem.Text;
            // string PropertyVale = ddlPropertyName.SelectedItem.Value;
            if (Session["propertyvalue"].ToString() != "0")
            {
                string PropertyVale = Session["propertyvalue"].ToString();

                SqlDataReader sdr1 = dd.getRooms(PropertyVale);
                if (sdr1.HasRows)
                {
                    sdr1.Read();
                    lblTotalRoom.Text = sdr1["Room"].ToString();
                }
                sdr1.Close();
                SqlDataReader sdr01 = dd.getCollection(PropertyVale);
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

                SqlDataReader sdr5 = dd.getTenants(PropertyVale);
                if (sdr5.HasRows)
                {
                    sdr5.Read();
                    lblTotalTenants.Text = sdr5["countTenants"].ToString();
                }
                sdr5.Close();
                SqlDataReader sdr11 = dd.getCountTotalBed(PropertyVale);
                if (sdr11.HasRows)
                {
                    sdr11.Read();
                    lblTotalBeds.Text = sdr11["r_BedsValue"].ToString();
                    Session["TotalBeds"] = lblTotalBeds.Text;
                }
                sdr11.Close();
                SqlDataReader sdr12 = dd.getCountTotalBedsOccupied(PropertyVale);
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
                SqlDataReader sdr17 = dd.getTotalDues(PropertyVale);
                if (sdr17.HasRows)
                {
                    sdr17.Read();
                    lblcountdues.Text = sdr17["CountDues"].ToString();
                    lblTotalDues.Text = sdr17["TotalDuesAmount"].ToString();
                    Session["TotalDues"] = lblTotalDues.Text;
                }
                sdr17.Close();
                SqlDataReader sdr19 = dd.getTotalIncome(PropertyVale);
                if (sdr19.HasRows)
                {
                    sdr19.Read();
                    lblCountIncome.Text = sdr19["CountIncome"].ToString();
                    string TotalRecvedAmount = sdr19["Totald_recivedAmount"].ToString();
                    Session["Totald_recivedAmount"] = TotalRecvedAmount;
                }
                sdr19.Close();


                SqlDataReader sdr18 = dd.getTotalExpence(PropertyVale);
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
                SqlDataReader sdr14 = dd.getCountTotalBooking(PropertyVale);
                if (sdr14.HasRows)
                {
                    sdr14.Read();
                    lblBookings.Text = sdr14["totalBookNow"].ToString();
                }
                sdr14.Close();
                SqlDataReader sdr15 = dd.getCountTotalSchedule(PropertyVale);
                if (sdr15.HasRows)
                {
                    sdr15.Read();
                    lblSchedules.Text = sdr15["totalScheduleVisit"].ToString();
                }
                sdr14.Close();
                SqlDataReader sdr4 = dd.getAnnouncement(PropertyVale);
                if (sdr4.HasRows)
                {
                    sdr4.Read();
                    lblAnnouncement.Text = sdr4["Announcements"].ToString();
                }

                sdr4.Close();


                SqlDataReader sdr6 = dd.getLeads(PropertyVale);
                if (sdr6.HasRows)
                {
                    sdr6.Read();
                    lblLeads.Text = sdr6["Lead"].ToString();
                }
                sdr6.Close();

                SqlDataReader sdr8 = dd.getNewComplaints(PropertyVale);
                if (sdr8.HasRows)
                {
                    sdr8.Read();
                    lblNew.Text = sdr8["NewComplaints"].ToString();
                }
                sdr8.Close();
                SqlDataReader sdr9 = dd.getSolvedComplaints(PropertyVale);
                if (sdr9.HasRows)
                {
                    sdr9.Read();
                    lblSolved.Text = sdr9["SolvedComplaints"].ToString();
                }
                sdr9.Close();
                SqlDataReader sdr10 = dd.getOnGoingComplaints(PropertyVale);
                if (sdr10.HasRows)
                {
                    sdr10.Read();
                    lblOngoing.Text = sdr10["OnGoingComplaints"].ToString();
                }

                sdr10.Close();

               // Gf.FillRooms("r_id", "r_roomNo", "Rooms", ddlroomNo, "", PropertyVale);

                SqlDataReader sdr20 = dd.getRoomVacant(PropertyVale);
                if (sdr20.HasRows)
                {
                    sdr20.Read();
                    lblVacant.Text = sdr20["Vacant"].ToString();
                    Session["Vacent"] = lblVacant.Text;
                }
                sdr20.Close();
                DataSet ds = dd.getRoomNo(PropertyVale);

                int sum = 0;
                int tblCount = ds.Tables.Count;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string romNo = dr["r_RoomNo"].ToString();
                    SqlDataReader sdr21 = dd.getRoomFull(PropertyVale, romNo);
                    if (sdr21.HasRows)
                    {
                        sdr21.Read();
                        int count = Convert.ToInt16(sdr21["FullRoom"]);
                        sum = sum + count;
                        lblFull.Text = sum.ToString();
                        Session["Full"] = lblFull.Text;
                    }
                    sdr21.Close();
                }

                string absolutValue = Math.Abs(Convert.ToInt32(Session["Full"]) + Convert.ToInt32(Session["Vacent"])).ToString();
                SqlDataReader sdr22 = dd.getRoomSemiVacant(PropertyVale);
                if (sdr22.HasRows)
                {
                    sdr22.Read();
                    int count = Convert.ToInt16(sdr22["SemiVacant"]);
                    int Semivecent = count - Convert.ToInt32(absolutValue);
                    lblSemiVacant.Text = Semivecent.ToString();
                }
                sdr22.Close();
                SqlDataReader sdr2 = dd.getDues(PropertyVale);
                if (sdr2.HasRows)
                {
                    sdr2.Read();
                    lblDues.Text = sdr2["dues"].ToString();
                }
                sdr2.Close();
                SqlDataReader sdr3 = dd.getExpence(PropertyVale);
                if (sdr3.HasRows)
                {
                    sdr3.Read();
                    lblExpenses.Text = sdr3["Expences"].ToString();
                }
                sdr3.Close();
            }
            else
            {
                Session["propertyvalue"] = "0";
                Response.Redirect("~/Content/Home.aspx");
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

            if (Session["propertyvalue"] != null)
            {
                if (Session["propertyvalue"].ToString() != "0")
                {

                    LoadData();
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    Response.Redirect("~/content/Home.aspx");
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            else
            {
                Session["propertyvalue"] = "0";
                Response.Redirect("~/content/Home.aspx");
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
}