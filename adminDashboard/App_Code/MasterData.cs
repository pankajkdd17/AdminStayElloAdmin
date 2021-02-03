using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class MasterData
{
    public DataSet GetDropdown()
    {
        string sql = "select p_id , p_name  from Property ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet GetGenderList()
    {
        string sql = "select g_id , g_name  from tbl_Gender ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetPropertyList()
    {
        string sql = "select p_id , p_name  from Property where p_id >0 ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetCompLaints()
    {
        string sql = "select cp_id , cp_name  from compmaster ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

   
    public DataSet GetDropdown(String PropertyValue)
    {
        string sql = "select p_id , p_name  from Property where p_id ='" + PropertyValue + "' ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UploadHomeSliderImage(string mobile, string filenameimage1, string pathimage1)
    {
        string sql = "insert into tblImages(i_mobile , i_Name , i_imagePath , i_crdate )values('" + mobile + "' , '" + filenameimage1 + "' , '" + pathimage1 + "' , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
}
