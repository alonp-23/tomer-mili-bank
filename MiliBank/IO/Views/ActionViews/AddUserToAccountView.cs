using MiliBank.BussinessLogics;
using MiliBank.Common;
using MiliBank.Exceptions;
using MiliBank.Results;
using MiliBank.Views;
using MiliBank.Views.Components;
using System;

namespace MiliBank.IO.Views.ActionViews
{
    public class AddUserToAccountView : ActionView
    {
        protected override void PrintTitle()
        {
            PrintTitle(IOMessages.AddUserToAccountTitle);
        }

        protected override void RunLogic()
        {
            var accountNumber = GetAccountNumber();
            var userId = GetUserId();

            if (GetUserConfirmation())
            {
                AddUserToAccount(userId, accountNumber);
            }
        }

        private int GetAccountNumber()
        {
            var accountNumberComponent = new AccountNumberComponent();
            accountNumberComponent.Run();

            return int.Parse(accountNumberComponent.Value);
        }

        private string GetUserId()
        {
            var userIdComponent = new UserIdComponent();
            userIdComponent.Run();

            return userIdComponent.Value;
        }

        private bool GetUserConfirmation()
        {
            var confirmationComponent = new ConfirmationComponent();
            confirmationComponent.Run();

            return confirmationComponent.Value.Equals(Constants.CONFIRM_CODE.ToString());
        }

        private void AddUserToAccount(string userId, int accountNumber)
        {
            var result = new AddUserToAccountBusinessLogic().RegisterUserToAccount(userId, accountNumber);

            if (result.Status.Equals(ResultStatus.CREATED))
            {
                new SuccessComponent(string.
                    Format(IOMessages.AddUserToAccountSuccess, userId, accountNumber)).Run();
            }
            else if (result.Status.Equals(ResultStatus.RULE_VIOLATION_ERROR))
            {
                new ErrorComponent(IOMessages.AccountOwnedByUser).Run();
            }
            else
            {
                new ErrorComponent(IOMessages.AccountOrUserDoNotExist).Run();
            }
        }
    }
}