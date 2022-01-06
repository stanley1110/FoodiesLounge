using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FoodiesLounge.Pages.Customer.Home
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IMenuItemRepo _menuItem;
        private readonly IShoppingCart  _shoppingCart;
        [BindProperty]
        public ShoppingCart Cart { get; set; }
        public DetailsModel(IMenuItemRepo menu, IShoppingCart  shoppingCart)
        {
            _menuItem = menu;
            _shoppingCart = shoppingCart;
        }
        public void OnGet(int Id)
        {
            var claimidentity = (ClaimsIdentity)User.Identity;
            var claim = claimidentity.FindFirst(ClaimTypes.NameIdentifier);
           

            Cart = new() {
                   ApplicationUserId = claim.Value,
                 MenuItem = _menuItem.GetFirstOrDefault(c => c.Id == Id, includeProperties: "Category,FoodType"),
                 MenuItemId = Id

        };

    }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ShoppingCart cart = _shoppingCart.GetFirstOrDefault(filter : o=> o.ApplicationUserId == Cart.ApplicationUserId
                 && o.MenuItemId == Cart.MenuItemId);
                if (cart == null)
                {

                    _shoppingCart.Add(Cart);
                    _shoppingCart.Save();
                }
                else
                {
                    _shoppingCart.IncrementCOunt(cart, Cart.Count);
                }

                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
 