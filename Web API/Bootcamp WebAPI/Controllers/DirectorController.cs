using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bootcamp_WebAPI.Controllers
{
	public class DirectorCompanyController
	{
		public static List<Director> directors = new List<Director>();

		public HttpResponseMessage Get()
		{
			string printMessage = "";

			if (directors == null)
				return Request.CreateResponse(HttpStatusCode.NotFound, $"List is empty.");

			foreach (Director director in directors)
			{
				printMessage += director.DisplayData();
			}

			return Request.CreateResponse(HttpStatusCode.OK, printMessage);
		}

		public HttpResponseMessage Get(int id)
		{
			Director tempDirector = directors.Find(director => director.Id == id);

			if (tempDirector == null)
				return Request.CreateResponse(HttpStatusCode.NotFound, id);

			return Request.CreateResponse(HttpStatusCode.OK, tempDirector);
		}

		public HttpResponseMessage Post([FromBody]Director director)
		{
			directors.Add(director);
			return Request.CreateResponse(HttpStatusCode.OK, "New director added to the list.");
		}

		public HttpResponseMessage Put(int id, [FromBody]Director director)
		{
			Director tempDirector = directors.Find(d => d.Id == id);
			tempDirector.FirstName = director.FirstName;
			tempDirector.LastName = director.LastName;
			
			return Request.CreateResponse(HttpStatusCode.OK, "Data update successfull.");
		}

		public HttpResponseMessage Delete(int id)
		{
			Director director = directors.Find(d => d.Id == id);

			if (director == null)
				return Request.CreateResponse(HttpStatusCode.NotFound, $"Director with the ID: {id} was not found.");

			directors.Remove(director);
			return Request.CreateResponse(HttpStatusCode.OK, $"Movie with the ID: {id} was successfully removed from the list.");
		}
	}

	public class Director
	{
		public string FirstName;
		public string LastName;
		public int Id;
		public List<Movie> Movies;

		public string DisplayData()
		{
			string message = $"{FirstName} {LastName} was a director for the following movies: ";
			foreach (Movie movie in Movies)
			{
				message += movie.DisplayData();
			}
			return message;
		}

	}
}