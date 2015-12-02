using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ioc.AutofacWebApi.HttpMoulde
{
    public class MyModule:IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += ctx_AutoRequest;
        }

        protected void ctx_AutoRequest(object sender, EventArgs e)
        {
            Console.Write("进来了");
        }
    }
}