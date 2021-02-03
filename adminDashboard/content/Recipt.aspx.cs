using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Recipt : System.Web.UI.Page
{
    DuesRecipt dueRecipt = new DuesRecipt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["s_MobileNo"] != null)
        {
            if (Request.QueryString["d_id"] != null)
            {
                string d_id = Request.QueryString["d_id"].ToString();
                GetReportData(d_id);
            }
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
               
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
        }
        else
        {
            Response.Redirect("~/content/login.aspx");
        }
    }

    private void GetReportData(string d_id)
    {
        try
        {
            string PropertyVale = Session["propertyvalue"].ToString();
            SqlDataReader sdr = dueRecipt.getReciptoFTenants(d_id, PropertyVale);
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                   // select d_id, d_prpertyname, d_prpertyvalue, d_PayeeText, d_PayeeValue, d_RoomNo, d_t_Mobile, d_DuesTypeText, d_DuesTypeValue, d_recivedAmount, d_DuesAmount, CONVERT(varchar, d_reciveddate, 103 ) as d_reciveddate , CONVERT(varchar, d_reciveddate, 103) as d_reciveddate ,  CONVERT(varchar, d_DuesMonth, 103) as d_DuesMonth ,  d_Remark ,convert(varchar, d_crdate, 103) as d_crdate ,d_mdfydate from  Dues where  d_prpertyvalue = '" + propertyVale + "' and d_id = '" + d_id + "' and d_status = 'recived' "
                    lblPgName.Text = sdr["d_prpertyname"].ToString();
                    lbldateTime.Text = sdr["d_reciveddate"].ToString();
                    lblReciptNo.Text = sdr["d_id"].ToString();
                    lblpgAddress.Text = sdr["p_address"].ToString();
                    lblTenantsName.Text = sdr["d_PayeeText"].ToString();
                    lblPhone.Text = sdr["d_t_Mobile"].ToString();
                    lblRoomNo.Text = sdr["d_RoomNo"].ToString();
                    lblpgNamee.Text = sdr["d_prpertyname"].ToString();
                    lblSrNo.Text = "1";
                    lblDueType.Text = sdr["d_DuesTypeText"].ToString();
                    lblDueMonth.Text = sdr["d_DuesMonth"].ToString();
                    lblDueAmount.Text = sdr["d_recivedAmount"].ToString();
                    lblPgName.Text = sdr["d_prpertyname"].ToString();
                    lblDueAmountSubTotal.Text = sdr["d_recivedAmount"].ToString();
                    lblTotalDueAmount.Text = sdr["d_recivedAmount"].ToString();
                }
                sdr.Close();
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }

    }
}