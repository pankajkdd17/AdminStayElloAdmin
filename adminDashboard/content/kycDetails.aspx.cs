using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_kycDetails : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();
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
                        if (Request.QueryString["t_id"] != null)
                        {
                            string t_id = Request.QueryString["t_id"].ToString();
                            GetKycByMobile(t_id);
                        }
                    }
                    else
                    {
                        if (Request.QueryString["t_id"] != null)
                        {
                            string t_id = Request.QueryString["t_id"].ToString();
                            GetKycByMobile(t_id);
                        }
                    }

                }
                 else
                {
                    Session["propertyvalue"] = "0";
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
    private void GetKycByMobile(string t_id)
    {
        try
        {
            SqlDataReader sdr = ed.GetTenantsById(t_id);
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    string mobile = sdr["t_MobileNo"].ToString();
                    GridView1.DataSource = uc.LoadKycOfTenantsByMobile(mobile);
                    GridView1.DataBind();
                }
                sdr.Close();
            }
            else
            {
                string text ="Kyc not uploaded yet";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
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
            GridView1.DataSource = uc.LoadKycOfTenants(PropertyVale);
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
            GridView1.DataSource = uc.LoadKycOfTenantsbySearch(txtSearch.Text);
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void lbtSearchKYC_Click(object sender, EventArgs e)
    {
        try
        {
            GridView1.DataSource = uc.LoadKycOfTenantsbySearch(txtSearch.Text);
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {

            if (e.CommandName == "DownloadFront")
            {
                string k_id = e.CommandArgument.ToString();
                SqlDataReader sdr = uc.GetFileFront(k_id);

                if (sdr.HasRows)
                {
                    sdr.Read();
                    string file = sdr["k_frontPath"].ToString();
                    Response.Redirect("http://www.stayello.com/" + file + "");
                }
                else
                {
                    string text = "File Not Uploded";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                }
            }
            else if (e.CommandName == "DownloadBack")
            {
                string k_id = e.CommandArgument.ToString();
                SqlDataReader sdr = uc.GetFileFront(k_id);

                if (sdr.HasRows)
                {
                    sdr.Read();
                    string file = sdr["k_BackPath"].ToString();
                    Response.Redirect("http://www.stayello.com/" + file + "");
                }
                else
                {
                    string text = "File Not Uploded";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                }
            }


        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

}
