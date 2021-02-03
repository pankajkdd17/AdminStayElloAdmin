using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddExpenses : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();

    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
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
                        Session["propertyvalue"] = "1";
                    }
                    else
                    {
                    }
                }
                else
                {
                    Session["propertyvalue"] = "1";
                }
                Gf.FillCategory("ec_id", "ex_categoryname", "ExpenseCategory", ddlCategory, "");
                Gf.FillPaidBy("s_id", "s_fullname", "signup", ddlPaidBy, "");

                btnExpenses.Visible = true;
                btnSaveChenges.Visible = false;

                if (Request.QueryString["e_id"] != null)
                {
                    string e_id = Request.QueryString["e_id"].ToString();
                    LoadExpenses(e_id);
                    btnExpenses.Visible = false;
                    btnSaveChenges.Visible = true;
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

    private void LoadExpenses(string e_id)
    {
        SqlDataReader sdr = ed.GetExpences(e_id);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {

                ddlCategory.SelectedItem.Text = sdr["e_CategoryText"].ToString();
                ddlCategory.SelectedItem.Value = sdr["e_CategoryValue"].ToString();
                ddlPaidBy.SelectedItem.Text = sdr["e_PaidBytext"].ToString();
                ddlPaidBy.SelectedItem.Value = sdr["e_PaidByValue"].ToString();
                txtAmount.Text = sdr["e_Amount"].ToString();
                txtPaidTo.Text = sdr["e_PaidTo"].ToString();
                ddlPaymentMethod.SelectedItem.Text = sdr["e_PaymentMethod"].ToString();
                txtExpenseDate.Text = sdr["e_ExpenseDate"].ToString();
                txtDetails.Text = sdr["e_Details"].ToString();
                btnExpenses.Visible = false;
                btnSaveChenges.Visible = true;
                // ddlPayee.Attributes.Add("disabled", "disabled");
            }
        }
        sdr.Close();
    }
    protected void btnExpenses_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory.SelectedItem.Value != "0")
            {
                DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                string PropertyName = ddlPropertyName.SelectedItem.Text;
                string PropertyVale = ddlPropertyName.SelectedValue;
                if (PropertyVale != "0")
                {
                    string mobile = Session["s_MobileNo"].ToString();
                    uc.AddExpence(mobile,PropertyName, PropertyVale, ddlCategory.SelectedItem.Text, ddlCategory.SelectedItem.Value, txtAmount.Text, ddlPaidBy.SelectedItem.Text, ddlPaidBy.SelectedItem.Value,
                    txtPaidTo.Text, ddlPaymentMethod.SelectedItem.Text, txtExpenseDate.Text, txtDetails.Text);
                    string textmsg = " Expence Added Successfully";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    ddlCategory.SelectedIndex = 0;
                    txtAmount.Text = string.Empty;
                    ddlPaidBy.SelectedIndex = 0;
                    txtPaidTo.Text = string.Empty;
                    ddlPaymentMethod.SelectedIndex = 0;
                    txtExpenseDate.Text = string.Empty;
                    txtDetails.Text = string.Empty;
                    btnExpenses.Visible = true;
                    btnSaveChenges.Visible = false;
                }
                else
                {
                    string errormsg = "Please Select property name";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
                }

            }
            else
            {
                string errormsg = "Please Select property name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
            }


        }
        catch (Exception Ex)
        {
            string exrmsg = Ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + exrmsg + "')</script>", false);
        }

    }
    protected void btnAddCetgory_Click(object sender, EventArgs e)
    {
        category.Visible = true;
        btnCate.Visible = true;
        btnhide.Visible = false;
    }
    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtCategory.Text.Length > 0)
            {
                uc.AddCategory(txtCategory.Text);
                string textmsg = " Category Added Successfully";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                txtCategory.Text = string.Empty;
                category.Visible = false;
                btnCate.Visible = false;
                btnhide.Visible = true;
                Gf.FillCategory("ec_id", "ex_categoryname", "ExpenseCategory", ddlCategory, "");
            }
            else
            {
                string txtmsg = "Please Enter Category Name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + txtmsg + "')</script>", false);
            }

        }
        catch (Exception ex)
        {
            string exxmsg = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + exxmsg + "')</script>", false);
        }

    }
    protected void btnViewExpenses_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Expenses.aspx");
    }
    protected void btnSaveChenges_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory.SelectedItem.Value != "0")
            {
                string e_id = Request.QueryString["e_id"].ToString();
                ed.UpdateExpence(e_id, ddlCategory.SelectedItem.Text, ddlCategory.SelectedItem.Value, txtAmount.Text, ddlPaidBy.SelectedItem.Text, ddlPaidBy.SelectedItem.Value, txtPaidTo.Text, ddlPaymentMethod.SelectedItem.Text, txtExpenseDate.Text, txtDetails.Text);
                string textmsg = " Expence Update Successfully";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                ddlCategory.SelectedIndex = 0;
                txtAmount.Text = string.Empty;
                ddlPaidBy.SelectedIndex = 0;
                txtPaidTo.Text = string.Empty;
                ddlPaymentMethod.SelectedIndex = 0;
                txtExpenseDate.Text = string.Empty;
                txtDetails.Text = string.Empty;
                btnExpenses.Visible = false;
                btnSaveChenges.Visible = true;

            }
            else
            {
                string errormsg = "Please Select Category name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
            }


        }
        catch (Exception Ex)
        {
            string exrmsg = Ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + exrmsg + "')</script>", false);
        }
    }
}