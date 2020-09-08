using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Microsoft.AspNet.SignalR;
[assembly: OwinStartup(typeof(ECIT.GIS.WebService.Startup))]

namespace ECIT.GIS.WebService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ///owin.cors 优先级最高--使用owin 方式寄宿 Cors模式(需要安装Microsoft.Owin.Cors程序集)
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(WebApiConfig.OwinWebApiConfiguration(new System.Web.Http.HttpConfiguration()));
            ///长连接--signalr
            //app.MapSignalR<MessageHubPersistenConnnection>("/MessageHubPersistenConnnection");
            ///hub类型
            HubConfiguration hub = new HubConfiguration()
            {
                EnableJavaScriptProxies = true,
                EnableJSONP = true
            };
            app.MapSignalR("/MessageHub", hub);
        }
    }
}