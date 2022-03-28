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
		Task<List<MovieEntity>> GetMoviesAsync();

		Task<MovieEntity> GetMovieByIdAsync(Guid id);

		Task AddMovieAsync(MovieEntity movie);

		Task UpdateMovieDataAsync(Guid id, MovieEntity movie);

		Task DeleteMovieAsync(Guid id);
	}
}
