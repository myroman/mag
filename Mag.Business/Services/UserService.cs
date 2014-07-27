using System;

using Mag.Business.Abstract;
using Mag.Business.Domain;

namespace Mag.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IAgentsRepository agentsRepository;

        private readonly SimpleAes simpleAesHelper;

        public UserService(IAgentsRepository agentsRepository, SimpleAes simpleAesHelper)
        {
            this.agentsRepository = agentsRepository;
            this.simpleAesHelper = simpleAesHelper;
        }

        public void RegisterUser(Agent agent)
        {
            EncryptPassword(agent);
            agent.RegistrationDate = DateTime.Now;

            agentsRepository.Add(agent);
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
    }
}