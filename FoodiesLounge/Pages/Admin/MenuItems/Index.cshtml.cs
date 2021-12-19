
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {
        private IMenuItemRepo _db;
        public IEnumerable<MenuItem>  menuItems { get; set;}

        public IndexModel( IMenuItemRepo appDb)
        {
            _db = appDb;
        }
        public void OnGet()
        {
            menuItems = _db.GetAll();
        }
    }
}
