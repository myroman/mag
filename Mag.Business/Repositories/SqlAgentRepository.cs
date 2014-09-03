using System;
using System.Collections.Generic;
using System.Linq;

using Mag.Business.Abstract;
using Mag.Business.Domain;
using Mag.Business.Repositories.Mappers;

namespace Mag.Business.Repositories
{
    public class SqlAgentRepository : SqlRepositoryBase, IAgentsRepository
    {
        public SqlAgentRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Agent> List()
        {
            Log.Info("Getting agents list...");
            try
            {
                var agents = DataContext.tbAgents.Select(x => x.ToDomain());
                Log.Info("OK");
                return agents;
            }
            catch (Exception exc)
            {
                Log.Error("Error when getting agents list", exc);
                throw;
            }
        }

        public Agent Read(int id)
        {
            Log.InfoFormat("Reading agent with id={0}...", id);
            var rec = DataContext.tbAgents.SingleOrDefault(x => x.id == id);
            if (rec != null)
            {
                var agent = rec.ToDomain();
                Log.Info("Found agent" + agent);
                return agent;
            }
            Log.WarnFormat("Haven't found agent by id={0}", id);
            return null;
        }

        public Agent FindByLogin(string login)
        {
            Log.InfoFormat("Finding by login={0}...", login);
            var agentOrNull = List().FirstOrDefault(agent => agent.Login == login);
            if (agentOrNull != null)
            {
                Log.InfoFormat("Found agent {0}", login);
            }
            else
            {
                Log.WarnFormat("Haven't found agent by login={0}", login);
            }
            return agentOrNull;
        }

        public void Add(Agent agent)
        {
            try
            {
                Log.InfoFormat("Adding agent {0}...", agent);
                DataContext.tbAgents.InsertOnSubmit(agent.ToItem());
                DataContext.SubmitChanges();
                Log.Info("OK");
            }
            catch (Exception exc)
            {
                Log.Error("Can't add agent", exc);
                throw;
            }
        }
    }
}