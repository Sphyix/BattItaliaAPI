using System.Collections.Generic;
using System.Web.Http;
using BattItaliaAPI.DB;
using BattItaliaAPI.DB.User;

namespace BattItaliaAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserSelect iUserSelect = null;
        private IUserInsert iUserInsert = null;
        private IUserUpdate iUserUpdate = null;

        // GET: api/user
        public IEnumerable<UserSelectResults> Get()
        {
            iUserSelect = new UserSelect();

            var res = iUserSelect.Execute();

            foreach (var item in res)
            {
                item.passwd = string.Empty;
            }

            return res;

        }

        // GET: api/user/username
        public UserSelectResults Get(int? id)
        {
            iUserSelect = new UserSelect();
            if (id == null)
            {
                return new UserSelectResults();
            }

            var res = iUserSelect.GetOne(null, id);
            res.passwd = string.Empty;

            return res;
        }

        // Post: api/user
        public bool Post([FromBody] UserSelectResults value)
        {
            iUserInsert = new UserInsert();

            if(string.IsNullOrWhiteSpace(value.nome) || string.IsNullOrWhiteSpace(value.email) || string.IsNullOrWhiteSpace(value.passwd))
            {
                return false;
            }

            var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(value.passwd);

            var res = iUserInsert.ExecuteNonQuery(value.nome, value.email, hash, value.permission);

            if (res == 1)
                return true;
            else
                return false;
        }

        // patch: api/user/id
        public bool Patch(int? id, [FromBody] UserSelectResults input)
        {
            iUserUpdate = new UserUpdate();
            iUserSelect = new UserSelect();

            if (id == null || input == null)
            {
                return false;
            }

            var currentUser = iUserSelect.GetOne(null, id);

            if (currentUser == null)
            {
                return false;
            }

            UserSelectResults updatedUser = new UserSelectResults();

            updatedUser.nome = DbHelper.CheckValue(input.nome, currentUser.nome);
            updatedUser.passwd = DbHelper.CheckValue(input.passwd, currentUser.passwd);
            updatedUser.email = DbHelper.CheckValue(input.email, currentUser.email);

            var res = iUserUpdate.ExecuteNonQuery(id, updatedUser.nome, updatedUser.email, updatedUser.passwd, input.permission);

            if (res == 1)
                return true;
            else
                return false;
        }

        
    }
}