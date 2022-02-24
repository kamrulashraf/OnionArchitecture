using Microsoft.EntityFrameworkCore;
using OA.Data;


namespace OA.Repo
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<TouristPlace> TouristPlace { get; set; }
        public DbSet<Location> Location { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new TouristPlaceMap(modelBuilder.Entity<TouristPlace>());
            new LocationMap(modelBuilder.Entity<Location>());
        }
    }
}
