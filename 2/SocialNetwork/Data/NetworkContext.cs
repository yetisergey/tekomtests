using Domain;
using System.Data.Entity;

namespace Data
{
    public class NetworkContext : DbContext
    {
        public NetworkContext() : base("Network") { }
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
