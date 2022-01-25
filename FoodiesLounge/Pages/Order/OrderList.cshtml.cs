using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.Order
{
    [Authorize]
    public class OrderListModel : PageModel
    {
       
        public void OnGet()
        {
        }
    }
}
