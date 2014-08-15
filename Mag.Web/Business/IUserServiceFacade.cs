using System.Web;

using Mag.Business.Domain;

namespace Mag.Web.Business
{
    public interface IUserServiceFacade
    {
        bool IsAuthenticated(HttpContext context);

        Agent GetCurrentUser();

        void RegisterUser(Agent newUser);

        void LoginUser(Agent user);
    }
}