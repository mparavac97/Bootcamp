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
        public List<MovieEntity> GetMovies()
        {
            MovieRepository movieRepository = new MovieRepository();
            return movieRepository.GetMovies();
        }

        public MovieEntity GetMovieById(Guid id)
        {
            MovieRepository movieRepository = new MovieRepository();
            return movieRepository.GetMovieById(id);
        }

        public void AddMovie(MovieEntity movie)
        {
            MovieRepository movieRepository = new MovieRepository();
            movieRepository.AddMovie(movie);
        }

        public void UpdateMovieData(Guid id, MovieEntity movie)
        {
            MovieRepository movieRepository = new MovieRepository();
            movieRepository.UpdateMovieData(id, movie);
        }

        public void DeleteMovie(Guid id)
        {
            MovieRepository movieRepository = new MovieRepository();
            movieRepository.DeleteMovie(id);
        }
    }
}
