using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for AddUsers
/// </summary>
public class AddUsers
{
    public AddUsers()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    GeneralFunctions.GeneralFunctions Gf = new GeneralFunctions.GeneralFunctions();
    public void AddUser(string FullName, string Email, string Mobile, string gender, string Pssword, string chbvalue)
    {
        string sql = "insert into signup(s_fullname , s_email, s_mobile, s_gender , s_password ,  s_check, s_cr_date, s_mdfy_date , s_usertype , s_isActive ) values('" + FullName + "','" + Email + "','" + Mobile + "','" + gender + "','" + Pssword + "','" + chbvalue + "',getdate() ,getdate() ,'user' , 0)";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getTicketCategory()
    {
        string sql = "select tc_id , tc_name , tc_crdate , tc_mdfy from TicketCategory";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getTicketIssueCategory()
    {
        string sql = "select tc_id , tc_name , fi_id , fi_name  from FacingIssue";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet getTicketIssueDropDownCategory()
    {
        string sql = "select DISTINCT  tc_id , tc_name   from FacingIssue";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getTicketIssueCategoryText(string catvalue)
    {
        string sql = "select fi_id , fi_name  from FacingIssue where  tc_id= '"+ catvalue + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void DeleteTicketCategory(int tc_id)
    {
        string sql = "delete FROM TicketCategory where tc_id ='" + tc_id + "'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int UpdateUser(string FullName, string Email, string gender, string Pssword, string chbvalue, string mobile)
    {
        string sql = @"UPDATE [signup] SET [s_fullname] = '" + FullName + "', [s_email] = '" + Email + "',[s_gender]='" + gender + "',[s_password]='" + Pssword + "',[s_check]='" + chbvalue + "'  WHERE s_mobile ''" + mobile + "";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetUserDetails(string mobile, string Pass)
    {
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, "select s_id, s_Name , s_MobileNo , s_AdhaarNo , s_PanNo , convert(varchar ,s_DateOfJoining ,103 ) as s_DateOfJoining  from staff  where s_MobileNo='" + mobile + "'  and  s_pass='" + Pass + "'");
    }

    public void UpdateTicketCategory(int userid, string TicketCategoryName)
    {
        string sql = "update TicketCategory set tc_name='" + TicketCategoryName + "' where tc_id='" + userid + "'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetUserDetails(string mobile)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, "select s_id, s_Name , s_MobileNo , s_AdhaarNo , s_PanNo , convert(varchar ,s_DateOfJoining ,103 ) as s_DateOfJoining  from staff  where s_MobileNo='" + mobile + "'");
    }

    public DataSet getpgManager()
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, " select pg.pgm_name , pg.pgm_mobile , p.p_name ,p.p_address from pg_manager pg inner join PropertyDetails p on pg.pgm_id=p.p_id");
    }
    //mobile, ddlProperty.SelectedItem.Text, ddlProperty.SelectedItem.Value, acNonAc, txtRoomSharingType.Text , txtStartingPrice.Text
    public void AddPropertyStartingPrice(string mobile, string PropertyName, string PropertyValue, string acNonAc, string RoomSharingType, string StartingPrice)
    {
        string sql = "insert into tbl_PropertyStartingPrice(sp_UserMobile, sp_PropertyName, sp_PropertyValue, sp_AcNonAC,  sp_RoomStartingRoomType,  sp_RoomStartingPrice , sp_crDate , sp_mdfDate)values('" + mobile + "', '" + PropertyName + "', '" + PropertyValue + "', '" + acNonAc + "', '" + RoomSharingType + "', '" + StartingPrice + "' , getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void addvisitedUser(string s_name, string s_mobile, string s_gender, string p_name, string p_address, string pgmName, string pgmMobile, string roomtype, string v_date, string v_time)
    {
        string sql = "insert into ScheduleVisit(s_name , s_mobile,  s_gender ,  p_name , p_address , pgm_name ,  pgm_mobile , p_roomtype ,v_date , v_timeslot , v_crdate , v_mdfydate) values ('" + s_name + "','" + s_mobile + "','" + s_gender + "','" + p_name + "', '" + p_address + "','" + pgmName + "','" + pgmMobile + "','" + roomtype + "','" + Gf.dmytomdy(v_date) + "','" + v_time + "', getdate() ,getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }


    public void addBookingUser(string s_name, string s_mobile, string s_gender, string bookingAmount, string p_name, string p_address, string pgmName, string pgmMobile, string roomtype, string b_date, string b_time)
    {
        string sql = "insert into BookNow(s_name , s_mobile,  s_gender , b_amount , p_name , p_address , pgm_name ,  pgm_mobile , p_roomtype , b_date , b_timeslot , b_status , b_crdate , b_mdfydate ) values ('" + s_name + "','" + s_mobile + "','" + s_gender + "','" + bookingAmount + "','" + p_name + "', '" + p_address + "','" + pgmName + "','" + pgmMobile + "','" + roomtype + "','" + Gf.dmytomdy(b_date) + "','" + b_time + "', 'Booked' , getdate() , getdate() )";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }



    public SqlDataReader CheckRoomType(string PropertyValue, string rdbtnAcNonAC, string RoomSharingType)
    {
        string sql = "SELECT sp_AcNonAC , sp_PropertyName, sp_PropertyValue , sp_RoomStartingRoomType, sp_RoomStartingPrice  FROM tbl_PropertyStartingPrice where sp_AcNonAC = '" + rdbtnAcNonAC + "' and  sp_PropertyValue ='" + PropertyValue + "' and sp_RoomStartingRoomType ='" + RoomSharingType + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void addBookingUseracc(string trascId, string s_name, string s_mobile, string s_gender, string bookingAmount, string p_name, string p_address, string pgmName, string pgmMobile, string roomtype)
    {
        string sql = "insert into BookNow( trascId , s_name , s_mobile,  s_gender , b_amount , p_name , p_address , pgm_name ,  pgm_mobile , p_roomtype , b_status ,b_date , b_crdate , b_mdfydate ) values ('" + trascId + "','" + s_name + "','" + s_mobile + "','" + s_gender + "','" + bookingAmount + "','" + p_name + "', '" + p_address + "','" + pgmName + "','" + pgmMobile + "','" + roomtype + "', 'pending' , getdate() ,  getdate() , getdate() )";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetPendingDues(string tenantsMobile)
    {
        string sql = "select d_PayeeText , d_RoomNo , d_t_Mobile , d_DuesTypeText , d_DuesAmount  from  dues where d_t_Mobile ='" + tenantsMobile + "' and d_status ='pending'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet ViewVisitings(string s_mobile)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, "select p_name , p_address, pgm_name , pgm_mobile , v_date , v_timeslot,  s_name , s_mobile  from ScheduleVisit where s_mobile='" + s_mobile + "' ");
    }


    public DataSet ViewBookings(string s_mobile)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, "select b_id , p_name , p_address, pgm_name ,  pgm_mobile ,b_amount, b_date , b_timeslot,  s_name , s_mobile , b_status  from BookNow where s_mobile='" + s_mobile + "' ");
    }

    public int UpdateProfileData(string Phone, string fullName, string email, string gender)
    {
        string sql = @"UPDATE [signup] SET [s_mobile] = '" + Phone + "', [s_fullname] = '" + fullName + "',[s_email]='" + email + "',[s_gender]='" + gender + "' , [s_mdfy_date] = getdate() WHERE s_mobile ='" + Phone + "'";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }


    public int UpdatePhoto(string Phone, string s_photo, string s_photoPath)
    {
        string sql = @"UPDATE [signup] SET ";

        if (s_photo.Length > 0)
        {
            sql = sql + "  [s_photo] = '" + s_photo + "', [s_photoPath] = '" + s_photoPath + "'";
        }

        sql = sql + " , [s_mdfy_date] = getdate() WHERE s_mobile ='" + Phone + "'";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public int UpdateStatus(string transID, string Mobile)
    {
        string sql = @"UPDATE [BookNow] SET [b_status] = 'Booked' where trascId = '" + transID + "'  and s_mobile = '" + Mobile + "'";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }


    public void AddProfle(string mobile, string rdbfood, string rdbSmoke, string rdbDrink, string rdbStay, string allergies)
    {
        string sql = "insert into tblprofile(s_mobile ,  p_food , p_smok , p_drink , p_stay ,  p_allergies , p_cr_date , p_mdfy_date ) values('" + mobile + "','" + rdbfood + "','" + rdbSmoke + "','" + rdbDrink + "','" + rdbStay + "', '" + allergies + "',  getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }


    public void AddKycDocuments(string mobile, string identityProof, string NameOnIdentity, string IdentityNo, string filenamePhotoFront, string pathPhotoFront, string filenamePhotoBack, string pathPhotoBack)
    {
        string sql = "insert into kycDocs(s_mobile ,  k_docsName , k_NameOnDocs , k_docsIdNo ,  k_frontName , k_frontPath , k_BackName ,k_BackPath , k_cr_date , k_mdfy_date  ) values('" + mobile + "','" + identityProof + "','" + NameOnIdentity + "','" + IdentityNo + "','" + filenamePhotoFront + "', '" + pathPhotoFront + "','" + filenamePhotoBack + "','" + pathPhotoBack + "',  getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }


    public void AddBankDetails(string mobile, string BankName, string AccountHolderName, string BankAccountNo, string ifsccode, string Branch)
    {
        string sql = "insert into BankDetails(s_mobile ,  b_Name , b_AccountHolderName , b_AccountNo ,  b_IfscCode , b_branch , b_cr_date , b_mdfy_date) values('" + mobile + "','" + BankName + "','" + AccountHolderName + "','" + BankAccountNo + "','" + ifsccode + "', '" + Branch + "',  getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddProperty(string mobile, string PropertyName, string PropertyAddress, string City, string pinCode, string MapLink, string ManagerName, string ManagerPhone, string gender, string StartPrice, string DiscountPrice, string DiscountPercentage, string filenameimage1, string pathimage1, string filenameimage2, string pathimage2, string filenameimage3, string pathimage3)
    {
        string sql = "insert into Property(s_mobile ,  p_name , p_address , p_city ,  p_pincode , p_maplink , p_mgName , p_pgMobile , p_gender , p_StartPrice , p_discountprice , p_DicountPercent , p_imageName1 , p_image1Path ,p_imageName2 ,p_image2Path ,p_imageName3 ,p_image3Path ,p_crdate ,p_mdfyDate) values('" + mobile + "','" + PropertyName + "','" + PropertyAddress + "','" + City + "','" + pinCode + "', '" + MapLink + "', '" + ManagerName + "', '" + ManagerPhone + "', '" + gender + "', '" + StartPrice + "', '" + DiscountPrice + "', '" + DiscountPercentage + "', '" + filenameimage1 + "', '" + pathimage1 + "', '" + filenameimage2 + "', '" + pathimage2 + "', '" + filenameimage3 + "', '" + pathimage3 + "',  getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet LoadPropert(string PropertyValue)
    {
        string sql = "select p_id , p_name , p_gender, p_address, p_maplink , p_StartPrice , p_discountprice , p_DicountPercent,  p_image1Path from Property ";

        if (PropertyValue == "0")
        {
            sql = sql + " where 1=1 and   p_id > 0";
        }
        else
        {
            sql = sql + "where p_id = '" + PropertyValue + "' and   p_id > 0";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet LoadPropert()
    {
        string sql = "select p_id , p_name , p_gender, p_address, p_maplink , p_StartPrice , p_discountprice , p_DicountPercent,  p_image1Path from Property  where p_id > 0";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet LoadPropertAll()
    {
        string sql = "select p_id , p_name , p_gender, p_address, p_maplink , p_StartPrice , p_discountprice , p_DicountPercent,  p_image1Path from Property  where 1=1";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }


    public void AddRooms(string mobile, string PropertyName, string PropertyVale, string roomNo, string FloorNoText, string FloorNoValue, string BedsText, string BedsValue, string Rent, string SecurityDeposit, string Remark, string Ac, string NonAC, string Ventilation, string Washroom, string LargeRoom, string Balcony, string CornerRoom, string WiFi)
    {
        string sql = "insert into Rooms(r_mobile , r_PropertyName , r_PropertyVale , r_roomNo , r_FloorNoText , r_FloorNovalue , r_BedsText ,r_BedsValue , r_Rent, r_SecurityDeposit, r_Remark , r_Ac , r_NonAC , r_Ventilation , r_Washroom , r_LargeRoom , r_Balcony , r_CornerRoom , r_WiFi , r_crdate , r_mdfydate )values('" + mobile + "', '" + PropertyName + "', '" + PropertyVale + "', '" + roomNo + "', '" + FloorNoText + "', '" + FloorNoValue + "', '" + BedsText + "', '" + BedsValue + "', '" + Rent + "', '" + SecurityDeposit + "', '" + Remark + "', '" + Ac + "', '" + NonAC + "', '" + Ventilation + "', '" + Washroom + "', '" + LargeRoom + "', '" + Balcony + "', '" + CornerRoom + "', '" + WiFi + "' ,getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet LoadRooms(string PropertyVale)
    {
        string sql = "select r_id , r_PropertyName , r_PropertyVale , r_roomNo , r_FloorNoText , r_FloorNovalue , r_BedsText ,r_BedsValue , r_Rent, r_SecurityDeposit, r_Remark , r_Ac , r_NonAC , r_Ventilation , r_Washroom , r_LargeRoom , r_Balcony , r_CornerRoom , r_WiFi  from Rooms  ";
        if (PropertyVale == "0")
        {
            sql = sql + " where 1=1 order by r_roomNo asc ";
        }
        else
        {
            sql = sql + " where r_PropertyVale = '" + PropertyVale + "' order by r_roomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }


    public DataSet LoadRoomsAll()
    {
        string sql = "select r_id , r_PropertyName , r_PropertyVale , r_roomNo  , r_FloorNoText , r_FloorNovalue , r_BedsText ,r_BedsValue , r_Rent, r_SecurityDeposit, r_Remark , r_Ac , r_NonAC , r_Ventilation , r_Washroom , r_LargeRoom , r_Balcony , r_CornerRoom , r_WiFi  from Rooms where 1=1 ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }


    public DataSet AddTenants(string mobile, string PropertyName, string PropertyVale, string Name, string MobileNo, string RoomNo, string BedsText, string BedsValue, string SecurityMoney, string RentMoney, string DateOfJoining, string RentDate, string LockinPeriodValue, string LockinPeriodText, string Details)
    {
        string sql = "insert into Tenants(t_mobile , t_PropertyName , t_PropertyVale , t_Name , t_MobileNo , t_RoomNo , t_BedsText , t_BedsValue ,t_SecurityMoney , t_RentMoney , t_DateOfJoining, t_RentDate, t_LockinPeriodValue , t_LockinPeriodText ,  t_Details , KycStatus , t_BankDetailStatus , t_crdate , t_mdfydate )values('" + mobile + "', '" + PropertyName + "', '" + PropertyVale + "', '" + Name + "', '" + MobileNo + "', '" + RoomNo + "','" + BedsText + "' , '" + BedsValue + "' , '" + SecurityMoney + "', '" + RentMoney + "', '" + DateOfJoining + "', '" + RentDate + "', '" + LockinPeriodValue + "', '" + LockinPeriodText + "', '" + Details + "' , 'Pending' , 'Pending' , getdate() , getdate())";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }


    public DataSet LoadTenantsAll()
    {
        string sql = "select t_id , t_mobile ,  t_PropertyName , t_PropertyVale , t_Name , t_MobileNo , t_RoomNo , t_SecurityMoney , t_RentMoney , convert(varchar ,t_DateOfJoining, 103) as  t_DateOfJoining, convert(varchar ,t_RentDate, 103) as  t_RentDate , t_LockinPeriodValue , t_LockinPeriodText , t_Details ,  convert(varchar ,t_crdate , 103) as t_crdate , t_mdfydate from Tenants where 1=1  order by t_RoomNo asc";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet Loadtenants(string PropertyVale)
    {
        string sql = "select t_id ,t_mobile , t_PropertyName , t_PropertyVale , t_Name , t_MobileNo , t_RoomNo , t_SecurityMoney ,t_BedsText , t_RentMoney , t_DateOfJoining, t_RentDate, t_LockinPeriodValue , t_LockinPeriodText , t_Details , KycStatus , t_BankDetailStatus , t_crdate , t_mdfydate from Tenants";
        if (PropertyVale == "0")
        {
            sql = sql + " where 1=1 order by t_RoomNo asc";
        }
        else
        {
            sql = sql + " where t_PropertyVale = '" + PropertyVale + "' order by t_RoomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet ShowCareer()
    {
        string sql = "select c_id , c_FullName , c_Mobile , c_email , c_Applyfor ,  c_filenameUploadCv , c_pathUploadCv , c_crdate , c_mdfydate from Careers";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet ShowCoaching()
    {
        string sql = "select c_id , c_CoachingName ,  c_FullName , c_Mobile , c_email ,  c_Designation , convert(varchar ,c_crdate ,103) as c_crdate, c_mdfyDate from Coaching";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetLeseProperty()
    {
        string sql = "select l_id , l_FullName ,  l_Mobile , l_City , l_NoBedRoom ,  l_NoOfWashrooom , l_PropertyAddress ,  l_Status , l_Map , convert(varchar , l_crdate , 103) as l_crdate, l_mdfyDate from LeasProperty";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet ViewVisitings()
    {
        string sql = "select p_name , p_address, pgm_name , pgm_mobile , CONVERT(VARCHAR, v_date, 103) as v_date , v_timeslot,  s_name , s_mobile  from ScheduleVisit  ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet ViewBookingsall(string propertyvalue)
    {
        string sql = "select b_id , p_name , p_address, pgm_name ,  pgm_mobile ,b_amount, CONVERT(VARCHAR, b_date, 103) as b_date , b_timeslot,  s_name , s_mobile , b_status  from BookNow where p_name = '" + propertyvalue + "'";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet GetScheduleVisit(string PropertyValue)
    {
        string sql = "select v.v_id , v.v_type , Convert(varchar , v.v_date , 103) as v_date, v.v_timeslot ,  v.s_name ,v.s_mobile,  v.s_gender,  v.p_name , v.p_roomtype , v.p_image  , v.p_address , v.p_maplink  , v.pgm_name  , v.pgm_mobile , convert(varchar , v.v_crdate , 103 ) as v_crdate  from ScheduleVisit v join  property p   on v.property_id =p.p_id";
        if (PropertyValue == "0")
        {
            sql = sql + " where 1=1 ";
        }
        else
        {
            sql = sql + " where p.p_id='" + PropertyValue + "'";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetBookings(string PropertyValue)
    {
        string sql = "select b.b_id , b.p_name , b.p_address, b.pgm_name ,  b.pgm_mobile ,b.b_amount, CONVERT(VARCHAR, b.b_date, 103) as b_date , b.b_timeslot,  b.s_name , b.s_mobile , b.b_status  from BookNow b join  property p   on b.property_id =p.p_id";
        if (PropertyValue == "0")
        {
            sql = sql + " where 1=1  order by b.b_id desc ";
        }
        else
        {
            sql = sql + " where p.p_id='" + PropertyValue + "' order by b.b_id desc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    //public DataSet ViewBookings(string pro)
    //{
    //    string sql = "select b_id , p_name , p_address, pgm_name ,  pgm_mobile ,b_amount, CONVERT(VARCHAR, b_date, 103) as b_date , b_timeslot,  s_name , s_mobile , b_status  from BookNow";
    //    return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    //}

    public DataSet LoadUsers()
    {
        string sql = "select s_fullname , s_email, s_mobile, s_gender , s_password ,  s_check, s_cr_date, s_mdfy_date , s_usertype , s_isActive from signup";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddTicketCategory(string TicketCategory)
    {
        string sql = "insert into TicketCategory(tc_name,tc_crdate,tc_mdfy)values('" + TicketCategory + "' ,getdate(),getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }



    public void AddIssueCategory(string TicketCategoryValue, string TicketCategoryName, string FacingIssu)
    {
        string sql = "insert into FacingIssue(tc_id , tc_name , fi_name , fi_crdate , fi_mdfy)values('" + TicketCategoryValue + "',  '" + TicketCategoryName + "','" + FacingIssu + "', getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    
    public void AddUpdateIssueCategory(string TicketCategoryValue,  string FacingIssu)
    {
        string sql = "update FacingIssue set fi_name ='"+ FacingIssu + "' , fi_mdfy = getdate() where fi_id = '" + TicketCategoryValue + "'  ";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }


    public SqlDataReader GetSubCategory(string TicketCategoryValue)
    {
        string sql = "select fi_id , fi_name from FacingIssue where tc_id ='" + TicketCategoryValue + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetSubCategoryOnupdate(string TicketCategoryValue)
    {
        string sql = "select fi_id , fi_name from FacingIssue where tc_id ='" + TicketCategoryValue + "' ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public void AddIssueSubCategory(string TicketCategoryMainissueValue, string TicketCategoryMainissueName, string FacingIssueValue, string FacingIssueName, string FacingIssueSubCategoryName)
    {
        string sql = "insert into FacingSubCategoryIssue(tc_id, tc_name ,fi_id ,fi_name,fsc_Name , fsc_crdate , fsc_mdfy)values('" + TicketCategoryMainissueValue + "','" + TicketCategoryMainissueName + "','" + FacingIssueValue + "','" + FacingIssueName + "','" + FacingIssueSubCategoryName + "' ,getdate(),getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdateIssueSubCategory(string TicketCategoryMainissueValue, string FacingIssueSubCategoryName)
    {
        string sql = "update FacingSubCategoryIssue  set fsc_Name ='"+ FacingIssueSubCategoryName  + "' , fsc_mdfy = getdate() where  fsc_id= '" + TicketCategoryMainissueValue + "' ";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    

    public void AddFooMenu(string Mobile, string WeekdaysValue, string WeekdaysText, string Breakfast, string BreakfastTime, string BreakfastTimeTo, string Lunch, string LunchTime, string LunchTimeTo, string Snacks, string SnacksTime, string SnacksTimeTo, string Dinner, string DinnarTime, string DinnarTimeTo)
    {
        string sql = "insert into FoodMenu(st_mobile ,f_WeekdaysValue,  f_WeekdaysText,  f_Breakfast,  f_BreakfastTime, f_BreakfastTimeto , f_Lunch,  f_LunchTime,f_LunchTimeTo ,  f_Snacks,  f_SnacksTime, f_SnacksTimeTo , f_Dinner,  f_DinnarTime , f_DinnarTimeTo ,f_crdate ,f_mdfydate)values('" + Mobile + "','" + WeekdaysValue + "', '" + WeekdaysText + "', '" + Breakfast + "', '" + BreakfastTime + "','" + BreakfastTimeTo + "', '" + Lunch + "', '" + LunchTime + "', '" + LunchTimeTo + "', '" + Snacks + "', '" + SnacksTime + "',  '" + SnacksTimeTo + "', '" + Dinner + "', '" + DinnarTime + "','" + DinnarTimeTo + "',getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }



    //public DataSet ShowFoodMenu()
    //{
    //    string sql = "select f_id , f_WeekdaysValue,  f_WeekdaysText,  f_Breakfast,  CONVERT(varchar(15),CAST(f_BreakfastTime AS TIME),100) as f_BreakfastTime ,  f_Lunch, CONVERT(varchar(15),CAST(f_LunchTime AS TIME),100) as f_LunchTime ,   f_Snacks, CONVERT(varchar(15),CAST(f_SnacksTime AS TIME),100) as f_SnacksTime ,  f_Dinner,  CONVERT(varchar(15),CAST(f_DinnarTime AS TIME),100) as f_DinnarTime  ,f_crdate ,f_mdfydate from FoodMenu where f_WeekdaysText='sunday' ";
    //    return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    //}
    public DataSet GetfoodmenuSunday()
    {
        string sql = "select f_id ,  f_WeekdaysValue ,  f_WeekdaysText ,  f_Breakfast ,  CONVERT(varchar(15),CAST(f_BreakfastTime AS TIME),100) as f_BreakfastTime  ,  CONVERT(varchar(15),CAST(f_BreakfastTimeto AS TIME),100) as f_BreakfastTimeto  ,  f_Lunch , CONVERT(varchar(15),CAST(f_LunchTime AS TIME),100) as  f_LunchTime , CONVERT(varchar(15),CAST(f_LunchTimeTo AS TIME),100) as  f_LunchTimeTo , f_Snacks , CONVERT(varchar(15),CAST(f_SnacksTime AS TIME),100) as f_SnacksTime , CONVERT(varchar(15),CAST(f_SnacksTimeTo AS TIME),100) as f_SnacksTimeTo , f_Dinner , CONVERT(varchar(15),CAST(f_DinnarTime AS TIME),100) as f_DinnarTime ,  CONVERT(varchar(15),CAST(f_DinnarTimeTo AS TIME),100) as f_DinnarTimeTo from FoodMenu where f_WeekdaysText ='Sunday'";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetfoodmenuMonday()
    {
        string sql = "select  f_id ,  f_WeekdaysValue ,  f_WeekdaysText ,  f_Breakfast ,  CONVERT(varchar(15),CAST(f_BreakfastTime AS TIME),100) as f_BreakfastTime  ,  CONVERT(varchar(15),CAST(f_BreakfastTimeto AS TIME),100) as f_BreakfastTimeto  ,  f_Lunch , CONVERT(varchar(15),CAST(f_LunchTime AS TIME),100) as  f_LunchTime , CONVERT(varchar(15),CAST(f_LunchTimeTo AS TIME),100) as  f_LunchTimeTo , f_Snacks , CONVERT(varchar(15),CAST(f_SnacksTime AS TIME),100) as f_SnacksTime , CONVERT(varchar(15),CAST(f_SnacksTimeTo AS TIME),100) as f_SnacksTimeTo , f_Dinner , CONVERT(varchar(15),CAST(f_DinnarTime AS TIME),100) as f_DinnarTime ,  CONVERT(varchar(15),CAST(f_DinnarTimeTo AS TIME),100) as f_DinnarTimeTo from FoodMenu where f_WeekdaysText ='Monday'";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }


    public object GetfoodmenuTuesday()
    {
        string sql = "select  f_id ,  f_WeekdaysValue ,  f_WeekdaysText ,  f_Breakfast ,  CONVERT(varchar(15),CAST(f_BreakfastTime AS TIME),100) as f_BreakfastTime  ,  CONVERT(varchar(15),CAST(f_BreakfastTimeto AS TIME),100) as f_BreakfastTimeto  ,  f_Lunch , CONVERT(varchar(15),CAST(f_LunchTime AS TIME),100) as  f_LunchTime , CONVERT(varchar(15),CAST(f_LunchTimeTo AS TIME),100) as  f_LunchTimeTo , f_Snacks , CONVERT(varchar(15),CAST(f_SnacksTime AS TIME),100) as f_SnacksTime , CONVERT(varchar(15),CAST(f_SnacksTimeTo AS TIME),100) as f_SnacksTimeTo , f_Dinner , CONVERT(varchar(15),CAST(f_DinnarTime AS TIME),100) as f_DinnarTime ,  CONVERT(varchar(15),CAST(f_DinnarTimeTo AS TIME),100) as f_DinnarTimeTo from FoodMenu where f_WeekdaysText ='Tuesday'";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetfoodmenuWednesday()
    {
        string sql = "select  f_id ,  f_WeekdaysValue ,  f_WeekdaysText ,  f_Breakfast ,  CONVERT(varchar(15),CAST(f_BreakfastTime AS TIME),100) as f_BreakfastTime  ,  CONVERT(varchar(15),CAST(f_BreakfastTimeto AS TIME),100) as f_BreakfastTimeto  ,  f_Lunch , CONVERT(varchar(15),CAST(f_LunchTime AS TIME),100) as  f_LunchTime , CONVERT(varchar(15),CAST(f_LunchTimeTo AS TIME),100) as  f_LunchTimeTo , f_Snacks , CONVERT(varchar(15),CAST(f_SnacksTime AS TIME),100) as f_SnacksTime , CONVERT(varchar(15),CAST(f_SnacksTimeTo AS TIME),100) as f_SnacksTimeTo , f_Dinner , CONVERT(varchar(15),CAST(f_DinnarTime AS TIME),100) as f_DinnarTime ,  CONVERT(varchar(15),CAST(f_DinnarTimeTo AS TIME),100) as f_DinnarTimeTo from FoodMenu where f_WeekdaysText ='Wednesday'";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetfoodmenuThursday()
    {
        string sql = "select  f_id ,  f_WeekdaysValue ,  f_WeekdaysText ,  f_Breakfast ,  CONVERT(varchar(15),CAST(f_BreakfastTime AS TIME),100) as f_BreakfastTime  ,  CONVERT(varchar(15),CAST(f_BreakfastTimeto AS TIME),100) as f_BreakfastTimeto  ,  f_Lunch , CONVERT(varchar(15),CAST(f_LunchTime AS TIME),100) as  f_LunchTime , CONVERT(varchar(15),CAST(f_LunchTimeTo AS TIME),100) as  f_LunchTimeTo , f_Snacks , CONVERT(varchar(15),CAST(f_SnacksTime AS TIME),100) as f_SnacksTime , CONVERT(varchar(15),CAST(f_SnacksTimeTo AS TIME),100) as f_SnacksTimeTo , f_Dinner , CONVERT(varchar(15),CAST(f_DinnarTime AS TIME),100) as f_DinnarTime ,  CONVERT(varchar(15),CAST(f_DinnarTimeTo AS TIME),100) as f_DinnarTimeTo from FoodMenu where f_WeekdaysText ='Thursday'";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetfoodmenuFriday()
    {
        string sql = "select  f_id ,  f_WeekdaysValue ,  f_WeekdaysText ,  f_Breakfast ,  CONVERT(varchar(15),CAST(f_BreakfastTime AS TIME),100) as f_BreakfastTime  ,  CONVERT(varchar(15),CAST(f_BreakfastTimeto AS TIME),100) as f_BreakfastTimeto  ,  f_Lunch , CONVERT(varchar(15),CAST(f_LunchTime AS TIME),100) as  f_LunchTime , CONVERT(varchar(15),CAST(f_LunchTimeTo AS TIME),100) as  f_LunchTimeTo , f_Snacks , CONVERT(varchar(15),CAST(f_SnacksTime AS TIME),100) as f_SnacksTime , CONVERT(varchar(15),CAST(f_SnacksTimeTo AS TIME),100) as f_SnacksTimeTo , f_Dinner , CONVERT(varchar(15),CAST(f_DinnarTime AS TIME),100) as f_DinnarTime ,  CONVERT(varchar(15),CAST(f_DinnarTimeTo AS TIME),100) as f_DinnarTimeTo from FoodMenu where f_WeekdaysText ='Friday'";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object GetfoodmenuSaturday()
    {
        string sql = "select  f_id ,  f_WeekdaysValue ,  f_WeekdaysText ,  f_Breakfast ,  CONVERT(varchar(15),CAST(f_BreakfastTime AS TIME),100) as f_BreakfastTime  ,  CONVERT(varchar(15),CAST(f_BreakfastTimeto AS TIME),100) as f_BreakfastTimeto  ,  f_Lunch , CONVERT(varchar(15),CAST(f_LunchTime AS TIME),100) as  f_LunchTime , CONVERT(varchar(15),CAST(f_LunchTimeTo AS TIME),100) as  f_LunchTimeTo , f_Snacks , CONVERT(varchar(15),CAST(f_SnacksTime AS TIME),100) as f_SnacksTime , CONVERT(varchar(15),CAST(f_SnacksTimeTo AS TIME),100) as f_SnacksTimeTo , f_Dinner , CONVERT(varchar(15),CAST(f_DinnarTime AS TIME),100) as f_DinnarTime ,  CONVERT(varchar(15),CAST(f_DinnarTimeTo AS TIME),100) as f_DinnarTimeTo from FoodMenu where f_WeekdaysText ='Saturday'";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }


    public SqlDataReader GetNameroomNo(string t_id)
    {
        string sql = "select * from Tenants where t_id ='" + t_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetDueTypePendingDueAmount(string propertyValue, string payeeName, string dueType)
    {

        string sql = "select t_Name , t_PropertyVale , t_SecurityMoney , t_RentMoney , t_MobileNo , from Tenants where t_PropertyVale ='" + propertyValue + "'  and t_Name ='" + payeeName + "'  and dueType ='" + dueType + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddDues(string Mobile, string PropertyName, string PropertyValue, string PayeeText, string PayeeValue, string RoomNo, string t_Mobile, string DuesTypeText, string DuesTypeValue, string DuesAmount, string DuesDate, string DuesMonth, string Remark)
    {
        string sql = "insert into Dues( d_Mobile , d_prpertyname , d_prpertyvalue , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText,  d_DuesTypeValue,  d_DuesAmount, d_DuesDate,  d_DuesMonth,  d_Remark ,d_status , d_DeleteStatus , d_crdate ,d_mdfydate )values('" + Mobile + "', '" + PropertyName + "', '" + PropertyValue + "','" + PayeeText + "',  '" + PayeeValue + "', '" + RoomNo + "',  '" + t_Mobile + "' , '" + DuesTypeText + "', '" + DuesTypeValue + "', '" + DuesAmount + "', '" + DuesDate + "', '" + DuesMonth + "', '" + Remark + "', 'pending' ,'No', getdate() ,getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getSerchDuesBytext(string Search, string propertyvalue)
    {
        string sql = "select d_id , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText,  d_DuesTypeValue,  d_DuesAmount, CONVERT(varchar , d_DuesDate , 103 ) as d_DuesDate , CONVERT(varchar , d_DuesMonth , 103) as d_DuesMonth , d_Remark ,convert (varchar ,d_crdate ,103) as d_crdate , d_mdfydate from  Dues";
        if ((Search != "") && (propertyvalue != "0"))
        {
            sql = sql + " where d_DeleteStatus ='No' and ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "')) and d_prpertyvalue ='" + propertyvalue + "' and  d_status= 'pending'  order by d_RoomNo asc";
        }
        else if ((Search != "") && (propertyvalue == "0"))
        {
            sql = sql + " where d_DeleteStatus ='No' and ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "'))  and  d_status= 'pending'   order by d_RoomNo asc";
        }
        else if ((Search == "") && (propertyvalue != "0"))
        {
            sql = sql + " where  d_DeleteStatus ='No' and ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "'))  and  d_status= 'pending'  order by d_RoomNo asc";
        }
        else
        {
            sql = sql + " where 1=1  and  d_status= 'pending' and d_DeleteStatus ='No' order by d_id desc  order by d_RoomNo asc";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getSerchDeletedDuesBytext(string Search, string propertyvalue)
    {
        string sql = "select d_id , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText,  d_DuesTypeValue,  d_DuesAmount, CONVERT(varchar , d_DuesDate , 103 ) as d_DuesDate , CONVERT(varchar , d_DuesMonth , 103) as d_DuesMonth , d_Remark ,convert (varchar ,d_crdate ,103) as d_crdate , d_mdfydate from  Dues";
        if ((Search != "") && (propertyvalue != "0"))
        {
            sql = sql + " where d_DeleteStatus ='Yes' and ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "')) and d_prpertyvalue ='" + propertyvalue + "' and  d_status= 'pending'  order by d_RoomNo asc";
        }
        else if ((Search != "") && (propertyvalue == "0"))
        {
            sql = sql + " where d_DeleteStatus ='Yes' and ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "'))  and  d_status= 'pending'   order by d_RoomNo asc";
        }
        else if ((Search == "") && (propertyvalue != "0"))
        {
            sql = sql + " where  d_DeleteStatus ='Yes' and ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "'))  and  d_status= 'pending'  order by d_RoomNo asc";
        }
        else
        {
            sql = sql + " where 1=1  and  d_status= 'pending' and d_DeleteStatus ='Yes' order by d_id desc  order by d_RoomNo asc";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getDues(string propertyvalue)
    {
        string sql = "select d_id , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText,  d_DuesTypeValue,  d_DuesAmount, CONVERT(varchar , d_DuesDate , 103 ) as d_DuesDate , CONVERT(varchar , d_DuesMonth , 103) as d_DuesMonth , d_Remark ,convert (varchar ,d_crdate ,103) as d_crdate ,d_mdfydate from  Dues";
        if (propertyvalue == "0")
        {
            sql = sql + " where 1=1 and d_status= 'pending' and d_DeleteStatus ='No'  order by d_RoomNo asc";
        }
        else
        {
            sql = sql + " where d_prpertyvalue ='" + propertyvalue + "' and d_status= 'pending' and  d_DeleteStatus ='No'   order by d_RoomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet getDeletedDues(string propertyvalue)
    {
        string sql = "select d_id , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText,  d_DuesTypeValue,  d_DuesAmount, CONVERT(varchar , d_DuesDate , 103 ) as d_DuesDate , CONVERT(varchar , d_DuesMonth , 103) as d_DuesMonth , d_Remark ,convert (varchar ,d_crdate ,103) as d_crdate ,d_mdfydate from  Dues";
        if (propertyvalue == "0")
        {
            sql = sql + " where 1=1 and d_status= 'pending' and d_DeleteStatus ='Yes' order by d_RoomNo asc";
        }
        else
        {
            sql = sql + " where d_prpertyvalue ='" + propertyvalue + "' and d_status= 'pending' and d_DeleteStatus ='Yes'  order by d_RoomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet getIncomee(string propertyvalue)
    {
        string sql = "select d_id , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText,  d_DuesTypeValue,  d_DuesAmount, d_recivedAmount , CONVERT(varchar , d_DuesDate , 103 ) as d_DuesDate , CONVERT(varchar , d_reciveddate , 103 ) as d_reciveddate ,  CONVERT(varchar , d_DuesMonth , 103) as d_DuesMonth ,  d_Remark ,convert (varchar ,d_crdate ,103) as d_crdate ,d_mdfydate from  Dues";
        if (propertyvalue == "0")
        {
            sql = sql + " where 1=1 and d_status= 'recived' order by d_RoomNo asc";
        }
        else
        {
            sql = sql + " where d_prpertyvalue ='" + propertyvalue + "' and d_status= 'recived' order by d_RoomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getIncomeAll(string propertyvalue)
    {
        string sql = "select d_id , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText, d_DuesMonth,  d_DuesTypeValue, d_recivedAmount , d_DuesAmount, CONVERT(varchar , d_reciveddate , 103 ) as d_reciveddate , CONVERT(varchar , d_reciveddate , 103 ) as d_reciveddate ,  CONVERT(varchar , d_DuesMonth , 103) as d_DuesMonth ,  d_Remark ,convert (varchar ,d_crdate ,103) as d_crdate ,d_mdfydate from  Dues";
        if (propertyvalue == "0")
        {
            sql = sql + " where 1=1 and d_status= 'recived' and d_DuesMonth = 'February-2021' order by d_RoomNo asc";
        }
        else
        {
            sql = sql + " where d_prpertyvalue ='" + propertyvalue + "' and  d_DuesMonth = 'February-2021' and  d_status= 'recived' order by d_RoomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getIncomeAllByMonth(string propertyvalue , string Month)
    {
        string sql = "select d_id , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText,  d_DuesMonth , d_DuesTypeValue, d_recivedAmount , d_DuesAmount, CONVERT(varchar , d_reciveddate , 103 ) as d_reciveddate , CONVERT(varchar , d_reciveddate , 103 ) as d_reciveddate ,  CONVERT(varchar , d_DuesMonth , 103) as d_DuesMonth ,  d_Remark ,convert (varchar ,d_crdate ,103) as d_crdate ,d_mdfydate from  Dues";
        if (propertyvalue == "0")
        {
            sql = sql + " where 1=1 and d_status= 'recived' and d_DuesMonth = '" + Month + "' order by d_RoomNo asc";
        }
        else
        {
            sql = sql + " where d_prpertyvalue ='" + propertyvalue + "' and  d_DuesMonth = '" + Month + "' and  d_status= 'recived' order by d_RoomNo asc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetNewComplaints(string tc_PropertyVal)
    {
        string sql = "select tc_id  , tc_Name  , tc_RoomNo  , tc_Mobile , tc_image , tc_MainIssueText  , tc_MainIssueValue , tc_issueText , tc_issueValue , tc_subCatIssueText , tc_subCatIssueValue , tc_message  , tc_status , convert(varchar , tc_crDate , 103) as tc_crDate  from Ticketcomplaints";
        if (tc_PropertyVal == "0")
        {
            sql = sql + " where tc_status = 'unresolved' and 1=1 ";
        }
        if (tc_PropertyVal != "0")
        {
            sql = sql + " where tc_status = 'unresolved' and tc_PropertyVal='" + tc_PropertyVal + "' ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetNewComplaintsMsg(string tc_PropertyVal)
    {
        string sql = "select tc_id  , tc_Name  , tc_RoomNo  , tc_Mobile , tc_image , tc_MainIssueText  , tc_MainIssueValue , tc_issueText , tc_issueValue , tc_subCatIssueText , tc_subCatIssueValue , tc_message  , tc_status , convert(varchar , tc_crDate , 103) as tc_crDate  from Ticketcomplaints";
        if (tc_PropertyVal == "0")
        {
            sql = sql + " where tc_status = 'unresolved' and 1=1 ";
        }
        if (tc_PropertyVal != "0")
        {
            sql = sql + " where tc_status = 'unresolved' and tc_PropertyVal='" + tc_PropertyVal + "' ";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet GetNewComplaintsbySearch(string tc_PropertyVal, string Search)
    {
        string sql = "select tc_id  , tc_Name  , tc_RoomNo  , tc_Mobile , tc_image , tc_MainIssueText  , tc_MainIssueValue , tc_issueText , tc_issueValue , tc_subCatIssueText , tc_subCatIssueValue , tc_message  , tc_status , convert(varchar , tc_crDate , 103) as tc_crDate  from Ticketcomplaints";
        if (tc_PropertyVal == "0")
        {
            sql = sql + " where tc_status = 'unresolved' and 1=1 and ((tc_Name = '" + Search.Trim() + "') or (tc_Mobile = '" + Search.Trim() + "') or (tc_RoomNo = '" + Search.Trim() + "'))";
        }
        if (tc_PropertyVal != "0")
        {
            sql = sql + " where tc_status = 'unresolved' and tc_PropertyVal='" + tc_PropertyVal + "'  and ((tc_Name = '" + Search.Trim() + "') or (tc_Mobile = '" + Search.Trim() + "') or (tc_RoomNo = '" + Search.Trim() + "'))";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetOngoingComplaints(string tc_PropertyVal)
    {
        string sql = "select tc_id  , tc_Name  , tc_RoomNo  , tc_Mobile , tc_image , tc_MainIssueText  , tc_MainIssueValue , tc_issueText , tc_issueValue , tc_subCatIssueText , tc_subCatIssueValue , tc_message  , tc_status , convert(varchar , tc_crDate , 103) as tc_crDate  from Ticketcomplaints ";
        if (tc_PropertyVal == "0")
        {
            sql = sql + "  where (tc_status = 'Acknowledged (By Management)' or tc_status = 'Verified (By Staff)' or tc_status = 'Tenant Availability Time Requested'  or tc_status = 'More Details/Time Required'  or tc_status = 'Service Person Assigned') and 1=1";
        }
        else
            if (tc_PropertyVal != "0")
        {
            sql = sql + "  where (tc_status = 'Acknowledged (By Management)' or tc_status = 'Verified (By Staff)' or tc_status = 'Tenant Availability Time Requested'  or tc_status = 'More Details/Time Required'  or tc_status = 'Service Person Assigned') and and tc_PropertyVal='" + tc_PropertyVal + "'";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetOngoingComplaintsMsg(string tc_PropertyVal)
    {
        string sql = "select tc_id  , tc_Name  , tc_RoomNo  , tc_Mobile , tc_image , tc_MainIssueText  , tc_MainIssueValue , tc_issueText , tc_issueValue , tc_subCatIssueText , tc_subCatIssueValue , tc_message  , tc_status , convert(varchar , tc_crDate , 103) as tc_crDate  from Ticketcomplaints ";
        if (tc_PropertyVal == "0")
        {
            sql = sql + "  where (tc_status = 'Acknowledged (By Management)' or tc_status = 'Verified (By Staff)' or tc_status = 'Tenant Availability Time Requested'  or tc_status = 'More Details/Time Required'  or tc_status = 'Service Person Assigned') and 1=1";
        }
        else
            if (tc_PropertyVal != "0")
        {
            sql = sql + "  where (tc_status = 'Acknowledged (By Management)' or tc_status = 'Verified (By Staff)' or tc_status = 'Tenant Availability Time Requested'  or tc_status = 'More Details/Time Required'  or tc_status = 'Service Person Assigned') and and tc_PropertyVal='" + tc_PropertyVal + "'";
        }

        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetOngoingComplaintsbySearch(string tc_PropertyVal, string Search)
    {
        string sql = "select tc_id  , tc_Name  , tc_RoomNo  , tc_Mobile , tc_image , tc_MainIssueText  , tc_MainIssueValue , tc_issueText , tc_issueValue , tc_subCatIssueText , tc_subCatIssueValue , tc_message  , tc_status , convert(varchar , tc_crDate , 103) as tc_crDate  from Ticketcomplaints ";
        if (tc_PropertyVal == "0")
        {
            sql = sql + "  where (tc_status = 'Acknowledged (By Management)' or tc_status = 'Verified (By Staff)' or tc_status = 'Tenant Availability Time Requested'  or tc_status = 'More Details/Time Required'  or tc_status = 'Service Person Assigned') and 1=1 and  ((tc_Name = '" + Search.Trim() + "') or (tc_Mobile = '" + Search.Trim() + "') or (tc_RoomNo = '" + Search.Trim() + "'))";
        }
        else
            if (tc_PropertyVal != "0")
        {
            sql = sql + "  where (tc_status = 'Acknowledged (By Management)' or tc_status = 'Verified (By Staff)' or tc_status = 'Tenant Availability Time Requested'  or tc_status = 'More Details/Time Required'  or tc_status = 'Service Person Assigned') and  tc_PropertyVal='" + tc_PropertyVal + "' and  ((tc_Name = '" + Search.Trim() + "') or (tc_Mobile = '" + Search.Trim() + "') or (tc_RoomNo = '" + Search.Trim() + "'))";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetResolvedComplaints(string tc_PropertyVal)
    {
        string sql = "select tc_id  , tc_Name  , tc_RoomNo  , tc_Mobile , tc_image , tc_MainIssueText  , tc_MainIssueValue , tc_issueText , tc_issueValue , tc_subCatIssueText , tc_subCatIssueValue , tc_message  , tc_status , convert(varchar , tc_crDate , 103) as tc_crDate  from Ticketcomplaints ";
        if (tc_PropertyVal == "0")
        {
            sql = sql + " where tc_status = 'Resolved'  and 1=1";
        }
        else
            if (tc_PropertyVal != "0")
        {
            sql = sql + " where tc_status = 'Resolved'  and tc_PropertyVal = '" + tc_PropertyVal + "' ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetResolvedComplaintsMsg(string tc_PropertyVal)
    {
        string sql = "select tc_id  , tc_Name  , tc_RoomNo  , tc_Mobile , tc_image , tc_MainIssueText  , tc_MainIssueValue , tc_issueText , tc_issueValue , tc_subCatIssueText , tc_subCatIssueValue , tc_message  , tc_status , convert(varchar , tc_crDate , 103) as tc_crDate  from Ticketcomplaints ";
        if (tc_PropertyVal == "0")
        {
            sql = sql + " where tc_status = 'Resolved'  and 1=1";
        }
        else
            if (tc_PropertyVal != "0")
        {
            sql = sql + " where tc_status = 'Resolved'  and tc_PropertyVal = '" + tc_PropertyVal + "' ";
        }
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetResolvedComplaintsbySearch(string tc_PropertyVal, string Search)
    {
        string sql = "select tc_id  , tc_Name  , tc_RoomNo  , tc_Mobile , tc_image , tc_MainIssueText  , tc_MainIssueValue , tc_issueText , tc_issueValue , tc_subCatIssueText , tc_subCatIssueValue , tc_message  , tc_status , convert(varchar , tc_crDate , 103) as tc_crDate  from Ticketcomplaints ";
        if (tc_PropertyVal == "0")
        {
            sql = sql + " where tc_status = 'Resolved'  and 1=1  and  ((tc_Name = '" + Search.Trim() + "') or (tc_Mobile = '" + Search.Trim() + "') or (tc_RoomNo = '" + Search.Trim() + "'))";
        }
        else
            if (tc_PropertyVal != "0")
        {
            sql = sql + " where tc_status = 'Resolved'  and tc_PropertyVal = '" + tc_PropertyVal + "'  and  ((tc_Name = '" + Search.Trim() + "') or (tc_Mobile = '" + Search.Trim() + "') or (tc_RoomNo = '" + Search.Trim() + "')) ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddCategory(String Category)
    {
        string sql = "insert into ExpenseCategory (ex_categoryname ,ec_crdate  , ec_mdfydate) values('" + Category + "' , getdate() , getdate()) ";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddExpence(string Mobile, string PropertyName, string PropertyVal, string CategoryText, string CategoryValue, string Amount, string PaidBytext, string PaidByValue, string PaidTo, string PaymentMethod, string ExpenseDate, string Details)
    {
        string sql = "insert into Expence(st_mobile ,e_PropertyName , e_PropertyVal ,e_CategoryText, e_CategoryValue, e_Amount, e_PaidBytext, e_PaidByValue, e_PaidTo, e_PaymentMethod, e_ExpenseDate, e_Details , e_crdate ,e_mdfydate) values('" + Mobile + "','" + PropertyName + "', '" + PropertyVal + "', '" + CategoryText + "', '" + CategoryValue + "', '" + Amount + "', '" + PaidBytext + "', '" + PaidByValue + "', '" + PaidTo + "', '" + PaymentMethod + "', '" + ExpenseDate + "','" + Details + "', getdate() ,getdate()) ";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getexpense(string PropertyVale)
    {
        string sql = "select  e_id , e_CategoryText, e_CategoryValue, e_Amount, e_PaidBytext, e_PaidByValue, e_PaidTo, e_PaymentMethod, Convert(varchar , e_ExpenseDate, 103 ) as e_ExpenseDate ,  e_Details , convert(varchar , e_crdate ,103 ) as e_crdate ,e_mdfydate from Expence ";
        if (PropertyVale == "0")
        {
            sql = sql + " where 1=1 ";
        }
        else
        {
            sql = sql + " where e_PropertyVal ='" + PropertyVale + "' ";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddAnnouncement(string mobile, string PropertyName, string PropertyVale, string AnnouncementText, string AnnouncementValue, string Mobile, string Announcement)
    {
        string sql = "insert into Announcement(st_mobile ,a_PropertyName, a_PropertyVal , a_Text , a_Value  , a_mobile , a_Details , a_crdate , a_mdfydate)values('" + mobile + "' ,'" + PropertyName + "' , '" + PropertyVale + "' , '" + AnnouncementText + "', '" + AnnouncementValue + "', '" + Mobile + "', '" + Announcement + "' ,  getdate() , getdate() ) ";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getAnouncement(string propertyValue)
    {
        string sql = "select a_id , a_Text ,a_mobile, a_Value  , a_PropertyName, a_PropertyVal , a_Details , Convert(varchar ,a_crdate  ,103) as a_crdate, a_mdfydate from Announcement";
        if (propertyValue != "0")
        {
            sql = sql + " where a_PropertyVal ='" + propertyValue + "' order by a_id desc ";
        }
        else
        {
            sql = sql + " where 1=1 order by a_id desc ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetUserMobile(string s_Name, string s_id)
    {
        string sql = "select t_MobileNo  from Tenants  where  t_Name = '" + s_Name + "' and  t_id ='" + s_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddLeads(string mobile, string PropertyName, string PropertyVale, string Name, string MobileNo, string ParentName, string ParentMobile, string AmountRecieved, string Gender, string RentAmount, string Roomtypepreferred, string Ac, string Ventilation, string Washroom, string LargeRoom, string Balcony, string CornerRoom, string Status, string Comments)
    {
        string sql = "insert into Leads(st_mobile ,l_PropertyName , l_PropertyVal ,l_Name, l_MobileNo, l_ParentName, l_ParentMobile, l_AmountRecieved, l_Gender, l_RentAmount, l_Roomtypepreferred, l_Ac, l_Ventilation, l_Washroom, l_LargeRoom, l_Balcony, l_CornerRoom, l_Status, l_Comments , l_crdate ,l_mdfydate) values ('" + mobile + "' ,'" + PropertyName + "' , '" + PropertyVale + "','" + Name + "', '" + MobileNo + "', '" + ParentName + "', '" + ParentMobile + "', '" + AmountRecieved + "', '" + Gender + "', '" + RentAmount + "', '" + Roomtypepreferred + "', '" + Ac + "', '" + Ventilation + "', '" + Washroom + "', '" + LargeRoom + "', '" + Balcony + "', '" + CornerRoom + "', '" + Status + "', '" + Comments + "' , getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetLeadsAll()
    {
        string sql = "select l_id , l_Name, l_MobileNo, l_ParentName, l_ParentMobile, l_AmountRecieved, l_Gender, l_RentAmount, l_Roomtypepreferred, l_Ac, l_Ventilation, l_Washroom, l_LargeRoom, l_Balcony, l_CornerRoom, l_Status, l_Comments , convert(varchar ,l_crdate , 103 ) as l_crdate ,l_mdfydate from Leads ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet GetLeads(string propertyvalue)
    {
        string sql = "select l_id , l_Name, l_MobileNo, l_ParentName, l_ParentMobile, l_AmountRecieved, l_Gender, l_RentAmount, l_Roomtypepreferred, l_Ac, l_Ventilation, l_Washroom, l_LargeRoom, l_Balcony, l_CornerRoom, l_Status, l_Comments , convert(varchar ,l_crdate , 103 ) as l_crdate ,l_mdfydate from Leads  ";
        if (propertyvalue == "0")
        {
            sql = sql + " where 1=1";
        }
        else
        {
            sql = sql + " where l_PropertyVal ='" + propertyvalue + "'";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddStaff(string Mobile, string Name, string MobileNo, string AdhaarNo, string PanNo, string FullAddress, string DateOfJoining, string password)
    {
        string sql = "insert into staff (st_mobile , s_Name, s_MobileNo, s_AdhaarNo, s_PanNo, s_FullAddress, s_DateOfJoining , s_pass ,s_crdate ,s_mdfyDate) values ('" + Mobile + "', '" + Name + "', '" + MobileNo + "', '" + AdhaarNo + "', '" + PanNo + "', '" + FullAddress + "', '" + DateOfJoining + "' , '" + password + "' , getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getStaff()
    {
        string sql = "select s_id ,s_Name, s_MobileNo, s_AdhaarNo, s_PanNo, s_FullAddress, convert(varchar ,s_DateOfJoining ,103 ) as s_DateOfJoining , convert(varchar , s_crdate , 103 )as s_crdate , s_mdfyDate from staff";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddPartner(string stmobile, string name, string mobile, string doj, string details)
    {
        string sql = "insert into Partner(st_mobile ,p_name ,p_mobile ,p_doj ,p_details , p_crdate ,p_mdfydate) values ('" + stmobile + "' ,'" + name + "' , '" + mobile + "' , '" + doj + "' , '" + details + "' , getdate() , getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet GetPartner()
    {
        string sql = "select p_id ,p_name ,p_mobile , convert(varchar ,p_doj , 103 ) as p_doj , p_details , convert (varchar ,p_crdate , 103 ) as p_crdate , p_mdfydate from  Partner ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader CheckDublicateTenent(string MobileNo)
    {
        string sql = @"SELECT TOP 1 t_name ,  t_MobileNo  , t_RoomNo  FROM Tenants WHERE t_MobileNo = '" + MobileNo + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader CheckOccupency(string Property, string roomNo)
    {
        string sql = "select count (t_MobileNo) as countTen , t_BedsValue  , t_roomNo from tenants where  t_PropertyVale='" + Property + "' and t_roomNo='" + roomNo + "' GROUP BY t_BedsValue , t_roomNo";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader CheckOccupency1(string Property, string roomNo)
    {
        string sql = "select  r_BedsText , r_BedsValue   from Rooms where  r_PropertyVale='" + Property + "' and r_roomNo='" + roomNo + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader CheckProperty(string proprtyName)
    {
        string sql = "select  p_name from Property where p_name='" + proprtyName + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetBedType(string Property, string RoomNo)
    {
        string sql = "select r_id , r_BedsText , r_BedsValue from Rooms  where r_PropertyVale='" + Property + "' and  r_roomNo = '" + RoomNo + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetRoomNo(string PropertyName)
    {
        string sql = "select Top 1 r_roomNo  from Rooms where  r_PropertyName = '" + PropertyName + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader CheckRoomNo(string PropertyValue, string roomNo)
    {
        string sql = "select Top 1 r_roomNo  from Rooms where  r_PropertyVale = '" + PropertyValue + "' and r_RoomNo='" + roomNo + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getWeekdays(string Weekdays)
    {
        string sql = "select f_id , f_WeekdaysValue ,  f_WeekdaysText  from FoodMenu where f_WeekdaysText ='" + Weekdays + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdateFooMenu(string f_id, string WeekdaysValue, string WeekdaysText, string Breakfast, string BreakfastTime, string BreakfastTimeTo, string Lunch, string LunchTime, string LunchTimeTo, string Snacks, string SnacksTime, string SnacksTimeTo, string Dinner, string DinnarTime, string DinnarTimeTo)
    {
        string sql = "update FoodMenu  set f_WeekdaysValue = '" + WeekdaysValue + "',  f_WeekdaysText = '" + WeekdaysText + "',  f_Breakfast = '" + Breakfast + "',  f_BreakfastTime  = '" + BreakfastTime + "' , f_BreakfastTimeto ='" + BreakfastTimeTo + "' , f_Lunch = '" + Lunch + "' ,  f_LunchTime = '" + LunchTime + "',  f_LunchTimeTo = '" + LunchTimeTo + "', f_Snacks = '" + Snacks + "',  f_SnacksTime = '" + SnacksTime + "' , f_SnacksTimeTo = '" + SnacksTimeTo + "' ,  f_Dinner = '" + Dinner + "' ,  f_DinnarTime = '" + DinnarTime + "' ,f_DinnarTimeTo = '" + DinnarTimeTo + "', f_mdfydate =getdate()  where f_WeekdaysValue ='" + WeekdaysValue + "'  and f_id = '" + f_id + "'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddIncome(string mobile, string PropertyName, string PropertyVale, string d_PayeeText, string d_PayeeTextValue, string txtRoomNo, string mobileNo, string DuesType, string DuesTypeValue, string txtDuesAmount, string txtRecivingDate, string DuesDate, string Month, string txtRemark)
    {
        string sql = "insert into Income( mobile , PropertyName , PropertyVale , I_PayeeText ,  I_PayeeValue ,  I_RoomNo ,  I_t_Mobile ,  I_DuesTypeText  ,  I_DuesTypeValue ,  I_DuesAmount ,I_reciveddate , I_DuesDate  ,  I_DuesMonth ,  I_Remark  , I_Status ,I_crdate  , I_mdfydate  )values('" + mobile + "', '" + PropertyName + "', '" + PropertyVale + "','" + d_PayeeText + "',  '" + d_PayeeTextValue + "', '" + txtRoomNo + "',  '" + mobileNo + "' , '" + DuesType + "', '" + DuesTypeValue + "', '" + txtDuesAmount + "', '" + txtRecivingDate + "', '" + DuesDate + "',  '" + Month + "' ,'" + txtRemark + "', 'recived' , getdate() ,getdate())";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdateDuesStatus(string d_id, string mobileNo)
    {
        string sql = "update dues set d_status ='received' where d_t_Mobile ='" + mobileNo + "' and d_id ='" + d_id + "'";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getMobile(string mobileNo)
    {
        string sql = "select Top 1  I_id , I_t_Mobile from Income where I_t_Mobile = '" + mobileNo + "'  order by I_t_Mobile desc";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }


    public void UpdateDuesRecived(string d_id, string DuesAmount, string RecivingDate, string ModeOfPayment, string Remark)
    {
        string sql = "update dues set d_recivedAmount ='" + DuesAmount + "' , d_reciveddate ='" + RecivingDate + "' , d_ModeOfPayment ='" + ModeOfPayment + "', d_Remark ='" + Remark + "' , d_status ='recived'  , d_mdfydate =getdate() where d_id ='" + d_id + "' ";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object getAnouncementBySearch(string PropertyValue, string Search)
    {
        string sql = "select a_id , a_Text ,a_mobile , a_Value  ,a_PropertyName, a_PropertyVal , a_Details , Convert(varchar ,a_crdate  ,103) as a_crdate, a_mdfydate from Announcement";
        if ((Search != "0") && (PropertyValue != "0"))
        {
            sql = sql + " where ((a_Text = '" + Search.Trim() + "') or (a_mobile ='" + Search.Trim() + "')) and a_PropertyVal = '" + PropertyValue + "' order by a_id desc";
        }
        else if ((Search == "0") && (PropertyValue == "0"))
        {
            sql = sql + " where ((a_Text = '" + Search.Trim() + "') or (a_mobile ='" + Search.Trim() + "')) order by a_id desc";
        }
        else
        {
            sql = sql + " where 1=1 order by a_id desc";

        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getAnouncementByProperty(string propertyValue)
    {
        string sql = "select a_id , a_Text ,a_mobile , a_Value  , a_PropertyName, a_PropertyVal , a_Details , Convert(varchar ,a_crdate  ,103) as a_crdate, a_mdfydate from Announcement ";
        if (propertyValue != "0")
        {
            sql = sql + " where a_PropertyVal='" + propertyValue + "' order by a_id desc ";
        }
        else
        {
            sql = sql + " where 1=1 order by a_id desc ";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object getLeaseProperty(string Search)
    {
        string sql = "select l_id , l_FullName ,  l_Mobile , l_City , l_NoBedRoom ,  l_NoOfWashrooom , l_PropertyAddress ,  l_Status , l_Map , convert(varchar , l_crdate , 103) as l_crdate, l_mdfyDate from LeasProperty where ((l_FullName = '" + Search.Trim() + "') or (l_Mobile = '" + Search.Trim() + "')  or (l_City = '" + Search.Trim() + "') )";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object getUesrSearch(string Search)
    {
        string sql = "select s_fullname , s_email, s_mobile, s_gender , s_password ,  s_check, s_cr_date, s_mdfy_date , s_usertype , s_isActive from signup where ((s_fullname = '" + Search.Trim() + "') or (s_mobile = '" + Search.Trim() + "')  or (s_email = '" + Search.Trim() + "') )";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }



    public object getPartnersearch(string Search)
    {
        string sql = "select p_id ,p_name ,p_mobile , convert(varchar ,p_doj , 103 ) as p_doj , p_details , convert (varchar ,p_crdate , 103 ) as p_crdate , p_mdfydate from  Partner where ((p_name = '" + Search.Trim() + "') or (p_mobile = '" + Search.Trim() + "')  )";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object getStaffsearch(string Search)
    {
        string sql = "select s_id ,s_Name, s_MobileNo, s_AdhaarNo, s_PanNo, s_FullAddress, convert(varchar ,s_DateOfJoining ,103 ) as s_DateOfJoining , convert(varchar , s_crdate , 103 )as s_crdate , s_mdfyDate from staff where ((s_Name = '" + Search.Trim() + "') or (s_MobileNo = '" + Search.Trim() + "')  )";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public object getContactsearch(string Search)
    {
        string sql = "select c_id ,c_name, c_email, c_mobile, c_gender, c_msg, convert(varchar ,c_crdate ,103 ) as c_crdate  from Contact where ((c_name = '" + Search.Trim() + "') or (c_mobile = '" + Search.Trim() + "')  )";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object getCareer(string Search)
    {
        string sql = "select c_id , c_FullName , c_Mobile , c_email , c_Applyfor ,  c_filenameUploadCv , c_pathUploadCv , c_crdate , c_mdfydate from Careers where ((c_FullName = '" + Search.Trim() + "') or (c_Mobile = '" + Search.Trim() + "'))";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object getCoaching(string Search)
    {
        string sql = "select c_id , c_CoachingName ,  c_FullName , c_Mobile , c_email ,  c_Designation , convert(varchar ,c_crdate ,103) as c_crdate, c_mdfyDate from Coaching where ((c_CoachingName = '" + Search.Trim() + "') or (c_Mobile = '" + Search.Trim() + "') or (c_FullName = '" + Search.Trim() + "'))";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object getProperty(string Search)
    {
        string sql = "select p_id , p_name , p_gender, p_address, p_maplink , p_StartPrice , p_discountprice , p_DicountPercent,  p_image1Path from Property  where (p_id = '" + Search.Trim() + "') ";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public DataSet getPropertySet(string Search)
    {
        string sql = "select p_id , p_name , p_gender, p_address, p_maplink , p_StartPrice , p_discountprice , p_DicountPercent,  p_image1Path from Property ";
        if (Search == "")
        {
            sql = sql + "  where ((CAST(p_id as nvarchar(300)) = '" + Search.Trim() + "') or (p_name = '" + Search.Trim() + "')) and p_id > 0 ";
        }
        else
        {
            sql = sql + " where ((CAST(p_id as nvarchar(300)) = '" + Search.Trim() + "') or (p_name = '" + Search.Trim() + "')) and p_id > 0 ";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }


    public SqlDataReader getAllRooms(string propertyValue, string Search)
    {
        string sql = "select  r_id , r_PropertyName , r_PropertyVale , r_roomNo , r_FloorNoText , r_FloorNovalue , r_BedsText ,r_BedsValue , r_Rent, r_SecurityDeposit, r_Remark , r_Ac , r_NonAC , r_Ventilation , r_Washroom , r_LargeRoom , r_Balcony , r_CornerRoom , r_WiFi  from Rooms";
        if ((Search != "0") && (propertyValue != "0"))
        {
            sql = sql + " where ((r_roomNo = '" + Search.Trim() + "') or (r_id = '" + Search.Trim() + "')) and r_PropertyVale= '" + propertyValue + "' order by r_roomNo asc";
        }
        else if((Search != "") && (propertyValue == "0"))
        {
            sql = sql + " where ((r_roomNo = '" + Search.Trim() + "') or (r_id = '" + Search.Trim() + "'))  order by r_roomNo asc";
        }
        else if ((Search == "") && (propertyValue != "0"))
        {
            sql = sql + " where ((r_roomNo = '" + Search.Trim() + "') or (r_id = '" + Search.Trim() + "'))  order by r_roomNo asc";
        }
        else
        {
            sql = sql + " where 1=1  order by r_roomNo asc";
        }

        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getAllTenants(string Search, string PropertyValue)
    {
        string sql = "select t_id ,t_mobile , t_PropertyName , t_LockinPeriodText , t_PropertyVale , t_Name , t_MobileNo , t_RoomNo , t_SecurityMoney ,t_BedsText , t_RentMoney , t_DateOfJoining, t_RentDate, t_Details , KycStatus, t_BankDetailStatus , t_crdate , t_mdfydate from Tenants";
        if ((Search == "") && (PropertyValue!="0"))
        {
            sql = sql + " where  ((t_Name ='" + Search.Trim() + "') or (t_RoomNo ='" + Search.Trim() + "') or (t_MobileNo = '" + Search.Trim() + "'))  order by t_RoomNo asc";
        }
        else if ((Search != "") && (PropertyValue != "0"))
        {
            sql = sql + " where  ((t_Name ='" + Search.Trim() + "') or (t_RoomNo ='" + Search.Trim() + "') or (t_MobileNo = '" + Search.Trim() + "')) and t_PropertyVale = '" + PropertyValue + "' order by t_RoomNo asc";
        }
        else if ((Search != "") && (PropertyValue == "0"))
        {
            sql = sql + " where  ((t_Name ='" + Search.Trim() + "') or (t_RoomNo ='" + Search.Trim() + "') or (t_MobileNo = '" + Search.Trim() + "'))  order by t_RoomNo asc";
        }
        else
        {
            sql = sql + " where 1=1 order  by t_RoomNo asc";
        }

        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getDuesSet(string Search)
    {
        string sql = "select d_prpertyvalue from dues  where ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "')) and d_status= 'pending'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader getIncomeBySearch(string propertyValue, string Search)
    {
        string sql = "select d_prpertyvalue , d_id , d_PayeeText,  d_PayeeValue,  d_RoomNo,  d_t_Mobile,  d_DuesTypeText,  d_DuesTypeValue,  d_DuesAmount, d_recivedAmount , CONVERT(varchar , d_DuesDate , 103 ) as d_DuesDate , CONVERT(varchar , d_reciveddate , 103 ) as d_reciveddate ,  CONVERT(varchar , d_DuesMonth , 103) as d_DuesMonth ,  d_Remark ,convert (varchar ,d_crdate ,103) as d_crdate ,d_mdfydate from  Dues";
        if ((Search != "") && (propertyValue != "0"))
        {
            sql = sql + " where ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "')) and d_prpertyvalue ='" + propertyValue + "' and  d_status= 'recived'  order by d_RoomNo asc";
        }
        else if ((Search != "") && (propertyValue == "0"))
        {
            sql = sql + " where  ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "'))  and  d_status= 'recived'  order by d_RoomNo asc ";
        }
        else if ((Search == "") && (propertyValue != "0"))
        {
            sql = sql + " where  ((d_t_Mobile = '" + Search.Trim() + "') or (d_RoomNo = '" + Search.Trim() + "') or (d_PayeeText = '" + Search.Trim() + "'))  and  d_status= 'recived'  order by d_RoomNo asc ";
        }
        else
        {
            sql = sql + " where 1=1  and  d_status= 'recived'  order by d_RoomNo asc ";
        }

        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }


    public SqlDataReader getExpenceSet(string Search)
    {
        string sql = "select e_PropertyVal from Expence  where ((e_PaidByText = '" + Search.Trim() + "') or (e_PaidTo = '" + Search.Trim() + "') )";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getBookingsSetBySearch(string propertyValue, string Search)
    {
        string sql = "select p.p_id , b.b_id , b.p_name , b.p_address, b.pgm_name ,  b.pgm_mobile ,b.b_amount, CONVERT(VARCHAR, b.b_date, 103) as b_date , b.b_timeslot,  b.s_name , b.s_mobile , b.b_status  from BookNow b join  property p   on b.p_name =p.p_name ";
        if (Search != "")
        {
            sql = sql + " where ((b.s_mobile = '" + Search.Trim() + "') or (b.s_name = '" + Search.Trim() + "')) and p.p_id ='" + propertyValue + "' ";
        }
        else
        {
            sql = sql + " where ((b.s_mobile = '" + Search.Trim() + "') or (b.s_name = '" + Search.Trim() + "')) order by b.b_id desc ";
        }

        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getVisiting(string Search)
    {
        string sql = "select select v.v_id , v.v_type , Convert(varchar , v.v_date , 103) as v_date, v.v_timeslot ,  v.s_name ,v.s_mobile,  v.s_gender,  v.p_name , v.p_roomtype , v.p_image  , v.p_address , v.p_maplink  , v.pgm_name  , v.pgm_mobile , convert(varchar , v.v_crdate , 103 ) as v_crdate  from ScheduleVisit v join  property p   on v.p_name =p.p_name   where ((v.s_mobile = '" + Search.Trim() + "') or (v.s_name = '" + Search.Trim() + "'))";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getStatus(string tc_id)
    {
        string sql = "select tc_id  ,  tc_status  from Ticketcomplaints  where tc_id = '" + tc_id + "'  ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void UpdateStatusComplaints(string tc_id, string status)
    {
        string sql = " update Ticketcomplaints set tc_status = '" + status + "'  where tc_id = '" + tc_id + "' ";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader CountTenants()
    {
        string sql = "select count(t_id) as CountTenants from Tenants";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public void AddTenantsDues(string mobile, string PropertyName, string PropertyVale, string tname, string tmobile, string troomNo, string tDuesType, string tDuesAmount, string tDuesDate, string d_DuesMonth, string tRemark)
    {
        string sql = "insert into Dues( d_mobile , d_prpertyname , d_prpertyvalue , d_PayeeText, d_t_Mobile,   d_RoomNo,    d_DuesTypeText, d_DuesTypeValue , d_DuesAmount, d_DuesDate,d_DuesMonth ,  d_Remark , d_status , d_crdate ,d_mdfydate ) values( '" + mobile + "', '" + PropertyName + "', '" + PropertyVale + "','" + tname + "',  '" + tmobile + "', '" + troomNo + "',  '" + tDuesType + "','1' , '" + tDuesAmount + "', '" + tDuesDate + "', '" + d_DuesMonth + "','" + tRemark + "',  'pending' , '2021-02-01 11:26:54.660' ,'2021-02-01 11:26:54.660')";
        SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader getDuesDublicate(string sDate)
    {
        string sql = "select * from Dues where d_DeleteStatus ='No' and d_DuesDate != '" + sDate + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object getContacts()
    {
        string sql = "select c_id ,c_name, c_email, c_mobile, c_gender, c_msg, convert(varchar ,c_crdate ,103 ) as c_crdate  from Contact";
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object LoadexitApplied(string propertyvalue)
    {
        string sql = "select ep_id ,ep_PropertyName , ep_propertyvalue , ep_roomNo  , ep_tenantsname , ep_tenantsmobile , (ep_text + ' ' + convert(varchar ,ep_date , 103))   as Application ,  ep_reason , ep_status , ep_crdate , ep_modfydte from exitproperty ";
        if (propertyvalue == "0")
        {
            sql = sql + " where 1=1 ";
        }
        else
        {
            sql = sql + " where ep_propertyvalue ='" + propertyvalue + "' ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public object LoadKycOfTenantsByMobile(string mobile)
    {
        string sql = "select k.k_id , s.s_fullname, k.s_mobile , k.k_frontName , k.k_docsName , k.k_BackName ,k.k_NameOnDocs , k.k_docsIdNo , k.k_frontPath , k.k_BackPath  ,  convert(varchar , k.k_cr_date , 103) as k_cr_date  from kycDocs k join  signup s  on k.s_mobile = s.s_mobile";
        if (mobile == null)
        {
            sql = sql + " where 1=1 ";
        }
        else
        {
            sql = sql + " where k.s_mobile ='" + mobile + "' ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public object LoadKycOfTenants(string PropertyVale)
    {
        string sql = "select k.k_id , s.s_fullname, k.s_mobile , k.k_frontName , k.k_docsName , k.k_BackName ,k.k_NameOnDocs , k.k_docsIdNo , k.k_frontPath , k.k_BackPath  , k.ep_propertyvalue , k.ep_PropertyName , convert(varchar , k.k_cr_date , 103) as k_cr_date  from kycDocs k join  signup s  on k.s_mobile = s.s_mobile";
        if (PropertyVale == "0")
        {
            sql = sql + " where 1=1 ";
        }
        else
        {
            sql = sql + " where k.ep_propertyvalue ='" + PropertyVale + "' ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object LoadKycOfTenantsbySearch(string Search)
    {
        string sql = "select k.k_id, s.s_fullname, k.s_mobile , k.k_frontName , k.k_BackName, k.k_docsName , k.k_NameOnDocs , k.k_docsIdNo , k.k_frontPath , k.k_BackPath  , convert(varchar , k.k_cr_date , 103) as k_cr_date   from kycDocs k join  signup s  on k.s_mobile =s.s_mobile where ((k.s_mobile = '" + Search.Trim() + "') or (k.k_docsIdNo = '" + Search.Trim() + "') or (s.s_fullname = '" + Search.Trim() + "')) ";
        //if (propertyvalue == "0")
        //{
        //    sql = sql + " where 1=1 ";
        //}
        //else
        //{
        //    sql = sql + " where ep_propertyvalue ='" + propertyvalue + "' ";
        //}
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object LoadexitAppliedSearch(string propertyvalue, string Search)
    {
        string sql = "select ep_id ,ep_PropertyName , ep_propertyvalue , ep_roomNo  , ep_tenantsname , ep_tenantsmobile , (ep_text + ' ' + convert(varchar ,ep_date , 103))   as Application ,  ep_reason , ep_status , ep_crdate , ep_modfydte from exitproperty ";
        if (propertyvalue == "0")
        {
            sql = sql + " where 1=1 and ((ep_roomNo = '" + Search.Trim() + "') or (ep_tenantsname = '" + Search.Trim() + "') or (ep_tenantsmobile = '" + Search.Trim() + "')) ";
        }
        else
        {
            sql = sql + " where ep_propertyvalue ='" + propertyvalue + "' and ((ep_roomNo = '" + Search.Trim() + "') or (ep_tenantsname = '" + Search.Trim() + "') or (ep_tenantsmobile = '" + Search.Trim() + "'))  ";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetFile(string c_id)
    {
        string sql = @"select c_pathUploadCv from Careers where c_id = '" + c_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public SqlDataReader GetFileFront(string k_id)
    {
        string sql = @"select k_frontPath, k_BackPath from kycDocs where k_id = '" + k_id + "' ";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object LoadBankDetails(string PropertyValue)
    {
        string sql = "select  b.b_id , t.t_PropertyName , t.t_PropertyVale ,s.s_fullname, b.s_mobile , b.b_Name , b.b_AccountHolderName , b.b_AccountNo , b.b_IfscCode , b.b_branch  , convert(varchar , b.b_cr_date , 103) as b_cr_date from bankdetails b join signup s  on b.s_mobile = s.s_mobile join tenants t  on s.s_mobile = t.t_MobileNo";
        if (PropertyValue != "0")
        {
            sql = sql + " where t.t_PropertyVale ='" + PropertyValue + "' order by b.b_id asc";
        }
        else
        {
            sql = sql + " where 1=1 order by b.b_id asc";
        }
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }

    public object LoadBankDetailsbySearch(string propertyValue, string Search)
    {
        string sql = "select  b.b_id , t.t_PropertyName , t.t_PropertyVale ,s.s_fullname, b.s_mobile , b.b_Name , b.b_AccountHolderName , b.b_AccountNo , b.b_IfscCode , b.b_branch  , convert(varchar , b.b_cr_date , 103) as b_cr_date from bankdetails b join signup s  on b.s_mobile = s.s_mobile join tenants t  on s.s_mobile = t.t_MobileNo";
        if ((Search != "")&&(propertyValue!="0"))
        {
            sql = sql + " where ((s.s_fullname = '" + Search.Trim() + "') or (b.s_mobile = '" + Search.Trim() + "') or (b.b_AccountNo = '" + Search.Trim() + "')) and t.t_PropertyVale ='" + propertyValue + "' order by b.b_id desc  ";
        }
        else if((Search == "") && (propertyValue == "0"))
        {
            sql = sql + " where ((s.s_fullname = '" + Search.Trim() + "') or (b.s_mobile = '" + Search.Trim() + "') or (b.b_AccountNo = '" + Search.Trim() + "')) order by b.b_id desc ";
        }
        else
        {
            sql = sql + " where 1=1 order by b.b_id desc";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
}