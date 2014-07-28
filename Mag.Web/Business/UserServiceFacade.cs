using System.Web;

using Mag.Business.Abstract;
using Mag.Business.Domain;

namespace Mag.Web.Business
{
    public class UserServiceFacade : IUserServiceFacade
    {
        protected readonly IUserService UserService;

        public UserServiceFacade(IUserService userService)
        {
            UserService = userService;
        }

        public bool IsAuthenticated(HttpContext context)
        {
            var hashCookie = context.Request.Cookies["hash"];
            if (hashCookie == null)
            {
                return false;
            }
            return GetCurrentUserByHash(hashCookie) != null;
        }

        private Agent GetCurrentUserByHash(HttpCookie hashCookie)
        {
            return UserService.GetCurrentUserByHash(hashCookie.Value);
        }
    }
}