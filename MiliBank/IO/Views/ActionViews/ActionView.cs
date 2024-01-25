using MiliBank.Views.Components;

namespace MiliBank.Views
{
    public abstract class ActionView : IView
    {
        public void Run()
        {
            PrintTitle();
            RunLogic();
            PressKeyToContinue();
        }

        protected abstract void PrintTitle();

        protected void PrintTitle(string title)
        {
            new TitleComponent(title).Run();
        }

        protected abstract void RunLogic();

        private void PressKeyToContinue()
        {
            new PressAnyKeyComponent().Run();
        }
    }
}