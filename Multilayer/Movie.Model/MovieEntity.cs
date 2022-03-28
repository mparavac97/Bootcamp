using Movie.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Model
{
	public class MovieEntity : IMovie
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
