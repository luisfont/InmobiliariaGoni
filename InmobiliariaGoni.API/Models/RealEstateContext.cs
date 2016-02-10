using Microsoft.Data.Entity;

namespace InmobiliariaGoni.Models
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<House> Houses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:RealEstateContextConnection"];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}