using ECIT.GIS.Common;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ECIT.GIS.WebService
{
    public class ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            WebResponseResult<object> result = null;
            if (actionExecutedContext.Exception == null)
            {
                if (!actionExecutedContext.ActionContext.Response.IsSuccessStatusCode)
                {
                    result = new WebResponseResult<object>()
                    {
                        IsSuccess = false,
                        Code = actionExecutedContext.Response.StatusCode.ToString(),
                        ErrorInfo = actionExecutedContext.Exception.Message
                    };
                    actionExecutedContext.Response = new HttpResponseMessage()
                    {
                        //Content=new StringContent()
                    };
                }
            }
        }
    }
}