namespace MiliBank
{
    public class UserQueries
    {        
        public static readonly string ID_PARAM = "@id";
        public static readonly string NAME_PARAM = "@name";

        public static readonly string GET_ALL = "SELECT id, name FROM milibank.users;";
        public static readonly string INSERT = $"INSERT INTO milibank.users (id, name) VALUES ({ID_PARAM}, {NAME_PARAM});";
        public static readonly string DELETE = $"DELETE FROM milibank.users WHERE id = {ID_PARAM};";
    }
}