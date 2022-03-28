using Bootcamp_WebAPI.Models;
using Movie.Model;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bootcamp_WebAPI.Controllers
{
	public class MoviesController : ApiController
	{

		//GET api/values
		[HttpGet]
		[Route("api/values")]
		public HttpResponseMessage Get()
		{
			MovieService movieService = new MovieService();

			if (movieService.GetMovies() == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}
			else
			{
				List<MovieRest> moviesRest = new List<MovieRest>();
				foreach (MovieEntity movie in movieService.GetMovies())
				{
					MovieRest movieRest = new MovieRest
					{
						Name = movie.Name,
						ReleaseYear = movie.ReleaseYear
					};
					moviesRest.Add(movieRest);
				}
				return Request.CreateResponse(HttpStatusCode.OK, moviesRest);
			}
		}

		// GET api/values/5
		[HttpGet]
		[Route("api/values/{id}")]
		public HttpResponseMessage Get(Guid id)
		{
			MovieService movieService = new MovieService();

			if (movieService.GetMovieById(id) == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}
			else
			{
				MovieRest movieRest = new MovieRest
				{
					Name = movieService.GetMovieById(id).Name,
					ReleaseYear = movieService.GetMovieById(id).ReleaseYear
				};
				return Request.CreateResponse(HttpStatusCode.OK, movieRest);
			}
		}

		// POST api/values
		[HttpPost]
		[Route("api/values")]
		public HttpResponseMessage Post([FromBody]MovieRest movieRest)
		{
			MovieService movieService = new MovieService();
			MovieEntity movie = new MovieEntity
			{
				Name = movieRest.Name,
				ReleaseYear = movieRest.ReleaseYear
			};

			movieService.AddMovie(movie);
			return Request.CreateResponse(HttpStatusCode.OK, "Movie successfully added to the table.");
		}

		// PUT api/values/5
		[HttpPut]
		[Route("api/values/{id}")]
		public HttpResponseMessage UpdateMovieData(Guid id, [FromBody]MovieRest movieRest)
		{
			MovieService movieService = new MovieService();

			if (movieService.GetMovieById(id) == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound, "Movie with the specified ID was not found.");
			}

			MovieEntity movie = new MovieEntity
			{
				Name = movieRest.Name,
				ReleaseYear = movieRest.ReleaseYear
			};

			movieService.UpdateMovieData(id, movie);

			return Request.CreateResponse(HttpStatusCode.OK, "Movie updated successfully.");
		}

		// DELETE api/values/5
		[HttpDelete]
		[Route("api/values/{id}")]
		public HttpResponseMessage Delete(Guid id)
		{
			MovieService movieService = new MovieService();

			if (movieService.GetMovieById(id) == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound, "Movie with the specified ID was not found.");
			}

			movieService.DeleteMovie(id);

			return Request.CreateResponse(HttpStatusCode.OK, "Movie with the specified ID was deleted from the table;");
		}
	}

	
}
