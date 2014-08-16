using System.Collections.Generic;
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


        /// <summary>
        /// Shows the list of sales for the user. If current user is admin, it gets the total sales list. Otherwise, only the sales of this user.
        /// </summary>
        /// <returns>The sales of current user or all sales.</returns>
        IEnumerable<Sale> GetSalesForCurrentUser();
    }
}