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
        
        public async Task<List<MovieEntity>> GetMoviesAsync()
        {
			SqlConnection connection = new SqlConnection(connectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand("SELECT * FROM Movie;", connection);
				await connection.OpenAsync();
				SqlDataReader reader = await command.ExecuteReaderAsync();

				if (reader.HasRows)
				{
					List<MovieEntity> tempMovies = new List<MovieEntity>();
					while (await reader.ReadAsync())
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

		public async Task<MovieEntity> GetMovieByIdAsync(Guid id)
		{
			SqlConnection connection = new SqlConnection(connectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand($"SELECT * FROM Movie WHERE MovieID = '{id}';", connection);
				await connection.OpenAsync();
				SqlDataReader reader = await command.ExecuteReaderAsync();

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
			}
		}

		public async Task AddMovieAsync(MovieEntity movie)
		{
			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"INSERT INTO Movie (MovieName, ReleaseYear) VALUES ('{movie.Name}', '{movie.ReleaseYear}');";

			using (connection)
			{
				SqlCommand command = new SqlCommand(sqlCommand, connection);
				await connection.OpenAsync();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

				await command.ExecuteNonQueryAsync();
				connection.Close();
			}
		}

		public async Task UpdateMovieDataAsync(Guid id, MovieEntity movie)
		{
			if (await this.GetMovieByIdAsync(id) == null)
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
					await connection.OpenAsync();
					SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

					await command.ExecuteNonQueryAsync();
					connection.Close();
				}
			}
		}

		public async Task DeleteMovieAsync (Guid id)
		{
			if (await this.GetMovieByIdAsync(id) == null)
			{
				return;
			}

			SqlConnection connection = new SqlConnection(connectionString);
			string sqlCommand = $"DELETE FROM Movie WHERE MovieId = '{id}';";

			using (connection)
			{
				SqlCommand command = new SqlCommand(sqlCommand, connection);
				await connection.OpenAsync();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection);

				await command.ExecuteNonQueryAsync();
				connection.Close();
			}
		}
    }
}
