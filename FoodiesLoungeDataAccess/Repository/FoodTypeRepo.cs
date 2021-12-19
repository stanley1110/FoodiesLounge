using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public class FoodTypeRepo : Repository<FoodType>, IFoodTypeRepo
    {
        private readonly AppDbContext _db;
        public FoodTypeRepo(AppDbContext db):base(db)   
        {
            _db = db;
        }
        public  void Save()
        {
            _db.SaveChanges();
        }

        public void Update(FoodType  foodType)
        {
           var result = _db.FoodTypes.FirstOrDefault(u => u.Id == foodType.Id);  
            if (result == null)
            {
                result.name = foodType.name;
               
            }
        }
    }
}
