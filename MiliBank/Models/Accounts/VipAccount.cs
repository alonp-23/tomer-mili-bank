namespace MiliBank.Models
{
    public class VipAccount : Account
    {
        public VipAccount(string ownerId) : base(ownerId)
        {
        }

        public VipAccount(string ownerId, int id, double balance) : base(ownerId, id, balance)
        {
        }
    }
}