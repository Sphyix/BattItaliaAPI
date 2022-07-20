using System;
using static BattItaliaAPI.Models.Enums;

namespace BattItaliaAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int Roles { get; set; }
    }
}