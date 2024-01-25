using MiliBank.Common;
using MiliBank.IO;

namespace MiliBank.Views.Components
{
    public class ConfirmationComponent : ValidValueComponent
    {
        protected override bool IsValidValue(string input)
        {
            return input.Equals(Constants.CONFIRM_CODE.ToString())
                || input.Equals(Constants.DECLINE_CODE.ToString());
        }

        protected override void PrintError()
        {
            PrintError(IOMessages.InvalidConfirmationInput);
        }

        protected override void PrintMessage()
        {
            PrintLine($"{IOMessages.GetConfirmation} " +
                $"({Constants.CONFIRM_CODE}/{Constants.DECLINE_CODE})");
        }
    }
}