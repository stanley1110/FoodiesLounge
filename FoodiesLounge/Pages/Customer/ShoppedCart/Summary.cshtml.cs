using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace FoodiesLounge.Pages.Customer.ShoppedCart
{

    [Authorize]
    [BindProperties]

    public class SummaryModel : PageModel
    {


            public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
            private readonly IShoppingCart _shoppingCart;
            private readonly IApplicationUser _applicationUser;
        private readonly IOrderView  _orderView;
        private readonly IOrderDetail _orderDetail;



        public OrderOverview OrderOverview { get; set; }
            public SummaryModel(IOrderDetail orderDetail, IOrderView orderView,IShoppingCart shoppingCart, IApplicationUser applicationUser)
            {
            _orderDetail = orderDetail;
            _orderView = orderView;
            _shoppingCart = shoppingCart;
                _applicationUser = applicationUser;
                OrderOverview = new OrderOverview();
            }

            public void OnGet()
            {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _shoppingCart.GetAll(filter: u => u.ApplicationUserId == claim.Value,
                    includeProperties: "MenuItem,MenuItem.FoodType,MenuItem.Category");

                foreach (var cartItem in ShoppingCartList)
                {
                    OrderOverview.OrderTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
                ApplicationUser applicationUser = _applicationUser.GetFirstOrDefault(u => u.Id == claim.Value);
                OrderOverview.PickupName = applicationUser.FirstName + " " + applicationUser.LastName;
                OrderOverview.PhoneNumber = applicationUser.PhoneNumber;
            }
        }
        public void OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _shoppingCart.GetAll(filter: u => u.ApplicationUserId == claim.Value,
                    includeProperties: "MenuItem,MenuItem.FoodType,MenuItem.Category");

                foreach (var cartItem in ShoppingCartList)
                {
                    OrderOverview.OrderTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
                OrderOverview.Status = Roles.StatusPending;
                OrderOverview.OrderDate = DateTime.Now;
                OrderOverview.UserId = claim.Value;
                OrderOverview.PickUpTime = Convert.ToDateTime(OrderOverview.PickUpDate.ToShortDateString() + " " +
                     OrderOverview.PickUpTime.ToShortTimeString());
                _orderView.Add(OrderOverview);
               var test = OrderOverview.Id;
                _orderView.Save();
                OrderDetails orderDetails = new OrderDetails();
                foreach (var item in ShoppingCartList)
                {
                  

                    orderDetails.MenuItemId = item.MenuItemId;
                       orderDetails.OrderId = OrderOverview.Id;
                        orderDetails.Name = item.MenuItem.Name;
                        orderDetails.Price = item.MenuItem.Price;
                    orderDetails.Count = item.Count;

                    
                    _orderDetail.Add(orderDetails);
                   

                }
                _orderDetail.Save();
                _shoppingCart.RemoveRange(ShoppingCartList);
                _shoppingCart.Save();



            }
        }





    }

}
