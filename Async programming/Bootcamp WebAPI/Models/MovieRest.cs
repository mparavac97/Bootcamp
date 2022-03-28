using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bootcamp_WebAPI.Models
{
	public class MovieRest
	{
		public string Name { get; set; }
		public int ReleaseYear { get; set; }

		public string DisplayData()
		{
			return ($"{Name}, {ReleaseYear}");
		}
	}
}