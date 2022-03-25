using Bootcamp_WebAPI.Models;
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
		static readonly string connectionString = "Data Source=DESKTOP-4HPED1P;Initial Catalog=BootcampDB;Integrated Security=True";

		//GET api/values
		[HttpGet]
		[Route("api/values")]
		public HttpResponseMessage Get()
		{
			SqlConnection connection = new SqlConnection(connectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand("SELECT * FROM Movie;", connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					List<Movie> tempMovies = new List<Movie>();
					while (reader.Read())
					{
						Movie movie = new Movie
						{
							Name = reader.GetString(1),
							ReleaseYear = reader.GetInt32(2),
							Id = reader.GetGuid(0)
						};
						tempMovies.Add(movie);
					}
					reader.Close();
					return Request.CreateResponse(HttpStatusCode.OK, tempMovies);
				}
				else
				{
					return Request.CreateResponse(HttpStatusCode.NotFound, "Object not found.");
				}
			}

		}

		// GET api/values/5
		[HttpGet]
		[Route("api/values/{id}")]
		public HttpResponseMessage Get(Guid id)
		{
			SqlConnection connection = new SqlConnection(connectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand($"SELECT * FROM Movie WHERE MovieID = '{id}';", connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					List<Movie> tempMovies = new List<Movie>();
					while (reader.Read())
					{
						Movie movie = new Movie
						{
							Name = reader.GetString(1),
							ReleaseYear = reader.GetInt32(2),
							Id = reader.GetGuid(0)
						};
						tempMovies.Add(movie);
					}
					reader.Close();
					return Request.CreateResponse(HttpStatusCode.OK, tempMovies);
				}
				else
				{
					return Request.CreateResponse(HttpStatusCode.NotFound, "Object not found.");
				}
			}
		}

		// POST api/values
		[HttpPost]
		[Route("api/values")]
		public HttpResponseMessage Post([FromBody]Movie movie)
		{
			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"INSERT INTO Movie (MovieName, ReleaseYear) VALUES ('{movie.Name}', '{movie.ReleaseYear}');";

			using (connection)
			{
				SqlCommand command = new SqlCommand(sqlCommand, connection);
				connection.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

				DataSet movieData = new DataSet();

				dataAdapter.Fill(movieData, "Movie");
				connection.Close();
			}

			return Request.CreateResponse(HttpStatusCode.OK, "New movie added to the table.");
		}

		// PUT api/values/5
		[HttpPut]
		[Route("api/values/{id}")]
		public HttpResponseMessage UpdateMovieData(Guid id, [FromBody]Movie movie)
		{
			if (!Get(id).IsSuccessStatusCode)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound, "Movie with the specified ID was not found.");
			}
			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"UPDATE Movie SET MovieName = '{movie.Name}', ReleaseYear = '{movie.ReleaseYear}' WHERE MovieID = '{id}';";

			using (connection)
			{
				SqlCommand command = new SqlCommand(sqlCommand, connection);
				connection.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

				DataSet updatedMovieData = new DataSet();
				dataAdapter.Fill(updatedMovieData, "Movie");

				connection.Close();
			}

			return Request.CreateResponse(HttpStatusCode.OK, "Data updated successfully.");
		}

		// DELETE api/values/5
		[HttpDelete]
		[Route("api/values/{id}")]
		public HttpResponseMessage Delete(Guid id)
		{
			if (!Get(id).IsSuccessStatusCode)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound, "Movie with the specified ID was not found.");
			}
			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"DELETE FROM Movie WHERE MovieId = '{id}';";

			using (connection)
			{
				SqlCommand command = new SqlCommand(sqlCommand, connection);
				connection.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

				DataSet deletedMovieData = new DataSet();
				dataAdapter.Fill(deletedMovieData, "Movie");

				connection.Close();
			}

			return Request.CreateResponse(HttpStatusCode.OK, $"Movie with the ID: {id} was successfully deleted from the table.");
		}
	}

	
}
