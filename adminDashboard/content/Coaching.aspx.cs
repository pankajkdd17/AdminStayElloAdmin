using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Coaching : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                ShowCoaching();
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

    private void ShowCoaching()
    {
        ListView1.DataSource = uc.ShowCoaching();
        ListView1.DataBind();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        ListView1.DataSource = uc.getCoaching(txtSearch.Text);
        ListView1.DataBind();
    }
    protected void lbtSearchCoaching_Click(object sender, EventArgs e)
    {
        ListView1.DataSource = uc.getCoaching(txtSearch.Text);
        ListView1.DataBind();
    }
}