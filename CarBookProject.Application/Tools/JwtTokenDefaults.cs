using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudiance = "https://localhost";
		public const string ValidIssuer = "https://localhost";
		public const string Key = "CarBook+*010203CARBOOK01+*..020304CarbookProject";
		public const int Expire = 3;
	}
}
