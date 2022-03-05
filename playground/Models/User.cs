using System;
using System.Collections.Generic;

namespace playground.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Nickname { get; set; }
		public string Password { get; set; }
		public IEnumerable<Repository> Repositories { get; set; }
     
    }
}

