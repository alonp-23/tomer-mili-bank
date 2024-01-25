using System;

namespace MiliBank.Exceptions
{
    public class OverdraftNotAllowedException : Exception
    {
        public OverdraftNotAllowedException()
        {
        }

        public OverdraftNotAllowedException(string message) : base(message)
        {
        }

        public OverdraftNotAllowedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}