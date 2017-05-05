using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using CustomDbProfileService2.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using CustomDbProfileService2.Stores;

namespace CustomDbProfileService2
{
    public class Startup
    {
		public Startup(IHostingEnvironment env)
		{
			
		}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

			var configBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			var Configuration = configBuilder.Build();

			services.AddDbContext<Id4Context>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("IdentityServiceConnection")));


			var builder = services.AddIdentityServer();

			//builder.Services.AddTransient<IProfileService, SMSProfileService>();

			//client store for 
			builder.Services.AddTransient<IClientStore, SMSClientStore>();

			//ResourceStore
			builder.Services.AddTransient<IResourceStore, SMSResourceStore>();

			builder.AddTemporarySigningCredential();

			//builder.AddInMemoryApiResources(Config.GetApis());

			//builder.AddInMemoryClients(Config.GetClients());

		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			app.UseIdentityServer();

			app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
