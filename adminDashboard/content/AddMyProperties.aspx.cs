using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class content_AddMyProperties : System.Web.UI.Page
{
    AddUsers uc = new AddUsers();
    MasterData md = new MasterData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["s_MobileNo"] != null)
            {
                ddlGender.DataSource = md.GetGenderList();
                ddlGender.DataBind();
                ddlGender.DataTextField = "g_name";
                ddlGender.DataValueField = "g_id";
                ddlGender.DataBind();
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
    protected void btnAddProperty_Click(object sender, EventArgs e)
    { try
        {
            if (checkDublicatePropert() != true)
            {
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

                    try
                    {
                        if ((fileExtensionimage1 == ".jpeg") && (fileExtensionimage2 == ".jpeg") && (fileExtensionimage3 == ".jpeg") && (fileSizeimage1 >= 150) && (fileSizeimage2 >= 150) && (fileSizeimage3 >= 150))
                        {
                            // string mobile = Session["s_mobile"].ToString();
                            string mobile = Session["s_MobileNo"].ToString();
                           
                                uc.AddProperty(mobile, txtPropertyName.Text, txtPropertyAddress.Text, txtCity.Text, txtpinCode.Text, txtMapLink.Text, txtManagerName.Text, txtManagerPhone.Text, ddlGender.SelectedItem.Text, txtStartPrice.Text, txtDiscountPrice.Text, txtDiscountPercentage.Text, filenameimage1, pathimage1, filenameimage2, pathimage2, filenameimage3, pathimage3);
                                string textmsg = "Property Added Successfully !";
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
                                loadData();
                                       
                        }
                        else
                        {
                            string text = "Image Extension must be .jpeg and image size must be 150kb above";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                            // lblError.Style.Add("display", "block");

                        }
                    }
                    catch (Exception ex)
                    {
                        string text = ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                    }
                }
                else
                {
                    string text = "Select Image rquired";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);

                }
            }
            
        }
        catch(Exception ex)
        {
            string text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);

        }
    }

    private void loadData()
    {
        DropDownList ddlPropertyName = (DropDownList)Master.FindControl("ddlProperty");
        string PropertyName = ddlPropertyName.SelectedItem.Text;
        string PropertyVale = ddlPropertyName.SelectedItem.Value;
        ddlPropertyName.DataSource = md.GetDropdown();
        ddlPropertyName.DataBind();
        ddlPropertyName.DataTextField = "p_name";
        ddlPropertyName.DataValueField = "p_id";
        ddlPropertyName.DataBind();
    }
    

    private bool checkDublicatePropert()
    {
        bool result = false;
        SqlDataReader sdr = uc.CheckProperty(txtPropertyName.Text);
        if (sdr.HasRows)
        {
            if (sdr.Read())
            {
                
                string Property = sdr["p_name"].ToString();
                string text = "This " + Property + " Already Exist";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                result = true;
            }
            sdr.Close();
        }
        return result;
    }

    protected void btnViewProperty_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/MyProperties.aspx");
    }
    protected void txtDiscountPercentage_TextChanged(object sender, EventArgs e)
    {
        if (txtDiscountPercentage.Text.Length > 0)
        {
            int startprice = Convert.ToInt32(txtStartPrice.Text);
            int percentvalue = Convert.ToInt32(txtDiscountPercentage.Text);
            int CalculatedPercent = (startprice * percentvalue) / 100;
            int DiscountPrice = startprice - CalculatedPercent;
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
            int startprice = Convert.ToInt32(txtStartPrice.Text);
            int percentvalue = Convert.ToInt32(txtDiscountPercentage.Text);
            int CalculatedPercent = (startprice * percentvalue) / 100;
            int DiscountPrice = startprice - CalculatedPercent;
            txtDiscountPrice.Text = Convert.ToString(DiscountPrice);
        }
        else
        {
            txtDiscountPrice.Text = txtStartPrice.Text;
        }
    }

    protected void btnAddStartingPrice_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/content/AddPropertyStartingPrice.aspx");
    }
}