using System;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
using ConnectionString;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for UserClass
/// </summary>
public class UserClass
{
	public UserClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool UserLogin(string Email ,  string Password)
    {
        using (SqlDataReader Sdr = SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, @"select s_id , s_fullname,s_gender, s_email, s_mobile ,s_photo ,s_photoPath , s_password  from signup where  (s_email= '" + Email.Replace("'", string.Empty).Replace("select", string.Empty) + "' or s_mobile= '" + Email.Replace("'", string.Empty).Replace("select", string.Empty) + "') and s_password='" + Password.Replace("'", string.Empty).Replace("select", string.Empty) + "'"))
        {
            if (Sdr.HasRows)
            {
                Sdr.Read();
                HttpContext.Current.Session["s_id"] = Convert.ToString(Sdr["s_id"]);
                HttpContext.Current.Session["s_fullname"] = Convert.ToString(Sdr["s_fullname"]);
                HttpContext.Current.Session["s_gender"] = Convert.ToString(Sdr["s_gender"]);
                HttpContext.Current.Session["s_email"] = Convert.ToString(Sdr["s_email"]);
                HttpContext.Current.Session["s_mobile"] = Convert.ToString(Sdr["s_mobile"]);
                HttpContext.Current.Session["s_password"] = Convert.ToString(Sdr["s_password"]);
                HttpContext.Current.Session["s_photo"] = Convert.ToString(Sdr["s_photo"]);
                HttpContext.Current.Session["s_photoPath"] = Convert.ToString(Sdr["s_photoPath"]);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}