using MiliBank.BussinessLogics;
using MiliBank.Exceptions;
using MiliBank.IO;
using MiliBank.Models;
using MiliBank.Results;
using MiliBank.Views.Components;

namespace MiliBank.Views
{
    public class CreateUserView : ActionView
    {
        protected override void PrintTitle()
        {
            PrintTitle(IOMessages.CreateUserTitle);
        }

        protected override void RunLogic()
        {
            InsertUser(GetUser());
        }

        public void InsertUser(User user)
        {
            var result = new UsersBusinessLogic().InsertUser(user);

            if (result.Status.Equals(ResultStatus.CREATED))
            {
                new SuccessComponent(IOMessages.UserCreationSuccess).Run();
            }
            else
            {
                new ErrorComponent(IOMessages.UserAlreadyExists).Run();
            }
        }

        private User GetUser()
        {
            var userIdComponent = new UserIdComponent();
            userIdComponent.Run();

            var nameComponent = new UserNameComponent();
            nameComponent.Run();

            return new User(userIdComponent.Value, nameComponent.Value);
        }
    }
}