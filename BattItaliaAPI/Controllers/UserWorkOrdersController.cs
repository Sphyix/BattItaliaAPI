using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BattItaliaAPI.DB.WorkOrders;

namespace BattItaliaAPI.Controllers
{
    [Authorize]
    public class UserWorkOrdersController : ApiController
    {
        private IUserWorkOrdersSelect iUserWorkOrderSelect = null;

        public IEnumerable<UserWorkOrdersSelectResults> Get(int? id)
        {
            iUserWorkOrderSelect = new UserWorkOrdersSelect();

            var res = iUserWorkOrderSelect.Execute(id);

            return res;

        }
    }
}