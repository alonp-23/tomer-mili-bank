using MiliBank.Common;
using MiliBank.IO;

namespace MiliBank.Views.Components
{
    public class VipStatusComponent : ConfirmationComponent
    {
        protected override void PrintMessage()
        {
            PrintLine($"{IOMessages.InsertVipFlag} " +
                $"({Constants.CONFIRM_CODE}/{Constants.DECLINE_CODE})");
        }
    }
}