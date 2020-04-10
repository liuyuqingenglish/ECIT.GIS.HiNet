using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
namespace ECIT.GIS.WebService
{
    public class ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.ActionContext.Response.IsSuccessStatusCode)
            {
                //actionExecutedContext.ActionContext.Response.Content.
            }
        }
    }
}