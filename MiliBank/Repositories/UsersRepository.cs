using MiliBank.Common;
using MiliBank.Exceptions;
using MiliBank.ModelMappers;
using MiliBank.Models;
using Npgsql;
using System.Collections.Generic;

namespace MiliBank.Repositories
{
    public class UsersRepository
    {
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                users = new UsersMapper().ToUsersList(GetAllUsersReader(connection));
                connection.Close();
            }

            return users;
        }

        public void InsertUser(User user)
        {
            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                ExecuteUserInsert(connection, user);
                connection.Close();
            }
        }

        public int DeleteUserById(string userId)
        {
            int rowsAffected;
            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                rowsAffected = ExecuteUserDelete(connection, userId);
                connection.Close();
            }

            return rowsAffected;
        }

        private NpgsqlDataReader GetAllUsersReader(NpgsqlConnection connection)
        {
            var query = UserQueries.GET_ALL;
            var command = new NpgsqlCommand(query, connection);

            return command.ExecuteReader();
        }

        private void ExecuteUserInsert(NpgsqlConnection connection, User user)
        {
            var query = UserQueries.INSERT;
            using (var command = new NpgsqlCommand(query, connection))
            {
                ExecuteInsertCommand(command, user.Id, user.Name);
            }
        }

        private void ExecuteInsertCommand(NpgsqlCommand command, string id, string name)
        {
            try
            {
                command.Parameters.AddWithValue(UserQueries.ID_PARAM,id);
                command.Parameters.AddWithValue(UserQueries.NAME_PARAM, name);
                command.ExecuteNonQuery();
            }
            catch (PostgresException)
            {
                throw new UserAlreadyExistsException($"User with id {id} already exists");
            }
        }

        private int ExecuteUserDelete(NpgsqlConnection connection, string userId)
        {
            var query = UserQueries.DELETE;
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(UserQueries.ID_PARAM, userId);

                return command.ExecuteNonQuery();
            }
        }
    }
}