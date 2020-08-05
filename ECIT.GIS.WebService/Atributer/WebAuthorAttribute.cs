using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ECIT.GIS.WebService
{
    public class WebAuthorAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            CheckQuery(actionContext);
            if (CheckHeader(actionContext) && CheckQuery(actionContext))
            {
            }
        }

        private static bool CheckHeader(HttpActionContext context)
        {
            var header = context.Request.Headers;
            if (header == null || header.Contains("ecitToken"))
            {
                return false;
            }
            var token = header.GetValues("ecitToken").FirstOrDefault();
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            return true;
        }

        private static bool CheckQuery(HttpActionContext context)
        {
            string paras = context.Request.RequestUri.Query.Substring(1);
            List<string> item = paras.Split('&').ToList();
            if (!item.Contains("ecitToken"))
            {
                return false;
            }
            return true;
        }
    }
}