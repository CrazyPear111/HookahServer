using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
	public class Users
	{
		public string Name { get; set; }
		public string Password { get; set; }

		public void Factory(Users ob)
		{
			Name = ob.Name;
			Password = ob.Password;
		}
	}
}
