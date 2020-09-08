using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System;
using Microsoft.AspNet.SignalR.Hubs;
namespace ECIT.GIS.WebService
{
    public class MessageHub : Hub
    {
        /// <summary>
        /// 客户端对象
        /// </summary>
        public ConcurrentDictionary<string, IRequest> client = new ConcurrentDictionary<string, IRequest>();

        /// <summary>
        /// 连接上
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            if (!client.ContainsKey(this.Context.ConnectionId))
            {
                client.TryAdd(this.Context.ConnectionId, this.Context.Request);
            }
            return base.OnConnected();
        }

        /// <summary>
        /// 断开时
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            if (client.ContainsKey(this.Context.ConnectionId))
            {
                IRequest request = null;
                client.TryRemove(this.Context.ConnectionId, out request);
            }
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 重连时
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            if (client.ContainsKey(this.Context.ConnectionId))
            {
                client[this.Context.ConnectionId] = this.Context.Request;
            }
            return base.OnReconnected();
        }

        [HubMethodName(nameof(SendMessage))]
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}