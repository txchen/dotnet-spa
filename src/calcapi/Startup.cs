using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace DotnetSPAAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Configure the console logger by reading config file
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            // this will enable logging to debug console, if no level is specified, Information is used.
            loggerFactory.AddDebug(LogLevel.Debug);

            // Add serilog to pipeline, let it write structured log as json to file
            //   In prod, consider using Seq or ElasticSearch, serilog has sinks to write to them.
            var levelSwitch = new LoggingLevelSwitch(); // use levelSwitch so that we can change it dynamically
            levelSwitch.MinimumLevel =  LogEventLevel.Information;
            // To write structured log to file, use Serilog.Sinks.Json
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                // currently override can be only done in code, not in json config file
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Hosting.Internal.WebHost", LogEventLevel.Information)
                .Enrich.FromLogContext() // add aspnet context to log
                .Enrich.WithMachineName()
                .WriteTo.JsonFile(path: "calcapi.log")
                .CreateLogger();
            loggerFactory.AddSerilog();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
