using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.Web;

/// <summary>
/// Summary description for sms
/// </summary>
public class sms
{
	public sms()
	{
		//
		// TODO: Add constructor logic here
		//

	}

    public string sendSMS()
    {
        String message = HttpUtility.UrlEncode("This is your message");
        using (var wb = new WebClient())
        {
            byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "m6PQ8S6Ivr4-v7VgZ9cmflrCh8TxDnrz8n9iNbZGRr"},
                {"numbers" , "7985648892"},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
            string result = System.Text.Encoding.UTF8.GetString(response);
            return result;
        }
    }
}