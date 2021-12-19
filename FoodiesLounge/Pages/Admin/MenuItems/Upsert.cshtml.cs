
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Pages.Admin.MenuItems
{
    public class UpsertModel : PageModel
    {
        private IFoodTypeRepo _db2;
        private ICategoryRepo _db1;
        private IMenuItemRepo _db;
        private readonly IWebHostEnvironment _webHost;
        public MenuItem  menuItems { get; set;}
        public IEnumerable<SelectListItem>  CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel( IMenuItemRepo appDb,ICategoryRepo db1, IFoodTypeRepo db2, IWebHostEnvironment webHost )
        {
            _db = appDb;
            _db1 = db1;
            _db2 = db2;
            _webHost = webHost;
            menuItems = new();
        }
        public void OnGet()
        {
            CategoryList = _db1.GetAll().Select(c=> new SelectListItem()
            {
                Text = c.name,
                 Value = c.Id.ToString()    
                 
            } );
            FoodTypeList = _db2.GetAll().Select(c => new SelectListItem()
            {
                Text = c.name,
                Value = c.Id.ToString()

            });
        }
        public async Task<IActionResult> OnPost(MenuItem menuItems ) 
        {
            string webRoothPath = _webHost.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(menuItems.Id == 0)
            {
                string ParenthPath = @"Images\MenuItems";
                string filename = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRoothPath,ParenthPath );
                var extension = Path.GetExtension(files[0].FileName);    
                using(var stream = new FileStream(Path.Combine(uploads,filename+extension),FileMode.Create))
                {
                    files[0].CopyTo(stream);
                    menuItems.Image = ParenthPath + filename + extension;
                    _db.Add(menuItems);
                    _db.Save();
                }

            }
            else
            {

            }
            return Page();

        }
    }
}
