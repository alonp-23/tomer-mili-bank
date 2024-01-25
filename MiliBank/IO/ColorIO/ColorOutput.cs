using TomerColorWriter;

namespace MiliBank.IO
{
    public sealed class ColorOutput
    {
        private readonly ColorsWriter ColorsWriter;
        private static ColorOutput instance;
        public static ColorOutput Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new ColorOutput();
                }

                return instance;
            }
        }
        
        private ColorOutput()
        {
            ColorsWriter = new ColorsWriter(Color.White);
        }

        public void Clear()
        {
            ColorsWriter.Clear();
        }

        public void PrintTitle(string title)
        {
            ColorsWriter.PrintLine(title, Color.Blue);
        }

        public void Print(string text)
        {
            ColorsWriter.PrintLine(text);
        }

        public void PrintEmptyLine()
        {
            ColorsWriter.PrintLine();
        }

        public void PrintError(string ErrorMessage)
        {
            ColorsWriter.PrintLine(ErrorMessage, Color.Red);
        }

        public void PrintSuccess(string successMessage)
        {
            ColorsWriter.PrintLine(successMessage, Color.Green);
        }

        public void PrintWarn(string text)
        {
            ColorsWriter.PrintLine(text, Color.Yellow);
        }
    }
}