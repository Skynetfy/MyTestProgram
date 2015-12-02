using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using System.IO;

namespace HangfireService.Pro
{
    public partial class Service1 : ServiceBase
    {
        //定时器  
        System.Timers.Timer t = null;  
        private BackgroundJobServer _server;
        public Service1()
        {
            InitializeComponent();
            //启用暂停恢复  
            base.CanPauseAndContinue = true;
            //每5秒执行一次  
            t = new System.Timers.Timer(5000);
            //设置是执行一次（false）还是一直执行(true)；  
            t.AutoReset = true;
            //是否执行System.Timers.Timer.Elapsed事件；  
            t.Enabled = true;
            //到达时间的时候执行事件(theout方法)；  
            t.Elapsed += new System.Timers.ElapsedEventHandler(theout);
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=10.1.249.76;Initial Catalog=HHubNotifyTaskDb3;User ID=tester;Password=123321a;Connect Timeout=20000");
        }

        protected override void OnStart(string[] args)
        {
            string state = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "启动";
            WriteLog(state);
           
            var options = new BackgroundJobServerOptions
            {
                Queues = new[] { "accordatapush" }
            };
            _server = new BackgroundJobServer(options);
        }

        protected override void OnStop()
        {
            string state = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "停止";
            WriteLog(state);  
            _server.Dispose();
        }

        protected override void OnPause()
        {
            string state = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "暂停";
            WriteLog(state);

            t.Stop();  
        }

        protected override void OnContinue()
        {
            string state = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "继续";
            WriteLog(state);
            t.Start();  
        }

        public void WriteLog(string msg)
        {
            FileStream fs = new FileStream(@"C:\Log\log.txt", FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(msg);
            }
            fs.Close();
            fs.Dispose();
        }
        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {

            WriteLog("theout:" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        }
    }
}
