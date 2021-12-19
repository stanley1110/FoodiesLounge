
using FoodiesLoungeModel;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLoungeDataAccess
{
   
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
            public DbSet<Category> Categories { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<MenuItem>  menuItems { get; set; }

    }
    
}
