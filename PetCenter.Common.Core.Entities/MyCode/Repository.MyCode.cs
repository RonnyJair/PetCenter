using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Common.Core.Entities.MyCode
{
    public static class Repository
    {
        static List<User> users = new List<User>() {

            new User() {Email="admin@gmail.com",Roles="Admin,Editor",Password="admin" },
            new User() {Email="user@gmail.com",Roles="Editor",Password="user" }
        };

        public static User GetUserDetails(User user)
        {
            return users.Where(u => u.Email.ToLower() == user.Email.ToLower() &&
            u.Password == user.Password).FirstOrDefault();
        }
    }
}
