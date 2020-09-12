using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Threading.Tasks;

namespace ECIT.GIS.WebService
{
    public class MessageHub : Hub
    {
        /// <summary>
        /// web组
        /// </summary>
        private const string WEB_GROUP = "web_group";

        /// <summary>
        /// 移动端组
        /// </summary>
        private const string MOBILE_GROUP = "mobile_group";

        /// <summary>
        /// 连接上
        /// </summary>
        /// <returns></returns>
        [HubMethodName("OnConnected")]
        public override Task OnConnected()
        {
            Clients.All.LoginSucess($"{this.Context.ConnectionId}用户登录成功");
            return base.OnConnected();
        }

        /// <summary>
        /// 断开时
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.AllExcept(Context.ConnectionId).LoginOut($"{this.Context.ConnectionId}用户注销登录");
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 重连时
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        [HubMethodName(nameof(SendMessage))]
        public void SendMessage(string message)
        {
            string id = this.Context.ConnectionId;
            Clients.All.RecevieMessage(id, message);
        }

    }
}