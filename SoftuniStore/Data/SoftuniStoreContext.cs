using System.Data.Entity;
using SoftuniStore.Models;

namespace SoftuniStore.Data
{
    public class SoftuniStoreContext : DbContext
    {
        public SoftuniStoreContext()
            : base("name=SoftuniStoreContext")
        {
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

    }
}