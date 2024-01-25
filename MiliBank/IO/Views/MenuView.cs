using MiliBank.IO;
using MiliBank.Views.Components;
using MiliBank.Views.Components.ValidValueComponents;

namespace MiliBank.Views
{
    public class MenuView : IView
    {
        private ViewsFactory ViewsFactory { get; }
        private TitleComponent TitleComponent { get; }
        private MenuComponent MenuComponent { get; }

        public MenuView()
        {
            ViewsFactory = new ViewsFactory();
            TitleComponent = new TitleComponent(IOMessages.MenuTitle);
            MenuComponent = new MenuComponent();
        }

        public void Run()
        {
            var userChoice = GetUserChoice();

            while (!userChoice.Equals(MenuOption.Exit))
            {
                InvokeUserAction(userChoice);

                userChoice = GetUserChoice();
            }
        }

        private MenuOption GetUserChoice()
        {
            TitleComponent.Run();
            MenuComponent.Run();

            return ToMenuOption(MenuComponent.Value);
        }

        private MenuOption ToMenuOption(string input)
        {
            return (MenuOption)int.Parse(input);
        }

        private void InvokeUserAction(MenuOption option)
        {
            ViewsFactory.GenerateView(option).Run();
        }
    }
}