using MiliBank.IO;

namespace MiliBank.Views.Components
{
    public class SuccessComponent : IComponent
    {
        private string Message { get; }

        public SuccessComponent(string message)
        {
            Message = message;
        }

        public void Run()
        {
            ColorOutput.Instance.PrintEmptyLine();
            ColorOutput.Instance.PrintSuccess(Message);
            ColorOutput.Instance.PrintEmptyLine();
        }
    }
}