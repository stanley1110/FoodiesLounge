
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Pages.FoodTypes
{
    public class IndexModel : PageModel
    {
        private IFoodTypeRepo _db;
        public IEnumerable<FoodType>   FoodTypes { get; set;}

        public IndexModel( IFoodTypeRepo appDb)
        {
            _db = appDb;
        }
        public void OnGet()
        {
            FoodTypes = _db.GetAll();
        }
    }
}
