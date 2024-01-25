using MiliBank.Common;
using MiliBank.IO;

namespace MiliBank.Views.Components
{
    public class AmountComponent : ValidValueComponent
    {
        protected override bool IsValidValue(string input)
        {
            return double.TryParse(input, out var result) 
                && result > 0 && result < Constants.MAX_ACTION_AMOUNT;
        }

        protected override void PrintError()
        {
            PrintError($"{IOMessages.InvalidAmount} {Constants.MAX_ACTION_AMOUNT}$");
        }

        protected override void PrintMessage()
        {
            PrintLine(IOMessages.InsertAmount);
        }
    }
}