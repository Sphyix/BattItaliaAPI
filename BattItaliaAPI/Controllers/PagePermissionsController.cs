using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BattItaliaAPI.DB.Page;

namespace BattItaliaAPI.Controllers
{
    public class PagePermissionsController : ApiController
    {

        private IPageSelect iPageSelect = null;


        public IEnumerable<PageSelectResults> Get()
        {
            iPageSelect = new PageSelect();
            var f = HttpContext.Current.User;

            var res = iPageSelect.Execute();

            return res;

        }

    }
}