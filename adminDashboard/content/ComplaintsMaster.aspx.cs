using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_ComplaintsMaster : System.Web.UI.Page
{
    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
    AddUsers uc = new AddUsers();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                loadfill();
                gvbindTicketCategory();
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

    private void gvbindTicketCategory()
    {
        GridView1.DataSource = uc.getTicketCategory();
        GridView1.DataBind();
    }



    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        int tc_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        uc.DeleteTicketCategory(tc_id);
        gvbindTicketCategory();
        LoadFilter();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        gvbindTicketCategory();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("lblID");
        //TextBox txtname=(TextBox)gr.cell[].control[];  
        TextBox textTicketCategoryName = (TextBox)row.Cells[1].Controls[0];
        string TCName = textTicketCategoryName.Text;
        GridView1.EditIndex = -1;
        uc.UpdateTicketCategory(userid, TCName);
        gvbindTicketCategory();
        LoadFilter();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        gvbindTicketCategory();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        gvbindTicketCategory();
    }

    protected void loadfill()
    {
        Gf.FillFaccingIssue("tc_id", "tc_name", "TicketCategory", ddlTicketCategory, "");
        Gf.FillFaccingIssue("tc_id", "tc_name", "TicketCategory", ddlTicketCategoryMainissue, "");

    }
    protected void loadTicketCategory()
    {
        Gf.FillFaccingIssue("tc_id", "tc_name", "TicketCategory", ddlTicketCategory, "");
        Gf.FillFaccingIssue("tc_id", "tc_name", "TicketCategory", ddlTicketCategoryMainissue, "");
    }
    protected void LoadFilter()
    {
        Gf.FillFaccingMainIssue("fi_id", "fi_name", "FacingIssue", ddlFacingIssue, "", ddlTicketCategoryMainissue.SelectedItem.Value);
    }
    protected void btnTicketCategory_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTicketCategory.Text.Trim().Length > 0)
            {
                uc.AddTicketCategory(txtTicketCategory.Text);
                string textmsg = "Record Added Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                txtTicketCategory.Text = string.Empty;
                loadTicketCategory();
                gvbindTicketCategory();
            }
            else { }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnbtnIssueCategory_Click(object sender, EventArgs e)
    {
        try
        {
            uc.AddIssueCategory(ddlTicketCategory.SelectedItem.Value, ddlTicketCategory.SelectedItem.Text, txtFacingIssueName.Text);
            string textmsg = "Record Added Successfully !";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
            txtFacingIssueName.Text = string.Empty;
            LoadFilter();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void btnIssueSubCategory_Click(object sender, EventArgs e)
    {
        try
        {
            uc.AddIssueSubCategory(ddlTicketCategoryMainissue.SelectedItem.Value, ddlTicketCategoryMainissue.SelectedItem.Text, ddlFacingIssue.SelectedItem.Value, ddlFacingIssue.SelectedItem.Text, txtFacingIssueSubCategoryName.Text);
            string textmsg = "Record Added Successfully !";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
            txtFacingIssueSubCategoryName.Text = string.Empty;
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void ddlTicketCategoryMainissue_SelectedIndexChanged(object sender, EventArgs e)
    {
        Gf.FillFaccingMainIssue("fi_id", "fi_name", "FacingIssue", ddlFacingIssue, "", ddlTicketCategoryMainissue.SelectedItem.Value);
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            uc.AddUpdateIssueCategory(ddlTicketCategoryUpdate.SelectedItem.Value, txtFacingIssueName.Text);
            string textmsg = "Record Updated Successfully !";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
            txtFacingIssueName.Text = string.Empty;
            LoadFilter();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void ddlTicketCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try  
        {
            string catValue = ddlTicketCategory.SelectedItem.Value;
            ddlTicketCategoryUpdate.DataSource = uc.GetSubCategoryOnupdate(catValue);
            ddlTicketCategoryUpdate.DataBind();
            ddlTicketCategoryUpdate.DataTextField = "fi_name";
            ddlTicketCategoryUpdate.DataValueField = "fi_id";
            ddlTicketCategoryUpdate.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void ddlTicketCategoryUpdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           // string catValue = ddlTicketCategoryUpdate.SelectedItem.Value;
            txtFacingIssueName.Text = ddlTicketCategoryUpdate.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void ddlFacingIssueUpdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtFacingIssueSubCategoryName.Text = ddlFacingIssueUpdate.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void ddlFacingIssue_SelectedIndexChanged(object sender, EventArgs e)
    {
        Gf.FillFaccingMainIssue("fi_id", "fi_name", "FacingIssue", ddlFacingIssueUpdate, "", ddlTicketCategoryMainissue.SelectedItem.Value);
    }

    protected void btnUpdateSubcatgory_Click(object sender, EventArgs e)
    {
        try
        {
            uc.UpdateIssueSubCategory(ddlFacingIssueUpdate.SelectedItem.Value , txtFacingIssueSubCategoryName.Text);
            string textmsg = "Record Updated Successfully !";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
            txtFacingIssueSubCategoryName.Text = string.Empty;
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}