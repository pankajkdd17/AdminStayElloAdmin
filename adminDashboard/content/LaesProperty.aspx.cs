using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_LaesProperty : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                showLeseProperty();
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

    private void showLeseProperty()
    {
        ListView1.DataSource = uc.GetLeseProperty();
        ListView1.DataBind();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        ListView1.DataSource = uc.getLeaseProperty(txtSearch.Text);
        ListView1.DataBind();
    }
    protected void lbtSearchLeaseProperty_Click(object sender, EventArgs e)
    {
        ListView1.DataSource = uc.getLeaseProperty(txtSearch.Text);
        ListView1.DataBind();
    }
}