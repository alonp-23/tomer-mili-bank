using MiliBank.Common;
using MiliBank.Exceptions;
using MiliBank.ModelMappers;
using MiliBank.Models;
using MiliBank.Queries;
using Npgsql;
using System.Collections.Generic;

namespace MiliBank.Repositories
{
    public class AccountRepository
    {
        public int InsertAccount(Account account)
        {
            int accoundNumber;

            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                accoundNumber = RunInsertQuery(connection, account);
                connection.Close();
            }

            return accoundNumber;
        }

        public List<Account> GetAllAccountsByUserId(string userId)
        {
            var accounts = new List<Account>();

            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                accounts = new AccountsMapper()
                    .ToAccounts(GetAllRelatedAccountsReader(connection, userId));
                connection.Close();
            }

            return accounts;
        }

        public Account GetAccountById(int accountId)
        {
            Account account = null;

            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                account = GetAccount(connection, accountId);
                connection.Close();
            }

            return account;
        }

        public int DeleteAcount(int accountId)
        {
            int rowsAffected;

            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                rowsAffected = ExecuteDeleteCommand(connection, accountId);
                connection.Close();
            }

            return rowsAffected;
        }

        public int Deposit(int accountId, double amount)
        {
            int rowsAffected;

            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                rowsAffected = ExecuteDepositCommand(connection, accountId, amount);
                connection.Close();
            }

            return rowsAffected;
        }

        public int Withdraw(int accountId, double amount)
        {
            int rowsAffected;
            using (var connection = new NpgsqlConnection(Constants.CONNECTION_STRING))
            {
                connection.Open();
                rowsAffected = ExecuteWithdrawCommand(connection, accountId, amount);
                connection.Close();
            }

            return rowsAffected;
        }

        private int RunInsertQuery(NpgsqlConnection connection, Account account)
        {
            var query = AccountQueries.INSERT;
            using (var command = new NpgsqlCommand(query, connection))
            {
                return ExecuteInsertCommand(command, account.OwnerId);
            }
        }

        private int ExecuteInsertCommand(NpgsqlCommand command, string ownerId)
        {
            try
            {
                command.Parameters.AddWithValue(AccountQueries.OWNER_ID_PARAM, ownerId);

                return (int)command.ExecuteScalar();
            }
            catch (PostgresException)
            {
                throw new UserDoesNotExistException($"Could not create an account for a non-existing user (id = {ownerId})");
            }
        }

        private NpgsqlDataReader GetAllRelatedAccountsReader(NpgsqlConnection connection, string userId)
        {
            var query = AccountQueries.GET_ALL_RELATED;
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(AccountQueries.OWNER_ID_PARAM, userId);

                return command.ExecuteReader();
            }
        }
    
        private Account GetAccount(NpgsqlConnection connection, int accountNumber)
        {
            var reader = GetAccountReader(connection, accountNumber);

            if (reader.Read())
            {
                return new AccountsMapper().ToAccount(reader);
            }

            return null;
        }

        private NpgsqlDataReader GetAccountReader(NpgsqlConnection connection, int accountId)
        {
            var query = AccountQueries.GET_BY_NUMBER;
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(AccountQueries.ACCOUNT_NUMBER_PARAM, accountId);

                return command.ExecuteReader();
            }
        }

        private int ExecuteDeleteCommand(NpgsqlConnection connection, int accountId)
        {
            var query = AccountQueries.DELETE;
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(AccountQueries.ACCOUNT_NUMBER_PARAM, accountId);

                return command.ExecuteNonQuery();
            }
        }

        private int ExecuteDepositCommand(NpgsqlConnection connection, int accountId, double amount)
        {
            var query = AccountQueries.DEPOSIT_AMOUNT_BY_ID;
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(AccountQueries.ACCOUNT_NUMBER_PARAM, accountId);
                command.Parameters.AddWithValue(AccountQueries.AMOUNT_PARAM, amount);

                return command.ExecuteNonQuery();
            }
        }

        private int ExecuteWithdrawCommand(NpgsqlConnection connection, int accountId, double amount)
        {
            var query = AccountQueries.WITHDRAW_AMOUNT_BY_ID;
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(AccountQueries.ACCOUNT_NUMBER_PARAM, accountId);
                command.Parameters.AddWithValue(AccountQueries.AMOUNT_PARAM, amount);

                return command.ExecuteNonQuery();
            }
        }
    }
}