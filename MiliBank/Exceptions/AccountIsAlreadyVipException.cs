using System;

namespace MiliBank.Exceptions
{
    public class AccountIsAlreadyVipException : AccountException
    {
        public AccountIsAlreadyVipException()
        {
        }

        public AccountIsAlreadyVipException(string message) : base(message)
        {
        }

        public AccountIsAlreadyVipException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}