namespace MiliBank.SqlQueries
{
    public class AddedUsersQueries
    {
        public static readonly string OWNER_ID_PARAM = "@owner_id";
        public static readonly string ACCOUNT_NUMBER_PARAM = "@account_number";
        public static readonly string INSERT = $"INSERT INTO milibank.added_users_to_accounts (account_number, user_id) VALUES ({ACCOUNT_NUMBER_PARAM}, {OWNER_ID_PARAM});";
    }
}