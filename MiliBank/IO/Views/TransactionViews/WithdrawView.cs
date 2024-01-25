using MiliBank.BussinessLogics;
using MiliBank.Exceptions;
using MiliBank.IO;
using MiliBank.Results;
using MiliBank.Views.Components;

namespace MiliBank.Views
{
    public class WithdrawView : TransactionView
    {
        protected override void PrintTitle()
        {
            PrintTitle(IOMessages.WithdrawTitle);
        }

        protected override void MakeTransaction(int accountNumber, double amount)
        {
            var result = new AccountBusinessLogic().Withdraw(accountNumber, amount);

            if (result.Status.Equals(ResultStatus.RULE_VIOLATION_ERROR))
            {
                new ErrorComponent(IOMessages.OverdraftNotAllowed).Run();
            }
            else if (result.Status.Equals(ResultStatus.ACCOUNT_NOT_EXISTS_ERROR))
            {
                new ErrorComponent(string.Format(IOMessages.AccountDoesNotExist, accountNumber)).Run();
            }
            else
            {
                new SuccessComponent(IOMessages.WithdrawSuccess).Run();
            }
        }
    }
}