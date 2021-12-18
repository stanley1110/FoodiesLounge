
using FoodiesLoungeDataAccess;
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
        private readonly AppDbContext _db;
        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            category = _db.Categories.Find(id);
        }
        public async Task<IActionResult> OnPost(Category category)
        {
            
               
                    _db.Categories.Remove(category);
                    await _db.SaveChangesAsync();
                TempData["Success"] = "Category successfully Deleted";
                    return RedirectToPage("Index");

                

                
            
            return Page();
        }
    }
}
