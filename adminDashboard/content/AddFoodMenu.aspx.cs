using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddFoodMenu : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                if (Session["propertyvalue"] != null)
                {
                    if(Session["propertyvalue"].ToString() == "0")
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
                btnSaveChengeFoodMenu.Visible = false;
                if (Request.QueryString["f_id"] != null)
                {
                    string f_id = Request.QueryString["f_id"].ToString();
                    LoadFoodMenu(f_id);
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

    private void LoadFoodMenu(string f_id)
    {
        SqlDataReader sdr = ed.GetFoodMenu(f_id);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                ddlWeekdays.SelectedItem.Text = sdr["f_WeekdaysText"].ToString();
                // ddlWeekdays.SelectedItem.Value = sdr["f_WeekdaysValue"].ToString();
                txtBreakfast.Text = sdr["f_Breakfast"].ToString();
                txtBreakfastTime.Text = sdr["f_BreakfastTime"].ToString();
                txtBreakfastTimeTo.Text = sdr["f_BreakfastTimeto"].ToString();
                txtLunch.Text = sdr["f_Lunch"].ToString();
                txtLunchTime.Text = sdr["f_LunchTime"].ToString();
                txtLunchTimeTo.Text = sdr["f_LunchTimeTo"].ToString();
                txtSnacks.Text = sdr["f_Snacks"].ToString();
                txtSnacksTime.Text = sdr["f_SnacksTime"].ToString();
                txttxtSnacksTimeTo.Text = sdr["f_SnacksTimeTo"].ToString();
                txtDinner.Text = sdr["f_Dinner"].ToString();
                txtDinnarTime.Text = sdr["f_DinnarTime"].ToString();
                txtDinnerTimeTo.Text = sdr["f_DinnarTimeTo"].ToString();
                btnFoodMenu.Visible = false;
                btnSaveChengeFoodMenu.Visible = true;
            }
        }
        sdr.Close();
    }
    protected void btnFoodMenu_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckWeekday() == false)
            {
                if (ddlWeekdays.SelectedItem.Text.Length > 0)
                {
                    string mobile = Session["s_MobileNo"].ToString();
                    uc.AddFooMenu(mobile ,ddlWeekdays.SelectedItem.Value, ddlWeekdays.SelectedItem.Text, txtBreakfast.Text, txtBreakfastTime.Text, txtBreakfastTimeTo.Text, txtLunch.Text, txtLunchTime.Text, txtLunchTimeTo.Text, txtSnacks.Text, txtSnacksTime.Text, txttxtSnacksTimeTo.Text, txtDinner.Text, txtDinnarTime.Text, txtDinnerTimeTo.Text);
                    string textmsg = "" + ddlWeekdays.SelectedItem.Text + " Menu Added Successfully !";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    txtBreakfast.Text = string.Empty;
                    txtBreakfastTime.Text = string.Empty;
                    txtBreakfastTimeTo.Text = string.Empty;
                    txtLunch.Text = string.Empty;
                    txtLunchTime.Text = string.Empty;
                    txtLunchTimeTo.Text = string.Empty;
                    txtSnacks.Text = string.Empty;
                    txtSnacksTime.Text = string.Empty;
                    txttxtSnacksTimeTo.Text = string.Empty;
                    txtDinner.Text = string.Empty;
                    txtDinnarTime.Text = string.Empty;
                    txtDinnerTimeTo.Text = string.Empty;
                    btnFoodMenu.Visible = true;
                    btnSaveChengeFoodMenu.Visible = false;
                }
                else
                {
                    btnSaveChengeFoodMenu.Visible = true;
                }
            }

        }
        catch (Exception Ex)
        {
            string text = Ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void btnSaveChengeFoodMenu_Click(object sender, EventArgs e)
    {

        try
        {
            if (Session["f_id"] != null)
            {

                if (ddlWeekdays.SelectedItem.Text.Length > 0)
                {

                    string f_id = Session["f_id"].ToString();
                    uc.UpdateFooMenu(f_id, ddlWeekdays.SelectedItem.Text, ddlWeekdays.SelectedItem.Text, txtBreakfast.Text, txtBreakfastTime.Text, txtBreakfastTimeTo.Text, txtLunch.Text, txtLunchTime.Text, txtLunchTimeTo.Text, txtSnacks.Text, txtSnacksTime.Text, txttxtSnacksTimeTo.Text, txtDinner.Text, txtDinnarTime.Text, txtDinnerTimeTo.Text);
                    string textmsg = "" + ddlWeekdays.SelectedItem.Text + " Menu Updated Successfully !";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    txtBreakfast.Text = string.Empty;
                    txtBreakfastTime.Text = string.Empty;
                    txtBreakfastTimeTo.Text = string.Empty;
                    txtLunch.Text = string.Empty;
                    txtLunchTime.Text = string.Empty;
                    txtLunchTimeTo.Text = string.Empty;
                    txtSnacks.Text = string.Empty;
                    txtSnacksTime.Text = string.Empty;
                    txttxtSnacksTimeTo.Text = string.Empty;
                    txtDinner.Text = string.Empty;
                    txtDinnarTime.Text = string.Empty;
                    txtDinnerTimeTo.Text = string.Empty;
                    btnFoodMenu.Visible = false;
                    Session.Remove("f_id");
                    btnSaveChengeFoodMenu.Visible = true;
                }
            }
            else
            {
                if (CheckWeekday() == true)
                {
                    if (ddlWeekdays.SelectedItem.Text.Length > 0)
                    {

                        string f_id = Request.QueryString["f_id"].ToString();
                        uc.UpdateFooMenu(f_id, ddlWeekdays.SelectedItem.Text, ddlWeekdays.SelectedItem.Text, txtBreakfast.Text, txtBreakfastTime.Text, txtBreakfastTimeTo.Text, txtLunch.Text, txtLunchTime.Text, txtLunchTimeTo.Text, txtSnacks.Text, txtSnacksTime.Text, txttxtSnacksTimeTo.Text, txtDinner.Text, txtDinnarTime.Text, txtDinnerTimeTo.Text);
                        string textmsg = "" + ddlWeekdays.SelectedItem.Text + " Menu Updated Successfully !";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                        txtBreakfast.Text = string.Empty;
                        txtBreakfastTime.Text = string.Empty;
                        txtBreakfastTimeTo.Text = string.Empty;
                        txtLunch.Text = string.Empty;
                        txtLunchTime.Text = string.Empty;
                        txtLunchTimeTo.Text = string.Empty;
                        txtSnacks.Text = string.Empty;
                        txtSnacksTime.Text = string.Empty;
                        txttxtSnacksTimeTo.Text = string.Empty;
                        txtDinner.Text = string.Empty;
                        txtDinnarTime.Text = string.Empty;
                        txtDinnerTimeTo.Text = string.Empty;
                        btnFoodMenu.Visible = false;
                        btnSaveChengeFoodMenu.Visible = true;

                    }
                }
            }
        }
        catch (Exception Ex)
        {
            string text = Ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }

    }

    protected bool CheckWeekday()
    {
        bool result = false;
        SqlDataReader sdr = uc.getWeekdays(ddlWeekdays.SelectedItem.Text);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                btnFoodMenu.Visible = false;
                btnSaveChengeFoodMenu.Visible = true;
                Session["f_id"] = sdr["f_id"].ToString();
                string f_id = Session["f_id"].ToString();
                LoadFoodMenu(f_id);
                result = true;
            }
            sdr.Close();
        }
        else
        {
            btnFoodMenu.Visible = true;
            btnSaveChengeFoodMenu.Visible = false;
            result = false;
        }
        return result;

    }
    protected void ddlWeekdays_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CheckWeekday() == true)
        {
            btnSaveChengeFoodMenu.Visible = true;
            btnFoodMenu.Visible = false;
        }
        else
        {
            btnFoodMenu.Visible = true;
            btnSaveChengeFoodMenu.Visible = false;
        }

    }
    protected void btnViewFoodMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/FoodMenu.aspx");
    }
}