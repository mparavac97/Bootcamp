using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bootcamp_WebAPI.Models
{
	public class Director
	{
		public string FirstName;
		public string LastName;
		public Guid Id;

		public string DisplayData()
		{
			return $"{FirstName}, {LastName}, {Id}";
		}

	}
}