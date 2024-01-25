using MiliBank.BussinessLogics;
using MiliBank.Exceptions;
using MiliBank.IO;
using MiliBank.Results;
using MiliBank.Views.Components;

namespace MiliBank.Views
{
    public class DepositView : TransactionView
    {
        protected override void PrintTitle()
        {
            PrintTitle(IOMessages.DepositTitle);
        }

        protected override void MakeTransaction(int accountNumber, double amount)
        {
            var result = new AccountBusinessLogic().Deposit(accountNumber,amount);

            if (result.Status.Equals(ResultStatus.OK))
            {
                new SuccessComponent(string.Format(IOMessages.DepositSuccess, amount, accountNumber)).Run();
            }
            else
            {
                new ErrorComponent(string.Format(IOMessages.AccountDoesNotExist, accountNumber)).Run();
            }
        }
    }
}