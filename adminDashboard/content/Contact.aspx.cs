using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Contact : System.Web.UI.Page
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
                showContacts();
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

    private void showContacts()
    {
        try
        {
            GridView1.DataSource = uc.getContacts();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = uc.getContactsearch(txtSearch.Text);
        GridView1.DataBind();
    }
    protected void lbtSearchStaff_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = uc.getContactsearch(txtSearch.Text);
        GridView1.DataBind();
    }
}