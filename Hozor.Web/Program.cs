using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GSD.Globalization;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hozor.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    var persianCulture = new PersianCulture();
        //    Thread.CurrentThread.CurrentCulture = persianCulture;
        //    Thread.CurrentThread.CurrentUICulture = persianCulture;
        //}
    }
}
