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
            return GetCurrentUser() != null;
        }

        public Agent GetCurrentUser()
        {
            var hashCookie = HttpContext.Current.Request.Cookies["hash"];
            if (hashCookie == null)
            {
                return null;
            }
            return GetCurrentUserByHash(hashCookie);
        }

        private Agent GetCurrentUserByHash(HttpCookie hashCookie)
        {
            return UserService.GetCurrentUserByHash(hashCookie.Value);
        }
    }
}