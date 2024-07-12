using DNSParser.CoreDataEntities;
using Microsoft.EntityFrameworkCore;

namespace DNSParser.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new BaseItemMap(modelBuilder.Entity<BaseItem>());
        }
    }
}