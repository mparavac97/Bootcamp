using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bootcamp_WebAPI.Controllers
{
	public class MoviesController : ApiController
	{
		public static List<Movie> movies = new List<Movie>();

		//GET api/values
		public HttpResponseMessage Get()
		{
			string printMessage = "";

			if (movies == null)
				return Request.CreateResponse(HttpStatusCode.NotFound, $"List is empty.");

			foreach (Movie movie in movies)
			{
				printMessage += movie.DisplayData();
			}
			
			return Request.CreateResponse(HttpStatusCode.OK, printMessage);
		}

		// GET api/values/5
		[HttpGet]
		//[Route("api/values/{id}")]
		public HttpResponseMessage Get(int id)
		{
			Movie tempMovie = movies.Find(movie => movie.Id == id);

			if (tempMovie == null)
				return Request.CreateResponse(HttpStatusCode.NotFound, id);

			return Request.CreateResponse(HttpStatusCode.OK, tempMovie);
		}

		// POST api/values
		public HttpResponseMessage Post([FromBody]Movie movie)
		{
			movies.Add(movie);
			return Request.CreateResponse(HttpStatusCode.OK, "New movie added to the list.");
		}

		// PUT api/values/5
		//[Route("api/values/{value}")]
		[HttpPut]
		public HttpResponseMessage UpdateMovieData(int id, [FromBody]Movie movie)
		{
			Movie tempMovie = movies.Find(m => m.Id == id);
			tempMovie.Name = movie.Name;
			tempMovie.ReleaseYear = movie.ReleaseYear;

			return Request.CreateResponse(HttpStatusCode.OK, "Data update successfull.");
		}

		// DELETE api/values/5
		public HttpResponseMessage Delete(int id)
		{
			Movie movie= movies.Find(m => m.Id == id);

			if (movie == null)
				return Request.CreateResponse(HttpStatusCode.NotFound, $"Movie with the ID: {id} was not found.");

			movies.Remove(movie);
			return Request.CreateResponse(HttpStatusCode.OK, $"Movie with the ID: {id} was successfully removed from the list.");
		}
	}

	public class Movie
	{
		public string Name { get; set; }
		public int ReleaseYear { get; set; }
		public int Id { get; set; }

		public string DisplayData()
		{
			return ($"{Name}, {ReleaseYear}, {Id}");
		}
	}
}
