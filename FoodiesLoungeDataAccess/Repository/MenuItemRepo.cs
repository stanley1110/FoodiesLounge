using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public class MenuItemRepo : Repository<MenuItem>, IMenuItemRepo
    {
        private readonly AppDbContext _db;
        public MenuItemRepo(AppDbContext db):base(db)   
        {
            _db = db;
        }
        public  void Save()
        {
            _db.SaveChanges();
        }

        public void Update(MenuItem  menuItem)
        {
           var result = _db.menuItems.FirstOrDefault(u => u.Id == menuItem.Id);  
            if (result != null)
            {
                result.Name = menuItem.Name;
                result.Description = menuItem.Description;
               
                    result.Image = menuItem.Image;
              
             
                result.Price = menuItem.Price;
                result.CAtegoryId = menuItem.CAtegoryId;
                result.FoodTypeId = menuItem.FoodTypeId;

            }
        }
    }
}
