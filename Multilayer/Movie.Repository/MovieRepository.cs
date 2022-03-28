using Movie.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Repository.Common;



namespace Movie.Repository
{
    public class MovieRepository : IMovieRepository
    {
        static readonly string connectionString = "Data Source=DESKTOP-4HPED1P;Initial Catalog=BootcampDB;Integrated Security=True";
        
        public List<MovieEntity> GetMovies()
        {
			SqlConnection connection = new SqlConnection(connectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand("SELECT * FROM Movie;", connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					List<MovieEntity> tempMovies = new List<MovieEntity>();
					while (reader.Read())
					{
						MovieEntity movie = new MovieEntity
						{
							Name = reader.GetString(1),
							ReleaseYear = reader.GetInt32(2),
							Id = reader.GetGuid(0)
						};
						tempMovies.Add(movie);
					}
					reader.Close();
					return tempMovies;
				}
				else
				{
					return null;
				}
			}
		}

		public MovieEntity GetMovieById(Guid id)
		{
			SqlConnection connection = new SqlConnection(connectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand($"SELECT * FROM Movie WHERE MovieID = '{id}';", connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				if (reader.Read())
				{
					MovieEntity movie = new MovieEntity
					{
						Name = reader.GetString(1),
						ReleaseYear = reader.GetInt32(2),
						Id = reader.GetGuid(0)
					};
					reader.Close();
					return movie;
				}
				else
				{
					reader.Close();
					return null;
				}
					

				

				
				//if (reader.HasRows)
				//{
				//	List<MovieEntity> tempMovies = new List<MovieEntity>();
				//	while (reader.Read())
				//	{
				//		MovieEntity movie = new MovieEntity
				//		{
				//			Name = reader.GetString(1),
				//			ReleaseYear = reader.GetInt32(2),
				//			Id = reader.GetGuid(0)
				//		};
				//		tempMovies.Add(movie);
				//	}
				//	reader.Close();
				//	return Request.CreateResponse(HttpStatusCode.OK, tempMovies);
				//}
				//else
				//{
				//	return null;
				//}
			}
		}

		public void AddMovie(MovieEntity movie)
		{
			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"INSERT INTO Movie (MovieName, ReleaseYear) VALUES ('{movie.Name}', '{movie.ReleaseYear}');";

			using (connection)
			{
				using (connection)
				{
					SqlCommand command = new SqlCommand(sqlCommand, connection);
					connection.Open();
					SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		public void UpdateMovieData(Guid id, MovieEntity movie)
		{
			if (this.GetMovieById(id) == null)
			{
				return;
			}
			else
			{
				SqlConnection connection = new SqlConnection(connectionString);
				string sqlCommand = $"UPDATE Movie SET MovieName = '{movie.Name}', ReleaseYear = '{movie.ReleaseYear}' WHERE MovieID = '{id}';";

				using (connection)
				{
					SqlCommand command = new SqlCommand(sqlCommand, connection);
					connection.Open();
					SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

					command.ExecuteNonQuery();
					connection.Close();
				}
			}
		}

		public void DeleteMovie (Guid id)
		{
			if (this.GetMovieById(id) == null)
			{
				return;
			}

			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"DELETE FROM Movie WHERE MovieId = '{id}';";

			using (connection)
			{
				SqlCommand command = new SqlCommand(sqlCommand, connection);
				connection.Open();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

				command.ExecuteNonQuery();
				connection.Close();
			}
		}
    }
}
