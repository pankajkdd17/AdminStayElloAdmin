using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Globalization;

public partial class dashboard : System.Web.UI.Page
{
    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
    Reports getReports = new Reports();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                ReportVisible();
            }
            else
            {
                Response.Redirect("~/content/login.aspx");
            }

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }


    protected void ReportVisible()
    {
        btnDuesReportExport.Visible = false;
        btnIncomeReportExport.Visible = false;
        btnRoomsReportExport.Visible = false;
        btnTenantsReportExport.Visible = false;
    }

    protected void btnIncomeReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string propertyValue = Session["propertyvalue"].ToString();
                GridView2.DataSource = getReports.GetAllIncomeReportByProperty(propertyValue);
                GridView2.DataBind();
                int Row = GridView2.Rows.Count;
                GridView1.Visible = false;
                GridView2.Visible = true;
                GridView3.Visible = false;
                GridView4.Visible = false;

                btnDuesReportExport.Visible = false;
                btnIncomeReportExport.Visible = true;
                btnRoomsReportExport.Visible = false;
                btnTenantsReportExport.Visible = false;
            }
            else if (txtFromDate.Text.Length <= 0)
            {
                String DateNow = null;
                GridView2.DataSource = getReports.GetAllIncomeReport(DateNow);
                GridView2.DataBind();
                int Row = GridView2.Rows.Count;
                GridView1.Visible = false;
                GridView2.Visible = true;
                GridView3.Visible = false;
                GridView4.Visible = false;

                btnDuesReportExport.Visible = false;
                btnIncomeReportExport.Visible = true;
                btnRoomsReportExport.Visible = false;
                btnTenantsReportExport.Visible = false;
            }
            else
            {
                //String DateNow = DateTime.ParseExact(txtFromDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                GridView2.DataSource = getReports.GetAllIncomeReport(txtFromDate.Text);
                GridView2.DataBind();
                int Row = GridView2.Rows.Count;
                GridView1.Visible = false;
                GridView2.Visible = true;
                GridView3.Visible = false;
                GridView4.Visible = false;

                btnDuesReportExport.Visible = false;
                btnIncomeReportExport.Visible = true;
                btnRoomsReportExport.Visible = false;
                btnTenantsReportExport.Visible = false;
            }

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnRoomsReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string propertyValue = Session["propertyvalue"].ToString();
                GridView3.DataSource = getReports.GetAllRoomsReportByProperty(propertyValue);
                GridView3.DataBind();
                int Row = GridView3.Rows.Count;
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = true;
                GridView4.Visible = false;

                btnDuesReportExport.Visible = false;
                btnIncomeReportExport.Visible = false;
                btnRoomsReportExport.Visible = true;
                btnTenantsReportExport.Visible = false;
            }
           else if (txtFromDate.Text.Length <= 0)
            {
                String DateNow = null;
                GridView3.DataSource = getReports.GetAllRoomsReport(DateNow);
                GridView3.DataBind();
                int Row = GridView3.Rows.Count;
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = true;
                GridView4.Visible = false;

                btnDuesReportExport.Visible = false;
                btnIncomeReportExport.Visible = false;
                btnRoomsReportExport.Visible = true;
                btnTenantsReportExport.Visible = false;

            }
            else
            {
                //String DateNow = DateTime.ParseExact(txtFromDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                GridView3.DataSource = getReports.GetAllRoomsReport(txtFromDate.Text);
                GridView3.DataBind();
                int Row = GridView3.Rows.Count;
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = true;
                GridView4.Visible = false;

                btnDuesReportExport.Visible = false;
                btnIncomeReportExport.Visible = false;
                btnRoomsReportExport.Visible = true;
                btnTenantsReportExport.Visible = false;
                lblDate.Text = txtFromDate.Text;
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnDuesReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string propertyValue = Session["propertyvalue"].ToString();
                GridView1.DataSource = getReports.GetAllDuesReportbyProperty(propertyValue);
                GridView1.DataBind();
                int Row = GridView1.Rows.Count;
                GridView1.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;

                btnDuesReportExport.Visible = true;
                btnIncomeReportExport.Visible = false;
                btnRoomsReportExport.Visible = false;
                btnTenantsReportExport.Visible = false;
            }

            else if (txtFromDate.Text.Length <= 0)
            {
                String DateNow = null;
                GridView1.DataSource = getReports.GetAllDuesReport(DateNow);
                GridView1.DataBind();
                int Row = GridView1.Rows.Count;
                GridView1.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;

                btnDuesReportExport.Visible = true;
                btnIncomeReportExport.Visible = false;
                btnRoomsReportExport.Visible = false;
                btnTenantsReportExport.Visible = false;
            }
            else
            {
                ///String DateNow = DateTime.ParseExact(txtFromDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                GridView1.DataSource = getReports.GetAllDuesReport(txtFromDate.Text);
                GridView1.DataBind();
                int Row = GridView1.Rows.Count;
                GridView1.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;

                btnDuesReportExport.Visible = true;
                btnIncomeReportExport.Visible = false;
                btnRoomsReportExport.Visible = false;
                btnTenantsReportExport.Visible = false;
            }

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnDuesReportExport_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Due_" + PropertyName + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
    protected void btnIncomeReportExport_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Income_" + PropertyName + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView2.GridLines = GridLines.Both;
            GridView2.HeaderStyle.Font.Bold = true;
            GridView2.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnRoomsReportExport_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Rooms_" + PropertyName + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView3.GridLines = GridLines.Both;
            GridView3.HeaderStyle.Font.Bold = true;
            GridView3.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

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

            //DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            //string PropertyName = ddlPropertyName.SelectedItem.Text;
            //string PropertyVale = ddlPropertyName.SelectedItem.Value;
            //String DateNow = null;
            //GridView4.DataSource = getReports.GetAllTenantsReport(DateNow);
            //GridView4.DataBind();
            //int Row = GridView4.Rows.Count;
            //GridView1.Visible = false;
            //GridView2.Visible = false;
            //GridView3.Visible = false;
            //GridView4.Visible = true;

            //btnDuesReportExport.Visible = false;
            //btnIncomeReportExport.Visible = false;
            //btnRoomsReportExport.Visible = false;
            //btnTenantsReportExport.Visible = true;

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


    protected void btnTenantsReport_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string propertyValue = Session["propertyvalue"].ToString();
                GridView4.DataSource = getReports.GetAllTenantsReportByProperty(propertyValue);
                GridView4.DataBind();
                int Row = GridView4.Rows.Count;
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = true;

                btnDuesReportExport.Visible = false;
                btnIncomeReportExport.Visible = false;
                btnRoomsReportExport.Visible = false;
                btnTenantsReportExport.Visible = true;
            }
            else if (txtFromDate.Text.Length <= 0)
            {
                String DateNow = null;
                GridView4.DataSource = getReports.GetAllTenantsReport(DateNow);
                GridView4.DataBind();
                int Row = GridView4.Rows.Count;
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = true;

                btnDuesReportExport.Visible = false;
                btnIncomeReportExport.Visible = false;
                btnRoomsReportExport.Visible = false;
                btnTenantsReportExport.Visible = true;
            }
            else
            {
                //String DateNow = DateTime.ParseExact(txtFromDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                GridView4.DataSource = getReports.GetAllTenantsReport(txtFromDate.Text);
                GridView4.DataBind();
                int Row = GridView4.Rows.Count;
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = true;

                btnDuesReportExport.Visible = false;
                btnIncomeReportExport.Visible = false;
                btnRoomsReportExport.Visible = false;
                btnTenantsReportExport.Visible = true;
            }

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void btnTenantsReportExport_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Tenants_" + PropertyName + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView4.GridLines = GridLines.Both;
            GridView4.HeaderStyle.Font.Bold = true;
            GridView4.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void txtMonthfilter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string propertyvalue = Session["propertyvalue"].ToString();
            DateTime duedate = Convert.ToDateTime(txtMonthfilter.Text);
            string month = duedate.ToString("MMMM-yyyy");
            string propertyValue = Session["propertyvalue"].ToString();
            GridView2.DataSource = getReports.GetAllIncomeReportByPropertyAndProperty(propertyValue , month);
            GridView2.DataBind();
            int Row = GridView2.Rows.Count;
            GridView1.Visible = false;
            GridView2.Visible = true;
            GridView3.Visible = false;
            GridView4.Visible = false;

            btnDuesReportExport.Visible = false;
            btnIncomeReportExport.Visible = true;
            btnRoomsReportExport.Visible = false;
            btnTenantsReportExport.Visible = false;
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}