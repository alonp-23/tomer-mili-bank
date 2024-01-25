namespace MiliBank.Queries
{
    public class AccountQueries
    {
        public static readonly string OWNER_ID_PARAM = "@owner_id";
        public static readonly string ACCOUNT_NUMBER_PARAM = "@account_number";
        public static readonly string AMOUNT_PARAM = $"@amount";

        public static readonly string DELETE = $"DELETE FROM milibank.accounts WHERE number = {ACCOUNT_NUMBER_PARAM};";
        public static readonly string INSERT = $"INSERT INTO milibank.accounts (owner_id) VALUES ({OWNER_ID_PARAM}) RETURNING number;";
        public static readonly string DEPOSIT_AMOUNT_BY_ID = $"UPDATE milibank.accounts SET balance = balance + {AMOUNT_PARAM} WHERE number = {ACCOUNT_NUMBER_PARAM};";
        public static readonly string WITHDRAW_AMOUNT_BY_ID = $"UPDATE milibank.accounts SET balance = balance - {AMOUNT_PARAM} WHERE number = {ACCOUNT_NUMBER_PARAM};";

        public static readonly string GET_BY_NUMBER = $@"SELECT accounts.number, accounts.owner_id, accounts.balance, vip.account_number is not null AS is_vip 
            FROM milibank.accounts AS accounts 
            LEFT JOIN milibank.vip_membership AS vip 
            ON vip.account_number = accounts.number 
            WHERE accounts.number = {ACCOUNT_NUMBER_PARAM}";
        
        public static readonly string GET_ALL_RELATED = $@"SELECT accounts.number, accounts.owner_id, accounts.balance, vip.account_number is not null AS is_vip
            FROM milibank.accounts AS accounts
            LEFT JOIN milibank.added_users_to_accounts AS added_users
            ON added_users.account_number = accounts.number
            LEFT JOIN milibank.users AS users
            ON added_users.user_id = users.id
            LEFT JOIN milibank.vip_membership AS vip
            ON vip.account_number = accounts.number
            WHERE users.id = {OWNER_ID_PARAM} OR accounts.owner_id = {OWNER_ID_PARAM};";
    }
}