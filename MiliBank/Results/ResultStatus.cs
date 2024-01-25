namespace MiliBank.Results
{
    public enum ResultStatus
    {
        OK,
        CREATED,
        USER_NOT_EXISTS_ERROR,
        ACCOUNT_NOT_EXISTS_ERROR,
        ALREADY_EXISTS_ERROR,
        RULE_VIOLATION_ERROR
    }
}