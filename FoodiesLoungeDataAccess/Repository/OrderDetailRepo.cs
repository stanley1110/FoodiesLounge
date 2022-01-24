using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public class OrderDetailRepo: Repository<OrderDetails>, IOrderDetail
    {
        private readonly AppDbContext _db;
        public OrderDetailRepo(AppDbContext db):base(db)   
        {
            _db = db;
        }
        public  void Save()
        {
            _db.SaveChanges();
        }

        public void Update(OrderDetails  details)
        {
          _db.OrderDetails.Update(details); 
        }

        
    }
}
