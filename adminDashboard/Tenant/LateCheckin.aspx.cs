﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tenant_LateCheckin : System.Web.UI.Page
{
    Tenants tenants = new Tenants();
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
                        GetLateCheckin();
                    }
                    else
                    {
                        GetLateCheckin();
                    }
                }
                else
                {
                    Session["propertyvalue"] = "0";
                    GetLateCheckin();
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

    private void GetLateCheckin()
    {
        try
        {
            if (Session["propertyvalue"] != null)
            {
                string PropertyVale = Session["propertyvalue"].ToString();
                gvLateCheckin.DataSource = tenants.GetLateCheckinRecord(PropertyVale);
                gvLateCheckin.DataBind();
            }
            else
            {
                Session["propertyvalue"] = "0";
            }
        }
        catch (Exception ex)
        {
            string errorMsg = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + errorMsg + "')</script>", false);
        }
    }

    private void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            gvLateCheckin.DataSource = tenants.GetLateCheckinRecord(PropertyVale);
            gvLateCheckin.DataBind();

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

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            gvLateCheckin.DataSource = tenants.GetLateCheckinRecordBySearch(PropertyVale , txtSearch.Text);
            gvLateCheckin.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

    protected void lbtSearchTenantsLateCheckin_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
            string PropertyName = ddlPropertyName.SelectedItem.Text;
            string PropertyVale = ddlPropertyName.SelectedItem.Value;
            gvLateCheckin.DataSource = tenants.GetLateCheckinRecordBySearch(PropertyVale, txtSearch.Text);
            gvLateCheckin.DataBind();
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }

   
    protected void btnExportExcel_Click(object sender, EventArgs e)
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
            string FileName = "LateCheckIn" + PropertyName + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvLateCheckin.GridLines = GridLines.Both;
            gvLateCheckin.HeaderStyle.Font.Bold = true;
            gvLateCheckin.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
        }
    }
}