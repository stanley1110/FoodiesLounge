using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace FoodiesLounge.Pages.Customer.ShoppedCart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        private readonly IShoppingCart _shoppingCart;
        public double CartTotal { get; set; }
        public IndexModel(IShoppingCart shoppingCart)
        {
            CartTotal = 0;
            _shoppingCart = shoppingCart;
        }
        public void OnGet()
        {
            var claimidentity = (ClaimsIdentity)User.Identity;
            var claim = claimidentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _shoppingCart.GetAll(filter: u => u.ApplicationUserId == claim.Value
                , includeProperties: "MenuItem,MenuItem.FoodType,MenuItem.Category");
                foreach(var cart in ShoppingCartList)
                {
                    CartTotal += (cart.MenuItem.Price * cart.Count);
                }

            }
        }
        public IActionResult OnPostPlus(int cartId)
        {
            var cart = _shoppingCart.GetFirstOrDefault(filter: u => u.Id == cartId);
            _shoppingCart.IncrementCOunt(cart, 1);
           return  RedirectToPage("/Customer/ShoppedCart/Index");
        }
        public IActionResult OnPostMinus(int cartId)
        {
            var cart = _shoppingCart.GetFirstOrDefault(filter: u => u.Id == cartId);
            if (cart.Count == 1)
            {

                _shoppingCart.Remove(cart);
                _shoppingCart.Save();
            }
            else
            {
                _shoppingCart.DecreaseCOunt(cart, 1);
            }
            return RedirectToPage("/Customer/ShoppedCart/Index");
        }
        public IActionResult OnPostRemove(int cartId)
        {
            var cart = _shoppingCart.GetFirstOrDefault(filter: u => u.Id == cartId);
         
                _shoppingCart.Remove(cart);
                _shoppingCart.Save();

            
            return RedirectToPage("/Customer/ShoppedCart/Index");
        }
    }
}
