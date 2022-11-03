using ExoContacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoContacts.DAL.Repositories
{
    public class UserRepository
    {
        private string _connectionString = "server=DESKTOP-SUVSSH1;Database=ExoContact;integrated security=true";

        public int Add(User user)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO [User] (Email, Password)" +
                " OUTPUT inserted.Id" +
                " VALUES (@email, @password)";
            cmd.Parameters.AddWithValue("email", user.Email);
            cmd.Parameters.AddWithValue("password", user.HashPwd);
            connection.Open();
            int? id = (int?)cmd.ExecuteScalar();
            connection.Close();

            return id ?? -1;

        }

        public User? GetById(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM [User] WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", id);

            connection.Open();

            User? user = null;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new User()
                {
                    Id = (int)reader["Id"],
                    Email = (string)reader["Email"],
                    HashPwd = (string)reader["Password"]
                };
            }
            connection.Close();
            return user;
        }

        public User? GetByMail(string email)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM [User] WHERE Email = @email";
            cmd.Parameters.AddWithValue("email", email);

            connection.Open();

            User? user = null;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new User()
                {
                    Id = (int)reader["Id"],
                    Email = (string)reader["Email"],
                    HashPwd = (string)reader["Password"]

                };
            }
            connection.Close();
            return user;
        }


    }
}
