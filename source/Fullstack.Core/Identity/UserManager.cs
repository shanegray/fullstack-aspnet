using Fullstack.Core.DbModels;
using Microsoft.AspNet.Identity;

namespace Fullstack.Core.Identity {
    public class UserManager : UserManager<User, int> {

        public UserManager(IUserStore<User, int> store) : base(store) { }
    }
}
