using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public class ShoppingCartRepo : Repository<ShoppingCart>, IShoppingCart
    {
        private readonly AppDbContext _db;
        public ShoppingCartRepo(AppDbContext db):base(db)   
        {
            _db = db;
        }

        public int DecreaseCOunt(ShoppingCart cart, int count)
        {
            cart.Count -= count;
            _db.SaveChanges();
            return cart.Count;  
        }

        public int IncrementCOunt(ShoppingCart cart, int count)
        {
            cart.Count += count;
            _db.SaveChanges();
            return cart.Count;
        }

        public  void Save()
        {
            _db.SaveChanges();
        }

        //public void Update(ShoppingCart shoppingCart)
        //{
        //   var result = _db.shoppingCarts.FirstOrDefault(u => u.Id == category.Id);  
        //    //if (result == null)
        //    //{
        //    //    result.name = category.name;
        //    //    result.DisplayOrder = category.DisplayOrder;
        //    //}
        //}
    }
}
