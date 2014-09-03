using Mag.Business.Domain;

namespace Mag.Business.Abstract
{
    public interface IUserService
    {
        void RegisterUser(Agent agent);

        void Login(Agent agent);

        Agent GetUserByLoginAndHash(string login, string passwordHash);
    }
}