using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddStaffs : System.Web.UI.Page
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
                btnStaffs.Visible = true;
                btnSaveChenge.Visible = false;


                if (Request.QueryString["s_id"] != null)
                {
                    string s_id = Request.QueryString["s_id"].ToString();
                    LoadStaff(s_id);
                    btnStaffs.Visible = false;
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

    private void LoadStaff(string s_id)
    {
        SqlDataReader sdr = ed.GetStaff(s_id);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {

                txtName.Text = sdr["s_Name"].ToString();
                txtMobileNo.Text = sdr["s_MobileNo"].ToString();
                txtAdhaarNo.Text = sdr["s_AdhaarNo"].ToString();
                txtPanNo.Text = sdr["s_PanNo"].ToString();
                txtFullAddress.Text = sdr["s_FullAddress"].ToString();
                txtDateOfJoining.Text = sdr["s_DateOfJoining"].ToString();

                btnStaffs.Visible = false;
                btnSaveChenge.Visible = true;
            }
        }
        sdr.Close();
    }
    protected void btnStaffs_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text.Length > 0)
            {
                string mobile = Session["s_MobileNo"].ToString();
                uc.AddStaff(mobile, txtName.Text, txtMobileNo.Text, txtAdhaarNo.Text, txtPanNo.Text, txtFullAddress.Text, txtDateOfJoining.Text, txtpass.Text);
                string textmsg = "" + txtName.Text + " Added Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                txtName.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                txtAdhaarNo.Text = string.Empty;
                txtPanNo.Text = string.Empty;
                txtFullAddress.Text = string.Empty;
                txtDateOfJoining.Text = string.Empty;
                btnStaffs.Visible = true;
                btnSaveChenge.Visible = false;
                sendotp();
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

    protected void sendotp()
    {

        string numbers = txtMobileNo.Text;
        Random rand = new Random();
        // string apikey = "m6PQ8S6Ivr4-v7VgZ9cmflrCh8TxDnrz8n9iNbZGRr";
        string sentsendpass = "" + txtpass.Text + " is your Password to login to your Admin stayello platform.";
        //string senders = "TXTLCL";
        string senders = "STAYLO";
        String url = "http://37.59.76.46/api/mt/SendSMS?user=STAYLO&password=8604@sms&senderid=" + senders + "&channel=TRANS&DCS=0&flashsms=0&number=" + numbers + "&text=" + sentsendpass + "&route=02";
        // String url = "https://api.textlocal.in/send/?apikey=" + apikey + "&numbers=" + numbers + "&message=" + sentOtp + "&sender=" + senders;
        //Store the OTP in session to verify in next page.
        //If you want to verify from DB store the OTP in DB for verification. But it will take space
        try
        {
            //Create the request and send data to Ozeki NG SMS Gateway Server by HTTP connection;

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();

            //inform the user
            // lblmessage.Text = responseString;
            lblmessage.Text = "Password send successfully !";
            lblmessage.ForeColor = System.Drawing.Color.Green;
            lblmessage.Visible = true;

        }
        catch (Exception ex)
        {
            //if sending request or getting response is not successful, Ozeki NG - SMS Gateway Server may not be running
            lblmessage.Text = ex.Message.ToString();
            lblmessage.ForeColor = System.Drawing.Color.Blue;
            lblmessage.Visible = true;
        }


    }

    protected void btnViewStaff_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/Staffs.aspx");
    }
    protected void btnSaveChenge_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtName.Text.Length > 0)
            {
                string s_id = Request.QueryString["s_id"].ToString();
                ed.UpdateStaff(s_id, txtName.Text, txtMobileNo.Text, txtAdhaarNo.Text, txtPanNo.Text, txtFullAddress.Text, txtDateOfJoining.Text);
                string textmsg = "" + txtName.Text + " Updated Successfully !";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                txtName.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                txtAdhaarNo.Text = string.Empty;
                txtPanNo.Text = string.Empty;
                txtFullAddress.Text = string.Empty;
                txtDateOfJoining.Text = string.Empty;
                btnStaffs.Visible = false;
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