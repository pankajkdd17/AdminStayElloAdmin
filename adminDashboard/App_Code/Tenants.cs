using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
public class Tenants
{
    public DataSet GetLateCheckinRecord(string propertyVale)
    {
        string sql = "select tlc_id , tlc_PropertyName, tlc_PropertyVale, tlc_Name, tlc_RoomNo,  tlc_BedsText, tlc_MobileNo, tlc_BedsValue, convert(varchar ,tlc_LateCheckinDate , 103 ) as tlc_LateCheckinDate ,CONVERT(VarChar(7), tlc_LateCheckinTime, 0) as tlc_LateCheckinTime,  tlc_FatherName, tlc_FatherMobile, tlc_msg , convert(varchar ,tlc_cr_date , 103) as tlc_cr_date , tlc_crmdfy_date from tbl_LateCheckin";
        if (propertyVale == "0")
        {
            sql = sql + " where 1=1 order by tlc_RoomNo asc ";
        }
        else
        {
            sql = sql + " where tlc_PropertyVale = '" + propertyVale + "' order by tlc_RoomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetLateCheckinRecordBySearch(string propertyValue, string Search)
    {
        string sql = "select tlc_id , tlc_PropertyName, tlc_PropertyVale, tlc_Name, tlc_RoomNo,  tlc_BedsText, tlc_MobileNo, tlc_BedsValue, convert(varchar ,tlc_LateCheckinDate , 103 ) as tlc_LateCheckinDate , tlc_LateCheckinTime, tlc_FatherName, tlc_FatherMobile, tlc_msg , convert(varchar ,tlc_cr_date , 103) as tlc_cr_date , tlc_crmdfy_date from tbl_LateCheckin";
        if ((Search != "0") && (propertyValue != "0"))
        {
            sql = sql + " where ((tlc_RoomNo = '" + Search.Trim() + "') or (tlc_id = '" + Search.Trim() + "')) and tlc_PropertyVale= '" + propertyValue + "' order by tlc_RoomNo asc";
        }
        else if ((Search != "") && (propertyValue == "0"))
        {
            sql = sql + " where ((tlc_RoomNo = '" + Search.Trim() + "') or (tlc_id = '" + Search.Trim() + "'))  order by tlc_RoomNo asc";
        }
        else if ((Search == "") && (propertyValue != "0"))
        {
            sql = sql + " where ((tlc_RoomNo = '" + Search.Trim() + "') or (tlc_id = '" + Search.Trim() + "'))  order by tlc_RoomNo asc";
        }
        else
        {
            sql = sql + " where 1=1  order by tlc_RoomNo asc";
        }

        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetReviewRecord(string propertyVale)
    {
        string sql = "select tfb_id,tfb_PropertyName,tfb_PropertyVale,tfb_Name,tfb_RoomNo,tfb_BedsText,tfb_MobileNo,tfb_BedsValue,tfb_rdbfoodText,tfb_rdbfoodValue,tfb_rdbHOUSEKEEPINGText,tfb_rdbHOUSEKEEPINGValue,tfb_rdbATMOSPHEREText,tfb_rdbATMOSPHEREValue,tfb_rdbSTAFFBEHAVIOURText,tfb_rdbSTAFFBEHAVIOURValue,tfb_rdbWIFICONNECTIVITYText,tfb_rdbWIFICONNECTIVITYValue,tfb_rdbRECOMMENDText,tfb_rdbRECOMMENDValue,tfb_POINTSOFIMPROVEMENTS,tfb_WORDSOFAPPRECIATION, convert(varchar ,tfb_crdate , 103) as tfb_crdate, tfb_mdfydate from tbl_feedback";
        if (propertyVale == "0")
        {
            sql = sql + " where 1=1 order by tfb_RoomNo asc ";
        }
        else
        {
            sql = sql + " where tfb_PropertyVale = '" + propertyVale + "' order by tfb_RoomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetReviewRecordBySearch(string propertyValue, string Search)
    {
        string sql = "select tfb_id,tfb_PropertyName,tfb_PropertyVale,tfb_Name,tfb_RoomNo,tfb_BedsText,tfb_MobileNo,tfb_BedsValue,tfb_rdbfoodText,tfb_rdbfoodValue,tfb_rdbHOUSEKEEPINGText,tfb_rdbHOUSEKEEPINGValue,tfb_rdbATMOSPHEREText,tfb_rdbATMOSPHEREValue,tfb_rdbSTAFFBEHAVIOURText,tfb_rdbSTAFFBEHAVIOURValue,tfb_rdbWIFICONNECTIVITYText,tfb_rdbWIFICONNECTIVITYValue,tfb_rdbRECOMMENDText,tfb_rdbRECOMMENDValue,tfb_POINTSOFIMPROVEMENTS,tfb_WORDSOFAPPRECIATION, convert(varchar ,tfb_crdate , 103) as tfb_crdate, tfb_mdfydate from tbl_feedback";
        if ((Search != "0") && (propertyValue != "0"))
        {
            sql = sql + " where ((tfb_RoomNo = '" + Search.Trim() + "') or (tfb_id = '" + Search.Trim() + "')) and tl_PropertyVale= '" + propertyValue + "' order by tlc_RoomNo asc";
        }
        else if ((Search != "") && (propertyValue == "0"))
        {
            sql = sql + " where ((tfb_RoomNo = '" + Search.Trim() + "') or (tfb_id = '" + Search.Trim() + "'))  order by tfb_RoomNo asc";
        }
        else if ((Search == "") && (propertyValue != "0"))
        {
            sql = sql + " where ((tfb_RoomNo = '" + Search.Trim() + "') or (tfb_id = '" + Search.Trim() + "'))  order by tfb_RoomNo asc";
        }
        else
        {
            sql = sql + " where 1=1  order by tfb_RoomNo asc";
        }

        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetLeaveRecord(string propertyVale)
    {
        string sql = "select tl_id , tl_PropertyName ,tl_PropertyVale ,tl_Name ,tl_RoomNo,tl_BedsText,tl_MobileNo,tl_BedsValue, convert(varchar , tl_LeaveStartDate , 103 ) as tl_LeaveStartDate, convert(varchar , tl_LeaveEndDate , 103 ) as tl_LeaveEndDate, tl_FatherName,tl_FatherMobile,tl_status,tl_msg,tl_cr_date,tl_crmdfy_date from tbl_leave";
        if (propertyVale == "0")
        {
            sql = sql + " where 1=1 order by tl_RoomNo asc ";
        }
        else
        {
            sql = sql + " where tl_PropertyVale = '" + propertyVale + "' order by tl_RoomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetTenantsLeaveRecordBySearch(string propertyValue, string Search)
    {
        string sql = "select tl_id , tl_PropertyName ,tl_PropertyVale ,tl_Name ,tl_RoomNo,tl_BedsText,tl_MobileNo,tl_BedsValue, convert(varchar , tl_LeaveStartDate , 103 ) as tl_LeaveStartDate, convert(varchar , tl_LeaveEndDate , 103 ) as tl_LeaveEndDate, tl_FatherName,tl_FatherMobile,tl_status,tl_msg,tl_cr_date,tl_crmdfy_date from tbl_leave";
        if ((Search != "0") && (propertyValue != "0"))
        {
            sql = sql + " where ((tl_RoomNo = '" + Search.Trim() + "') or (tl_id = '" + Search.Trim() + "')) and tl_PropertyVale= '" + propertyValue + "' order by tlc_RoomNo asc";
        }
        else if ((Search != "") && (propertyValue == "0"))
        {
            sql = sql + " where ((tl_RoomNo = '" + Search.Trim() + "') or (tl_id = '" + Search.Trim() + "'))  order by tl_RoomNo asc";
        }
        else if ((Search == "") && (propertyValue != "0"))
        {
            sql = sql + " where ((tl_RoomNo = '" + Search.Trim() + "') or (tl_id = '" + Search.Trim() + "'))  order by tl_RoomNo asc";
        }
        else
        {
            sql = sql + " where 1=1  order by tl_RoomNo asc";
        }

        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
}