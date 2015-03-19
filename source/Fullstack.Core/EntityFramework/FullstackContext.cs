using Fullstack.Core.DbModels;
using System.Data.Entity;

namespace Fullstack.Core.EntityFramework {
    public class FullstackContext : DbContext {

        public FullstackContext()
            : base("name=FullstackContext") {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
    }
}
