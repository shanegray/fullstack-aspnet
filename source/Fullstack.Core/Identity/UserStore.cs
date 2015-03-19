using Fullstack.Core.DbModels;
using Fullstack.Core.EntityFramework;
using Fullstack.Core.Query;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace Fullstack.Core.Identity {
    public class UserStore : IUserStore<User, int>, IUserPasswordStore<User, int>{
        private readonly FullstackContext context;
        public UserStore() {
            this.context = new FullstackContext();
        }

        public Task CreateAsync(User user) {
            var hasher = new PasswordHasher();
            user.PasswordHash = hasher.HashPassword(user.Password);
            this.context.User.Add(user);
            this.context.SaveChanges();

            return Task.FromResult<int>(0);
        }

        public Task DeleteAsync(User user) {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int userId) {
            var user = this.context.User.Find(userId);

            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string userName) {
            var user = this.context.User.FirstOrDefault(x => x.UserName == userName);

            return Task.FromResult(user);
        }


        public Task UpdateAsync(User user) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            this.context.Dispose();
        }

        public Task<string> GetPasswordHashAsync(User user) {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user) {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash) {
            throw new NotImplementedException();
        }
    }
}
