using FoodiesLoungeDataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodiesLounge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListController : Controller
    {
        private IOrderView _db;
        private readonly IWebHostEnvironment _webHost;
        
        public OrderListController(IOrderView appDb,  IWebHostEnvironment webHost)
        {
            _db = appDb;
           
            _webHost = webHost;
           
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var orders = _db.GetAll(includeProperties: "ApplicationUser");

            return Json(new { data = orders});
        }
       
      
    }
}
