using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Leads : System.Web.UI.Page
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
                        ShowLeads();
                    }
                    else
                    {
                        ShowLeads();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    ShowLeads();
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



    private void ShowLeads()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
                GridView1.DataSource = uc.GetLeads(PropertyVale);
                GridView1.DataBind();
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
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedValue;
            GridView1.DataSource = uc.GetLeads(PropertyVale);
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

    protected void btnAddNewLeads_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddLeads.aspx");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string l_id = e.CommandArgument.ToString();
                Response.Redirect("AddLeads.aspx?l_id=" + l_id + "");
            }
            else if (e.CommandName == "Dlt")
            {
                int l_id = Convert.ToInt32(e.CommandArgument);
                dt.DeleteLeads(l_id);
                string textmsg = "" + l_id + " Record Deleted Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                ShowLeads();
            }
        }
        catch (Exception ex)
        {
            //string text = ex.Message.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

}