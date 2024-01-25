using MiliBank.Common;
using MiliBank.IO;
using System.Text.RegularExpressions;

namespace MiliBank.Views.Components
{
    public class UserNameComponent : ValidValueComponent
    {
        protected override bool IsValidValue(string input)
        {
            return input.Length >= Constants.MIN_NAME_LENGTH
                && input.Length <= Constants.MAX_NAME_LENGTH
                && Regex.IsMatch(input, "^[a-zA-Z ]*$");
        }

        protected override void PrintError()
        {
            PrintError(string.Format(IOMessages.InvalidName,
                Constants.MIN_NAME_LENGTH, Constants.MAX_NAME_LENGTH));
        }

        protected override void PrintMessage()
        {
            PrintLine(IOMessages.InsertName);
        }
    }
}