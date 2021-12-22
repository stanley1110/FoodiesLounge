
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Pages.Admin.Categories
{
 
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Category category { get; set; }
        private ICategoryRepo _db;
        public DeleteModel(ICategoryRepo db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            category = _db.GetFirstOrDefault(u=> u.Id == id);
        }
        public async Task<IActionResult> OnPost(Category category)
        {
            if(category.Id != null)
            {

                _db.Remove(category);
                _db.Save();
                TempData["Success"] = "Category successfully Deleted";
                return RedirectToPage("Index");

            }

                
            
            return Page();
        }
    }
}
