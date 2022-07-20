using System.Collections.Generic;
using System.Web.Http;
using BattItaliaAPI.DB;

namespace BattItaliaAPI.Controllers
{
    [Authorize]
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public string Get()
        {
            //var f = new DB.ClientDB();
            //var res = f.Execute();

            return "";
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
