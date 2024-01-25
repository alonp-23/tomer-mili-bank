namespace MiliBank.Models
{
    public class SimpleAccount : Account
    {
        public SimpleAccount(string ownerId) : base(ownerId)
        {
        }

        public SimpleAccount(string ownerId, int id, double balance) : base(ownerId, id, balance)
        {
        }
    }
}