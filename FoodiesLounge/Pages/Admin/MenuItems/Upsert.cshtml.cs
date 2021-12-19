
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Pages.Admin.MenuItems
{
    public class UpsertModel : PageModel
    {
        private IFoodTypeRepo _db2;
        private ICategoryRepo _db1;
        private IMenuItemRepo _db;
        public MenuItem  menuItems { get; set;}
        public IEnumerable<SelectListItem>  CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel( IMenuItemRepo appDb,ICategoryRepo db1, IFoodTypeRepo db2 )
        {
            _db = appDb;
            _db1 = db1;
            _db2 = db2;
            menuItems = new();
        }
        public void OnGet()
        {
            CategoryList = _db1.GetAll().Select(c=> new SelectListItem()
            {
                Text = c.name,
                 Value = c.Id.ToString()    
                 
            } );
            FoodTypeList = _db2.GetAll().Select(c => new SelectListItem()
            {
                Text = c.name,
                Value = c.Id.ToString()

            });
        }
    }
}
