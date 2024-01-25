using MiliBank.BussinessLogics;
using MiliBank.IO;
using MiliBank.Models;
using MiliBank.Views.Components;
using System.Collections.Generic;

namespace MiliBank.Views
{
    public class PrintAllRelatedAccountsView : ActionView
    {
        protected override void PrintTitle()
        {
            PrintTitle(IOMessages.AllAccountsByUserTitle);
        }

        protected override void RunLogic()
        {
            var userId = GetUserId();
            var result = new AccountBusinessLogic().GetAllRelatedAccounts(userId);
            PrintAllAccounts(result.Value);
        }

        private string GetUserId()
        {
            var userIdComponent = new UserIdComponent();
            userIdComponent.Run();

            return userIdComponent.Value;
        }

        private void PrintAllAccounts(List<Account> accounts)
        {
            accounts.ForEach(account => new AccountDetailsComponent(account).Run());
            ColorOutput.Instance.PrintEmptyLine();
        }
    }
}