using System.Collections.Generic;

using Mag.Business.Domain;

namespace Mag.Business.Abstract
{
    public interface IAgentsRepository
    {
        IEnumerable<Agent> List();

        Agent Read(int id);

        void Add(Agent agent);
    }
}