using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IMenuItemRepo  _menuItem;
        [BindProperty]
        public MenuItem menu { get; set; }
        public DetailsModel(IMenuItemRepo menuItem)
        {
            _menuItem = menuItem;
        }
        public void OnGet(int id)
        {
            menu = _menuItem.GetFirstOrDefault(c=> c.Equals(id));

        }
    }
}
