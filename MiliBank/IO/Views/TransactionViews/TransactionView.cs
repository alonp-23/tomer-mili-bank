using MiliBank.IO;
using MiliBank.Views.Components;

namespace MiliBank.Views
{
    public abstract class TransactionView : ActionView
    {
        protected override void RunLogic()
        {
            var accountNumber = GetAccountNumber();
            var amount = GetAmount();

            MakeTransaction(accountNumber, amount);
        }

        private int GetAccountNumber()
        {
            var accountNumberComponent = new AccountNumberComponent();
            accountNumberComponent.Run();

            return int.Parse(accountNumberComponent.Value);
        }

        private double GetAmount()
        {
            var amountComponent = new AmountComponent();
            amountComponent.Run();

            return double.Parse(amountComponent.Value);
        }

        protected abstract void MakeTransaction(int accountNumber, double amount);
    }
}