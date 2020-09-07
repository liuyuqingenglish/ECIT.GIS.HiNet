using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(ECIT.GIS.WebService.Startup))]

namespace ECIT.GIS.WebService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ///owin.cors 优先级最高--使用owin 方式寄宿
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(WebApiConfig.OwinWebApiConfiguration(new System.Web.Http.HttpConfiguration()));
            ///长连接--signalr
            app.MapSignalR<MessageHubPersistenConnnection>("/MessageHubPersistenConnnection");
        }
    }
}