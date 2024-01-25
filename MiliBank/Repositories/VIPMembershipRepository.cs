using MiliBank.Common;
using MiliBank.Exceptions;
using MiliBank.Queries;
using Npgsql;

namespace MiliBank.Repositories
{
    public class VIPMembershipRepository
    {
        public void CreateVIPMembership(int accountId)
        {
            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                RunInsertQuery(connection, accountId);
                connection.Close();
            }
        }

        private void RunInsertQuery(NpgsqlConnection connection, int accountNumber)
        {
            var query = VIPQueries.INSERT;
            using (var command = new NpgsqlCommand(query, connection))
            {
                ExecuteInsertCommand(command, accountNumber);
            }
        }

        private void ExecuteInsertCommand(NpgsqlCommand command, int accountNumber)
        {
            try
            {
                command.Parameters.AddWithValue(VIPQueries.ACCOUNT_NUMBER_PARAM, accountNumber);
                command.ExecuteNonQuery();
            }
            catch (PostgresException exception)
            {
                if (exception.SqlState.Equals(SqlStates.ForeignKeyViolation))
                {
                    throw new AccountDoesNotExistException($"Account with id: {accountNumber} does not exist. Hence, can not be registered as VIP account");
                }
                else if (exception.SqlState.Equals(SqlStates.UniqueViolation))
                {
                    throw new AccountIsAlreadyVipException($"Account No. {accountNumber} is already regitered as a VIP");
                }
            }
        }
    }
}