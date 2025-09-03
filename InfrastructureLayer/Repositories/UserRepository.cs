using System.Data;
using System.Data.SqlClient;
using CoreLayer.Entities;
using CoreLayer.Interfaces;
using Microsoft.Data.SqlClient;

namespace InfrastructureLayer.Repositories
{
    public class UserRepository : IUser
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Users ValidateUser(string userName, string userPassword)
        {
            Users user = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ValidateUser", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@userPassword", userPassword);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new Users
                        {
                            Id = (int)reader["Id"],
                            userName = reader["userName"].ToString(),
                            userPassword = reader["userPassword"].ToString(),
                            userDescription = reader["userDescription"].ToString()
                        };
                    }
                }
            }

            return user;
        }
    }
}
