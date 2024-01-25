namespace MiliBank.Queries
{
    public class VIPQueries
    {
        public static readonly string ACCOUNT_NUMBER_PARAM = "@account_number";
        public static readonly string INSERT = $"INSERT INTO milibank.vip_membership (account_number) VALUES ({ACCOUNT_NUMBER_PARAM});";
    }
}