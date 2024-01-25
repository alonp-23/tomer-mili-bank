using MiliBank.IO;

namespace MiliBank.Views.Components
{
    public abstract class ValidValueComponent : IComponent
    {
        public string Value { get; private set; }

        public void Run()
        {
            Value = GetValidValue();
        }

        private string GetValidValue()
        {
            PrintMessage();
            var input = ColorInput.Instance.GetInput();

            while (!IsValidValue(input))
            {
                PrintError();

                PrintMessage();
                input = ColorInput.Instance.GetInput();
            }

            return input;
        }

        protected abstract bool IsValidValue(string input);

        protected abstract void PrintMessage();

        protected void PrintLine(string message)
        {
            ColorOutput.Instance.Print(message);
        }

        protected abstract void PrintError();

        protected void PrintError(string message)
        {
            new ErrorComponent(message).Run();
        }
    }
}