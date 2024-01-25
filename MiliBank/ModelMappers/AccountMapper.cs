using MiliBank.Models;
using Npgsql;
using System.Collections.Generic;

namespace MiliBank.ModelMappers
{
    public class AccountsMapper
    {
        public List<Account> ToAccounts(NpgsqlDataReader reader)
        {
            var accounts = new List<Account>();

            while (reader.Read())
            {
                accounts.Add(ToAccount(reader));
            }

            return accounts;
        }

        public Account ToAccount(NpgsqlDataReader reader)
        {
            if (IsVipAccount(reader))
            {
                return new VipAccount(reader["owner_id"].ToString(),
                    int.Parse(reader["number"].ToString()),
                    double.Parse(reader["balance"].ToString()));
            }
            else
            {
                return new SimpleAccount(reader["owner_id"].ToString(),
                    int.Parse(reader["number"].ToString()),
                    double.Parse(reader["balance"].ToString()));
            }
        }

        private bool IsVipAccount(NpgsqlDataReader reader)
        {
            return bool.Parse(reader["is_vip"].ToString());
        }
    }
}