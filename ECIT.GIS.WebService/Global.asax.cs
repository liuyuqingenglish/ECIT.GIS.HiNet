using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ECIT.GIS.Service;
using Autofac.Integration.WebApi;
using Autofac;
namespace ECIT.GIS.WebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ///依赖注入
            AutofacRegister.InitAutoFac();

            ///automapper
            AutoMapperConfig.InitConfig();

           // AutofacRegister.ApiResolver.BeginScope().GetRequestLifetimeScope().res
        }
    }
}
