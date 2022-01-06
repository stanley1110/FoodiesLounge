using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public interface IShoppingCart: IRepository<ShoppingCart>
    {
        int IncrementCOunt(ShoppingCart cart, int count);
        int DecreaseCOunt(ShoppingCart cart, int count);


        void Save();    
    }
}
