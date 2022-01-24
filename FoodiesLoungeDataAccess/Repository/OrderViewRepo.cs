using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public class OrderViewRepo : Repository<OrderOverview>, IOrderView
    {
        private readonly AppDbContext _db;
        public OrderViewRepo(AppDbContext db):base(db)   
        {
            _db = db;
        }
        public  void Save()
        {
            _db.SaveChanges();
        }

        public void Update(OrderOverview overview)
        {

            _db.OrderOverviews.Update(overview);
        }

       
    }
}
