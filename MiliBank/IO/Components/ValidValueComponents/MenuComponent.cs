using MiliBank.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiliBank.Views.Components.ValidValueComponents
{
    public class MenuComponent : ValidValueComponent
    {
        private Dictionary<MenuOption, string> Menu { get; }

        public MenuComponent()
        {
            Menu = new Dictionary<MenuOption, string>()
            {
                { MenuOption.CreateUser, IOMessages.MenuCreateUser },
                { MenuOption.CreateAccount, IOMessages.MenuCreateAccount },
                { MenuOption.DeleteUser, IOMessages.MenuDeleteUser },
                { MenuOption.DeleteAccount, IOMessages.MenuDeleteAccount },
                { MenuOption.Deposit, IOMessages.MenuDeposit },
                { MenuOption.Withdraw, IOMessages.MenuWithdraw },
                { MenuOption.PrintAllUsers, IOMessages.MenuPrintAllUsers },
                { MenuOption.PrintAccountsByUser, IOMessages.MenuPrintAllRelatedAccounts },
                { MenuOption.AddUserToAccount, IOMessages.MenuAddUserToAccount },
                { MenuOption.Exit, IOMessages.MenuExit }
            };
        }

        protected override bool IsValidValue(string input)
        {
            return int.TryParse(input, out var result) 
                && Enum.IsDefined(typeof(MenuOption), result);
        }

        protected override void PrintError()
        {
            new ErrorComponent(IOMessages.InvalidMenuOption).Run();
        }

        protected override void PrintMessage()
        {
            ColorOutput.Instance.Print(GetMenu());
        }

        private string GetMenu()
        {
            var lines = Menu
                .Select(pair => $"[{(int)pair.Key}] {pair.Value}");

            return string.Join(Environment.NewLine, lines);
        }
    }
}