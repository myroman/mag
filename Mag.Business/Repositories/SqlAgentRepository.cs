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
            return DataContext.tbAgents.Select(x => x.ToDomain());
        }

        public Agent Read(int id)
        {
            var rec = DataContext.tbAgents.SingleOrDefault(x => x.id == id);
            if (rec != null)
            {
                return rec.ToDomain();
            }
            return null;
        }

        public Agent FindByLogin(string userName)
        {
            return List().FirstOrDefault(agent => agent.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Agent agent)
        {
            DataContext.tbAgents.InsertOnSubmit(agent.ToItem());
            DataContext.SubmitChanges();
        }
    }
}