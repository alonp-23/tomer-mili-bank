using MiliBank.IO;
using MiliBank.Models;

namespace MiliBank.Views.Components
{
    public class UserDetailsComponent : IComponent
    {
        private User User { get; }

        public UserDetailsComponent(User user)
        {
            User = user;
        }

        public void Run()
        {
            ColorOutput.Instance.PrintWarn("------------------");
            ColorOutput.Instance.Print($"{IOMessages.UserId}: {User.Id}");
            ColorOutput.Instance.Print($"{IOMessages.UserName}: {User.Name}");
        }
    }
}