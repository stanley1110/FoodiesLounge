using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public interface IMenuItemRepo : IRepository<MenuItem>
    {
        void Update(MenuItem   menuItem); 
        void Save();    
    }
}
