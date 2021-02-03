using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Partners : System.Web.UI.Page
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
                showPartner();
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

    private void showPartner()
    {
        try
        {
            GridView1.DataSource = uc.GetPartner();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void btnAddNewPartners_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddPartners.aspx");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string p_id = e.CommandArgument.ToString();
                Response.Redirect("AddPartners.aspx?p_id=" + p_id + "");
            }
            else if (e.CommandName == "Dlt")
            {
                int p_id = Convert.ToInt32(e.CommandArgument);
                dt.DeletePartner(p_id);
                string textmsg = "" + p_id + " Record Deleted Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                showPartner();
            }
        }
        catch (Exception ex)
        {
            //string text = ex.Message.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = uc.getPartnersearch(txtSearch.Text);
        GridView1.DataBind();
    }
    protected void lbtSearchPartners_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = uc.getPartnersearch(txtSearch.Text);
        GridView1.DataBind();
    }
}