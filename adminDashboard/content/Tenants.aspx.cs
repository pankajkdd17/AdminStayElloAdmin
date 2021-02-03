using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Tenants : System.Web.UI.Page
{
    EditData ed = new EditData();
    Delete dt = new Delete();
    AddUsers uc = new AddUsers();
    Dashboard dd = new Dashboard();
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
                        ShowTenants();
                        showCounttenants();
                    }
                    else
                    {
                        ShowTenants();
                        showCounttenants();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    ShowTenants();
                    showCounttenants();
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

    private void showCounttenants()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();

                SqlDataReader sdr1 = dd.getRooms(PropertyVale);
                if (sdr1.HasRows)
                {
                    sdr1.Read();
                    lblTotalRooms.Text = sdr1["Room"].ToString();
                }
                SqlDataReader sdr5 = dd.getTenants(PropertyVale);
                if (sdr5.HasRows)
                {
                    sdr5.Read();
                    lblTotalTenants.Text = sdr5["countTenants"].ToString();
                }
                sdr5.Close();
                SqlDataReader sdr11 = dd.getCountTotalBeds(PropertyVale);
                if (sdr11.HasRows)
                {
                    sdr11.Read();
                    lblTotalBeds.Text = sdr11["r_BedsValue"].ToString();
                }
                sdr11.Close();
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
    protected void btnAddNewTenants_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddTenants.aspx");
    }
    public void ShowTenants()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.Loadtenants(PropertyVale);
                ListView1.DataBind();
            }
            else
            {
                Session["propertyvalue"] = "0";
                string PropertyVale = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.Loadtenants(PropertyVale);
                ListView1.DataBind();
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
        // string ddlProperty = Session["Property"].ToString();
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        showCounttenants();
        ListView1.DataSource = uc.Loadtenants(PropertyVale);
        ListView1.DataBind();
        // This Method will be Called.
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string t_id = e.CommandArgument.ToString();
                Response.Redirect("AddTenants.aspx?t_id=" + t_id + "");
            }
            else if (e.CommandName == "Dlt")
            {
                int t_id = Convert.ToInt32(e.CommandArgument);
                SqlDataReader sdr = dt.GetTenantMobile(t_id);
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        Session["TenantMobile"] = sdr["t_MobileNo"].ToString();
                    }
                }
                if (checkDuesPending() == false)
                {
                    dt.DeleteTenants(t_id);
                    string textmsg = "" + t_id + " Record Deleted Successfully !";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                }
                ShowTenants();
            }
            else if (e.CommandName == "GetKYC")
            {
                string t_id = e.CommandArgument.ToString();
                Response.Redirect("kycDetails.aspx?t_id=" + t_id + "");
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    private bool checkDuesPending()
    {
        bool result = false;
        string TenantsMobile = Session["TenantMobile"].ToString();
        SqlDataReader sdr = uc.GetPendingDues(TenantsMobile);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                string tenantName = sdr["d_PayeeText"].ToString();
                string d_RoomNo = sdr["d_RoomNo"].ToString();
                string d_t_Mobile = sdr["d_t_Mobile"].ToString();
                string d_DuesTypeText = sdr["d_DuesTypeText"].ToString();
                string d_DuesAmount = sdr["d_DuesAmount"].ToString();
                string text = "The due of " + tenantName + "(" + d_t_Mobile + ") Room no " + d_RoomNo + " Due type " + d_DuesTypeText + " of Rs." + d_DuesAmount + " is pending you can not delete it";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                result = true;
            }
            sdr.Close();
        }
        else
        {
            result = false;
        }
        return result;
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            ListView1.DataSource = uc.getAllTenants(txtSearch.Text, PropertyVale);
            ListView1.DataBind();
            showCounttenants();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }

    }
    protected void lbtSearchTenants_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            ListView1.DataSource = uc.getAllTenants(txtSearch.Text, PropertyVale);
            ListView1.DataBind();
            showCounttenants();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}