using Microsoft.EntityFrameworkCore;

namespace Rentless.Models {
    public class RentlessDBContext: DbContext
    {
        public RentlessDBContext(DbContextOptions<RentlessDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=Rentless;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Currency> Currency {get; set;}
        public DbSet<Country> Country {get; set;}
        public DbSet<State> State {get; set;}
        public DbSet<City> City {get; set;}
    }
}