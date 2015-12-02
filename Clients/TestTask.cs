using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    internal class TestTask
    {
        private Random rand = new Random();
        public int TaskId { get; private set; }

        public TestTask(int taskId)
        {
            this.TaskId = taskId;
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns>接收到的数据，-1表示未接受</returns>
        public int ReceiveData()
        {
            var i = rand.Next(1, 1000);
            if (i < 990) return -1;
            return i;
        }

        /// <summary>
        /// 异步接收数据
        /// </summary>
        /// <returns></returns>
        public async Task<int> ReceiveDataAsync()
        {
            var task = new Task<int>(ReceiveData);
            task.Start();
            return await task;
        }
    }
}
