using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddLeads : System.Web.UI.Page
{
    EditData ed = new EditData();
    AddUsers uc = new AddUsers();
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
                btnLeads.Visible = true;
                btnSaveChenges.Visible = false;


                if (Request.QueryString["l_id"] != null)
                {
                    string l_id = Request.QueryString["l_id"].ToString();
                    LoadLeads(l_id);
                    btnLeads.Visible = false;
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

    private void LoadLeads(string l_id)
    {
        SqlDataReader sdr = ed.GetLeads(l_id);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {

                txtName.Text = sdr["l_Name"].ToString();
                txtMobileNo.Text = sdr["l_MobileNo"].ToString();
                txtParentName.Text = sdr["l_ParentName"].ToString();
                txtParentMobile.Text = sdr["l_ParentMobile"].ToString();
                txtAmountRecieved.Text = sdr["l_AmountRecieved"].ToString();
                ddlGender.SelectedItem.Text = sdr["l_Gender"].ToString();
                txtRentAmount.Text = sdr["l_RentAmount"].ToString();
                ddlRoomtypepreferred.SelectedItem.Text = sdr["l_Roomtypepreferred"].ToString();
                ddlStatus.SelectedItem.Text = sdr["l_Status"].ToString();
                txtComments.Text = sdr["l_Comments"].ToString();

                string ac = sdr["l_Ac"].ToString();
                if (ac == "AC")
                {
                    chbAC.Checked = true;
                }
                else
                {
                    chbAC.Checked = false;
                }

                string l_Ventilation = sdr["l_Ventilation"].ToString();
                if (l_Ventilation == "Ventilation")
                {
                    chbVentilation.Checked = true;
                }
                else
                {
                    chbVentilation.Checked = false;
                }
                string l_Washroom = sdr["l_Washroom"].ToString();
                if (l_Washroom == "Washroom Attached")
                {
                    chbWashroom.Checked = true;
                }
                else
                {
                    chbWashroom.Checked = false;
                }
                string l_LargeRoom = sdr["l_LargeRoom"].ToString();
                if (l_LargeRoom == "Large Room")
                {
                    chbLargeRoom.Checked = true;
                }
                else
                {
                    chbLargeRoom.Checked = false;
                }
                string l_Balcony = sdr["l_Balcony"].ToString();
                if (l_Balcony == "Balcony")
                {
                    chbBalcony.Checked = true;
                }
                else
                {
                    chbBalcony.Checked = false;
                }
                string CornerRooms = sdr["l_CornerRoom"].ToString();
                if (CornerRooms == "Corner Room")
                {
                    chbCornerRoom.Checked = true;
                }
                else
                {
                    chbCornerRoom.Checked = false;
                }
                btnLeads.Visible = false;
                btnSaveChenges.Visible = true;
            }
        }
        sdr.Close();
    }
    protected void btnLeads_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text.Length > 0)
            {
                DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                string PropertyName = ddlPropertyName.SelectedItem.Text;
                string PropertyVale = ddlPropertyName.SelectedValue;
                if (PropertyVale != "0")
                {
                    string Ac = chbAC.Checked ? "AC" : "Non AC";
                    string Ventilation = chbVentilation.Checked ? "Ventilation" : "No Ventilation";
                    string Washroom = chbWashroom.Checked ? "Washroom Attached" : "Washroom Common";
                    string LargeRoom = chbLargeRoom.Checked ? "Large Room" : "Medium Room";
                    string Balcony = chbBalcony.Checked ? "Balcony" : "No Balcony";
                    string CornerRoom = chbCornerRoom.Checked ? "Corner Room" : "No Corner Room";
                    string mobile = Session["s_MobileNo"].ToString();
                    uc.AddLeads(mobile, PropertyName, PropertyVale, txtName.Text, txtMobileNo.Text, txtParentName.Text, txtParentMobile.Text, txtAmountRecieved.Text, ddlGender.SelectedItem.Text, txtRentAmount.Text, ddlRoomtypepreferred.SelectedItem.Text, Ac, Ventilation, Washroom, LargeRoom, Balcony, CornerRoom, ddlStatus.SelectedItem.Text, txtComments.Text);
                    string textmsg = "Leads Added Successfully !";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    txtName.Text = string.Empty;
                    txtMobileNo.Text = string.Empty;
                    txtParentName.Text = string.Empty;
                    txtAmountRecieved.Text = string.Empty;
                    ddlGender.SelectedIndex = 0;
                    txtRentAmount.Text = string.Empty;
                    txtParentMobile.Text = string.Empty;
                    ddlRoomtypepreferred.SelectedIndex = 0;
                    ddlStatus.SelectedIndex = 0;
                    chbAC.Checked = false;
                    chbVentilation.Checked = false;
                    chbLargeRoom.Checked = false;
                    chbBalcony.Checked = false;
                    chbCornerRoom.Checked = false;
                }
                else
                {
                    string errormsg = "Please Select property name";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errormsg + "')</script>", false);
                }
            }
            else
            {
                string text = "Please Enter Name ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }

    }
    protected void btnViewLeads_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Leads.aspx");
    }
    protected void btnSaveChenges_Click(object sender, EventArgs e)
    {
        try
        {
            string Ac = chbAC.Checked ? "AC" : "Non AC";
            string Ventilation = chbVentilation.Checked ? "Ventilation" : "No Ventilation";
            string Washroom = chbWashroom.Checked ? "Washroom Attached" : "Washroom Common";
            string LargeRoom = chbLargeRoom.Checked ? "Large Room" : "Medium Room";
            string Balcony = chbBalcony.Checked ? "Balcony" : "No Balcony";
            string CornerRoom = chbCornerRoom.Checked ? "Corner Room" : "No Corner Room";

            string l_id = Request.QueryString["l_id"].ToString();
            ed.UpdateLeads(l_id, txtName.Text, txtMobileNo.Text, txtParentName.Text, txtParentMobile.Text, txtAmountRecieved.Text, ddlGender.SelectedItem.Text, txtRentAmount.Text, ddlRoomtypepreferred.SelectedItem.Text, Ac, Ventilation, Washroom, LargeRoom, Balcony, CornerRoom, ddlStatus.SelectedItem.Text, txtComments.Text);
            string textmsg = "Leads Updated Successfully !";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
            txtName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtParentName.Text = string.Empty;
            txtAmountRecieved.Text = string.Empty;
            ddlGender.SelectedIndex = 0;
            txtRentAmount.Text = string.Empty;
            ddlRoomtypepreferred.SelectedIndex = 0;
            txtParentMobile.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
            chbAC.Checked = false;
            chbWashroom.Checked = false;
            chbVentilation.Checked = false;
            chbLargeRoom.Checked = false;
            chbBalcony.Checked = false;
            chbCornerRoom.Checked = false;
            txtComments.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}