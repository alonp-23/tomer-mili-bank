using MiliBank.Exceptions;
using MiliBank.Logs.Loggers;
using MiliBank.Models;
using MiliBank.Repositories;
using MiliBank.Results;
using System.Collections.Generic;

namespace MiliBank.BussinessLogics
{
    public class AccountBusinessLogic
    {
        private readonly AccountRepository AccountsRepository = new AccountRepository();

        public ResultObject CreateAccount(Account account)
        {
            try
            {
                account.Number = InsertAccount(account);
                LogsWriter.Instance.WriteInfo($"Created new account (No. {account.Number})");

                return new ValueResultObject<Account>(ResultStatus.CREATED, account);
            }
            catch (UserDoesNotExistException exception)
            {
                LogsWriter.Instance.WriteWarn(exception.Message);

                return new ResultObject(ResultStatus.ALREADY_EXISTS_ERROR);
            }
        }

        public ValueResultObject<List<Account>> GetAllRelatedAccounts(string userId)
        {
            var accounts = AccountsRepository.GetAllAccountsByUserId(userId);
            LogsWriter.Instance.WriteWarn($"Viewed {accounts.Count} accounts related to user with id {userId}");

            return new ValueResultObject<List<Account>>(ResultStatus.OK, accounts);
        }

        public ResultObject DeleteAccount(int accountNumber)
        {
            var rowsAffected = AccountsRepository.DeleteAcount(accountNumber);

            if (rowsAffected != 1)
            {
                return new ResultObject(ResultStatus.ACCOUNT_NOT_EXISTS_ERROR);
            }

            LogsWriter.Instance.WriteWarn($"Deleted account No. {accountNumber}");

            return new ResultObject(ResultStatus.OK);
        }

        public ResultObject Deposit(int accountNumber, double amount)
        {
            var rowsAffected = AccountsRepository.Deposit(accountNumber, amount);

            if (rowsAffected != 1)
            {
                return new ResultObject(ResultStatus.ACCOUNT_NOT_EXISTS_ERROR);
            }

            LogsWriter.Instance.WriteInfo($"Deposited {amount}$ to account No. {accountNumber}");

            return new ResultObject(ResultStatus.OK);
        }

        public ResultObject Withdraw(int accountNumber, double amount)
        {
            try
            {
                ExecuteWithdrawal(accountNumber, amount);
                LogsWriter.Instance.WriteInfo($"withdrew {amount}$ from account No. {accountNumber}");
            }
            catch (AccountDoesNotExistException exception)
            {
                LogsWriter.Instance.WriteWarn(exception.Message);

                return new ResultObject(ResultStatus.ACCOUNT_NOT_EXISTS_ERROR);
            }
            catch (OverdraftNotAllowedException exception)
            {
                LogsWriter.Instance.WriteWarn(exception.Message);

                return new ResultObject(ResultStatus.RULE_VIOLATION_ERROR);
            }

            return new ResultObject(ResultStatus.OK);
        }

        private int InsertAccount(Account account)
        {
            var accountNumber = AccountsRepository.InsertAccount(account);

            if (account is VipAccount)
            {
                new VIPMembershipBusinessLogic().CreateVipMembership(accountNumber);
            }

            return accountNumber;
        }

        private void ExecuteWithdrawal(int accountNumber, double amount)
        {
            var account = AccountsRepository.GetAccountById(accountNumber);

            if (account is null)
            {
                throw new AccountDoesNotExistException($"Account No. {accountNumber} does not exist");
            }
            else if (!(account is VipAccount) && account.Balance - amount < 0)
            {
                throw new OverdraftNotAllowedException($"Failed to withdraw {amount}$ from account No. {accountNumber} because it does not have enough money");
            }
            
            AccountsRepository.Withdraw(accountNumber, amount);
        }
    }
}