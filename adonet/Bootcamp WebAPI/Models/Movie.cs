using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bootcamp_WebAPI.Models
{
	public class Movie
	{
		public string Name { get; set; }
		public int ReleaseYear { get; set; }
		public Guid Id { get; set; }

		public string DisplayData()
		{
			return ($"{Name}, {ReleaseYear}, {Id}");
		}
	}
}