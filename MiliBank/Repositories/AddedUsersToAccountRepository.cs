using MiliBank.Common;
using MiliBank.Exceptions;
using MiliBank.SqlQueries;
using Npgsql;

namespace MiliBank.Repositories
{
    public class AddedUsersToAccountRepository
    {
        public void AddUserToAccount(string userId, int accountNumber)
        {
            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                RunInsertQuery(connection, userId, accountNumber);
                connection.Close();
            }
        }

        private void RunInsertQuery(NpgsqlConnection connection, string userId, int accountNumber)
        {
            var query = AddedUsersQueries.INSERT;
            using (var command = new NpgsqlCommand(query, connection))
            {
                ExecuteInsertCommand(command, userId, accountNumber);
            }
        }

        private void ExecuteInsertCommand(NpgsqlCommand command, string userId, int accountNumber)
        {
            try
            {
                command.Parameters.AddWithValue(AddedUsersQueries.ACCOUNT_NUMBER_PARAM, accountNumber);
                command.Parameters.AddWithValue(AddedUsersQueries.OWNER_ID_PARAM, userId);
                command.ExecuteNonQuery();
            }
            catch (PostgresException exception)
            {
                if (exception.SqlState.Equals(SqlStates.ForeignKeyViolation))
                {
                    throw new UserOrAccountDoNotExist($"given account or user are not recognized");
                }
                else if (exception.SqlState.Equals(SqlStates.UniqueViolation))
                {
                    throw new AddUserToOwnedAccountException($"User with ID {userId} is already linked to account No. {accountNumber}");
                }
            }
        }
    }
}