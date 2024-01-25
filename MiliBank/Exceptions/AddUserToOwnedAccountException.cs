using System;

namespace MiliBank.Exceptions
{
    public class AddUserToOwnedAccountException : Exception
    {
        public AddUserToOwnedAccountException()
        {
        }

        public AddUserToOwnedAccountException(string message) : base(message)
        {
        }

        public AddUserToOwnedAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}