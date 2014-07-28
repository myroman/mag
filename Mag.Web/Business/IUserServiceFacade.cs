using System.Web;

namespace Mag.Web.Business
{
    public interface IUserServiceFacade
    {
        bool IsAuthenticated(HttpContext context);
    }
}