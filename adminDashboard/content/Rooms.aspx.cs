using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Rooms : System.Web.UI.Page
{
    Dashboard dd = new Dashboard();
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();
    Delete dt = new Delete();
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
                        // Session.Remove("propertyvalue");
                        ShowRooms();
                        showCountBed();
                    }
                    else
                    {
                        ShowRooms();
                        showCountBed();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    ShowRooms();
                    showCountBed();
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

    private void showCountBed()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
                SqlDataReader sdr1 = dd.getRooms(PropertyVale);
                if (sdr1.HasRows)
                {
                    sdr1.Read();
                    lblTotalRooms.Text = sdr1["Room"].ToString();
                }
                sdr1.Close();


                SqlDataReader sdr20 = dd.getRoomCountVacant(PropertyVale);
                if (sdr20.HasRows)
                {
                    sdr20.Read();
                    lblVacent.Text = sdr20["Vacant"].ToString();
                    Session["Vacent"] = lblVacent.Text;
                }
                sdr20.Close();
                DataSet ds = dd.getRoomNo(PropertyVale);

                int sum = 0;
                int tblCount = ds.Tables.Count;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string romNo = dr["r_RoomNo"].ToString();
                    SqlDataReader sdr21 = dd.getRoomsFull(PropertyVale, romNo);
                    if (sdr21.HasRows)
                    {
                        sdr21.Read();
                        int count = Convert.ToInt16(sdr21["FullRoom"]);
                        sum = sum + count;
                        lblFull.Text = sum.ToString();
                        Session["Full"] = lblFull.Text;
                    }
                    sdr21.Close();
                }

                string absolutValue = Math.Abs(Convert.ToInt32(Session["Full"]) + Convert.ToInt32(Session["Vacent"])).ToString();
                SqlDataReader sdr22 = dd.getRoomSemiVacant(PropertyVale);
                if (sdr22.HasRows)
                {
                    sdr22.Read();
                    int count = Convert.ToInt16(sdr22["SemiVacant"]);
                    int Semivecent = count - Convert.ToInt32(absolutValue);
                    lblSemiOccupied.Text = Semivecent.ToString();
                }
                sdr22.Close();
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
    protected void btnAddNewRooms_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddRooms.aspx");
    }

    public void ShowRooms()
    {
        try
        {

            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
                ListView1.DataSource = uc.LoadRooms(PropertyVale);
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

    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            showCountBed();
            ListView1.DataSource = uc.LoadRooms(PropertyVale);
            ListView1.DataBind();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // Create an event handler for the master page's contentCallEvent event
        Master.contentCallEvent += new EventHandler(ddlProperty_SelectedIndexChanged);
    }
    protected void btnAddTenants_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddTenants.aspx");
    }
    protected void btnViewTenants_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Tenants.aspx");
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Edit")
            {
                string r_id = e.CommandArgument.ToString();
                Response.Redirect("AddRooms.aspx?r_id=" + r_id + "");
            }
            else if (e.CommandName == "Dlt")
            {
                DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
                string PropertyName = ddlPropertyName.SelectedItem.Text;
                string PropertyVale = ddlPropertyName.SelectedItem.Value;
                int r_id = Convert.ToInt32(e.CommandArgument);
                SqlDataReader sdr = ed.GetRommNo(r_id);
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        string roomNo = sdr["r_roomNo"].ToString();
                        SqlDataReader sdr2 = ed.GetTenantsInRooms(roomNo , PropertyVale);
                        if (sdr2.HasRows)
                        {
                            if (sdr2.Read())
                            {
                                string Tenants = sdr2["t_Name"].ToString();
                                string textmsg = "" + Tenants + " Tenants are exist in " + roomNo + " You can not delete it";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                            }
                            sdr2.Close();
                        }
                        else
                        {
                            dt.DeleteRoom(r_id , PropertyVale);
                            string textmsg = " Room " + roomNo + " Deleted Successfully !";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + textmsg + "')</script>", false);
                            ShowRooms();
                        }
                    }
                    sdr.Close();
                }

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
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            ListView1.DataSource = uc.getAllRooms(PropertyVale, txtSearch.Text);
            ListView1.DataBind();
        }
        catch(Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void lbtSearchRooms_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            ListView1.DataSource = uc.getAllRooms(PropertyVale, txtSearch.Text);
            ListView1.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}