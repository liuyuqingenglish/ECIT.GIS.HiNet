using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Web.Http;

namespace ECIT.GIS.WebService.ApiControl
{
    [WebAuthorAttribute]
    [ActionFilter]
    public class BaseController<T> : ApiController where T : IHub, new()
    {
        protected IHubConnectionContext<dynamic> clients { get; }

        protected IGroupManager group { get; }

        protected BaseController()
        {
            System.Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            var context = GlobalHost.ConnectionManager.GetHubContext<T>();
            //var context = GlobalHost.ConnectionManager.GetConnectionContext<T>();
            ///表示客户端在转而使用其他传输或连接失败之前应允许连接的时间。默认值为 5 秒。(传输超时时间)
            GlobalHost.Configuration.TransportConnectTimeout = TimeSpan.FromSeconds(30);
            //表示连接在超时之前保持打开状态的时间
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(5);
            //表示两次发送保持活动消息之间的时间长度。如果启用，此值必须至少为两秒。设置为 null 可禁用。
            GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(2);
            //Websocket模式下允许传输数据的最大值，默认为64kb
            GlobalHost.Configuration.MaxIncomingWebSocketMessageSize = 64;
            //设置消息缓冲区大小
            GlobalHost.Configuration.DefaultMessageBufferSize = 500;
            clients = context.Clients;
            group = context.Groups;
        }
    }
}