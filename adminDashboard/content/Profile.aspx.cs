using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_Profile : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    EditData ed = new EditData();
    Delete dt = new Delete();
    MasterData md = new MasterData();
    GeneralFunctions.GeneralFunctions generalFunctions = new GeneralFunctions.GeneralFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            generalFunctions.fillGender("g_id", "g_name", "tbl_Gender", ddlGender, "");
            if (Session["s_MobileNo"] != null)
            {
                if (Request.QueryString["p_id"] != null)
                {
                    string p_id = Request.QueryString["p_id"].ToString();
                    getPropert(p_id);
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

    private void getPropert(string p_id)
    {
        SqlDataReader sdr = ed.GetProperty(p_id);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {

                Image4.ImageUrl = "https://admin.stayello.com/" + sdr["p_image1Path"].ToString();
                Session["Image4"] = sdr["p_image1Path"].ToString();

                lblimg1.Text = sdr["p_imageName1"].ToString();
                Image5.ImageUrl = "https://admin.stayello.com/" + sdr["p_image2Path"].ToString();
                Session["Image5"] = sdr["p_image2Path"].ToString();

                lblimg2.Text = sdr["p_imageName2"].ToString();
                Image6.ImageUrl = "https://admin.stayello.com/" + sdr["p_image3Path"].ToString();
                Session["Image6"] =  sdr["p_image2Path"].ToString();
                lblimg3.Text = sdr["p_imageName3"].ToString();
                txtPropertyName.Text = sdr["p_name"].ToString();
                txtPropertyAddress.Text = sdr["p_address"].ToString();
                txtCity.Text = sdr["p_city"].ToString();
                txtpinCode.Text = sdr["p_pincode"].ToString();
                txtMapLink.Text = sdr["p_maplink"].ToString();
                txtManagerName.Text = sdr["p_mgName"].ToString();
                txtManagerPhone.Text = sdr["p_pgMobile"].ToString();
                ddlGender.SelectedItem.Text = sdr["p_gender"].ToString();
                ddlGender.SelectedItem.Value = sdr["p_gender"].ToString();
                txtStartPrice.Text = sdr["p_StartPrice"].ToString();
                txtDiscountPrice.Text = sdr["p_discountprice"].ToString();
                txtDiscountPercentage.Text = sdr["p_DicountPercent"].ToString();

            }
        }
    }
    protected void btnSaveChenges_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["p_id"] != null)
            {
                string p_id = Request.QueryString["p_id"].ToString();

                if (image1.HasFile && image2.HasFile && image3.HasFile)
                {
                    //image1
                    string fileExtensionimage1 = System.IO.Path.GetExtension(image1.FileName);
                    int fileSizeimage1 = image1.PostedFile.ContentLength;

                    string filenameimage1 = System.IO.Path.GetFileNameWithoutExtension(image1.FileName) + DateTime.Now.ToString("ddMMyyyyHHmmssms") + System.IO.Path.GetExtension(fileExtensionimage1);
                    image1.PostedFile.SaveAs(Server.MapPath("~/content/PropertyPhoto/") + filenameimage1);
                    string filepathimage1 = Server.MapPath("~/content/PropertyPhoto/");
                    string pathimage1 = "content/PropertyPhoto/" + filenameimage1;

                    //image2
                    string fileExtensionimage2 = System.IO.Path.GetExtension(image2.FileName);
                    int fileSizeimage2 = image2.PostedFile.ContentLength;

                    string filenameimage2 = System.IO.Path.GetFileNameWithoutExtension(image2.FileName) + DateTime.Now.ToString("ddMMyyyyHHmmssms") + System.IO.Path.GetExtension(fileExtensionimage2);
                    image2.PostedFile.SaveAs(Server.MapPath("~/content/PropertyPhoto/") + filenameimage2);
                    string filepathimage2 = Server.MapPath("~/content/PropertyPhoto/");
                    string pathimage2 = "content/PropertyPhoto/" + filenameimage2;

                    //image3
                    string fileExtensionimage3 = System.IO.Path.GetExtension(image3.FileName);
                    int fileSizeimage3 = image3.PostedFile.ContentLength;

                    string filenameimage3 = System.IO.Path.GetFileNameWithoutExtension(image3.FileName) + DateTime.Now.ToString("ddMMyyyyHHmmssms") + System.IO.Path.GetExtension(fileExtensionimage3);
                    image3.PostedFile.SaveAs(Server.MapPath("~/content/PropertyPhoto/") + filenameimage3);
                    string filepathimage3 = Server.MapPath("~/content/PropertyPhoto/");
                    string pathimage3 = "content/PropertyPhoto/" + filenameimage3;

                    if ((fileExtensionimage1 == ".jpeg") && (fileExtensionimage2 == ".jpeg") && (fileExtensionimage3 == ".jpeg") && (fileSizeimage1 >= 150) && (fileSizeimage2 >= 150) && (fileSizeimage3 >= 150))
                    {
                         //string mobile = Session["s_mobile"].ToString();
                        // string mobile = "8604365781";
                        ed.UpdatedProperty(p_id, txtPropertyName.Text, txtPropertyAddress.Text, txtCity.Text, txtpinCode.Text, txtMapLink.Text, txtManagerName.Text, txtManagerPhone.Text, ddlGender.SelectedItem.Text, txtStartPrice.Text, txtDiscountPrice.Text, txtDiscountPercentage.Text, filenameimage1, pathimage1, filenameimage2, pathimage2, filenameimage3, pathimage3);
                        string textmsg = "Property Updated Successfully !";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                        txtPropertyName.Text = string.Empty;
                        txtPropertyAddress.Text = string.Empty;
                        txtCity.Text = string.Empty;
                        txtpinCode.Text = string.Empty;
                        txtMapLink.Text = string.Empty;
                        txtManagerName.Text = string.Empty;
                        txtManagerPhone.Text = string.Empty;
                        txtStartPrice.Text = string.Empty;
                        txtDiscountPrice.Text = string.Empty;
                        txtDiscountPercentage.Text = string.Empty;
                        Image4.ImageUrl = string.Empty;
                        lblimg1.Text = string.Empty;
                        Image5.ImageUrl = string.Empty;
                        lblimg2.Text = string.Empty;
                        Image6.ImageUrl = string.Empty;
                        lblimg3.Text = string.Empty;
                    }
                    else
                    {
                        string text = "Image Extension must be .jpeg and image size must be 150kb above";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                        // lblError.Style.Add("display", "block");
                    }
                }
                else
                {


                    string filenameimage1 = lblimg1.Text;
                    string pathimage1 = Session["Image4"].ToString();
                    string filenameimage2 = lblimg2.Text;
                    string pathimage2 = Session["Image5"].ToString();
                    string filenameimage3 = lblimg3.Text;
                    string pathimage3 = Session["Image6"].ToString();
                    if ((filenameimage1.Length > 0) && (pathimage1.Length > 0) && (filenameimage2.Length > 0) && (pathimage2.Length > 0) && (filenameimage3.Length > 0) && (pathimage3.Length > 0))
                    {
                         //string mobile = Session["s_mobile"].ToString();
                        // string mobile = "8604365781";
                        ed.UpdatedProperty(p_id, txtPropertyName.Text, txtPropertyAddress.Text, txtCity.Text, txtpinCode.Text, txtMapLink.Text, txtManagerName.Text, txtManagerPhone.Text, ddlGender.SelectedValue, txtStartPrice.Text, txtDiscountPrice.Text, txtDiscountPercentage.Text, filenameimage1, pathimage1, filenameimage2, pathimage2, filenameimage3, pathimage3);
                        string textmsg = "Property Updated Successfully !";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                        txtPropertyName.Text = string.Empty;
                        txtPropertyAddress.Text = string.Empty;
                        txtCity.Text = string.Empty;
                        txtpinCode.Text = string.Empty;
                        txtMapLink.Text = string.Empty;
                        txtManagerName.Text = string.Empty;
                        txtManagerPhone.Text = string.Empty;
                        txtStartPrice.Text = string.Empty;
                        txtDiscountPrice.Text = string.Empty;
                        txtDiscountPercentage.Text = string.Empty;
                        Image4.ImageUrl = string.Empty;
                        lblimg1.Text = string.Empty;
                        Image5.ImageUrl = string.Empty;
                        lblimg2.Text = string.Empty;
                        Image6.ImageUrl = string.Empty;
                        lblimg3.Text = string.Empty;
                    }
                    else
                    {
                        string textmsg = "Image and path are missing";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + textmsg + "')</script>", false);
                    }

                }
            }
        }
        catch (Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
            //lblError.Style.Add("display", "block");
            //lblError.InnerText = ex.Message;
        }

    }

    protected void txtDiscountPercentage_TextChanged(object sender, EventArgs e)
    {
        if (txtDiscountPercentage.Text.Length > 0)
        {
            decimal startprice = Convert.ToDecimal(txtStartPrice.Text);
            decimal percentvalue = Convert.ToDecimal(txtDiscountPercentage.Text);
            decimal CalculatedPercent = (startprice * percentvalue) / 100;
            decimal DiscountPrice = startprice - CalculatedPercent;
            txtDiscountPrice.Text = Convert.ToString(DiscountPrice);
        }
        else
        {
            txtDiscountPrice.Text = txtStartPrice.Text;
        }
    }
    protected void txtStartPrice_TextChanged(object sender, EventArgs e)
    {
        if (txtDiscountPercentage.Text.Length > 0)
        {
            decimal startprice = Convert.ToDecimal(txtStartPrice.Text);
            decimal percentvalue = Convert.ToDecimal(txtDiscountPercentage.Text);
            decimal CalculatedPercent = (startprice * percentvalue) / 100;
            decimal DiscountPrice = startprice - CalculatedPercent;
            txtDiscountPrice.Text = Convert.ToString(DiscountPrice);
        }
        else
        {
            txtDiscountPrice.Text = txtStartPrice.Text;
        }
    }
    protected void btnViewProperty_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/MyProperties.aspx");
    }
}