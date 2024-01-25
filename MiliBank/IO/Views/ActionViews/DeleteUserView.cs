using MiliBank.BussinessLogics;
using MiliBank.Common;
using MiliBank.IO;
using MiliBank.Results;
using MiliBank.Views.Components;

namespace MiliBank.Views
{
    public class DeleteUserView : ActionView
    {
        protected override void PrintTitle()
        {
            PrintTitle(IOMessages.DeleteUserTitle);
        }

        protected override void RunLogic()
        {
            var userId = GetUserId();

            if (GetUserConfirmation())
            {
                DeleteUser(userId);
            }
        }

        private void DeleteUser(string id)
        {
            var result = new UsersBusinessLogic().DeleteUser(id);

            if (result.Status.Equals(ResultStatus.OK))
            {
                new SuccessComponent(IOMessages.DeleteUserSuccess).Run();
            }
            else
            {
                new ErrorComponent($"{IOMessages.DeleteUserFail} {id}").Run();
            }
        }

        private string GetUserId()
        {
            var userIdComponent = new UserIdComponent();
            userIdComponent.Run();

            return userIdComponent.Value;
        }

        private bool GetUserConfirmation()
        {
            var confirmationComponent = new ConfirmationComponent();
            confirmationComponent.Run();

            return confirmationComponent.Value.Equals(Constants.CONFIRM_CODE.ToString());
        }
    }
}