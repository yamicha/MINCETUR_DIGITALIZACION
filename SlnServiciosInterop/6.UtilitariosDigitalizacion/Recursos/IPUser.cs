﻿using System.Net;
namespace Utilitarios.Recursos
{
   public class IPUser
    {
        public static string ObtenerIP()
        {
            string ClientIP, Forwaded, RealIP = string.Empty;
            //try
            //{
            //    RealIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            //    ClientIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT-IP"];
            //    if (!string.IsNullOrEmpty(ClientIP))
            //    {
            //        RealIP = ClientIP;
            //    }
            //    else
            //    {
            //        Forwaded = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X-Forwarded-For"];
            //        if (!string.IsNullOrEmpty(Forwaded)) RealIP = Forwaded;
            //        else
            //        {
            //            RealIP = System.Web.HttpContext.Current.Request.UserHostAddress.ToString().Trim();
            //            if (RealIP.Length < 5)
            //            {
            //                string hostName = Dns.GetHostName();
            //                IPAddress[] ips = Dns.GetHostByName(hostName).AddressList;
            //                RealIP = Dns.GetHostByName(hostName).AddressList[ips.Length - 1].ToString();
            //            }
            //        }
            //    }
            //}
            //finally { }
            return RealIP;
        }
    }
}

