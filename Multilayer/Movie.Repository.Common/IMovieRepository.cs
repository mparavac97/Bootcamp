using Movie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Repository.Common
{
	public interface IMovieRepository
	{
		List<MovieEntity> GetMovies();

		MovieEntity GetMovieById(Guid id);

		void AddMovie(MovieEntity movie);

		void UpdateMovieData(Guid id, MovieEntity movie);

		void DeleteMovie(Guid id);
	}
}
