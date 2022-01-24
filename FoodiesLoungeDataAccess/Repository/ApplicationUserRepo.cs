using FoodiesLoungeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeDataAccess.Repository
{
    public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUser
    {
        private readonly AppDbContext _db;
        public ApplicationUserRepo(AppDbContext db):base(db)   
        {
            _db = db;
        }
        
    }
}
