
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private ICategoryRepo _db;
        public IEnumerable<Category>  Categories { get; set;}

        public IndexModel( ICategoryRepo appDb)
        {
            _db = appDb;
        }
        public void OnGet()
        {
            Categories = _db.GetAll();
        }
    }
}
