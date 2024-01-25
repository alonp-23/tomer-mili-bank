using MiliBank.IO;
using MiliBank.Models;

namespace MiliBank.Views.Components
{
    public class AccountDetailsComponent : IComponent
    {
        private Account Account { get; }

        public AccountDetailsComponent(Account account)
        {
            Account = account;
        }

        public void Run()
        {
            ColorOutput.Instance.PrintWarn("------------------");
            ColorOutput.Instance.Print($"{IOMessages.AccountNumber} {Account.Number}");
            ColorOutput.Instance.Print($"{IOMessages.AccountOwnerId} {Account.OwnerId}");
            PrintIfVip();
            PrintBalance();
        }

        private void PrintIfVip() 
        {
            if (Account is VipAccount)
            {
                ColorOutput.Instance.PrintSuccess($"{IOMessages.AccountVip}");
            }
        }

        private void PrintBalance()
        {
            var balanceString = $"{IOMessages.AccountBalance} {Account.Balance}$";

            if (Account.Balance > 0)
            {
                ColorOutput.Instance.PrintSuccess(balanceString);
            }
            else
            {
                ColorOutput.Instance.PrintError(balanceString);
            }
        }
    }
}