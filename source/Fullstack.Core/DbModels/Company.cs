
namespace Fullstack.Core.DbModels {
    public class Company {
        public int Id { get; set; }
        public string Name { get; set; }

        public User User { get; set; } // potentially many-to-many
    }
}
