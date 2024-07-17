
using CyberTech.AuthApi.Services.IService;
using CyberTech.AuthApi.Services;
using Microsoft.AspNetCore.Identity;
using System;

namespace CyberTech.AuthApi
{
    public class Program
    {
     
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
