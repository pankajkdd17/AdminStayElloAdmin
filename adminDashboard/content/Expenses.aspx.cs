using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Expenses : System.Web.UI.Page
{
    EditData ed = new EditData();
    Delete dt = new Delete();
    AddUsers uc = new AddUsers();
    Dashboard dd = new Dashboard();
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
                        showExpenses();
                        showExpensesCount();
                    }
                    else
                    {
                        showExpenses();
                        showExpensesCount();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    showExpenses();
                    showExpensesCount();
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

    private void showExpensesCount()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();

                SqlDataReader sdr7 = dd.getCountTotalExpence(PropertyVale);
                if (sdr7.HasRows)
                {
                    sdr7.Read();
                    lblTotalExpences.Text = sdr7["TotalExpenceCount"].ToString();
                }

                SqlDataReader sdr1 = dd.getClearDues(PropertyVale);
                if (sdr1.HasRows)
                {
                    sdr1.Read();
                    lblClearDues.Text = sdr1["DuesClearCount"].ToString();
                }
                SqlDataReader sdr = dd.getCountPendingDues(PropertyVale);
                if (sdr.HasRows)
                {
                    sdr.Read();
                    lblPendingDues.Text = sdr["DuesPendingCount"].ToString();
                }
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

    private void showExpenses()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.getexpense(PropertyVale);
                ListView1.DataBind();
            }
            else
            {
                Session["propertyvalue"] = "0";
            }
        }
        catch (Exception ex)
        {
            string exrmsg = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + exrmsg + "')</script>", false);
        }
    }

    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string Propertyname = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        ListView1.DataSource = uc.getexpense(PropertyVale);
        ListView1.DataBind();
        showExpensesCount();
        // This Method will be Called.
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }


    protected void btnAddNewExpenses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddExpenses.aspx");
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string e_id = e.CommandArgument.ToString();
                Response.Redirect("AddExpenses.aspx?e_id=" + e_id + "");
            }
            else if (e.CommandName == "Dlt")
            {
                int e_id = Convert.ToInt32(e.CommandArgument);
                dt.DeleteExpence(e_id);
                string textmsg = "" + e_id + " Record Deleted Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                showExpenses();
                showExpensesCount();
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
        SqlDataReader sdr = uc.getExpenceSet(txtSearch.Text);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                Session["propertyvalue"] = sdr["e_PropertyVal"].ToString();
                string propertyvalue = Session["propertyvalue"].ToString();
                showExpenses();
                showExpensesCount();
                ListView1.DataSource = uc.getexpense(propertyvalue);
                ListView1.DataBind();
            }
            sdr.Close();
        }
        else
        {
            string text = "Record Not Found";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void lbtSearchExpences_Click(object sender, EventArgs e)
    {
        SqlDataReader sdr = uc.getExpenceSet(txtSearch.Text);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                Session["propertyvalue"] = sdr["e_PropertyVal"].ToString();
                string propertyvalue = Session["propertyvalue"].ToString();
                showExpenses();
                showExpensesCount();
                ListView1.DataSource = uc.getexpense(propertyvalue);
                ListView1.DataBind();
            }
            sdr.Close();
        }
        else
        {
            string text = "Record Not Found";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}