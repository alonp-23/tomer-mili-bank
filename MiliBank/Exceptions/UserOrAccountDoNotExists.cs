using System;

namespace MiliBank.Exceptions
{
    public class UserOrAccountDoNotExist : Exception
    {
        public UserOrAccountDoNotExist()
        {
        }

        public UserOrAccountDoNotExist(string message) : base(message)
        {
        }

        public UserOrAccountDoNotExist(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}