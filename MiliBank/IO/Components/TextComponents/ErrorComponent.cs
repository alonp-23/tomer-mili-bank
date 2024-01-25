using MiliBank.IO;

namespace MiliBank.Views.Components
{
    internal class ErrorComponent : IComponent
    {
        private string Message { get; }

        public ErrorComponent(string message)
        {
            Message = message;
        }

        public void Run()
        {
            ColorOutput.Instance.PrintEmptyLine();
            ColorOutput.Instance.PrintError(Message);
            ColorOutput.Instance.PrintEmptyLine();
        }
    }
}