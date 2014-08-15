using System.Web;

using Mag.Business.Abstract;
using Mag.Business.Domain;

namespace Mag.Web.Business
{
    public class UserServiceFacade : IUserServiceFacade
    {
        private const string UserCookieKey = "hash";

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
            var hashCookie = HttpContext.Current.Request.Cookies[UserCookieKey];
            if (hashCookie == null)
            {
                return null;
            }
            return GetCurrentUserByHash(hashCookie);
        }

        private Agent GetCurrentUserByHash(HttpCookie hashCookie)
        {
            var userInfoArr = hashCookie.Value.Split('|');
            if (userInfoArr.Length != 2)
            {
                return null;
            }
            
            return UserService.GetUserByEmailAndHash(userInfoArr[0], userInfoArr[1]);
        }

        public void RegisterUser(Agent newUser)
        {
            UserService.RegisterUser(newUser);
            if (!string.IsNullOrEmpty(newUser.Email) && !string.IsNullOrEmpty(newUser.PasswordHash))
            {
                var cookieValue = newUser.Email + "|" + newUser.PasswordHash;
                HttpContext.Current.Response.AppendCookie(new HttpCookie(UserCookieKey, cookieValue));
            }
        }

        public void LoginUser(Agent user)
        {
            UserService.Login(user);
            var cookieValue = user.Email + "|" + user.PasswordHash;

            HttpContext.Current.Response.AppendCookie(new HttpCookie(UserCookieKey, cookieValue));
        }
    }
}