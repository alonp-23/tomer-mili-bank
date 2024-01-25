using System;

namespace MiliBank.Exceptions
{
    public class AccountDoesNotExistException : AccountException
    {
        public AccountDoesNotExistException()
        {
        }

        public AccountDoesNotExistException(string message) : base(message)
        {
        }

        public AccountDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}