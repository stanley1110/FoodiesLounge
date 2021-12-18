
using FoodiesLoungeDataAccess;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Pages.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public IEnumerable<FoodType>   FoodTypes { get; set;}

        public IndexModel( AppDbContext appDb)
        {
            _db = appDb;
        }
        public void OnGet()
        {
            FoodTypes = _db.FoodTypes;
        }
    }
}
