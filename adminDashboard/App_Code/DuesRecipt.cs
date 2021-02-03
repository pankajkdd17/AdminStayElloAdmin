
using ConnectionString;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DuesRecipt
{
    public SqlDataReader getReciptoFTenants(string d_id, string propertyVale)
    {
        string sql = "select d.d_id , p.p_address ,d.d_prpertyname , d.d_prpertyvalue , d.d_PayeeText,  d.d_PayeeValue,  d.d_RoomNo,  d.d_t_Mobile,  d.d_DuesTypeText,  d.d_DuesTypeValue, d_recivedAmount , d.d_DuesAmount, CONVERT(varchar , d.d_reciveddate , 103 ) as d_reciveddate , CONVERT(varchar , d.d_reciveddate , 103 ) as d_reciveddate ,  CONVERT(varchar , d.d_DuesMonth , 103) as d_DuesMonth ,  d.d_Remark ,convert (varchar ,d.d_crdate ,103) as d_crdate , d.d_mdfydate  from  Dues d join property p on  d.d_prpertyvalue = p.p_id  where  d.d_prpertyvalue = '"+ propertyVale + "' and  d.d_id = '"+ d_id + "' and d.d_status= 'recived'";
        return SqlHelper.ExecuteReader(CnSettings.cnString1, CommandType.Text, sql);
    }
}