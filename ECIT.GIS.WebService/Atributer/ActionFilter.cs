using ECIT.GIS.Common;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Text;
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
                else
                {
                    result = actionExecutedContext.ActionContext.Response.Content == null || actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().IsFaulted
                        ? new WebResponseResult<object>() : new WebResponseResult<object>(actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>());
                }
            }
            if (result != null)
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    Content = new StringContent(result.ToJson(), Encoding.GetEncoding("UTF-8"), "application/json")
                };     
            }
        }
    }
}