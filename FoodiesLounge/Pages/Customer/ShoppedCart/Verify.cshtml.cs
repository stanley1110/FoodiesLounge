using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PayStack.Net;
using System.Security.Claims;

namespace FoodiesLounge.Pages.Customer.ShoppedCart
{
    public class VerifyModel : PageModel
    {
        private PayStackApi StackApi { get; set; }
        private readonly IConfiguration _configuration;
        private readonly string token;
        [BindProperty]
        public string OrderId { get; set; }
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        private readonly IShoppingCart _shoppingCart;

        private readonly IOrderView _orderView;
        public OrderOverview OrderOverview { get; set; }

        public VerifyModel(IConfiguration configuration, IOrderView orderView, IShoppingCart shoppingCart, IApplicationUser applicationUser)
        {
            _configuration = configuration;
            token = _configuration["Paystack:Key"];
            StackApi = new PayStackApi(token);
            _orderView = orderView;
            _shoppingCart = shoppingCart;
            OrderOverview = new OrderOverview();
        }

        public void OnGet(string reference)
        {
         


       
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            TransactionVerifyResponse response = StackApi.Transactions.Verify(reference);
            if (response.Data.Status == "success")
            {
                var transaction = _orderView.GetFirstOrDefault(x => x.PaymentIntentId == reference);
                if (transaction != null)
                {
                    transaction.Status = Roles.StatusInProcess;
                    _orderView.Update(transaction);
                    _orderView.Save();

                    ShoppingCartList = _shoppingCart.GetAll(filter: u => u.ApplicationUserId == claim.Value,
                  includeProperties: "MenuItem,MenuItem.FoodType,MenuItem.Category");
                    _shoppingCart.RemoveRange(ShoppingCartList);
                    _shoppingCart.Save();
                }
                OrderId = reference;

            }
            ViewData["error"] = response.Data.GatewayResponse;
        }

    }
}

