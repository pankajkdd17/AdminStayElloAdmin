using System;
using System.Web;

namespace ConnectionString
{
	/// <summary>
	/// Summary description for ConnectionSettings.
	/// </summary>
	public sealed class  CnSettings
	{
		private  CnSettings()
		{			 
		}
		public static string cnString1
		{
			get
			{
                string cn = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
				return cn;
			}
		}
        //public static string cnParle
        //{
        //    get
        //    {
        //        string cn = System.Configuration.ConfigurationManager.ConnectionStrings["parle"].ConnectionString;
        //        return cn;
        //    }
        //}
       
    }
}
			