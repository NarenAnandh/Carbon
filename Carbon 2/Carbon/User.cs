using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbolibrary
{

	public class User
	{

		public User(string name, string origin, string extraInfo = "")
		{
			Name = name;
			Origin = origin;
			ExtraInfo = extraInfo;
		}

		public string Name;
		public string Origin;
		public string ExtraInfo;

		public string UID { get; set; }

	}

}
