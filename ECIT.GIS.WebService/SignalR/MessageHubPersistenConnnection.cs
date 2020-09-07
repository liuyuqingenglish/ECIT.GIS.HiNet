using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ECIT.GIS.WebService
{
    /// <summary>
    /// 永久连接模型--类似websocket
    /// </summary>
    public class MessageHubPersistenConnnection : PersistentConnection,IBaseMessage
    {
        /// <summary>
        /// 客户端对象
        /// </summary>
        public ConcurrentDictionary<string, IRequest> client = new ConcurrentDictionary<string, IRequest>();

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            ///组--加入特定组
            //Groups.Add(connectionId, "测试");
            //Groups.Send();
            if (!client.ContainsKey(connectionId))
            {
                client.TryAdd(connectionId, request);
            }
            return Connection.Broadcast(connectionId + ":登录成功");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(connectionId + ":" + data);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            if (client.ContainsKey(connectionId))
            {
                IRequest tempRequest = null;
                client.TryRemove(connectionId, out request);
            }
            Connection.Broadcast(connectionId + ":退出了");
            return base.OnDisconnected(request, connectionId, stopCalled);
        }
    }
}