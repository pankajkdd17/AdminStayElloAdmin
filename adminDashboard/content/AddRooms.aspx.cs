using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddRooms : System.Web.UI.Page
{
    EditData ed = new EditData();
    AddUsers uc = new AddUsers();
    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gf.FillFloorNo("f_id", "f_name", "tbl_FloorNo", ddlFloorNo, "");
            Gf.FillBedType("b_id", "b_name", "tbl_BedType", ddlBeds, "");
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
                btnSingleRooms.Visible = true;
                btnUpdateRooms.Visible = false;


                if (Request.QueryString["r_id"] != null)
                {
                    string r_id = Request.QueryString["r_id"].ToString();
                    LoadRooms(r_id);
                    btnSingleRooms.Visible = false;
                    btnUpdateRooms.Visible = true;
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

    private void LoadRooms(string r_id)
    {
        try
        {
            SqlDataReader sdr = ed.GetRooms(r_id);
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    txtRoomNo.Text = sdr["r_roomNo"].ToString();
                    ddlFloorNo.SelectedItem.Text = sdr["r_FloorNoText"].ToString();
                    ddlBeds.SelectedItem.Text = sdr["r_BedsText"].ToString();
                    ddlBeds.SelectedItem.Value = sdr["r_BedsValue"].ToString();
                    ddlFloorNo.SelectedItem.Value = sdr["r_FloorNovalue"].ToString();
                    txtRent.Text = sdr["r_Rent"].ToString();
                    txtSecurityDeposit.Text = sdr["r_SecurityDeposit"].ToString();
                    txtRemark.Text = sdr["r_Remark"].ToString();
                    string ac = sdr["r_Ac"].ToString();
                    if (ac.Length > 0)
                    {
                        chbAC.Checked = true;
                    }
                    else
                    {
                        chbAC.Checked = false;
                    }
                    string r_NonAC = sdr["r_NonAC"].ToString();
                    if (r_NonAC.Length > 0)
                    {
                        chbNonAC.Checked = true;
                    }
                    else
                    {
                        chbNonAC.Checked = false;
                    }
                    string r_Ventilation = sdr["r_Ventilation"].ToString();
                    if (r_Ventilation.Length > 0)
                    {
                        chbVentilation.Checked = true;
                    }
                    else
                    {
                        chbVentilation.Checked = false;
                    }
                    string r_Washroom = sdr["r_Washroom"].ToString();
                    if (r_Washroom.Length > 0)
                    {
                        chbWashroom.Checked = true;
                    }
                    else
                    {
                        chbWashroom.Checked = false;
                    }
                    string r_LargeRoom = sdr["r_LargeRoom"].ToString();
                    if (r_LargeRoom.Length > 0)
                    {
                        chbLargeRoom.Checked = true;
                    }
                    else
                    {
                        chbLargeRoom.Checked = false;
                    }
                    string r_Balcony = sdr["r_Balcony"].ToString();
                    if (r_Balcony.Length > 0)
                    {
                        chbBalcony.Checked = true;
                    }
                    else
                    {
                        chbBalcony.Checked = false;
                    }
                    string r_WiFi = sdr["r_WiFi"].ToString();
                    if (r_WiFi.Length > 0)
                    {
                        chbCornerRoom.Checked = true;
                    }
                    else
                    {
                        chbCornerRoom.Checked = false;
                    }
                    btnSingleRooms.Visible = false;
                    btnUpdateRooms.Visible = true;
                }
            }
            sdr.Close();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnSaveMultipleRooms_Click(object sender, EventArgs e)
    {

    }
    protected void btnSingleRooms_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtRoomNo.Text.Length == 1)
            {
                string roomNo = "" + ddlFloorNo.SelectedItem.Value.ToString().Trim() + "" + txtRoomNo.Text.ToString().Trim().PadLeft(2, '0').Trim() + "";
                if (checkDuplicateRoomNO() == false)
                {
                    string mobile = Session["s_MobileNo"].ToString();
                    DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                    string PropertyName = ddlPropertyName.SelectedItem.Text;
                    string PropertyVale = ddlPropertyName.SelectedItem.Value;
                    if (ddlPropertyName.SelectedItem.Value != "0")
                    {
                        string Ac = chbAC.Checked ? "AC" : "";
                        string NonAC = chbNonAC.Checked ? "Non AC" : "";
                        string Ventilation = chbVentilation.Checked ? "Ventilation" : "";
                        string Washroom = chbWashroom.Checked ? "Washroom" : "";
                        string LargeRoom = chbLargeRoom.Checked ? "Large Room" : "";
                        string Balcony = chbBalcony.Checked ? "Balcony" : "";
                        string CornerRoom = chbCornerRoom.Checked ? "Corner Room" : "";
                        string WiFi = chbWifi.Checked ? "Wifi" : "";

                        uc.AddRooms(mobile, PropertyName, PropertyVale, roomNo, ddlFloorNo.SelectedItem.Text, ddlFloorNo.SelectedItem.Value, ddlBeds.SelectedItem.Text, ddlBeds.SelectedItem.Value, txtRent.Text, txtSecurityDeposit.Text, txtRemark.Text, Ac, NonAC, Ventilation, Washroom, LargeRoom, Balcony, CornerRoom, WiFi);
                        string textmsg = "Rooms " + roomNo + " inside " + PropertyName + " created  Successfully !";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                        txtRoomNo.Text = string.Empty;
                        txtRent.Text = string.Empty;
                        txtSecurityDeposit.Text = string.Empty;

                        btnSingleRooms.Visible = true;
                        btnUpdateRooms.Visible = false;
                    }
                    else
                    {
                        string text = "Please select Property Name";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                    }
                }
                else
                {
                    string text = "This Room No. " + roomNo + " Already Created Please Creat Another Room ;";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                }
            }
            else
            {
                string text = "Enter only one Digit(Like: 102 =2) of Room No  ;";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    private bool checkDuplicateRoomNO()
    {
        bool result = false;
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        string roomNo = "" + ddlFloorNo.SelectedItem.Value.ToString().Trim() + "" + txtRoomNo.Text.ToString().Trim().PadLeft(2, '0').Trim() + "";
        SqlDataReader sdr1 = uc.CheckRoomNo(PropertyVale, roomNo);
        if (sdr1.HasRows)
        {
            if (sdr1.Read())
            {
                string GetroomNo = sdr1["r_roomNo"].ToString();
                string text = "This Room No. " + GetroomNo + " Already Created Please Creat Another Room ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                result = true;
            }
            sdr1.Close();
        }
        return result;
    }

    protected void btnViewRooms_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Rooms.aspx");
    }

    protected void ddlFloorNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        string roomNo = "" + ddlFloorNo.SelectedItem.Value.ToString().Trim() + "" + txtRoomNo.Text.ToString().Trim().PadLeft(2, '0').Trim() + "";
        SqlDataReader sdr1 = uc.CheckRoomNo(PropertyVale, roomNo);
        if (sdr1.HasRows)
        {
            if (sdr1.Read())
            {
                string roomNoo = sdr1["r_roomNo"].ToString();
                string text = "This Room No. " + roomNoo + " Already Created Please Creat Another Room ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);

            }
        }
        sdr1.Close();
    }
    protected void txtRoomNo_TextChanged(object sender, EventArgs e)
    {
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        string roomNo = "" + ddlFloorNo.SelectedValue.ToString().Trim() + "" + txtRoomNo.Text.ToString().Trim().PadLeft(2, '0').Trim() + "";
        SqlDataReader sdr1 = uc.CheckRoomNo(PropertyName, roomNo);
        if (sdr1.HasRows)
        {
            if (sdr1.Read())
            {
                string roomNoo = sdr1["r_roomNo"].ToString();
                string text = "This Room No. " + roomNoo + " Already Created Please Create Another Room ";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);

            }
        }
        sdr1.Close();
    }
    protected void btnUpdateRooms_Click(object sender, EventArgs e)
    {
        try
        {

            if (checkDuplicateRoomNO() == false)
            {
                DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                string PropertyName = ddlPropertyName.SelectedItem.Text;
                string PropertyVale = ddlPropertyName.SelectedItem.Value;
                if (ddlPropertyName.SelectedItem.Value != "0")
                {
                    string Ac = chbAC.Checked ? "AC" : "";
                    string NonAC = chbNonAC.Checked ? "Non AC" : "";
                    string Ventilation = chbVentilation.Checked ? "Ventilation" : "";
                    string Washroom = chbWashroom.Checked ? "Washroom" : "";
                    string LargeRoom = chbLargeRoom.Checked ? "Large Room" : "";
                    string Balcony = chbBalcony.Checked ? "Balcony" : "";
                    string CornerRoom = chbCornerRoom.Checked ? "Corner Room" : "";
                    string WiFi = chbWifi.Checked ? "Wifi" : "";
                    string r_id = Request.QueryString["r_id"].ToString();
                    string roomNo = "" + ddlFloorNo.SelectedItem.Value.ToString().Trim() + "" + txtRoomNo.Text.ToString().Trim().Substring(2, 1).PadLeft(2, '0').Trim() + "";
                    ed.UpdateRooms(r_id, PropertyName, PropertyVale, roomNo, ddlFloorNo.SelectedItem.Text, ddlFloorNo.SelectedItem.Value, ddlBeds.SelectedItem.Text, ddlBeds.SelectedItem.Value, txtRent.Text, txtSecurityDeposit.Text, txtRemark.Text, Ac, NonAC, Ventilation, Washroom, LargeRoom, Balcony, CornerRoom, WiFi);
                    string textmsg = "Rooms " + txtRoomNo.Text + " inside " + PropertyName + " Updated  Successfully !";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    txtRoomNo.Text = string.Empty;
                    txtRent.Text = string.Empty;
                    txtSecurityDeposit.Text = string.Empty;
                    btnSingleRooms.Visible = false;
                    btnUpdateRooms.Visible = true;
                }
                else
                {
                    string text = "Please select Property Name";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                }
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}