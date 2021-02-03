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
/// Summary description for AdminPanel
/// </summary>
public class UserManagement
{
	public UserManagement()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   
    GeneralFunctions.GeneralFunctions  Gf = new GeneralFunctions.GeneralFunctions ();
    public bool AdminLogin(string al_username, string Password)
    {
        using (SqlDataReader Sdr = SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, @"select al_username, al_pass  from AdminLogin where al_username= '" + al_username.Replace("'", string.Empty).Replace("select", string.Empty) + "' and al_pass='" + Password.Replace("'", string.Empty).Replace("select", string.Empty) + "'"))
        {
            if (Sdr.HasRows)
            {
                Sdr.Read();
                HttpContext.Current.Session["al_username"] = Convert.ToString(Sdr["al_username"]);
                HttpContext.Current.Session["al_username"] = Convert.ToString(Sdr["al_username"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool ClentLogin(string cl_userid, string Password)
    {
        using (SqlDataReader Sdr = SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, @"select r.vr_VehicleRegistrationNo , r.vr_userid , c.cl_userid, c.cl_pass from VehicleRegistration r
inner join ClientLogin c on r.vr_userid = c.cl_userid where  c.cl_userid = '" + cl_userid.Replace("'", string.Empty).Replace("select", string.Empty) + "' and c.cl_pass='" + Password.Replace("'", string.Empty).Replace("select", string.Empty) + "'"))
        {
            if (Sdr.HasRows)
            {
                Sdr.Read();
                HttpContext.Current.Session["vr_userid"] = Convert.ToString(Sdr["vr_userid"]);
                HttpContext.Current.Session["cl_userid"] = Convert.ToString(Sdr["cl_userid"]);
                HttpContext.Current.Session["cl_pass"] = Convert.ToString(Sdr["cl_pass"]);
                HttpContext.Current.Session["vr_VehicleRegistrationNo"] = Convert.ToString(Sdr["vr_VehicleRegistrationNo"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool UserLogin(string EmpId, string Password)
    {
        using (SqlDataReader Sdr = SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, @"select E_Id, E_Name,E_Password,E_email,E_RepId ,E_RepEmpName  from EmployeeDetails where E_Id= '" + EmpId.Replace("'", string.Empty).Replace("select", string.Empty) + "' and E_Password='" + Password.Replace("'", string.Empty).Replace("select", string.Empty) + "'"))
        {
            if (Sdr.HasRows)
            {
                Sdr.Read();
                HttpContext.Current.Session["E_Id"] = Convert.ToString(Sdr["E_Id"]);
                HttpContext.Current.Session["E_Name"] = Convert.ToString(Sdr["E_Name"]);
                HttpContext.Current.Session["E_Password"] = Convert.ToString(Sdr["E_Password"]);
                HttpContext.Current.Session["E_email"] = Convert.ToString(Sdr["E_email"]);
                HttpContext.Current.Session["E_RepId"] = Convert.ToString(Sdr["E_RepId"]);
                HttpContext.Current.Session["E_RepEmpName"] = Convert.ToString(Sdr["E_RepEmpName"]);
              
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    public bool adminLogin(string Username, string Password)
    {
        using (SqlDataReader Sdr = SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, @"select Username, password from EmpLogin where Username= '" + Username.Replace("'", string.Empty).Replace("select", string.Empty) + "' and Password='" + Password.Replace("'", string.Empty).Replace("select", string.Empty) + "'"))
        {
            if (Sdr.HasRows)
            {
                Sdr.Read();
                HttpContext.Current.Session["Username"] = Convert.ToString(Sdr["Username"]);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    public SqlDataReader GetSchoolInfo(string Imeino)
    {
        string sql = @"select s.id SchoolId,Established,Pincode,s.Name SchoolName,Address,sm.name State,cm.name City,ParentName,pr.id ParentId,pr.tstamp RegisDate from tblSchoolMaster s
join StateMaster sm on s.state = sm.id
join cityMaster cm on s.city = cm.id
join ParentRegistration pr on pr.schoolid = s.id 
where imeino = '" + Imeino+"'";
       return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader GetStudentList(string Imeino)
    {
        string sql = @"select 
sc.id SchoolId,s.id StudentId,Established,sem.sessionid,
sem.sessionname,sem.FromDate SessionStartDate,sem.ToDate SessionEndDate,
Pincode,sc.Name SchoolName,
sc.Address SchoolAddress,stm.name State,
ctm.name City,ParentName,pr.id ParentId,pr.tstamp ParentRegisDate ,
s.name StudentName,s.Image StudentImage,s.fathername,s.dob,s.bloodgroup,s.contactno,s.address,
classname,section,s.tstamp regisdate from StudentMaster s
join tblSchoolMaster sc on sc.id=s.schoolid
join ClassMaster cm on cm.id = s.classid
join SectionMaster sm on sm.id = s.sectionid 
join ParentRegistration pr on pr.schoolid = sc.id
join SessionMaster sem on sem.sessionid=pr.sessionid and sem.schoolid=pr.schoolid
join StateMaster stm on sc.state = stm.id
join cityMaster ctm on sc.city = ctm.id
where getdate() between sem.fromdate and sem.todate 
and pr.imeino='" + Imeino + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }

   
    public int CreateSession(string SessionName
           , string SchoolId
           , string FromDate
           , string ToDate)
    {
        string sql = @"INSERT INTO [SessionMaster]
           ([SessionName]
           ,[SchoolId]
           ,[FromDate]
           ,[ToDate])
     VALUES
           ('"+SessionName+"','"+SchoolId+"','"+FromDate+"','"+ToDate+"')";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
  
  public int UpdateSession(string SessionId,string SessionName , string SchoolId, string FromDate, string ToDate)
    {
        string sql = @"UPDATE [SessionMaster]
   SET [SessionName] = '"+SessionName+"',[SchoolId] = '"+SchoolId+"',[FromDate] = '"+FromDate+"',[ToDate] = '"+ToDate+"' WHERE SessionId = '"+SessionId+"'";
       return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet GetAllSessions(string SchoolId)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, "Select * from SessionMaster where schoolid='" + SchoolId + "' order by tstamp desc");
    }
    public bool IsDateInCurrentSession(string SchoolId, string SesionId,string Date)
    {
        object obj=SqlHelper.ExecuteScalar(CnSettings.cnString1, CommandType.Text, "Select * from SessionMaster where schoolid='" + SchoolId + "' and sessionid='"+ SesionId + "' and '"+Date+"' between fromdate and todate");
        if (obj == null)
            return false;
        else
            return true;
    }
    public int CreateParent(string ParentName,string MobileNo,string Address,string Imeino,string SessionId,string SchoolId)
    {
        string sql = @"INSERT INTO [ParentRegistration]
           ([ParentName]
           ,[SchoolId]
           ,[MobileNo]
           ,[Address]
           ,[Imeino]
           ,[SessionId]
           )
     VALUES
           ('" + ParentName + "','" + SchoolId + "','" + MobileNo + "','" + Address + "','" + Imeino + "','" + SessionId + "')";
       return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public int CreateStudent(string ParentId, string Name, string FatherName, string DOB, string BloodGroup, string ContactNo, string Address, string SchoolId, string ClassId, string SectionId, string Image, string Session)
    {
        string sql = @"INSERT INTO [StudentMaster]
           ([ParentId]
           ,[Name]
           ,[FatherName]
           ,[DOB]
           ,[BloodGroup]
           ,[ContactNo]
           ,[Address]
           ,[SchoolId]
           ,[ClassId]
           ,[SectionId]
           ,[Image]
           ,[Session])
     VALUES
('"+ParentId+"','"+Name + "','" + FatherName + "','" + DOB + "','" + BloodGroup + "','" + ContactNo + "','" + Address + "','" + SchoolId + "','" + ClassId + "','" + SectionId + "','" + Image + "','" + Session + "')";
       return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public int UpdateParent(string ParentId, string ParentName, string MobileNo, string Address, string Imeino, string SessionId, string SessionName, string SchoolId)
    {
        string sql = @"UPDATE [ParentRegistration]
   SET [ParentName] = '" + ParentName + "',[SchoolId] = '"+SchoolId+"',[MobileNo] = '"+MobileNo+"',[Address] = '"+Address+"',[Imeino] = '"+Imeino+"',[SessionId] = '"+SessionId+"' WHERE id = '"+ParentId+"'";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }

public DataSet GetAllStudents(string SessionId, string SchoolId)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, @"
select stu.id, stu.name, stu.FatherName, stu.dob,pr.parentname ,
bloodgroup, cm.classname, sm.section, stu.contactno,
pr.mobileno, image, stu.tstamp from StudentMaster stu
join ParentRegistration pr on pr.id = stu.parentid
join ClassMaster cm on cm.id = stu.classid
join SectionMaster sm on sm.id = stu.sectionid  where stu.schoolid ='" + SchoolId + "' and stu.session ='"+ SessionId + "' ");
    }
    public DataSet GetAllParents(string SessionId, string SchoolId)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, "Select * from ParentRegistration where schoolid='"+ SchoolId + "' and sessionid='"+ SessionId + "' order by tstamp desc");
    }
      public int CreateTeacher(string SchoolId, string SessionId , string TeacherName, string MobileNo, string Address, string Password, string DOB, string DOJ)
    {
        string sql = @"INSERT INTO [TeacherMaster]
           ([SchoolId]
           ,[SessionId]
           ,[TeacherName]
           ,[MobileNo]
           ,[Address]
           ,[Password]
           ,[DOB]
           ,[DOJ])
     VALUES
           ('"+SchoolId+"','"+SessionId+"','"+TeacherName+"' ,'"+MobileNo+"','"+Address+"','"+Password+"' ,'"+DOB+"','"+DOJ+"')";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader GetClassSectionMapping(string SchoolId, string SessionId)
    {
        try {
           
            return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, "select * from classsectionmap where schoolid='" + SchoolId + "' and session='" + SessionId + "'");
        }
        catch
        {
            return null;
        }
    }
    public int UpdateTeacher(string TeacherId, string SchoolId, string SessionId , string TeacherName, string MobileNo, string Address, string Password, string DOB, string DOJ)
    {
        string sql = @"UPDATE [TeacherMaster]
   SET [SchoolId] = '" + SchoolId + "',[SessionId] = '"+SessionId+"',[TeacherName] = '"+TeacherName+"',[MobileNo] = '"+MobileNo+"',[Address] = '"+Address+"',[Password] = '"+Password+"',[DOB] = '"+DOB+"',[DOJ] = '"+DOJ+"' WHERE id= '"+TeacherId+"'";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet GetAllTeachers(string SessionId, string SchoolId)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, "Select * from TeacherMaster where schoolid='" + SchoolId + "' and sessionid='" + SessionId + "'");
    }

    public int CreateLounge(string SchoolId,string LoungeName,string Session)
    {
        string sql = @"INSERT INTO [tblLoungeMaster]
           ([SchoolId]
           ,[LoungeName]
           ,[Session])
     VALUES
           ('"+SchoolId+"', '"+LoungeName + "','"+Session+"')";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public int UpdateLounge(string LoungeId, string SchoolId,string LoungeName,string SessionId)
    {
        string sql = @"UPDATE [tblLoungeMaster] SET [SchoolId] = '" + SchoolId + "',[LoungeName]='"+LoungeName+ "',[Session] = '"+ SessionId + "' WHERE id='"+LoungeId+ "' ";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader GetLounges(string SchoolId, string SessionId)
    {
        string sql = @"select * from LoungeMaster where schoolid='" + SchoolId + "' and session='" + SessionId + "'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public int CreateSubject(string SchoolId, string SubjectName)
    {
        string sql = @"INSERT INTO SubjectMaster(SchoolId,SubjectName) VALUES ('"+SchoolId+"','"+SubjectName+"')";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public int UpdateSubject(string SubjectId, string SchoolId, string SubjectName)
    {
        string sql = @"UPDATE [SubjectMaster] SET [SchoolId] = '" + SchoolId + "',[SubjectName] = '"+SubjectName+"' WHERE id='"+SubjectId+"'";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public SqlDataReader GetAllSubjects(string SchoolId)
    {
        string sql = @"select * from SubjectMaster where schoolid='" + SchoolId + "' order by tstamp desc";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet GetAllSubjectsMappings(string SessionId, string SchoolId)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, @"select tsm.id, ClassName Class, Section Section, TeacherName Teacher, SubjectName Subject from TeacherSubjectMap tsm
join classmaster cm on cm.id = tsm.classid
join sectionmaster sm on sm.id = tsm.sectionid
join teachermaster tm on tm.id = tsm.teacherid
join subjectmaster sub on sub.id = tsm.subjectid
where tsm.schoolid ='" + SchoolId + "'  and tsm.sessionid ='"+ SessionId + "' order by tsm.tstamp desc");
}
    public string DeleteCircle(string CircleCode)
    {
        string status=string.Empty;
        try
        {
            SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, "delete from CircleMaster where CircleCode='"+CircleCode+"'");
            status = "true";
        }
        catch
        {
            status = "false";
        }
        return status;
    }
    public DataSet SearchFsMapping(string UnitCode, string CircleCode, string Userid)
    {
        string sql = @" select fsm.fieldmanid,fsm.id MapId,fieldmanname,salepointname,mobileno,dm.designation,unitname,circlename from FSMapping fsm join SalePointDetails spd on spd.salepointid=fsm.salepointid
 join SalePointMaster spm on spm.id=spd.salepointid
 join fieldmanmaster fm on fm.fieldmanid=fsm.fieldmanid
   join designationmaster dm on fm.designation=dm.id
join UnitMaster Um on spm.unitcode = um.unitcode
join CircleMaster Cm on spm.circlecode = cm.Circlecode where 1=1 ";
        if (UnitCode != "0")
        {
            sql += " and spm.unitcode='" + UnitCode + "'";
        }
        if (CircleCode != "0")
        {
            sql += " and spm.Circlecode='" + CircleCode + "'";
        }
        if (Userid != "0")
        {
            sql += " and fsm.fieldmanid='" + Userid + "'";
        }

        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, sql);
    }
    public string GetLatestVersion()
    {
        //no,Imei,msgtype,content,DateTime,selfno
        try
        {
            object Obj=SqlHelper.ExecuteScalar(CnSettings.cnString1, CommandType.Text, "Select Top 1 version from VersionMaster order by tstamp desc");
            if(Obj!=null)
            {
                return Obj.ToString();
            }
            else
            {
                return "Error";
            }
            
        }
        catch { return "Error"; }
    }
    public int CreateHoliday(string Holiday, string Date, string SchoolId,string SessionId)
    {
        string sql = @"INSERT INTO [HoliDayMaster]
           ([SchoolId],[SessionId]
           ,[Holiday]
           ,[Date])
     VALUES
           ('" + SchoolId + "', '" + SessionId + "','" + Holiday + "', '" + Date + "')";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public int UpdateHoliday(string Id,string Holiday, string Date, string SchoolId, string SessionId)
    {
        string sql = @"Update [HoliDayMaster] set [SchoolId]='"+ SchoolId + "',[Holiday]='" + Holiday + "',[Date]='"+Date+ "',[SessionId]='"+ SessionId + "' where id='" + Id+"'";
        return SqlHelper.ExecuteNonQuery(CnSettings.cnString1, CommandType.Text, sql);
    }
    public DataSet GetAllHoliday(string SchoolId,string SessionId)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, @"select hm.id,Holiday,Date,convert(varchar,Date,103) Dt from HolidayMaster hm where hm.schoolid ='" + SchoolId+"' and hm.sessionid ='"+SessionId+"' order by hm.date");
    }
    public DataSet GetHolidayById(string Id)
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, @"select * from HolidayMaster hm where hm.id='"+Id+"'");
    }
    public DataSet GetLeaveReasons()
    {
        return SqlHelper.ExecuteDataset(CnSettings.cnString1, CommandType.Text, @"select * from LeaveReasonMaster");
    }

    
}