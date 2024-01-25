using MiliBank.IO.Views.ActionViews;
using System.Collections.Generic;

namespace MiliBank.Views
{
    public class ViewsFactory
    {
        private readonly Dictionary<MenuOption, IView> Views
            = new Dictionary<MenuOption, IView>()
            {
                { MenuOption.CreateUser, new CreateUserView() },
                { MenuOption.CreateAccount, new CreateAccountView() },
                { MenuOption.DeleteUser, new DeleteUserView() },
                { MenuOption.DeleteAccount, new DeleteAccountView() },
                { MenuOption.Deposit, new DepositView() },
                { MenuOption.Withdraw, new WithdrawView() },
                { MenuOption.PrintAllUsers, new PrintAllUsersView() },
                { MenuOption.AddUserToAccount, new AddUserToAccountView() },
                { MenuOption.PrintAccountsByUser, new PrintAllRelatedAccountsView() },
            };

        public IView GenerateView(MenuOption menuOption)
        {
            return Views[menuOption];
        }
    }
}