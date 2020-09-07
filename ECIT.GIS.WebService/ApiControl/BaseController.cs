using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
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
            clients = context.Clients;
            group = context.Groups;
        }
    }
}