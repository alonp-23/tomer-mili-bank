using MiliBank.IO;

namespace MiliBank.Views.Components
{
    public class PressAnyKeyComponent : IComponent
    {
        public void Run()
        {
            ColorOutput.Instance.PrintTitle(IOMessages.PressAnyKeyToContinue);
            ColorInput.Instance.WaitForKeyPress();
        }
    }
}