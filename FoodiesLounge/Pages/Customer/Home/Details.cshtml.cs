using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FoodiesLounge.Pages.Customer.Home
{
 
    public class DetailsModel : PageModel
    {
        private readonly IMenuItemRepo _menuItem;

        [BindProperty]
        public MenuItem menu { get; set; }
        [Range(1,100,ErrorMessage = "Please select a count between 1 and 100")]
        public int count { get; set; }  
        public DetailsModel(IMenuItemRepo menu)
        {
            _menuItem = menu;
        }
        public void OnGet(int Id)
        {
            menu = _menuItem.GetFirstOrDefault(c=> c.Id == Id,includeProperties:"Category,FoodType");
        }
    }
}
 