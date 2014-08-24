using System;

using Mag.Business.Domain;

namespace Mag.Business.Tests.Account
{
    public static class AgentFactory
    {
        private static readonly Random Random = new Random();
        
        public static Agent Mock
        {
            get
            {

                return new Agent
                {
                    FullName = "some user",
                    Password = "pass",
                    ConfirmPassword = "pass",
                    Id = Random.Next(),
                    Email = "a@a.a"
                };
            }
        }

        public static Agent KnowsAccessCode(this Agent agent, string val)
        {
            agent.AccessCode = val;
            return agent;
        }

        public static Agent Id(this Agent agent, int val)
        {
            agent.Id = val;
            return agent;
        }
    }
}