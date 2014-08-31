using System;
using System.Diagnostics;
using System.Linq;

using log4net;
using log4net.Core;

using Mag.Business.Abstract;
using Mag.Business.Domain;

namespace Mag.Business.Services
{
    public class UserService : IUserService
    {  
        private const string MessageFormatWithAgentDesc = "{0}: {1}";
        private readonly IAgentsRepository agentsRepository;

        private readonly SimpleAes simpleAesHelper;

        private readonly IAccountSettings accountSettings;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserService(IAgentsRepository agentsRepository, SimpleAes simpleAesHelper, IAccountSettings accountSettings)
        {
            this.agentsRepository = agentsRepository;
            this.simpleAesHelper = simpleAesHelper;
            this.accountSettings = accountSettings;
        }

        private void LogAndThrowDomainExc(string msg, Agent agent, Level msgLevel)
        {
            if (msgLevel == Level.Warn)
            {
                log.WarnFormat(MessageFormatWithAgentDesc, msg, agent);
            }
            throw new DomainException(msg);
        }

        public void RegisterUser(Agent agent)
        {
            if (accountSettings.RegistrationAccessCode != agent.AccessCode)
            {
                LogAndThrowDomainExc("Вы ввели неверный код доступа", agent, Level.Warn);
            }

            if (agentsRepository.FindByEmail(agent.Email) != null)
            {
                LogAndThrowDomainExc("Такой пользователь уже зарегистрирован", agent, Level.Warn);
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
                LogAndThrowDomainExc("Такого пользователя нет", agent, Level.Warn);
            }

            EncryptPassword(agent);
            Debug.Assert(foundAgent != null, "foundAgent != null");
            if (foundAgent.PasswordHash != agent.PasswordHash)
            {
                LogAndThrowDomainExc("Пароль введен неверно", agent, Level.Warn);
            }
        }

        private void EncryptPassword(Agent agent)
        {
            if (string.IsNullOrEmpty(agent.Password))
            {
                LogAndThrowDomainExc("Empty password when registering", agent, Level.Warn);
            }
            try
            {
                agent.PasswordHash = simpleAesHelper.EncryptToString(agent.Password);
            }
            catch (Exception exc)
            {
                log.Error(string.Format(MessageFormatWithAgentDesc, "Encryption error:{0}", agent), exc);
                throw new DomainException("Error when encrypting", exc);
            }
        }

        public Agent GetUserByEmailAndHash(string email, string passwordHash)
        {
            return agentsRepository.List().FirstOrDefault(x => x.Email.Equals(email) && x.PasswordHash.Equals(passwordHash));
        }
    }
}