using GraphQL.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Db.Context
{
    public class GasCarDbContext : DbContext
    {

        public GasCarDbContext(DbContextOptions<GasCarDbContext> options)
            : base(options)
        {

        }

        public DbSet<GasCarTable> GasCars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
