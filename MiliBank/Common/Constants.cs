using System;

namespace MiliBank.Common
{
    public class Constants
    {
        public const int MAX_NAME_LENGTH = 20;
        public const int MIN_NAME_LENGTH = 3;
        public const int PERSON_ID_LENGTH = 9;
        public const char CONFIRM_CODE = 'y';
        public const char DECLINE_CODE = 'n';
        public const int MAX_ACTION_AMOUNT = 10000;
        public static readonly string CONNECTION_STRING = Environment.GetEnvironmentVariable("MilibankConnectionString");
    }
}