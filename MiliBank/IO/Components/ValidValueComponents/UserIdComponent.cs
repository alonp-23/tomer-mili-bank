using MiliBank.Common;
using MiliBank.IO;
using System.Linq;

namespace MiliBank.Views.Components
{
    public class UserIdComponent : ValidValueComponent
    {
        protected override bool IsValidValue(string input)
        {
            return input.Length == Constants.PERSON_ID_LENGTH
                && input.All(char.IsDigit);
        }

        protected override void PrintMessage()
        {
            PrintLine(IOMessages.InsertId);
        }

        protected override void PrintError()
        {
            PrintError(string.Format(IOMessages.InvalidId, Constants.PERSON_ID_LENGTH));
        }
    }
}