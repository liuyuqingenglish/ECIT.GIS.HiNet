using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
namespace ECIT.GIS.WebService
{
    public class WebAuthorAttribute : AuthorizationFilterAttribute
    {
        private readonly string TOKEN_HEADER = "ecitToken";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)
            {
                return;
            }
            if (!CheckHeader(actionContext) && !CheckQuery(actionContext))
            {
                var httpcontent = new StringContent("无权限用户，请重新登录");
                actionContext.Response.Content = httpcontent;
            }
        }

        private  bool CheckHeader(HttpActionContext context)
        {
            var header = context.Request.Headers;
            if (header == null || header.Contains(TOKEN_HEADER))
            {
                return false;
            }
            var token = header.GetValues(TOKEN_HEADER).FirstOrDefault();
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            return true;
        }

        private  bool CheckQuery(HttpActionContext context)
        {
            string paras = context.Request.RequestUri.Query.Substring(1);
            List<string> item = paras.Split('&').ToList();
            if (!item.Contains(TOKEN_HEADER))
            {
                return false;
            }
            return true;
        }
    }
}