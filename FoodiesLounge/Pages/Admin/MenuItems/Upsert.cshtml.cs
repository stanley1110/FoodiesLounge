
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using FoodiesLoungeUtilities;
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
        [BindProperty]
        public MenuItem   MenuItem { get; set;}
        public IEnumerable<SelectListItem>  CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel( IMenuItemRepo appDb,ICategoryRepo db1, IFoodTypeRepo db2, IWebHostEnvironment webHost )
        {
            _db = appDb;
            _db1 = db1;
            _db2 = db2;
            _webHost = webHost;
            MenuItem = new();
        }
        public void OnGet(int? id)
        {
            if(id != null)
            {
                MenuItem = _db.GetFirstOrDefault(u => u.Id == id);
            }
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
        public  IActionResult OnPost() 
        {

            var webRoothPath = _webHost.WebRootPath;
            string fileName_new = Guid.NewGuid().ToString();
         
            var uploads = Path.Combine(webRoothPath, @"Images\MenuItems");
           
            if (MenuItem.Id == 0)
            {
                var files = HttpContext.Request.Form.Files;
                var extension = Path.GetExtension(files[0].FileName);

                Utility.fileupload(MenuItem, fileName_new,files,extension,uploads);
                MenuItem.Image = @"\Images\MenuItems\" + fileName_new + extension;
            _db.Add(MenuItem);
                _db.Save();
                return RedirectToPage("Index"); 
            }
            else
            {
                var files = HttpContext.Request.Form.Files;
               

                var menuItem = _db.GetFirstOrDefault(u => u.Id == MenuItem.Id);
                if (files.Count > 0)
                {
                    var extension = Path.GetExtension(files[0].FileName);
                    if (menuItem.Image != null)
                    {
                        Utility.filedelete(menuItem, fileName_new, files, extension, uploads, webRoothPath);
                    }
                  
                    MenuItem.Image = @"\Images\MenuItems\" + fileName_new + extension;
                    Utility.fileupload(MenuItem, fileName_new, files, extension, uploads);
                }
               
                
                    _db.Update(MenuItem);
                    _db.Save();
                    return RedirectToPage("Index");
                


            }
            return Page();

        }
    }
}
