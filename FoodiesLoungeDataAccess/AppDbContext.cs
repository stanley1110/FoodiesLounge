
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLoungeDataAccess
{
   
        public class AppDbContext : IdentityDbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
            public DbSet<Category> Categories { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<MenuItem>  menuItems { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderOverview>   OrderOverviews { get; set; }
        public DbSet<OrderDetails>  OrderDetails { get; set; }

        public DbSet<ShoppingCart>  shoppingCarts { get; set; }

    }
    
}
