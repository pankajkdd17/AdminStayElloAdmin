using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_FoodMenu : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();
    Delete dt = new Delete();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                FoodmenuShow();
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

    private void FoodmenuShow()
    {
        // ListView1.DataSource = uc.ShowFoodMenu();
        // ListView1.DataBind();
        try
        {

            ListView1.DataSource = uc.GetfoodmenuSunday();
            ListView1.DataBind();

            ListView2.DataSource = uc.GetfoodmenuMonday();
            ListView2.DataBind();

            ListView3.DataSource = uc.GetfoodmenuTuesday();
            ListView3.DataBind();

            ListView4.DataSource = uc.GetfoodmenuWednesday();
            ListView4.DataBind();

            ListView5.DataSource = uc.GetfoodmenuThursday();
            ListView5.DataBind();

            ListView6.DataSource = uc.GetfoodmenuFriday();
            ListView6.DataBind();

            ListView7.DataSource = uc.GetfoodmenuSaturday();
            ListView7.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnAddNewFoodMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddFoodMenu.aspx");
    }

    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string f_id = e.CommandArgument.ToString();
                Response.Redirect("AddFoodMenu.aspx?f_id=" + f_id + "");
            }
            else if (e.CommandName == "Delete")
            {
                int f_id = Convert.ToInt32(e.CommandArgument);
                dt.DeleteFoodMenu(f_id);
                string textmsg = "" + f_id + " Record Deleted Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                FoodmenuShow();

            }
        }
        catch (Exception ex)
        {
            //string text = ex.Message.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}