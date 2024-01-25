using MiliBank.BussinessLogics;
using MiliBank.Common;
using MiliBank.IO;
using MiliBank.Models;
using MiliBank.Results;
using MiliBank.Views.Components;

namespace MiliBank.Views
{
    public class CreateAccountView : ActionView
    {
        protected override void PrintTitle()
        {
            PrintTitle(IOMessages.CreateAccountTitle);
        }

        protected override void RunLogic()
        {
            InsertAccount();
        }

        private void InsertAccount()
        {
            var result = new AccountBusinessLogic()
                .CreateAccount(GetAccountFromUser());

            PrintInsertResult(result);
        }

        private Account GetAccountFromUser()
        {
            var userIdComponent = new UserIdComponent();
            userIdComponent.Run();

            var vipStatusComponent = new VipStatusComponent();
            vipStatusComponent.Run();

            return CreateAccount(userIdComponent.Value, vipStatusComponent.Value);
        }

        private Account CreateAccount(string ownerId, string vipStatus)
        {
            if (vipStatus.Equals(Constants.CONFIRM_CODE.ToString()))
            {
                return new VipAccount(ownerId);
            }

            return new SimpleAccount(ownerId);
        }

        private void PrintInsertResult(ResultObject result)
        {
            if (result.Status.Equals(ResultStatus.CREATED))
            {
                new SuccessComponent(string.Format(IOMessages.AccountAddSuccess,
                    ((ValueResultObject<Account>)result).Value.Number)).Run();
            }
            else
            {
                new ErrorComponent(IOMessages.UserDoesNotExist);
            }
        }
    }
}