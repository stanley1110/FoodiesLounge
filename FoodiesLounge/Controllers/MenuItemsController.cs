using FoodiesLoungeDataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodiesLounge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : Controller
    {
        private IMenuItemRepo _db;
        private readonly IWebHostEnvironment _webHost;
        
        public MenuItemsController(IMenuItemRepo appDb,  IWebHostEnvironment webHost)
        {
            _db = appDb;
           
            _webHost = webHost;
           
        }
        [HttpGet]   
        public IActionResult Index()
        {
            var menuitemList = _db.GetAll(includeProperties: "Category,FoodType");

            return Json(new { data = menuitemList});
        }
    }
}
