using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddPropertyStartingPrice : System.Web.UI.Page
{
    MasterData md = new MasterData();
    AddUsers uc = new AddUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                ddlProperty.DataSource = md.GetPropertyList();
                ddlProperty.DataBind();
                ddlProperty.DataTextField = "p_name";
                ddlProperty.DataValueField = "p_id";
                ddlProperty.DataBind();

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
                btnSavePropertyStratingPrice.Visible = true;
                btnSaveChenge.Visible = false;


                if (Request.QueryString["r_id"] != null)
                {
                    string r_id = Request.QueryString["r_id"].ToString();
                    LoadPriceStarting(r_id);
                    btnSavePropertyStratingPrice.Visible = false;
                    btnSaveChenge.Visible = true;
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

    private void LoadPriceStarting(string r_id)
    {
        //throw new NotImplementedException();
    }
    protected void btnSavePropertyStratingPrice_Click(object sender, EventArgs e)
    {
        try
        {
            if (checkDublicateRoomNO() == false)
            {
                string mobile = Session["s_MobileNo"].ToString();
                if (ddlProperty.SelectedItem.Value != "0")
                {
                    string acNonAc = rdbtnAcNonAC.Checked ? "AC" : "NON-AC";
                    uc.AddPropertyStartingPrice(mobile, ddlProperty.SelectedItem.Text, ddlProperty.SelectedItem.Value, acNonAc, txtRoomSharingType.Text.ToUpper(), txtStartingPrice.Text);
                    string textmsg = "Rooms Types " + txtRoomSharingType.Text + " starting price " + txtStartingPrice.Text + " added  Successfully !";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                    txtRoomSharingType.Text = string.Empty;
                    txtStartingPrice.Text = string.Empty;
                    btnSavePropertyStratingPrice.Visible = true;
                    btnSaveChenge.Visible = false;
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
    private bool checkDublicateRoomNO()
    {
        bool result = false;
        string acNonAc = rdbtnAcNonAC.Checked ? "AC" : "NON-AC";
        SqlDataReader sdr = uc.CheckRoomType(ddlProperty.SelectedItem.Value, acNonAc , txtRoomSharingType.Text.ToUpper() );
        if(sdr.HasRows)
        {
            if(sdr.Read())
            {
                string AcNonAc = sdr["sp_AcNonAC"].ToString();
                string propertyName = sdr["sp_PropertyName"].ToString();
                string roomType = sdr["sp_RoomStartingRoomType"].ToString();
                string startingPrice = sdr["sp_RoomStartingPrice"].ToString();
                string text = "This "+ propertyName + " with "+ AcNonAc + " Room Type "+ roomType + " starting price "+ startingPrice + " already exist";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                result = true;
            }
            sdr.Close();
        }
        else
        {
            result = false;
        }
        return result;
    }

    protected void btnSaveChenge_Click(object sender, EventArgs e)
    {

    }

    protected void btnViewProperty_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/MyProperties.aspx");
    }
}