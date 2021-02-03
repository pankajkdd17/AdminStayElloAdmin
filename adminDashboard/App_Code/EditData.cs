using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class EditData
{
    public SqlDataReader GetFoodMenu(string f_id)
    {
        string sql = "select f_id , f_WeekdaysText , f_Breakfast,  f_BreakfastTime, f_BreakfastTimeto , f_Lunch,  f_LunchTime, f_LunchTimeTo, f_Snacks,  f_SnacksTime ,f_SnacksTimeTo , f_Dinner,  f_DinnarTime ,  f_DinnarTimeTo   from FoodMenu where f_id='" + f_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetProperty(string p_id)
    {
        string sql = "select p_id , p_name , p_address , p_city ,  p_pincode , p_maplink , p_mgName , p_pgMobile , p_gender , p_StartPrice , p_discountprice , p_DicountPercent , p_imageName1 , p_image1Path ,p_imageName2 ,p_image2Path ,p_imageName3 ,p_image3Path ,p_crdate ,p_mdfyDate from Property where p_id = '" +p_id +  "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdatedProperty(string p_id, string PropertyName, string PropertyAddress, string City, string pinCode, string MapLink, string ManagerName, string ManagerPhone, string gender, string StartPrice, string DiscountPrice, string DiscountPercentage, string filenameimage1, string pathimage1, string filenameimage2, string pathimage2, string filenameimage3, string pathimage3)
    {
        string sql = "update Property set  p_name ='" + PropertyName + "' , p_address = '" + PropertyAddress + "', p_city = '" + City + "',  p_pincode = '" + pinCode + "' , p_maplink = '" + MapLink + "' , p_mgName ='" + ManagerName + "', p_pgMobile = '" + ManagerPhone + "' , p_gender = '" + gender + "' , p_StartPrice = '" + StartPrice + "' , p_discountprice = '" + DiscountPrice + "' , p_DicountPercent = '" + DiscountPercentage + "', p_imageName1 = '" + filenameimage1 + "' , p_image1Path ='" + pathimage1 + "' ,p_imageName2 = '" + filenameimage2 + "',p_image2Path ='" + pathimage2 + "' , p_imageName3  ='" + filenameimage3 + "' ,p_image3Path ='" + pathimage3 + "', p_mdfyDate =getdate()  where p_id ='"+ p_id +"' ";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetStaff(string f_id)
    {
        string sql = "select s_id ,s_Name, s_MobileNo, s_AdhaarNo, s_PanNo, s_FullAddress,  convert(varchar, s_DateOfJoining, 23) as s_DateOfJoining ,  s_crdate , s_mdfyDate from staff where s_id ='" + f_id + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdateStaff(string s_id ,string Name, string MobileNo, string AdhaarNo, string PanNo, string FullAddress, string DateOfJoining)
    {
        string sql = "update staff set  s_Name ='" + Name + "', s_MobileNo ='" + MobileNo + "', s_AdhaarNo ='" + AdhaarNo + "', s_PanNo = '" + PanNo + "', s_FullAddress = '" + FullAddress + "', s_DateOfJoining = '" + DateOfJoining + "' , s_mdfyDate = getdate() where s_id ='"+ s_id+"'"; 
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetRooms(string r_id)
    {
        string sql = "select r_id , r_PropertyName , r_PropertyVale , r_roomNo , r_FloorNoText , r_FloorNovalue , r_BedsText ,r_BedsValue , r_Rent, r_SecurityDeposit, r_Remark , r_Ac , r_NonAC , r_Ventilation , r_Washroom , r_LargeRoom , r_Balcony , r_CornerRoom , r_WiFi  from Rooms where r_id = '" + r_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

   
    public void UpdateRooms(string r_id, string PropertyName, string PropertyVale, string roomNo, string FloorNoText, string FloorNoValue, string BedsText, string BedsValue, string Rent, string SecurityDeposit, string Remark, string Ac, string NonAC, string Ventilation, string Washroom, string LargeRoom, string Balcony, string CornerRoom, string WiFi)
    {
        string sql = "update Rooms set  r_roomNo =  '" + roomNo + "' , r_FloorNoText = '" + FloorNoText + "', r_FloorNovalue =  '" + FloorNoValue + "', r_BedsText  = '" + BedsText + "',r_BedsValue ='" + BedsValue + "' , r_Rent ='" + Rent + "', r_SecurityDeposit ='" + SecurityDeposit + "', r_Remark = '" + Remark + "', r_Ac='" + Ac + "' , r_NonAC = '" + NonAC + "' , r_Ventilation ='" + Ventilation + "' , r_Washroom ='" + Washroom + "' , r_LargeRoom ='" + LargeRoom + "' , r_Balcony ='" + Balcony + "' , r_CornerRoom = '" + CornerRoom + "', r_WiFi ='" + WiFi + "' ,  r_mdfydate =getdate()  where r_id = '" + r_id + "'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader Getpartner(string p_id)
    {
        string sql = "select p_id , p_name ,p_mobile , convert(varchar ,p_doj , 23 ) as p_doj , p_details , convert (varchar ,p_crdate , 23 ) as p_crdate , p_mdfydate from  Partner where p_id ='" + p_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdatePartner(string p_id ,string name, string mobile, string doj, string details)
    {
        string sql = "update Partner set p_name ='" + name + "'  ,p_mobile = '" + mobile + "' ,p_doj = '" + doj + "' ,p_details  = '" + details + "' ,p_mdfydate ==  getdate() where p_id ='"+ p_id +"'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetTenants(string t_id)
    {
        string sql = "select t_id ,t_mobile , t_PropertyName , t_PropertyVale , t_Name , t_MobileNo ,  t_RoomNo , t_BedsText , t_BedsValue , t_SecurityMoney , t_RentMoney , t_DateOfJoining, t_RentDate, t_LockinPeriodValue , t_LockinPeriodText , t_Details , t_crdate , t_mdfydate from Tenants where t_id = '" + t_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader GetTenantsById(string t_id)
    {
        string sql = "select t_id ,t_mobile , t_PropertyName , t_PropertyVale , t_Name , t_MobileNo ,  t_RoomNo , t_BedsText , t_BedsValue , t_SecurityMoney , t_RentMoney , t_DateOfJoining, t_RentDate, t_Details , t_crdate , t_mdfydate from Tenants where t_id = '" + t_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    //t_id, txtName.Text, txtMobileNo.Text, ddlRoomNo.SelectedItem.Text, txtRoomType.Text, bedValue , ddlRoomNo.SelectedItem.Value, txtSecurityMoney.Text, txtRentMoney.Text, txtDateOfJoining.Text, txtRentDate.Text, txtDetails.Text
    public void UpdateTenants(string t_id, string Name, string MobileNo, string RoomNo, string BedsText, string BedsValue, string SecurityMoney, string RentMoney, string DateOfJoining, string RentDate , string LockinPeriodValue , string LockinPeriodText ,  string Details)
    {
        string sql = "update Tenants set   t_Name  = '" + Name + "', t_MobileNo = '" + MobileNo + "', t_RoomNo = '" + RoomNo + "', t_BedsText ='" + BedsText + "' , t_BedsValue = '" + BedsValue + "',t_SecurityMoney ='" + SecurityMoney + "' , t_RentMoney = '" + RentMoney + "' , t_DateOfJoining = '" + DateOfJoining + "', t_RentDate ='" + RentDate + "', t_LockinPeriodValue ='" + LockinPeriodValue + "', t_LockinPeriodText ='" + LockinPeriodText + "', t_Details = '" + Details + "',  t_mdfydate= getdate() where t_id = '" + t_id + "' ";
         SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetDues(string d_id)
    {
        string sql = "select d_id , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText,  d_DuesTypeValue, d_reciveddate , d_DuesAmount, convert(varchar, d_DuesDate, 23) as d_DuesDate , d_DuesMonth ,  d_ModeOfPayment , d_Remark ,convert (varchar ,d_crdate ,23) as d_crdate ,d_mdfydate from  Dues where d_id = '" + d_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdateDues(string d_id, string PayeeText, string PayeeValue, string RoomNo,  string DuesTypeText, string DuesTypeValue, string DuesAmount, string DuesDate, string DuesMonth, string Remark)
    {
        string sql = "update Dues set d_PayeeText ='" + PayeeText + "',  d_PayeeValue = '" + PayeeValue + "',  d_RoomNo = '" + RoomNo + "',   d_DuesTypeText = '" + DuesTypeText + "',  d_DuesTypeValue = '" + DuesTypeValue + "',  d_DuesAmount = '" + DuesAmount + "', d_DuesDate =  '" + DuesDate + "',  d_DuesMonth = '" + DuesMonth + "',  d_Remark = '" + Remark + "'  , d_mdfydate = getdate() where d_id = '"+ d_id+ "'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetExpences(string e_id)
    {
        string Sql = "select  e_id , e_CategoryText, e_CategoryValue, e_Amount, e_PaidBytext, e_PaidByValue, e_PaidTo, e_PaymentMethod, Convert(varchar , e_ExpenseDate, 23 ) as e_ExpenseDate ,  e_Details , convert(varchar , e_crdate ,23 ) as e_crdate ,e_mdfydate from Expence where e_id ='" + e_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, Sql);
    }

    public void UpdateExpence(string e_id,  string CategoryText, string CategoryValue, string Amount, string PaidBytext, string PaidByValue, string PaidTo, string PaymentMethod, string ExpenseDate, string Details)
    {
        string sql = "update Expence set e_CategoryText = '" + CategoryText + "', e_CategoryValue = '" + CategoryValue + "', e_Amount =  '" + Amount + "', e_PaidBytext = '" + PaidBytext + "', e_PaidByValue ='" + PaidByValue + "',  e_PaidTo ='" + PaidTo + "', e_PaymentMethod = '" + PaymentMethod + "', e_ExpenseDate ='" + ExpenseDate  + "', e_Details  = '" + Details + "', e_mdfydate = getdate() where e_id ='"+ e_id +"'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetAnnouncement(string a_id)
    {
        string sql = "select a_id , a_Text , a_Value  , a_mobile , a_Details , a_crdate , a_mdfydate from Announcement where a_id ='" + a_id + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdateAnnouncement(string a_id , string AnnouncementText, string AnnouncementValue, string Mobile, string Announcement)
    {
        string sql = "update Announcement set  a_Text = '" + AnnouncementText + "', a_Value = '" + AnnouncementValue + "' , a_mobile = '" + Mobile + "' , a_Details = '" + Announcement + "'  , a_mdfydate =  getdate() where a_id = '"+ a_id +"'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetLeads(string l_id)
    {
        string sql = "select l_id , l_Name, l_MobileNo, l_ParentName, l_ParentMobile, l_AmountRecieved, l_Gender, l_RentAmount, l_Roomtypepreferred, l_Ac, l_Ventilation, l_Washroom, l_LargeRoom, l_Balcony, l_CornerRoom, l_Status, l_Comments , convert(varchar ,l_crdate , 103 ) as l_crdate ,l_mdfydate from Leads where l_id = '" + l_id  + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdateLeads(string l_id , string Name, string MobileNo, string ParentName, string ParentMobile, string AmountRecieved, string Gender, string RentAmount, string Roomtypepreferred, string Ac, string Ventilation, string Washroom, string LargeRoom, string Balcony, string CornerRoom, string Status, string Comments)
    {
        string sql = "update Leads set l_Name = '" + Name + "', l_MobileNo = '" + MobileNo + "', l_ParentName = '" + ParentName + "', l_ParentMobile ='" + ParentMobile + "',  l_AmountRecieved = '" + AmountRecieved + "', l_Gender = '" + Gender + "', l_RentAmount ='" + RentAmount + "', l_Roomtypepreferred = '" + Roomtypepreferred + "',  l_Ac = '" + Ac + "', l_Ventilation = '" + Ventilation + "', l_Washroom ='" + Washroom + "', l_LargeRoom = '" + LargeRoom + "', l_Balcony = '" + Balcony + "', l_CornerRoom ='" + CornerRoom + "', l_Status = '" + Status + "', l_Comments='" + Comments + "' , l_mdfydate =getdate() where l_id ='"+ l_id+"'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader CheckProperty(int PropertyVale)
    {
        string sql = "select r_PropertyVale , r_PropertyName , r_roomNo from rooms where  r_PropertyVale ='" + PropertyVale + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

   
    public SqlDataReader CheckTenantsExist(string MobileNo)
    {
        string sql = @"SELECT TOP 1 t_name ,  t_MobileNo  , t_RoomNo  FROM Tenants WHERE t_MobileNo = '" + MobileNo + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetRommNo(int r_id)
    {
        string sql = @"SELECT  r_roomNo   FROM Rooms WHERE r_id = '" + r_id + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    
    public SqlDataReader GetTenantsInRooms(string roomNo , string Propertyvalue)
    {
        string sql = @"select t_Name from Tenants where t_RoomNo = '" + roomNo + "' and t_PropertyVale ='"+ Propertyvalue + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetRoomsInProperty(string property)
    {
        string sql = @"select r_roomNo , r_PropertyName  from rooms where r_PropertyVale = '" + property + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader TotalAnnouncement()
    {
        string sql = @"select count(a_id) as TotalAnnouncement from Announcement";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader TotalAnnouncementToUser()
    {
        string sql = @"select count(a_Text) as TotalUserAnnouncement from Announcement where a_Text !='all'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader TotalAnnouncementToAll()
    {
        string sql = @"select count(a_Text) as TotalUserAnnouncement from Announcement where a_Text ='all'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetTenants()
    {
        string sql = "select t_id ,t_mobile , t_PropertyName , t_PropertyVale , t_Name , t_MobileNo ,  t_RoomNo , t_BedsText , t_BedsValue , t_SecurityMoney , t_RentMoney , t_DateOfJoining, t_RentDate, t_Details , t_crdate , t_mdfydate from Tenants";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
}
