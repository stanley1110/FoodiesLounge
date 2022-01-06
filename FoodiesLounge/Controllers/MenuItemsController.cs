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
        public IActionResult Get()
        {
            var menuitemList = _db.GetAll(includeProperties: "Category,FoodType");

            return Json(new { data = menuitemList});
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _db.GetFirstOrDefault(u=> u.Id == id);
            if (result.Image != null)
            {
                string webRoothPath = _webHost.WebRootPath;
                var OLdImagePath = Path.Combine(webRoothPath, result.Image.TrimStart('\\'));
                if (System.IO.File.Exists(OLdImagePath))
                {
                    System.IO.File.Delete(OLdImagePath);
                }
                _db.Remove(result);
                _db.Save();
                return Json(new { success = true, message = " Delete successful" });
            }
            return Json(new { success = true, message = " File not found" });
        }
    }
}
