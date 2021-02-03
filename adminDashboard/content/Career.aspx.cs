using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Career : System.Web.UI.Page
{
    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
    string edit;
    AddUsers uc = new AddUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                ShowCareer();
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
    public void ShowCareer()
    {
        ListView1.DataSource = uc.ShowCareer();
        ListView1.DataBind();
    }
    protected void Gvw_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Download")
            {
                string c_id = e.CommandArgument.ToString();
                //string vr_VehicleRegistrationNo = VehicleRegistrationNo.Replace("'", string.Empty);
                SqlDataReader sdr = uc.GetFile(c_id);
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        string file = sdr["c_pathUploadCv"].ToString();
                        Response.Redirect("http://www.stayello.com/" + file + "");
                    }
                    else
                    {
                        string text = "File Not Uploded";
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
    public void callurl(string url)
    {
        WebRequest request = HttpWebRequest.Create(url);
        WebResponse response = request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string urlText = reader.ReadToEnd(); // it takes the response from your url. now you can use as your need  
        Response.Write(urlText.ToString());
    }
    protected void lbtSearchCareer_Click(object sender, EventArgs e)
    {
        ListView1.DataSource = uc.getCareer(txtSearch.Text);
        ListView1.DataBind();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        ListView1.DataSource = uc.getCareer(txtSearch.Text);
        ListView1.DataBind();
    }
}