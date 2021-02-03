using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class Delete
{
    public int DeleteFoodMenu(int f_id)
    {
        string sql = @"delete from FoodMenu WHERE f_id=" + f_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int DeleteStaff(int s_id)
    {
        string sql = @"delete from staff WHERE s_id=" + s_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int DeleteRoom(int r_id , string propertyvalue)
    {
        string sql = @"delete from Rooms WHERE r_id=" + r_id + " and r_PropertyVale ='" + propertyvalue + "' ";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int DeletePartner(int p_id)
    {
        string sql = @"delete from Partner WHERE p_id=" + p_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int DeleteTenants(int t_id)
    {
        string sql = @"delete from  Tenants WHERE t_id=" + t_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    
    public int DeleteDues(string d_id)
    {
        string sql = @"delete from  Dues WHERE d_id=" + d_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int DeleteRestoreDues(int d_id)
    {
        string sql = "Update Dues set d_DeleteStatus ='No' WHERE d_id=" + d_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int DeleteUpdateDues(int d_id)
    {
        string sql = "Update Dues set d_DeleteStatus ='Yes' WHERE d_id=" + d_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int DeleteExpence(int e_id)
    {
        string sql = @"delete from  Expence WHERE e_id=" + e_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int DeleteAnnouncment(int a_id)
    {
        string sql = @"delete from  Announcement WHERE a_id=" + a_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }  

    public int DeleteLeads(int l_id)
    {
        string sql = @"delete from  Leads WHERE l_id=" + l_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int DeleteProperty(int p_id)
    {
        string sql = @"delete from  property WHERE p_id=" + p_id + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetTenantMobile(int t_id)
    {
        string sql = "select t_MobileNo from Tenants where t_id ='"+ t_id + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
}
