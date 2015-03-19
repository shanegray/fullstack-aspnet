using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fullstack.Core.DbModels {
    public class User : IUser<int> {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public string Password { get; set; }
        public string PasswordHash { get; set; }

        //    SecurityStamp
        //    Claims
        //    Logins
        //    Roles
    }
}
