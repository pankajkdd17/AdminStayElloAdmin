using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
using System.Net;
using System.IO;

namespace GeneralFunctions
{

    ///// <summary>
    ///// Summary description for GeneralFunctions
    ///// </summary>
    public class GeneralFunctions : CollectionBase
    {
        private string ConnStr;
        public GeneralFunctions()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }

        
        public bool BulkInsertQuery(string BulkQuery)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery(trans, CommandType.Text, BulkQuery);
                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }


        public String SendMail(String MailTo, String MailFrom, String Subject, String MailBody)
        {
            try
            {
                MailMessage msg = new MailMessage();
                MailAddress mailaddressfrom = new MailAddress(MailFrom);
                MailAddress mailaddressTo = new MailAddress(MailTo);
                msg.From = mailaddressfrom;
                msg.To.Add(mailaddressTo);
                msg.Subject = Subject;
                msg.Body = MailBody;
                msg.IsBodyHtml = true;
                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = "mail.jhaformwork.com.au";
                objSmtp.Send(msg);
                return "mailsend";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string GetProperTextLength(string strtext)
        {
            int MaxHeadingLength = 50;

            if (strtext.Length > MaxHeadingLength)
                return strtext.Substring(0, MaxHeadingLength) + " ...";
            else
                return strtext.Substring(0, strtext.Length - 1);
        }

        // Added by Faisal on 23-Nov-07

        public string dmytomdy(string tempdate)
        {
            string dd, mm, yy;
            dd = tempdate.Substring(0, 2);
            mm = tempdate.Substring(3, 2);
            yy = tempdate.Substring(6, 4);
            return mm + "/" + dd + "/" + yy;
        }
        public string mdytodmy(string tempdate)
        {
            string mm, dd, yy;
            string str = tempdate;
            char buff = Convert.ToChar("/");
            string[] ext = str.Split(buff);
            if (ext[0].Length == 1)
                mm = "0" + ext[0];
            else
                mm = ext[0];
            if (ext[1].Length == 1)
                dd = "0" + ext[1];
            else
                dd = ext[1];
            if (ext[2].Length == 1)
                yy = "0" + ext[2];
            else
                yy = ext[2];

            return dd + "/" + mm + "/" + yy;
        }

        public string ChopString(string StrName)
        {
            if (StrName.Length > 150)
                return (StrName.Substring(0, 150) + "....");
            else
                return StrName;
        }

        public string ChopStringWithLen(string StrName, int Len)
        {
            if (StrName.Length > Len)
                return (StrName.Substring(0, Len) + "....");
            else
                return StrName;
        }

        //Filling combos
        public void FillVehicleType(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype)
        {
            DataSet ds;
            ds = GetRecordsToFillVehicleType(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillVehicleType(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " order by " + displayfield + "";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }

        public void FillStatus(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype)
        {
            DataSet ds;
            ds = GetRecordsToFillStatus(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillStatus(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " order by " + displayfield + "";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }
        public void FillMake(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype, String ddlvtype)
        {
            DataSet ds;
            ds = GetRecordsToFillMake(valuefield, displayfield, tablename, ddlvtype);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillMake(String valuefield, String displayfield, String tablename, String ddlvtype)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + "  where  vt_id ='" + ddlvtype + "' order by " + displayfield + "  ";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }


        public void FillNoOfWheels(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype)
        {
            DataSet ds;
            ds = GetRecordsToFillNoOfWheels(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillNoOfWheels(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " order by " + valuefield + " ASC ";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }

        public void FillRooms(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype, string property)
        {
            DataSet ds;
            ds = GetRecordsToFillFillRooms(valuefield, displayfield, tablename, property);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillFillRooms(String valuefield, String displayfield, String tablename, string property)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + "  where r_PropertyVale = '" + property + "' order by " + valuefield + " ASC ";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }

        public void FillDistrict(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype)
        {
            DataSet ds;
            ds = GetRecordsToFillDistrict(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillDistrict(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " order by " + displayfield + "";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }
        public void FillComboEmployeeType(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype)
        {
            DataSet ds;
            ds = GetRecordsToFillComboEmployeeType(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillComboEmployeeType(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " order by " + displayfield + "";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }
        //FillComboEmployeeType
        public void FillCombo(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype)
        {
            DataSet ds;
            ds = GetRecordsToFillCombo(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }

        public void FillComboFromQry(String valuefield, String displayfield, String qry, DropDownList ddl, String stype)
        {
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, qry);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            li.Text = "Select";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }

        public void FillCombo_Filter(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype, String Wherefield, String Comparefield)
        {

            DataSet ds;
            ds = GetRecordsToFillCombo_Filter(valuefield, displayfield, tablename, Wherefield, Comparefield);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
        }

        public DataSet GetRecordsToFillCombo(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " order by " + displayfield + "";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }

        //public DataSet GetRecordsToFillCombo(String valuefield, String displayfield, String tablename)
        //{
        //    DataSet ds;
        //    String sql;
        //    sql = "select " + valuefield + "," + displayfield + " from " + tablename + " order by " + displayfield + "";
        //    ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
        //    return ds;
        //}
        public DataSet GetRecordsToFillCombo_Filter(String valuefield, String displayfield, String tablename, String Wherefield, String Comparefield)
        {
            DataSet ds;
            String sql;
            sql = "select Distinct " + valuefield + "," + displayfield + " from " + tablename + "  Where " + Wherefield + "='" + Comparefield + "'  order by " + displayfield + "";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }
        public string createID(string tablename, string idField, string strFormat)
        {

            int SID;
            string StateStr;
            StateStr = "";
            //SqlDataReader dr = SqlHelper.ExecuteReader(ConnStr, CommandType.Text, "SELECT  MAX(CONVERT(int, SUBSTRING(" + idField + ", 4, LEN(" + idField + ") - "+ (strFormat.Length) +"))) as STID FROM " + tablename + " where " + idField + " LIKE '%" + strFormat + "%'");
            SqlDataReader dr = SqlHelper.ExecuteReader(ConnStr, CommandType.Text, "SELECT  MAX(CONVERT(int, SUBSTRING(" + idField + ", 4, LEN(" + idField + ") - " + (strFormat.Length) + "))) as STID FROM " + tablename + " where " + idField + " LIKE '%" + strFormat + "%'");

            if (dr.Read() && dr["STID"] != DBNull.Value)
                SID = Convert.ToInt32(dr["STID"]) + 1;
            else
                SID = 1;
            string s;
            string sformat;
            s = SID.ToString();
            sformat = strFormat.Substring(0, 3);
            StateStr = strFormat + SID.ToString("0000000");

            dr.Close();
            return StateStr;
        }

        public string GetUniqueFileName(string filename)
        {
            try
            {
                string[] ext = new string[5];
                ext = filename.Split('.');
                return ext[0] + Guid.NewGuid().ToString() + "." + ext[ext.Length - 1];
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string GetUniqueId()
        {
            try
            {
                return Guid.NewGuid().ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string UploadFile(FileUpload FileToUpload, String FolderPath)
        {
            try
            {
                string newfname = string.Empty;

                if (FileToUpload.PostedFile.ContentLength != 0)
                {

                    string[] ext = FileToUpload.PostedFile.FileName.Split('.');
                    newfname = ext[0] + "_" + Guid.NewGuid().ToString() + "." + ext[ext.Length - 1];
                    FileToUpload.PostedFile.SaveAs(FolderPath + "/" + newfname);
                }
                return newfname;
            }
            catch
            {
                return null;
            }
        }

        public void GetSMSResponse(string mobileno, string userid, string pass, string name)
        {
            string msg = "Dear " + name + " You have successfully registered with mmmdsp. Your userid = " + userid + " and password=" + pass;
            string WFLocation = "http://sms.smssure.com/cmmapi/pushsms.php?usr=555223&pwd=123456&sndr=MMM&ph=" + mobileno + "&text=" + msg + "&rpt=1";
            string location = WFLocation;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
        }

        public void GetSMSPassword(string mobileno, string pass)
        {
            string msg = "Your Password for MMMDSP is = " + pass;
            string WFLocation = "http://sms.smssure.com/cmmapi/pushsms.php?usr=555223&pwd=123456&sndr=MMM&ph=" + mobileno + "&text=" + msg + "&rpt=1";
            string location = WFLocation;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
        }


        public string GetSMSResponse(string mobileno, string msg)
        {
            string WFLocation = "http://sms.smssure.com/cmmapi/pushsms.php?usr=555223&pwd=123456&sndr=MMM&ph=" + mobileno + "&text=" + msg + "&rpt=1";
            string location = WFLocation;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            return results;
        }

        public string getSMSCredit()
        {
            string WFLocation = "http://208.101.14.59/api/balance.php?usr=2427&pwd=hasapur";
            string location = WFLocation;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            return results;
        }

        public void SaveSMSInfo(Int64 UserID, bool isSuccess)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString.CnSettings.cnString1, "Proc_SMSInfo", new object[] { (object)UserID, (object)isSuccess });
        }

        public void FillComboFranch(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype)
        {
            DataSet ds;
            ds = GetRecordsToFillCombo(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "Admin";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
        }

        public void FillAvailableStockCombo(string branchid, DropDownList ddl)
        {
            string sql = "Select * from tblProducts Where sno in(select ProductId from tblStockTransfer Where challanid in(select challanid from tblMasterStockTransfer where BranchId=" + branchid + ")) order by ProductName";
            ddl.DataSource = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            ddl.DataTextField = "ProductName";
            ddl.DataValueField = "sno";
            ddl.DataBind();
            ListItem li = new ListItem();
            li.Text = "Select";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        public SqlDataReader FillCascadeDdl(String valuefield, String displayfield, String tablename, String Wherefield, String Comparefield)
        {
            SqlDataReader sdr = null;
            String sql;
            sql = "select Distinct " + valuefield + "," + displayfield + " from " + tablename + "  Where " + Wherefield + "=" + Comparefield + "  order by " + displayfield + "";
            if (valuefield == displayfield)
            {
                sql = "select Distinct " + displayfield + " from " + tablename + "  Where " + Wherefield + "=" + Comparefield + "  order by " + displayfield + "";
            }
            sdr = SqlHelper.ExecuteReader(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return sdr;
        }
        public void FillHtmlSelect_Filter(String valuefield, String displayfield, String tablename, HtmlSelect htmlselect, String stype, String Wherefield, String Comparefield)
        {
            // Bind the HtmlSelect control to the data source.
            SqlDataReader sdr = null;
            ListItem li = new ListItem();
            sdr = FillCascadeDdl(valuefield, displayfield, tablename, Wherefield, Comparefield);
            if (sdr.HasRows && sdr != null)
            {
                htmlselect.DataSource = sdr;
                htmlselect.DataTextField = displayfield;
                htmlselect.DataValueField = valuefield;
                htmlselect.DataBind();
                li.Text = "Select";
                li.Value = "0";
                htmlselect.Items.Insert(0, li);
            }
            else
            {
                li.Text = "No Data";
                li.Value = "0";
                htmlselect.Items.Insert(0, li);

            }
        }
        public int DeleteRecords(string tblname, string fieldname, string ids)
        {
            string sql = "delete from " + tblname + " where " + fieldname + " in(" + ids + ")";
            return SqlHelper.ExecuteNonQuery(ConnStr, CommandType.Text, sql);
        }
        public string GetApiUrl(string type)
        {
            return SqlHelper.ExecuteScalar(ConnStr, "GetApiUrl", new object[] { (object)type }).ToString();
        }
        public void Logout()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();

        }
        public string GeneratePassword()
        {
            //Since I'm big on security, I wanted to generate passwords that contained numbers, letters and special
            //characters - and not easily hacked.

            //I started with creating three string variables.
            //This one tells you how many characters the string will contain.
            // string PasswordLength = "12";
            string PasswordLength = "8";
            //This one, is empty for now - but will ultimately hold the finised randomly generated password
            string NewPassword = "";

            //This one tells you which characters are allowed in this new password
            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            //  allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            // allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            // allowedChars += "~,!,@,#,$,%,^,&,*,+,?";

            //Then working with an array...

            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);

            string IDString = "";
            string temp = "";

            //utilize the "random" class
            Random rand = new Random();

            //and lastly - loop through the generation process...
            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;

                //For Testing purposes, I used a label on the front end to show me the generated password.
                //lblProduct.Text = IDString;
            }

            return NewPassword;
        }
        public void SendEmailGmail(string pTo, string pSubject, string pAttachmentPath, string mailfrom, string mailbody)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(pTo);
            // mail.To.Add("Another Email ID where you wanna send same email");
            // mail.From = new MailAddress("xcell.india2012@gmail.com");
            mail.From = new MailAddress("joinrecharge2u@gmail.com");
            mail.Subject = pSubject;

            string Body = mailbody;
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            //smtp.Credentials = new System.Net.NetworkCredential
            //     ("xcell.india2012@gmail.com", "xcell@2012#");
            smtp.Credentials = new System.Net.NetworkCredential
                 ("joinrecharge2u@gmail.com", "vibar@123");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }
        public List<Dictionary<string, object>> ConvertDataReaderToJson(SqlDataReader Dr)
        {
            List<Dictionary<string, object>> Rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> Wrapper;
            using (Dr)
            {
                if (Dr != null)
                {
                    if (Dr.HasRows)
                    {
                        while (Dr.Read())
                        {
                            Wrapper = new Dictionary<string, object>();
                            for (int i = 0; i < Dr.FieldCount; i++)
                            {
                                Wrapper.Add(Dr.GetName(i), Dr[i]);
                            }
                            Rows.Add(Wrapper);
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            return Rows;
        }

        public List<Dictionary<string, object>> ConvertDataSetToJson(DataSet Ds)
        {
            List<Dictionary<string, object>> Rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> Wrapper;
            using (Ds)
            {
                if (Ds != null)
                {
                    DataTable dt = null;
                    dt = Ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        Wrapper = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            Wrapper.Add(col.ColumnName, dr[col]);
                        }
                        Rows.Add(Wrapper);
                    }
                }
                else
                {
                    return null;
                }
            }
            return Rows;
        }
        public string ddmmyyyyTOyyyymmdd(string mydate)
        {
            return DateTime.ParseExact(mydate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyyMMdd");
        }
        public string mmddyyyyTOyyyymmdd(string mydate)
        {
            return DateTime.ParseExact(mydate, "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyyMMdd");
        }
        public void ClearControls(Control control)
        {
            var textbox = control as TextBox;
            if (textbox != null)
                textbox.Text = string.Empty;
            var dropDownList = control as DropDownList;
            if (dropDownList != null)
                dropDownList.SelectedIndex = 0;
            foreach (Control childControl in control.Controls)
            {
                ClearControls(childControl);
            }
        }


        public void FillProperty(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillProperty(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                
            }

           ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillProperty(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " ";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }


        public void FillSubProperty(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype, String Category)
        {
            DataSet ds;
            ds = GetRecordsFillProperty(valuefield, displayfield, tablename, Category);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsFillProperty(String valuefield, String displayfield, String tablename, String Category)
        {
            DataSet ds;
            String sql;
            sql = "select distinct " + valuefield + "," + displayfield + " from " + tablename + " where p_id='" + Category + "' order by " + valuefield + " ASC ";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }
        public void FillFaccingIssue(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillFaccingIssue(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillFaccingIssue(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " order by " + displayfield + "";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }


        public void FillFaccingMainIssue(String valuefield, String displayfield, String tablename, DropDownList ddl, String stype, String Category)
        {
            DataSet ds;
            ds = GetRecordsFillFaccingMainIssue(valuefield, displayfield, tablename, Category);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            //  ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsFillFaccingMainIssue(String valuefield, String displayfield, String tablename, String Category)
        {
            DataSet ds;
            String sql;
            sql = "select distinct " + valuefield + "," + displayfield + " from " + tablename + " where tc_id='" + Category + "'";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);
            return ds;
        }

        public void FillPayee(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype , string propertyvalue)
        {
            DataSet ds;
            ds = GetRecordsToFillPayee(valuefield, displayfield, tablename, propertyvalue);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillPayee(String valuefield, String displayfield, String tablename, string propertyvalue)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " where t_PropertyVale =" + propertyvalue+ "";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }


        public void FillCategory(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillCategory(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillCategory(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " order by " + displayfield + " ASC";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }

        public void FillPaidBy(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillPaidBy(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillPaidBy(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + " where s_usertype ='admin' and s_isActive='1' order by " + displayfield + " ASC";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }

     


        public void FillAnnouncementTo(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillAnnouncementTo(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillAnnouncementTo(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + "  order by " + displayfield + " ASC";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }


        public void fillGender(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsTofillGender(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsTofillGender(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + "  order by " + valuefield + " ASC";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }

        public void fillComplaints(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillfillComplaints(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillfillComplaints(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + "  order by " + valuefield + " ASC";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }

        public void FillDueType(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillDueType(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillDueType(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + "  order by " + valuefield + " ASC";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }



        public void FillFloorNo(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillFloorNo(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            //ListItem li = new ListItem();
            //if (stype == "A")
            //{
            //    li.Text = "All";
            //    li.Value = "0";
            //    ddl.Items.Insert(0, li);
            //}
            //else
            //{
            //    li.Text = "Select";
            //    li.Value = "0";
            //    ddl.Items.Insert(0, li);
            //}
            //ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillFloorNo(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + "  order by " + valuefield + " ASC";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }

        public void FillBedType(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillBedType(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillBedType(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + "  order by " + valuefield + " ASC";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }

        public void FillLockinPeriod(String valuefield, String displayfield, String tablename, DropDownList ddl, string stype)
        {
            DataSet ds;
            ds = GetRecordsToFillLockinPeriod(valuefield, displayfield, tablename);
            ddl.DataSource = ds;
            ddl.DataTextField = displayfield;
            ddl.DataValueField = valuefield;
            ddl.DataBind();
            ListItem li = new ListItem();
            if (stype == "A")
            {
                li.Text = "All";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            else
            {
                //if ((li.Text == "Select") && (li.Value == "0"))
                //{
                li.Text = "Select";
                li.Value = "0";
                ddl.Items.Insert(0, li);
                // ddl.SelectedValue = "1";
                //}
            }

            ddl.SelectedValue = "0";
        }
        public DataSet GetRecordsToFillLockinPeriod(String valuefield, String displayfield, String tablename)
        {
            DataSet ds;
            String sql;
            sql = "select " + valuefield + "," + displayfield + " from " + tablename + "  order by " + valuefield + " ASC";
            ds = SqlHelper.ExecuteDataset(ConnectionString.CnSettings.cnString1, CommandType.Text, sql);

            return ds;
        }

    }

}
