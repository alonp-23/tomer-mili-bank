using MiliBank.Exceptions;
using MiliBank.Logs.Loggers;
using MiliBank.Models;
using MiliBank.Repositories;
using MiliBank.Results;
using System.Collections.Generic;

namespace MiliBank.BussinessLogics
{
    public class UsersBusinessLogic
    {
        private readonly UsersRepository UsersRepository = new UsersRepository();

        public ValueResultObject<List<User>> GetAllUsers()
        {
            var users = UsersRepository.GetAllUsers();
            LogsWriter.Instance.WriteWarn($"All users were viewed");

            return new ValueResultObject<List<User>>(ResultStatus.OK, users);
        }

        public ResultObject InsertUser(User user)
        {
            try
            {
                UsersRepository.InsertUser(user);
                LogsWriter.Instance.WriteInfo($"Created user with id '{user.Id}'");

                return new ResultObject(ResultStatus.CREATED);
            }
            catch (UserAlreadyExistsException exception)
            {
                LogsWriter.Instance.WriteInfo($"Could not create user with id '{user.Id}' because it already exists");

                return new ResultObject(ResultStatus.ALREADY_EXISTS_ERROR);
            }
        }

        public ResultObject DeleteUser(string userId)
        {
            var rowsAffected = UsersRepository.DeleteUserById(userId);

            if (rowsAffected != 1)
            {
                return new ResultObject(ResultStatus.USER_NOT_EXISTS_ERROR);
            }

            LogsWriter.Instance.WriteInfo($"Deleted user with id '{userId}'");

            return new ResultObject(ResultStatus.OK);
        }
    }
}