using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bootcamp_WebAPI.Models;

namespace Bootcamp_WebAPI.Controllers
{
	public class DirectorController : ApiController
	{
		static readonly string connectionString = "Data Source=DESKTOP-4HPED1P;Initial Catalog=BootcampDB;Integrated Security=True";

		[HttpGet]
		[Route("api/director")]
		public HttpResponseMessage Get()
		{
			SqlConnection connection = new SqlConnection(connectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand("SELECT * FROM Director;", connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					List<Director> tempDirectors = new List<Director>();
					while (reader.Read())
					{
						Director director = new Director()
						{
							FirstName = reader.GetString(1),
							LastName = reader.GetString(2),
							Id = reader.GetGuid(0)
						};
						tempDirectors.Add(director);
					}
					reader.Close();
					return Request.CreateResponse(HttpStatusCode.OK, tempDirectors);
				}
				else
				{
					return Request.CreateResponse(HttpStatusCode.NotFound, "Object not found.");
				}
			}

		}

		[Route("api/director/{id}")]
		public HttpResponseMessage Get(Guid id)
		{
			SqlConnection connection = new SqlConnection(connectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand($"SELECT * FROM Director WHERE DirectorID = '{id}';", connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					reader.Read();
					Director director = new Director();
					director.FirstName = reader.GetString(1);
					director.LastName = reader.GetString(2);
					director.Id = reader.GetGuid(0);

					reader.Close();
					return Request.CreateResponse(HttpStatusCode.OK, director);
				}
				else
				{
					return Request.CreateResponse(HttpStatusCode.NotFound, "Director with the specified ID was not found.");
				}
			}
		}

		[HttpPost]
		[Route("api/director")]
		public HttpResponseMessage Post([FromBody]Director director)
		{
			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"INSERT INTO Director (FirstName, LastName) VALUES ('{director.FirstName}', '{director.LastName}');";

			using (connection)
			{
				SqlCommand command = new SqlCommand(sqlCommand, connection);
				connection.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

				command.ExecuteNonQuery();
				connection.Close();
			}

			return Request.CreateResponse(HttpStatusCode.OK, "New director added to the table.");
		}

		[Route("api/director/{id}")]
		public HttpResponseMessage Put(Guid id, [FromBody]Director director)
		{
			if (!Get(id).IsSuccessStatusCode)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound, "Director with the specified ID was not found.");
			}
			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"UPDATE Director SET FirstName = '{director.FirstName}', LastName = '{director.LastName}' WHERE DirectorID = '{id}';";

			using (connection)
			{
				SqlCommand command = new SqlCommand(sqlCommand, connection);
				connection.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

				command.ExecuteNonQuery();
				connection.Close();
			}

			return Request.CreateResponse(HttpStatusCode.OK, "Data updated successfully.");
		}

		[Route("api/director/{id}")]
		public HttpResponseMessage Delete(Guid id)
		{
			if (!Get(id).IsSuccessStatusCode)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound, "Director with the specified ID was not found.");
			}

			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"DELETE FROM Director WHERE DirectorID = '{id}';";

			using (connection)
			{
				SqlCommand command = new SqlCommand(sqlCommand, connection);
				connection.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

				command.ExecuteNonQuery();
				connection.Close();
			}

			return Request.CreateResponse(HttpStatusCode.OK, $"Director with the ID: {id} was successfully removed from the table.");
		}
	}

	
}