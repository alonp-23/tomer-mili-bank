using MiliBank.Exceptions;
using MiliBank.Logs.Loggers;
using MiliBank.Repositories;
using MiliBank.Results;

namespace MiliBank.BussinessLogics
{
    public class VIPMembershipBusinessLogic
    {
        private readonly VIPMembershipRepository VipRepository = new VIPMembershipRepository();

        public ResultObject CreateVipMembership(int accountNumber)
        {
            ResultObject result;

            try
            {
                VipRepository.CreateVIPMembership(accountNumber);
               
                LogsWriter.Instance.WriteInfo($"Created vip membership to account No. {accountNumber}");
                result = new ResultObject(ResultStatus.CREATED);
            }
            catch (AccountDoesNotExistException exception)
            {
                LogsWriter.Instance.WriteWarn(exception.Message);
                result = new ResultObject(ResultStatus.ACCOUNT_NOT_EXISTS_ERROR);
            }
            catch (AccountIsAlreadyVipException exception)
            {
                LogsWriter.Instance.WriteWarn(exception.Message);
                result = new ResultObject(ResultStatus.USER_NOT_EXISTS_ERROR);
            }

            return result;
        }
    }
}