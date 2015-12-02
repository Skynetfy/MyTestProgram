using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using HZLogger.NLogWrapper;

namespace Ioc.SignalRMvc
{
    public class EchoConnection:PersistentConnection
    {
        /// <summary>
        /// 当前连接数
        /// </summary>
        private static int _connections = 0;
        /// <summary>
        /// 连接建立后执行方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        protected override async Task OnConnected(IRequest request, string connectionId)
        {
            HZLogger.NLogWrapper.HZLogger.Info(string.Format("连接{0}已建立", connectionId));

            //原子操作,防止多条现成同时+1而只做一次变化
            Interlocked.Increment(ref _connections);
            //return base.OnConnected(request, connectionId);

            await Connection.Send(connectionId, "Hi, " + connectionId + "!");
            await Connection.Broadcast("新连接 " + connectionId + "开启. 当前连接数: " + _connections);
        }

        /// <summary>
        /// 连接关闭后执行方法
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        protected override  Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            HZLogger.NLogWrapper.HZLogger.Info(string.Format("连接{0}已关闭", connectionId));
            //return base.OnDisconnected(request, connectionId, stopCalled);
            //原子操作,防止多条现成同时-1而只做一次变化
            Interlocked.Decrement(ref _connections);
            return Connection.Broadcast(connectionId + " 连接关闭. 当前连接数: " + _connections);
        }

        /// <summary>
        /// 链接开始时执行
        /// </summary>
        /// <param name="request"></param>
        /// <param name="connectionId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var message = connectionId + ">> " + data;
            HZLogger.NLogWrapper.HZLogger.Info(message);
            return Connection.Broadcast(message);
        }
    }
}