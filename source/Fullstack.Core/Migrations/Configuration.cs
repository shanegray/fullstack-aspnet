using Fullstack.Core.EntityFramework;
using System.Data.Entity.Migrations;

namespace Fullstack.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FullstackContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FullstackContext context)
        {
        }
    }
}
