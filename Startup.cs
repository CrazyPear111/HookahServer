using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace WebApplication1
{
	public class Startup
	{
		public Users Ob = new Users();
		public void ConfigureServices(IServiceCollection services)
		{
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			
			app.Use(async (context, next) => 
			{
				context.Response.ContentType = "text/html;charset=utf-8";
				await next();
			});

			app.UseMiddleware<Mapping>(Ob);
			app.UseMiddleware<JsonSer>(Ob);

		}

	}
}
