using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApplication1
{
	public class JsonSer
	{
		private RequestDelegate _next;
		private string _json;
		private Users ob = new Users {Name = "name", Password = "password"};
		public Users obBack;
		private Users obTemp;
		public JsonSer(RequestDelegate next, Users ob)
		{
			_next = next;
			this.obBack = ob;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			_json = JsonConvert.SerializeObject(ob);
			await context.Response.WriteAsync(_json);
			_json = context.Request.QueryString.Value.Replace("%22", @"""");
			_json = _json.Replace("?", "");
			await context.Response.WriteAsync(_json);
			obTemp = JsonConvert.DeserializeObject<Users>(_json);
			obBack.Factory(obTemp);
			
			await _next(context);
		}
	}
}
