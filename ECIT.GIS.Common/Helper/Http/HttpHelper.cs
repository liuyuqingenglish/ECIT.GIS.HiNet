using System;
using System.Web;

namespace ECIT.GIS.Common
{
    public class HttpHelper
    {
        public static string GetClientIp()
        {
            string ip = string.Empty;
            try
            {
                var request = HttpContext.Current.Request;
                ip = string.IsNullOrEmpty(request.ServerVariables["HTTP_X_FORWARDED_FOR"]) ? request.ServerVariables["REMOTE_ADDR"].ToString():string.Empty;
                return ip;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}