using MiliBank.IO;

namespace MiliBank.Views.Components
{
    public class AccountNumberComponent : ValidValueComponent
    {
        protected override bool IsValidValue(string input)
        {
            return int.TryParse(input, out var result) && result > 0;
        }

        protected override void PrintError()
        {
            PrintError(IOMessages.InvalidAccountNumber);
        }

        protected override void PrintMessage()
        {
            PrintLine(IOMessages.EnterAccountNumber);
        }
    }
}