using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Staffs : System.Web.UI.Page
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
                showStaff();
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

    private void showStaff()
    {
        try
        {
            GridView1.DataSource = uc.getStaff();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnAddNewStaffs_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddStaffs.aspx");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string s_id = e.CommandArgument.ToString();
                Response.Redirect("AddStaffs.aspx?s_id=" + s_id + "");
            }
            else if (e.CommandName == "Dlt")
            {
                int s_id = Convert.ToInt32(e.CommandArgument);
                dt.DeleteStaff(s_id);
                string textmsg = "" + s_id + " Record Deleted Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);

                this.showStaff();

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
        GridView1.DataSource = uc.getStaffsearch(txtSearch.Text);
        GridView1.DataBind();
    }
    protected void lbtSearchStaff_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = uc.getStaffsearch(txtSearch.Text);
        GridView1.DataBind();
    }
}