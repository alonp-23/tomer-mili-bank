namespace MiliBank.Models
{
    public abstract class Account
    {
        public int Number { get; set; }
        public string OwnerId { get; set; }
        public double Balance { get; private set; }

        protected Account(string ownerId)
        {
            OwnerId = ownerId;
            Balance = 0;
        }

        protected Account(string ownerId, int number, double balance)
        {
            OwnerId = ownerId;
            Number = number;
            Balance = balance;
        }
    }
}