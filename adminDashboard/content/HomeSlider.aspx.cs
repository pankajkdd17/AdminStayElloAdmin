using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
public partial class content_HomeSlider : System.Web.UI.Page
{
    MasterData md = new MasterData();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (image1.HasFile)
            {
                //image1
                string fileExtensionimage1 = System.IO.Path.GetExtension(image1.FileName);
                int fileSizeimage1 = image1.PostedFile.ContentLength;

                string filenameimage1 = System.IO.Path.GetFileNameWithoutExtension(image1.FileName) + DateTime.Now.ToString("ddMMyyyyHHmmssms") + System.IO.Path.GetExtension(fileExtensionimage1);
                image1.PostedFile.SaveAs(Server.MapPath("~/content/PropertyPhoto/") + filenameimage1);
                string filepathimage1 = Server.MapPath("~/content/PropertyPhoto/");
                string pathimage1 = "content/PropertyPhoto/" + filenameimage1;
               
                if (((fileExtensionimage1 == ".jpeg") || (fileExtensionimage1 == ".png") || (fileExtensionimage1 == ".jpg") || (fileExtensionimage1 == ".mp4")) && (fileSizeimage1 >= 150))
                {
                    string mobile = Session["s_MobileNo"].ToString();
                    md.UploadHomeSliderImage(mobile , filenameimage1, pathimage1);
                    string textmsg = "Slider image uploaded Successfully !";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopsuccess('" + textmsg + "')</script>", false);
                }
                else
                {
                    string text = "Image Extension must be .jpeg , png , jpg and image size must be 150kb above";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + text + "')</script>", false);
                }

            }
            else
            {
                string text = " Image Not Selected!";
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