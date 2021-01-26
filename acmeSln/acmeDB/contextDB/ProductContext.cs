using Microsoft.EntityFrameworkCore;
using acmeDB.models;
using acmeDB.methods;
namespace acmeDB.contextDB
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new ParametersACME().GetJsonAppSetting("ConnectionStrings","DbACMEConnection"));
        }     
    }
}
