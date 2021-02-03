using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_MyProperties : System.Web.UI.Page
{
    Dashboard dd = new Dashboard();
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();
    Delete dt = new Delete();
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

                        ShowProperty();
                        showCount();
                    }
                    else
                    {
                        ShowProperty();
                        showCount();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    ShowProperty();
                    showCount();
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



    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string p_id = e.CommandArgument.ToString();
                Response.Redirect("Profile.aspx?p_id=" + p_id + "");
            }

            else if (e.CommandName == "Dlt")
            {
                int p_id = Convert.ToInt32(e.CommandArgument);
                SqlDataReader sdr = ed.CheckProperty(p_id);
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        string r_PropertyVale = sdr["r_PropertyVale"].ToString();
                        SqlDataReader sdr2 = ed.GetRoomsInProperty(r_PropertyVale);
                        if (sdr2.HasRows)
                        {
                            if (sdr2.Read())
                            {
                                string Rooms = sdr2["r_roomNo"].ToString();
                                string r_Property = sdr2["r_PropertyName"].ToString();
                                string textmsg = "" + Rooms + " Room are exist in " + r_Property + " You can not delete it";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                            }
                            sdr2.Close();
                        }
                        else
                        {
                            dt.DeleteProperty(p_id);
                            string textmsg = "" + p_id + " Record Deleted Successfully !";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                            ShowProperty();
                        }
                    }
                    sdr.Close();
                }
            }
        }
        catch (Exception ex)
        {
            //string text = ex.Message.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }


    //private bool checkRoomExist()
    //{
    //    bool result = false;

    //    DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");

    //    if (ddlPropertyName.SelectedItem.Value != "0")
    //    {
    //        string PropertyName = ddlPropertyName.SelectedItem.Text;
    //        if (Session["propertyvalue"] != null)
    //        {
    //            string PropertyVale = Session["propertyvalue"].ToString();
    //            SqlDataReader sdr = ed.CheckRooms(PropertyVale);
    //            if (sdr.HasRows)
    //            {
    //                if (sdr.Read())
    //                {
    //                    string r_PropertyName = sdr["r_PropertyName"].ToString();
    //                    string roomNo = sdr["r_roomNo"].ToString();
    //                    string text = "In This Property " + r_PropertyName + " rooms " + roomNo + "  are exist you can not delete it";
    //                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
    //                    result = true;
    //                }
    //            }
    //            sdr.Close();
    //        }
    //        else
    //        {
    //            Session["propertyvalue"] = "1";
    //        }
    //    }
    //    else
    //    {
    //        string text = "Please Select property ";
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
    //    }
    //    return result;
    //}
    private void showCount()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();

                SqlDataReader sdr7 = dd.getProperty();
                if (sdr7.HasRows)
                {
                    sdr7.Read();
                    lblproperty.Text = sdr7["Property"].ToString();
                }

                SqlDataReader sdr1 = dd.getRooms(PropertyVale);
                if (sdr1.HasRows)
                {
                    sdr1.Read();
                    lblTotalRoom.Text = sdr1["Room"].ToString();
                }

                SqlDataReader sdr5 = dd.getTenants(PropertyVale);
                if (sdr5.HasRows)
                {
                    sdr5.Read();
                    lblTotalTenants.Text = sdr5["countTenants"].ToString();
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
    protected void btnAddNewProperties_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddMyProperties.aspx");
    }

    public void ShowProperty()
    {
        try
        {

            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.LoadPropert(PropertyVale);
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

    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        ListView1.DataSource = uc.LoadPropert(PropertyVale);
        ListView1.DataBind();
        showCount();
        // This Method will be Called.
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }
    protected void btnPeople_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Tenants.aspx");
    }
    protected void btnRoom_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Rooms.aspx");
    }
    protected void btnAccounts_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Dues.aspx");
    }
    protected void btnComplaints_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Complaints.aspx");
    }
    protected void btnDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/dashboard.aspx");
    }

    protected void lbtSearchProperty_Click(object sender, EventArgs e)
    {

        try
        {
            ListView1.DataSource = uc.getPropertySet(txtSearch.Text);
            ListView1.DataBind();
            showCount();
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
            ListView1.DataSource = uc.getPropertySet(txtSearch.Text);
            ListView1.DataBind();
            showCount();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}