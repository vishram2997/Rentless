using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Rentless.Models;
//using Pomelo.EntityFrameworkCore.MySql.Extensions;
using NetTopologySuite;  
namespace Rentless.Models {
    public class RentlessDBContext: DbContext
    {
        public RentlessDBContext(DbContextOptions<RentlessDBContext> options) : base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AttributeValue>()
                .HasKey(o => new { o.AttributeTypeCode, o.Value });
          

            modelBuilder.Entity<City>()
                .HasKey(o => new { o.Code, o.StateCode });

            modelBuilder.Entity<CustListing>()
                .HasKey(o => new { o.CustomerId, o.ProductCode });
            
            modelBuilder.Entity<CustPaymMode>()
                .HasKey(o => new { o.CustomerId, o.PaymModeCode });

            modelBuilder.Entity<ProductDocument>()
                .HasKey(o => new { o.ProductCode, o.DocumentId });
          


        }
        public DbSet<Currency> Currency {get; set;}
        public DbSet<Country> Country {get; set;}
        public DbSet<State> State {get; set;}
        public DbSet<City> City {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<PostalCode> PostalCode { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<PaymMode> PaymMode { get; set; }
        public DbSet<ProductAttribute> ProductAttribute { get; set; }
        public DbSet<ProductDocument> ProductDocument { get; set; }
        public DbSet<CustListing> CustListing { get; set; }
        public DbSet<CustPaymMode> CustPaymMode { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<DocuType>  DocuType { get; set; }
        public DbSet<AttributeType> AttributeType { get; set; }

        public DbSet<AttributeValue> AttributeValue {get; set;}



    }

    // required when local database deleted
    public class RentlessContextFactory : IDesignTimeDbContextFactory<RentlessDBContext>
    {
        public RentlessDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RentlessDBContext>();
            builder.UseNpgsql(@"Host=localhost;Database=Rentless;Username=postgres;Password=123456"
             ,x => x.UseNetTopologySuite());
            return new RentlessDBContext(builder.Options);
        }
    }
}