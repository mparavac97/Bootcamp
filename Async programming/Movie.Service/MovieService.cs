using Movie.Model;
using Movie.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Service.Common;

namespace Movie.Service
{
    public class MovieService : IMovieService
    {
        public async Task<List<MovieEntity>> GetMoviesAsync()
        {
            MovieRepository movieRepository = new MovieRepository();
            return await movieRepository.GetMoviesAsync();
        }

        public async Task<MovieEntity> GetMovieByIdAsync(Guid id)
        {
            MovieRepository movieRepository = new MovieRepository();
            return await movieRepository.GetMovieByIdAsync(id);
        }

        public async Task AddMovieAsync(MovieEntity movie)
        {
            MovieRepository movieRepository = new MovieRepository();
            await movieRepository.AddMovieAsync(movie);
        }

        public async Task UpdateMovieDataAsync(Guid id, MovieEntity movie)
        {
            MovieRepository movieRepository = new MovieRepository();
            await movieRepository.UpdateMovieDataAsync(id, movie);
        }

        public async Task DeleteMovieAsync(Guid id)
        {
            MovieRepository movieRepository = new MovieRepository();
            await movieRepository.DeleteMovieAsync(id);
        }
    }
}
