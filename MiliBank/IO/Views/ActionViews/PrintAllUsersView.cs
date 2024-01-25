using MiliBank.BussinessLogics;
using MiliBank.IO;
using MiliBank.Models;
using MiliBank.Views.Components;
using System.Collections.Generic;

namespace MiliBank.Views
{
    public class PrintAllUsersView : ActionView
    {
        protected override void PrintTitle()
        {
            PrintTitle(IOMessages.AllUsersTitle);
        }

        protected override void RunLogic()
        {
            var result = new UsersBusinessLogic().GetAllUsers();
            PrintAllUsers(result.Value);
        }

        private void PrintAllUsers(List<User> users)
        {
            users.ForEach(user => new UserDetailsComponent(user).Run());
            ColorOutput.Instance.PrintEmptyLine();
        }
    }
}