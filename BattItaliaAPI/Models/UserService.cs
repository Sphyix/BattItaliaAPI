using System;
using System.Collections.Generic;
using System.Linq;
using BattItaliaAPI.DB.User;
using static BattItaliaAPI.Models.Enums;

namespace BattItaliaAPI.Models
{
    public interface IUserService
    {
        User Validate(string email, string password);
        List<User> GetUserList();
        User GetUserById(int id);
        List<User> SearchByName(string name);
    }

    // UserService concrete class
    public class UserService : IUserService
    {

        private IUserSelect iUserSelect = null;

        private List<User> userList = new List<User>();
        public UserService()
        {
            iUserSelect = new UserSelect();

            var res = iUserSelect.Execute();

            foreach (var item in res)
            {
                userList.Add(new User
                {
                    Id = item.users_id,
                    Name = item.nome,
                    Password = item.passwd,
                    Email = item.email,
                    Roles = item.permission
                });
            }
        }

        public User Validate(string name, string password)
            => userList.FirstOrDefault(x => x.Name == name && CheckPassword(password, x.Password));

        private bool CheckPassword(string inputPsw, string hash)
        {
            bool verified = BCrypt.Net.BCrypt.EnhancedVerify(inputPsw, hash);
            return verified;
        }

        public List<User> GetUserList() => userList;

        public User GetUserById(int id)
            => userList.FirstOrDefault(x => x.Id == id);

        public List<User> SearchByName(string name)
            => userList.Where(x => x.Name.Contains(name)).ToList();
    }
}