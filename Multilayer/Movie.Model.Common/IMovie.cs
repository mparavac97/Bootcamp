using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Model.Common
{
	public interface IMovie
	{
		string Name { get; set; }
		int ReleaseYear { get; set; }
		Guid Id { get; set; }
	}
}
