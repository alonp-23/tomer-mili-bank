using MiliBank.Models;
using Npgsql;
using System.Collections.Generic;

namespace MiliBank.ModelMappers
{
    public class UsersMapper
    {
        public List<User> ToUsersList(NpgsqlDataReader reader)
        {
            var users = new List<User>();

            while (reader.Read())
            {
                users.Add(ToUser(reader));
            }

            return users;
        }

        public User ToUser(NpgsqlDataReader reader)
        {
            return new User(reader["id"].ToString(), reader["name"].ToString());
        }
    }
}