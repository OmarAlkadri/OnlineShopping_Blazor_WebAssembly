using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineShoppingCenterproject.Data_DB
{
    public class Context_DB : IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Castomer> Castomer { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<OrderAddress> OrderAddress { get; set; }
        public DbSet<CastomerAddress> CastomerAddress { get; set; }
        public DbSet<ProductCompany> ProductCompany { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<FavoriteForProduct> FavoriteForProduct { get; set; }
        public Context_DB()
        {

        }
      
        public Context_DB(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  var mutableProperties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            //foreach (var property in mutableProperties)
            //    property.Relational().ColumnType = "varchar(100)";

            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context_DB).Assembly);
           // modelBuilder.ApplyConfiguration(new RoleForUsersConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.;database=OnlineShoppingCenter_DB;trusted_connection=true;");
            }
        }
    }
}
