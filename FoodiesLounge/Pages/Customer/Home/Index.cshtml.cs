using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IMenuItemRepo _menuItem;
        private readonly ICategoryRepo _categoryRepo ;
        public IEnumerable<MenuItem>  MenuItem { get; set; }
        public IEnumerable<Category>  Category { get; set; }
        public IndexModel(IMenuItemRepo  menu,ICategoryRepo category)
        {
            _menuItem = menu;
            _categoryRepo = category;   


        }
        public void OnGet()
        {
            MenuItem = _menuItem.GetAll(includeProperties: ("Category,FoodType")).OrderBy(c => c.Name);
            
            Category = _categoryRepo.GetAll().OrderBy(c => c.DisplayOrder); 

        }
    }
}
