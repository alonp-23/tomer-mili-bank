using MiliBank.BussinessLogics;
using MiliBank.Common;
using MiliBank.IO;
using MiliBank.Results;
using MiliBank.Views.Components;

namespace MiliBank.Views
{
    public class DeleteAccountView : ActionView
    {
        protected override void PrintTitle()
        {
            PrintTitle(IOMessages.DeleteAccountTitle);
        }

        protected override void RunLogic()
        {
            var accountId = GetAccountNumberFromUser();

            if (GetUserConfirmation())
            {
                DeleteAccount(accountId);
            }
        }

        private void DeleteAccount(int id)
        {
            var result = new AccountBusinessLogic().DeleteAccount(id);

            if (result.Status.Equals(ResultStatus.OK))
            {
                new SuccessComponent(IOMessages.AccountDeleteSuccess).Run();
            }
            else
            {
                new ErrorComponent(string.Format(IOMessages.AccountDeleteFail, id)).Run();
            }
        }

        private int GetAccountNumberFromUser()
        {
            var accountNumberComponent = new AccountNumberComponent();
            accountNumberComponent.Run();

            return int.Parse(accountNumberComponent.Value);
        }

        private bool GetUserConfirmation()
        {
            var confirmationComponent = new ConfirmationComponent();
            confirmationComponent.Run();

            return confirmationComponent.Value.Equals(Constants.CONFIRM_CODE.ToString());
        }
    }
}