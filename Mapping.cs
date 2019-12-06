using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication1
{
	public class Mapping
	{
		private RequestDelegate _next;
		private Users ob;
		public Mapping(RequestDelegate next, Users ob)
		{
			this._next = next;
			this.ob = ob;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			if(context.Request.Path == "/show") 
				await context.Response.WriteAsync($"<h3>{ob.Name + "   " + ob.Password}</h3>");
			else if (context.Request.Path == "/bitch")
				await context.Response.WriteAsync($"<h3>BITCHES</h3>");
			else
				await _next(context);
		}
	}
}
