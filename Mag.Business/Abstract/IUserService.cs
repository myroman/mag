using Mag.Business.Domain;

namespace Mag.Business.Abstract
{
    public interface IUserService
    {
        void RegisterUser(Agent agent);

        void Login(Agent agent);

        Agent GetUserByEmailAndHash(string email, string passwordHash);
    }
}