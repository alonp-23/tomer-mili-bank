using System;

namespace MiliBank.Exceptions
{
    public abstract class AccountException : Exception
    {
        public AccountException()
        {
        }

        public AccountException(string message) : base(message)
        {
        }

        public AccountException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}