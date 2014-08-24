using System;
using System.Linq;

using Mag.Business.Abstract;
using Mag.Business.Domain;

namespace Mag.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IAgentsRepository agentsRepository;

        private readonly SimpleAes simpleAesHelper;

        private readonly IAccountSettings accountSettings;

        public UserService(IAgentsRepository agentsRepository, SimpleAes simpleAesHelper, IAccountSettings accountSettings)
        {
            this.agentsRepository = agentsRepository;
            this.simpleAesHelper = simpleAesHelper;
            this.accountSettings = accountSettings;
        }

        public void RegisterUser(Agent agent)
        {
            if (accountSettings.RegistrationAccessCode != agent.AccessCode)
            {
                throw new DomainException("Вы ввели неверный код доступа");
            }

            if (agentsRepository.FindByEmail(agent.Email) != null)
            {
                throw new DomainException("Такой пользователь уже зарегистрирован");
            }

            EncryptPassword(agent);
            agent.RegistrationDate = DateTime.Now;

            agentsRepository.Add(agent);
        }

        public void Login(Agent agent)
        {
            var foundAgent = agentsRepository.FindByEmail(agent.Email);
            if (foundAgent == null)
            {
                throw new DomainException("Такого пользователя нет");
            }

            EncryptPassword(agent);
            if (foundAgent.PasswordHash != agent.PasswordHash)
            {
                throw new DomainException("Пароль введен неверно");
            }
        }

        private void EncryptPassword(Agent agent)
        {
            if (string.IsNullOrEmpty(agent.Password))
            {
                throw new DomainException("Empty password when registering");
            }
            try
            {
                agent.PasswordHash = simpleAesHelper.EncryptToString(agent.Password);
            }
            catch (Exception exc)
            {
                throw new DomainException("Error when encrypting", exc);
            }
        }

        public Agent GetUserByEmailAndHash(string email, string passwordHash)
        {
            return agentsRepository.List().FirstOrDefault(x => x.Email.Equals(email) && x.PasswordHash.Equals(passwordHash));
        }
    }
}