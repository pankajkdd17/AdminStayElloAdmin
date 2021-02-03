using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_ExitProperty : System.Web.UI.Page
{
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
                        // Session.Remove("propertyvalue");
                        showExitTenants();
                    }
                    else
                    {
                        showExitTenants();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    showExitTenants();
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

    private void showExitTenants()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string propertyvalue = Session["propertyvalue"].ToString();
                GridView1.DataSource = uc.LoadexitApplied(propertyvalue);
                GridView1.DataBind();
            }
            else
            {
                Session["propertyvalue"] = "0";
                showExitTenants();
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
            GridView1.DataSource = uc.LoadexitApplied(PropertyVale);
            GridView1.DataBind();

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
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string propertyvalue = Session["propertyvalue"].ToString();
                GridView1.DataSource = uc.LoadexitAppliedSearch(propertyvalue, txtSearch.Text);
                GridView1.DataBind();
            }
            else
            {
                Session["propertyvalue"] = "0";
                showExitTenants();
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void lbtSearchTenantsexit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string propertyvalue = Session["propertyvalue"].ToString();
                GridView1.DataSource = uc.LoadexitAppliedSearch(propertyvalue, txtSearch.Text);
                GridView1.DataBind();
            }
            else
            {
                Session["propertyvalue"] = "0";
                showExitTenants();
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}