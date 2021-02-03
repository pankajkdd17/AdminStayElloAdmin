using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Income : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();
    Delete dt = new Delete();
    Dashboard dd = new Dashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime duedate = System.DateTime.Now;
        txtMonthfilter.Text = duedate.ToString("yyyy-MM");
        if (!IsPostBack)
        {
            
            if (Session["s_MobileNo"] != null)
            {
                if (Session["propertyvalue"] != null)
                {
                    if (Session["propertyvalue"].ToString() == "0")
                    {
                        showDues();
                        showIncomeCalculate();
                    }
                    else
                    {
                        showDues();
                        showIncomeCalculate();
                    }
                }
                else
                {

                    Session["propertyvalue"] = "0";
                    showDues();
                    showIncomeCalculate();
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

    private void showIncomeCalculate()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();

                SqlDataReader sdr7 = dd.getTotalDuesSum(PropertyVale);
                if (sdr7.HasRows)
                {
                    sdr7.Read();
                    lblTotalDues.Text = sdr7["d_DuesAmount"].ToString();
                }

                SqlDataReader sdr1 = dd.getTotalIncomeSum(PropertyVale);
                if (sdr1.HasRows)
                {
                    sdr1.Read();
                    lblTotalIncome.Text = sdr1["d_recivedAmount"].ToString();
                }
                SqlDataReader sdr = dd.getTotalExpenceSum(PropertyVale);
                if (sdr.HasRows)
                {
                    sdr.Read();
                    lblTotalExpence.Text = sdr["e_Amount"].ToString();
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
    protected void btnAddNewIncome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddIncome.aspx");
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string d_id = e.CommandArgument.ToString();
                Response.Redirect("AddIncome.aspx?d_id=" + d_id + "");
            }
            else if (e.CommandName == "Dlt")
            {
                int d_id = Convert.ToInt32(e.CommandArgument);
                dt.DeleteDues(d_id);
                string textmsg = "" + d_id + " Record Deleted Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                showDues();
                showIncomeCalculate();
            }
            else if (e.CommandName == "Receipt")
            {
                string d_id = e.CommandArgument.ToString();
                Response.Redirect("Recipt.aspx?d_id=" + d_id + "");
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
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        showIncomeCalculate();
        ListView1.DataSource = uc.getIncomeAll(PropertyVale);
        ListView1.DataBind();
        // This Method will be Called.
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }

    private void showDues()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.getIncomeAll(PropertyVale);
                ListView1.DataBind();
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
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string propertyvalue = Session["propertyvalue"].ToString();
            ListView1.DataSource = uc.getIncomeBySearch(propertyvalue, txtSearch.Text);
            ListView1.DataBind();
            showIncomeCalculate();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void lbtSearchIncome_Click(object sender, EventArgs e)
    {
        try
        {
            string propertyvalue = Session["propertyvalue"].ToString();
            ListView1.DataSource = uc.getIncomeBySearch(propertyvalue, txtSearch.Text);
            ListView1.DataBind();
            showIncomeCalculate();
        }
        catch(Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void txtMonthfilter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string propertyvalue = Session["propertyvalue"].ToString();
            DateTime duedate = Convert.ToDateTime(txtMonthfilter.Text);
            string month = duedate.ToString("MMMM-yyyy");
            ListView1.DataSource = uc.getIncomeAllByMonth(propertyvalue , month);
            ListView1.DataBind();
            showIncomeCalculate();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}