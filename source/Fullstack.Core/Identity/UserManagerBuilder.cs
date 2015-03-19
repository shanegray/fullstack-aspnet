
using Microsoft.AspNet.Identity;
namespace Fullstack.Core.Identity {
    public class UserManagerBuilder {
        public UserManager Build() {
            var userStore = new UserStore();
            var userManager = new UserManager(userStore);

            userManager.PasswordValidator = new PasswordValidator {
                RequiredLength = 6
            };

            return userManager;
        }
    }
}
