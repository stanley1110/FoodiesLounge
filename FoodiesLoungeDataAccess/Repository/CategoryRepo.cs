using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        private readonly AppDbContext _db;
        public CategoryRepo(AppDbContext db):base(db)   
        {
            _db = db;
        }
        public  void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
           var result = _db.Categories.FirstOrDefault(u => u.Id == category.Id);  
            if (result == null)
            {
                result.name = category.name;
                result.DisplayOrder = category.DisplayOrder;
            }
        }
    }
}
