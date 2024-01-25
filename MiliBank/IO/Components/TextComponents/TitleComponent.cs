using MiliBank.IO;

namespace MiliBank.Views.Components
{
    public class TitleComponent : IComponent
    {
        private string Title { get; }

        public TitleComponent(string title)
        {
            Title = title;
        }

        public void Run()
        {
            ColorOutput.Instance.Clear();
            ColorOutput.Instance.PrintTitle(Title);
            ColorOutput.Instance.PrintEmptyLine();
        }
    }
}