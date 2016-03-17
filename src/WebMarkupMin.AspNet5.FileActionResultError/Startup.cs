using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebMarkupMin.AspNet5.FileActionResultError
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
               .AddWebMarkupMin(o =>
               {
                   o.AllowMinificationInDevelopmentEnvironment = true;
                   o.AllowCompressionInDevelopmentEnvironment = false;
               })
               .AddHtmlMinification(o =>
               {
                   o.MinificationSettings = new WebMarkupMin.Core.HtmlMinificationSettings(true)
                   {
                       WhitespaceMinificationMode = WebMarkupMin.Core.WhitespaceMinificationMode.Safe,
                   };
               });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddConsole(LogLevel.Debug);

            app.UseIISPlatformHandler();

            app.UseWebMarkupMin();

            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
