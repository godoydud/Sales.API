using Microsoft.EntityFrameworkCore;
using Sales.API.Domain.Entities;

namespace Sales.API.Infra.Data.Context
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) :base(options) 
        {

        }

        public DbSet<Product> Product{ get; set; }
        public DbSet<Comission> Comission{ get; set; }
        public DbSet<User> User{ get; set; }
       
    }
}
