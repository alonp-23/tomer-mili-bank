using MiliBank.Exceptions;
using MiliBank.Logs.Loggers;
using MiliBank.Repositories;
using MiliBank.Results;

namespace MiliBank.BussinessLogics
{
    public class AddUserToAccountBusinessLogic
    {
        public ResultObject RegisterUserToAccount(string userId, int accountNumber)
        {
            if (IsAccountOwnedByUser(userId, accountNumber))
            {
                return new ResultObject(ResultStatus.ALREADY_EXISTS_ERROR);
            }

            return AddUserToAccount(userId, accountNumber);
        }

        private bool IsAccountOwnedByUser(string userId, int accountNumber)
        {
            var account = new AccountRepository().GetAccountById(accountNumber);

            return !(account is null) && account.OwnerId.Equals(userId);
        }

        private ResultObject AddUserToAccount(string userId, int accountNumber)
        {
            try
            {
                new AddedUsersToAccountRepository().AddUserToAccount(userId, accountNumber);
                LogsWriter.Instance.WriteInfo($"Added user with id {userId} to account No. {accountNumber}");

                return new ResultObject(ResultStatus.CREATED);
            }
            catch (UserOrAccountDoNotExist exception)
            {
                LogsWriter.Instance.WriteWarn(exception.Message);

                return new ResultObject(ResultStatus.USER_NOT_EXISTS_ERROR);
            }
            catch (AddUserToOwnedAccountException exception)
            {
                LogsWriter.Instance.WriteWarn(exception.Message);

                return new ResultObject(ResultStatus.RULE_VIOLATION_ERROR);
            }
        }
    }
}