
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
            string webRoothPath = _webHost.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(MenuItem.Id == 0)
            {
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRoothPath, @"Images\MenuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuItem.Image = @"\Images\MenuItems\" + fileName_new + extension;
            _db.Add(MenuItem);
                _db.Save();
                return RedirectToPage("Index"); 
            }
            else
            {
                var result = _db.GetFirstOrDefault(u => u.Id == MenuItem.Id);
                    if (files.Count> 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRoothPath, @"Images\MenuItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    var OLdImagePath = Path.Combine(webRoothPath, result.Image.TrimStart('\\'));
                    if(System.IO.File.Exists(OLdImagePath))
                    {
                        System.IO.File.Delete(OLdImagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    MenuItem.Image = @"\Images\MenuItems\" + fileName_new + extension;
                    _db.Update(MenuItem);
                    _db.Save();
                    return RedirectToPage("Index");
                }


            }
            return Page();

        }
    }
}
