using ColorWriter;
using TomerColorWriter;

namespace MiliBank.IO
{
    public sealed class ColorInput
    {
        private readonly ColorsReader ColorsReader;
        private static ColorInput instance;
        public static ColorInput Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new ColorInput();
                }

                return instance;
            }
        }

        private ColorInput()
        {
            ColorsReader = new ColorsReader(Color.Magenta);
        }

        public string GetInput()
        {
            return ColorsReader.GetInput();
        }

        public void WaitForKeyPress() 
        {
            ColorsReader.GetKey();
        }
    }
}