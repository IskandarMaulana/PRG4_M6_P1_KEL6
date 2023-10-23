
using System.Data.SqlClient;

namespace PRG4_M6_P1_KEL6.Models
{
    public class Users
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public Users(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }
        public User getDataByUsername_Password(string username, string password)
        {
            User user = new User();
            try
            {
                string query = "SELECT * FROM data_petugas WHERE username = @p1 AND password = @p2";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", username);
                command.Parameters.AddWithValue("@p2", password);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["id"].ToString());
                    user.Username = reader["username"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Alamat = reader["alamat"].ToString();
                    user.NoTelp = reader["no_telp"].ToString();
                    user.Status = Convert.ToInt32(reader["status"].ToString());
                    reader.Close();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    }
}
