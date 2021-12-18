using FoodiesLounge.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Datas
{
   
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
            public DbSet<Category> Categories { get; set; }

        }
    
}
