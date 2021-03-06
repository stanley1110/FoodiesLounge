using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public interface IOrderView: IRepository<OrderOverview>
    {
        void Update(OrderOverview  overview); 
        void Save();    
    }
}
