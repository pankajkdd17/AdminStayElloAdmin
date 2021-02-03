using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for AddUsers
/// </summary>
public class Reports
{
    public DataSet GetAllDuesReport(string dateNow)
    {
        string sql = "select d_id , d_mobile , d_prpertyname , d_prpertyvalue , d_PayeeText, d_t_Mobile,   d_RoomNo,    d_DuesTypeText,  d_DuesAmount, d_DuesDate,  d_Remark , d_status , d_crdate ,d_mdfydate from dues ";
        if (dateNow != null)
        {
            sql = sql + " where d_status='pending' and convert(varchar, d_crdate, 23)  ='" + dateNow + "' order by d_id asc";
        }
        else
        {
            sql = sql + " where 1=1 and d_status='pending' order by d_id asc";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1 , CommandType.Text,sql);
    }

    public DataSet GetAllDuesReportbyProperty(string propertyValue)
    {
        string sql = "select d_id , d_mobile , d_prpertyname , d_prpertyvalue , d_PayeeText, d_t_Mobile,   d_RoomNo,    d_DuesTypeText,  d_DuesAmount, d_DuesDate,  d_Remark , d_status , d_crdate ,d_mdfydate from dues ";
        if (propertyValue != "0")
        {
            sql = sql + " where d_status='pending' and d_prpertyvalue  ='" + propertyValue + "' order by d_id asc";
        }
        else
        {
            sql = sql + " where 1=1 and d_status='pending' order by d_id asc";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }


    public DataSet GetAllRoomsReport(string dateNow)
    {
        string sql = "select  r_id , r_PropertyName , r_PropertyVale , r_roomNo , r_FloorNoText , r_FloorNovalue , r_BedsText ,r_BedsValue , r_Rent, r_SecurityDeposit, r_Remark , r_Ac , r_NonAC , r_Ventilation , r_Washroom , r_LargeRoom , r_Balcony , r_CornerRoom , r_WiFi  from Rooms ";
        if(dateNow!=null)
        {
            sql = sql + " where convert(varchar, r_crdate, 23) = '" + dateNow + "' order by r_roomNo asc";
        }
        else
        {
            sql = sql + " where 1=1  order by r_roomNo asc";
        }
        
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetAllRoomsReportByProperty(string propertyValue)
    {
        string sql = "select  r_id , r_PropertyName , r_PropertyVale , r_roomNo , r_FloorNoText , r_FloorNovalue , r_BedsText ,r_BedsValue , r_Rent, r_SecurityDeposit, r_Remark , r_Ac , r_NonAC , r_Ventilation , r_Washroom , r_LargeRoom , r_Balcony , r_CornerRoom , r_WiFi  from Rooms ";
        if (propertyValue != "0")
        {
            sql = sql + " where r_PropertyVale = '" + propertyValue + "' order by r_roomNo asc";
        }
        else
        {
            sql = sql + " where 1=1  order by r_roomNo asc";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetAllIncomeReport(string dateNow)
    {
        string sql = "select d_id, d_PayeeText, d_PayeeValue, d_RoomNo, d_t_Mobile, d_DuesTypeText, d_DuesTypeValue, d_recivedAmount, d_DuesAmount, CONVERT(varchar, d_reciveddate, 103 ) as d_reciveddate ,  CONVERT(varchar, d_DuesMonth, 103) as d_DuesMonth ,  convert(varchar, d_DuesDate, 103) as d_DuesDate , d_Remark ,convert(varchar, d_crdate, 103) as d_crdate , d_status , d_mdfydate from  Dues ";
        if (dateNow != null)
        {
            sql = sql + " where d_status= 'recived' and   convert(varchar, d_crdate, 23) ='" + dateNow + "' order by d_id asc";
        }
        else
        {
            sql = sql + " where 1=1 and d_status= 'recived'  order by d_id asc";
        }

        
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetAllIncomeReportByProperty(string propertyValue)
    {
        string sql = "select d_id, d_PayeeText, d_prpertyname , d_PayeeValue , d_prpertyvalue, d_RoomNo, d_DuesMonth , d_t_Mobile, d_DuesTypeText, d_DuesTypeValue, d_recivedAmount, d_DuesAmount, CONVERT(varchar, d_reciveddate, 103 ) as d_reciveddate ,  CONVERT(varchar, d_DuesMonth, 103) as d_DuesMonth ,  d_Remark ,convert(varchar, d_crdate, 103) as d_crdate , convert(varchar, d_DuesDate, 103) as d_DuesDate , d_status ,  d_mdfydate from  Dues ";
        if (propertyValue != "0")
        {
            sql = sql + " where d_status= 'recived' and   d_prpertyvalue ='" + propertyValue + "' order by d_id asc";
        }
        else
        {
            sql = sql + " where 1=1 and d_status= 'recived'  order by d_id asc";
        }


        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetAllIncomeReportByPropertyAndProperty(string propertyValue , string Month)
    {
        string sql = "select d_id, d_PayeeText, d_prpertyname , d_PayeeValue , d_prpertyvalue, d_DuesMonth , d_RoomNo, d_t_Mobile, d_DuesTypeText, d_DuesTypeValue, d_recivedAmount, d_DuesAmount, CONVERT(varchar, d_reciveddate, 103 ) as d_reciveddate ,  CONVERT(varchar, d_DuesMonth, 103) as d_DuesMonth ,  d_Remark ,convert(varchar, d_crdate, 103) as d_crdate , convert(varchar, d_DuesDate, 103) as d_DuesDate , d_status ,  d_mdfydate from  Dues ";
        if (propertyValue != "0")
        {
            sql = sql + " where d_status= 'recived' and   d_prpertyvalue ='" + propertyValue + "' and d_DuesMonth = '" + Month + "' order by d_id asc";
        }
        else
        {
            sql = sql + " where 1=1 and d_status='recived'  and d_DuesMonth = '" + Month + "' order by d_id asc";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetAllTenantsReport(string dateNow)
    {
        string sql = "select t_id ,t_mobile , t_PropertyName , t_PropertyVale , t_Name , t_MobileNo , t_RoomNo , t_SecurityMoney ,t_BedsText , t_RentMoney ,convert(varchar , t_DateOfJoining , 103) as t_DateOfJoining, convert(varchar , t_RentDate , 103) as t_RentDate, t_Details , convert(varchar , t_crdate , 103)as t_crdate , t_mdfydate from Tenants";
        if (dateNow != null)
        {
            sql = sql + " where  convert(varchar, t_crdate, 23) ='" + dateNow + "' order by t_id asc";
        }
        else
        {
            sql = sql + " where 1=1   order by t_id asc";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetAllTenantsReportByProperty(string PropertyValue)
    {
        string sql = "select t_id ,t_mobile , t_PropertyName , t_PropertyVale , t_Name , t_MobileNo , t_RoomNo , t_SecurityMoney ,t_BedsText , t_RentMoney ,convert(varchar , t_DateOfJoining , 103) as t_DateOfJoining, convert(varchar , t_RentDate , 103) as t_RentDate, t_Details , convert(varchar , t_crdate , 103)as t_crdate , t_mdfydate from Tenants";
        if (PropertyValue != "0")
        {
            sql = sql + " where  t_PropertyVale ='" + PropertyValue + "' order by t_PropertyVale asc";
        }
        else
        {
            sql = sql + " where 1=1   order by t_PropertyVale asc";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

}