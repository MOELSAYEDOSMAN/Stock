using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stock.Models.DbModels.ItemModel;
using Stock.Models.DbModels.StoreModel;

namespace Stock.Models
{
    public class ApplicationDataBaseContext:DbContext
    {
        //private string ConnectionString = string.Empty;
        //public ApplicationDataBaseContext(IConfiguration configuration)
        //{
        //    ConnectionString = configuration.GetSection("ConnectionStrings")
        //        .GetValue<string>("DefaultConnection");
        //    Console.WriteLine(ConnectionString);
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionString);
        //}

        public ApplicationDataBaseContext(DbContextOptions<ApplicationDataBaseContext> options)
            : base(options)
        { }
        //Tables
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
