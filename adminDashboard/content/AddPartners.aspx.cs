using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddPartners : System.Web.UI.Page
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
                btnSaveChenge.Visible = true;
                btnSaveChenge.Visible = false;


                if (Request.QueryString["p_id"] != null)
                {
                    string p_id = Request.QueryString["p_id"].ToString();
                    LoadPartner(p_id);
                    btnPartners.Visible = false;
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

    private void LoadPartner(string p_id)
    {
        SqlDataReader sdr = ed.Getpartner(p_id);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                txtName.Text = sdr["p_name"].ToString();
                txtMobileNo.Text = sdr["p_mobile"].ToString();
                txtDateOfJoining.Text = sdr["p_doj"].ToString();
                txtDetails.Text = sdr["p_details"].ToString();
                btnPartners.Visible = false;
                btnSaveChenge.Visible = true;
            }
        }
        sdr.Close();
    }
    protected void btnPartners_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text.Length > 0)
            {
                string mobile = Session["s_MobileNo"].ToString();
                uc.AddPartner(mobile,txtName.Text, txtMobileNo.Text, txtDateOfJoining.Text, txtDetails.Text);
                string textmsg = "" + txtName.Text + " Now Partner with Stayello Successfully added !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                txtName.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                txtDateOfJoining.Text = string.Empty;
                txtDetails.Text = string.Empty;
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
    protected void btnViewPartners_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Partners.aspx");
    }
    protected void btnSaveChenge_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text.Length > 0)
            {
                string p_id = Request.QueryString["p_id"].ToString();
                ed.UpdatePartner(p_id, txtName.Text, txtMobileNo.Text, txtDateOfJoining.Text, txtDetails.Text);
                string textmsg = "" + txtName.Text + " Now Partner with Stayello Successfully added !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                txtName.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                txtDateOfJoining.Text = string.Empty;
                txtDetails.Text = string.Empty;
                btnPartners.Visible = false;
                btnSaveChenge.Visible = true;
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
}