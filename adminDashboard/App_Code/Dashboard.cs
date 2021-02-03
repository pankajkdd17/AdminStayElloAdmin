using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


public class Dashboard
{
    public SqlDataReader getRooms(string PropertyVale)
    {
        string sql = @"SELECT  count(r_id) as Room  from Rooms";
        if (PropertyVale == "0")
        {
            sql = sql +  " where 1=1";
        }
        else
        {
            sql = sql + " where  r_PropertyVale = '" + PropertyVale + "'";
        }

        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getCountRooms()
    {
        string sql = @"SELECT  count(r_id) as Room  from Rooms ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getCountTotalBed()
    {
        string sql = @"select sum(Convert (int ,r_BedsValue ))as  r_BedsValue from Rooms";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalBedsOccupied()
    {
        string sql = @" SELECT   count(t_id) as totaltenatns from tenants";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalBed(string PropertyVale)
    {
        string sql = @"select sum(Convert (int ,r_BedsValue ))as  r_BedsValue from Rooms where r_PropertyVale ='" + PropertyVale + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalBeds(string PropertyVale)
    {
        string sql = @"select sum(Convert (int ,r_BedsValue ))as  r_BedsValue from Rooms";
        if(PropertyVale=="0")
        {
            sql = sql + " where 1=1 ";
        }
        else
        {
            sql = sql + " where r_PropertyVale ='" + PropertyVale + "'";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalBedsOccupied(string PropertyVale)
    {
        string sql = @" SELECT   count(t_id) as totaltenatns from tenants where t_PropertyVale='" + PropertyVale + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getDues(string PropertyVale)
    {
        string sql = @"SELECT  count(d_id) as dues  from Dues where d_prpertyvalue =  '" + PropertyVale + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getExpence(string PropertyVale)
    {
        string sql = @"SELECT  count(e_id) as Expences  from Expence where  e_PropertyVal = '" + PropertyVale + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getAnnouncement(string PropertyVale)
    {
        string sql = @"SELECT  count(a_id) as Announcements  from Announcement where  a_PropertyVal = '" + PropertyVale + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getTenants(string PropertyVale)
    {
        string sql = @"SELECT  count(t_id) as countTenants  from Tenants";
        if (PropertyVale == "0")
        {
            sql = sql + " where 1=1 ";
        }
        else
        {
            sql = sql + " where t_PropertyVale = '" + PropertyVale + "'";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalTenants()
    {
        string sql = @"SELECT  count(t_id) as countTenants  from Tenants ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getLeads(string PropertyVale)
    {
        string sql = @"SELECT  count(l_id) as Lead  from Leads where l_PropertyVal = '" + PropertyVale + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getProperty()
    {
        string sql = @"SELECT  count(p_id) as Property  from Property  where p_id>0";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCollection(string PropertyVale)
    {
        string sql ="select sum(CAST(t_RentMoney AS NUMERIC)) as RentMoney , sum(CAST(t_SecurityMoney AS NUMERIC)) as SecurityMoney from  tenants";
        if(PropertyVale=="0")
        {
            sql = sql + " where 1=1 ";
        }
        else
        {
            sql = sql + " where t_PropertyVale ='"+ PropertyVale + "' ";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalDues(string PropertyValue)
    {
        string sql = @"SELECT  count(d_id) as DuesTotalCount  from Dues ";
        if (PropertyValue == "0")
        {
            sql = sql + "where 1=1 ";
        }
        else
        {
            sql = sql + " where  d_prpertyvalue = '" + PropertyValue + "' ";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getTotalDuesSum(string PropertyValue)
    {
        string sql = @"select sum(cast(d_DuesAmount as int) ) as d_DuesAmount from  dues  ";
        if (PropertyValue == "0")
        {
            sql = sql + " where 1=1  and d_status ='pending'";
        }
        else
        {
            sql = sql + " where  d_prpertyvalue = '" + PropertyValue + "' and d_status ='pending' ";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getTotalIncomeSum(string PropertyValue)
    {
        string sql = @"select sum(cast(d_recivedAmount as int) ) as d_recivedAmount from  dues  ";
        if (PropertyValue == "0")
        {
            sql = sql + " where 1=1  and d_status ='recived'";
        }
        else
        {
            sql = sql + " where  d_prpertyvalue = '" + PropertyValue + "' and d_status ='recived' ";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

      public SqlDataReader getTotalExpenceSum(string PropertyValue)
    {
        string sql = @" select sum(cast(e_Amount as int ) ) as e_Amount  from  expence ";
        if (PropertyValue == "0")
        {
            sql = sql + " where 1=1  ";
        }
        else
        {
            sql = sql + " where  d_prpertyvalue = '" + PropertyValue + "' ";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

   
    public SqlDataReader getCountPendingDues(string PropertyValue)
    {
        string sql = @"SELECT  count(d_id) as DuesPendingCount  from Dues ";
        if (PropertyValue == "0")
        {
            sql = sql + " where 1=1 and  d_status = 'pending'";
        }
        else
        {
            sql = sql + " where  d_prpertyvalue = '" + PropertyValue + "' and d_status = 'pending'";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalExpence(string PropertyValue)
    {
        string sql = @"SELECT  count(d_id) as DuesClearCount  from Dues ";
        if (PropertyValue == "0")
        {
            sql = sql + " where  1=1 and  d_status = 'recived'";
        }
        else
        {
            sql = sql + " where  d_prpertyvalue = '" + PropertyValue + "' and d_status = 'recived'";
        }


        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }


    public SqlDataReader getClearDues(string PropertyValue)
    {
        string sql = @"SELECT  count(e_id) as EpenceCount  from expence ";
        if (PropertyValue == "0")
        {
            sql = sql + " where  1=1 ";
        }
        else
        {
            sql = sql + " where  d_prpertyvalue = '" + PropertyValue + "' ";
        }


        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }


    public SqlDataReader getNewComplaints(string PropertyVale)
    {
        string sql = @"SELECT  count(tc_id) as NewComplaints  from Ticketcomplaints where tc_PropertyVal = '" + PropertyVale + "' and tc_status ='Unresolved'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getNewComplaints()
    {
        string sql = @"SELECT  count(tc_id) as NewComplaints  from Ticketcomplaints where  tc_status ='Unresolved'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getSolvedComplaints(string PropertyVale)
    {
        string sql = @"SELECT  count(tc_id) as SolvedComplaints  from Ticketcomplaints where tc_PropertyVal = '" + PropertyVale + "' and tc_status ='Resolved'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getSolvedComplaints()
    {
        string sql = @"SELECT  count(tc_id) as SolvedComplaints  from Ticketcomplaints where tc_status ='Resolved'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }


    public SqlDataReader getOnGoingComplaints(string PropertyVale)
    {
        string sql = @"SELECT  count(tc_id) as OnGoingComplaints  from Ticketcomplaints where tc_PropertyVal = '" + PropertyVale + "' and  (tc_status ='Acknowledged (By Management)' or tc_status ='Verified (By Staff)'  or tc_status ='Tenant Availability Time Requested' or tc_status ='More Details/Time Required'  or tc_status ='Service Person Assigned') ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getOnGoingComplaints()
    {
        string sql = @"SELECT  count(tc_id) as OnGoingComplaints  from Ticketcomplaints where tc_status ='Acknowledged (By Management)' or tc_status ='Verified (By Staff)'  or tc_status ='Tenant Availability Time Requested' or tc_status ='More Details/Time Required'  or tc_status ='Service Person Assigned' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getRoomVacant(string Property)
    {
        string sql = @"SELECT count( r_id )  as Vacant FROM rooms WHERE r_RoomNo not IN (SELECT t_RoomNo FROM Tenants ) and r_PropertyVale ='" + Property + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getRoomCountVacant(string Property)
    {
        string sql = @"SELECT count( r_id )  as Vacant FROM rooms";
        if(Property=="0")
        {
            sql = sql + " where  1=1 and r_RoomNo not IN (SELECT t_RoomNo FROM Tenants )";
        }
        else
        {
            sql = sql + " WHERE r_RoomNo not IN (SELECT t_RoomNo FROM Tenants ) and r_PropertyVale ='" + Property + "'";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }


    public DataSet getRoomNo(string PropertyVale)
    {
        string sql = "select r_RoomNo from rooms group by r_RoomNo ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getRoomFull(string PropertyVale, string romNo)
    {
        string sql = " SELECT count( r_id ) as FullRoom FROM rooms WHERE r_RoomNo  IN (select r_RoomNo from rooms r  join Tenants t on t.t_roomNo =r.r_roomNo where (select r_BedsValue from rooms where r_PropertyVale ='" + PropertyVale + "' and r_RoomNo ='" + romNo + "') = (select count(t_MobileNo) from Tenants  where t_PropertyVale ='" + PropertyVale + "' and  t_RoomNo ='" + romNo + "' )) and r_PropertyVale ='" + PropertyVale + "' and r_RoomNo ='" + romNo + "'  ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }


    public SqlDataReader getRoomsFull(string PropertyVale, string romNo)
    {
        string sql = " SELECT count( r_id ) as FullRoom FROM rooms WHERE r_RoomNo  IN (select r_RoomNo from rooms r  join Tenants t on t.t_roomNo =r.r_roomNo where (select r_BedsValue from rooms where r_PropertyVale ='" + PropertyVale + "' and r_RoomNo ='" + romNo + "') = (select count(t_MobileNo) from Tenants  where t_PropertyVale ='" + PropertyVale + "' and  t_RoomNo ='" + romNo + "' )) and r_PropertyVale ='" + PropertyVale + "' and r_RoomNo ='" + romNo + "'  ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getRoomSemiVacant(string PropertyVale)
    {
        string sql = " SELECT count( r_RoomNo ) as SemiVacant FROM rooms WHERE r_PropertyVale ='" + PropertyVale + "'  ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }





    public SqlDataReader getCountTotalSignup()
    {

        string sql = " SELECT count(s_id) as totalsignup from signup  ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalBooking()
    {
        string sql = "SELECT count(b_id) as totalBookNow from BookNow";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalVisit()
    {
        string sql = "SELECT count(v_id) as totalScheduleVisit from ScheduleVisit";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalVisits(string property)
    {
        string sql = "SELECT count(v_id) as totalScheduleVisit from ScheduleVisit where p_name ='" + property + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getCountTotalBookings()
    {
        string sql = "SELECT count(b_id) as totalBookNow from BookNow ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getCountTotalBooking(string PropertyValue)
    {
        string sql = "select count(s.b_id) as totalBookNow from BookNow s join  property p   on s.p_name =p.p_name ";
        if (PropertyValue == "0")
        {
            sql = sql + " where 1=1 ";
        }
        else
        {
            sql = sql + " where p.p_id='" + PropertyValue + "'";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalVisiting(string PropertyValue)
    {
        string sql = "select count(s.v_id) as totalVisiting from ScheduleVisit s join  property p   on s.p_name =p.p_name ";
        if (PropertyValue == "0")
        {
            sql = sql + "where 1=1 ";
        }
        else
        {
            sql = sql + "where p.p_id='" + PropertyValue + "'";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalSchedule()
    {
        string sql = "SELECT count(v_id) as totalScheduleVisit from ScheduleVisit";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountTotalSchedule(string PropertyValue)
    {
        string sql = "select count(s.v_id) as totalScheduleVisit from ScheduleVisit s join  property p   on s.p_name =p.p_name where p.p_id='" + PropertyValue + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getTotalLeads()
    {
        string sql = "SELECT count(l_id) as totalleads from leads";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getTotalExpence()
    {
        string sql = "  SELECT count(e_id) as Counte_Amount ,  sum(Convert (float ,e_Amount ))as  Totale_Amount from Expence";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getTotalExpence(string e_PropertyVal)
    {
        string sql = "  SELECT count(e_id) as Counte_Amount ,  sum(Convert (float ,e_Amount ))as  Totale_Amount from Expence where e_PropertyVal ='" + e_PropertyVal + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getTotalDues()
    {
        string sql = "SELECT count(d_id) as CountDues ,  sum(Convert (float ,d_DuesAmount ))as  TotalDuesAmount from dues  where d_status ='pending'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getTotalDues(string d_prpertyvalue)
    {
        string sql = "SELECT count(d_id) as CountDues ,  sum(Convert (float ,d_DuesAmount ))as  TotalDuesAmount from dues  where d_prpertyvalue ='" + d_prpertyvalue + "' and d_status ='pending'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getTotalIncome( string Month)
    {
        string sql = "SELECT count(d_id) as CountIncome ,  sum(Convert (float ,d_recivedAmount ))as  Totald_recivedAmount from dues  WHERE d_status ='recived'  AND  d_DuesMonth ='"+ Month + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getTotalIncome(string d_prpertyvalue , string Month)
    {
        string sql = "SELECT count(d_id) as CountIncome ,  sum(Convert (float ,d_recivedAmount ))as  Totald_recivedAmount from dues where d_prpertyvalue ='" + d_prpertyvalue + "' and  d_DuesMonth ='" + Month + "' and d_status ='recived'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getCountSignup()
    {
        string sql = "SELECT count(s_id) as totalsignup from signup";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
}
