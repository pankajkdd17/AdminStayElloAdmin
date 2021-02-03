using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_login : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    UserClass Um = new UserClass();
    AddUsers us = new AddUsers();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
        }
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtmobile.Text.Length > 0)
            {
                SqlDataReader ds = us.GetUserDetails(txtmobile.Text , txtpass.Text);
               
                    if (ds.HasRows)
                    {
                        if (ds.Read())
                        {
                            HttpContext.Current.Session["s_id"] = ds["s_id"];
                            HttpContext.Current.Session["s_Name"] = ds["s_Name"].ToString();
                            HttpContext.Current.Session["s_MobileNo"] = ds["s_MobileNo"].ToString();
                            HttpContext.Current.Session["s_PanNo"] = ds["s_PanNo"].ToString();
                            HttpContext.Current.Session["s_AdhaarNo"] = ds["s_AdhaarNo"].ToString();
                            HttpContext.Current.Session["s_DateOfJoining"] = ds["s_DateOfJoining"].ToString();
                            Response.Redirect("~/Content/Home.aspx");
                        }
                        ds.Close();
                    }
                    else
                    {
                        lblmsg.Text = "This phone number or password incorrect please contact to admin !";
                    }
            }
            else
            {
                lblmsg.Text = "Please Enter Valide Mobile No.!";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
    }
}