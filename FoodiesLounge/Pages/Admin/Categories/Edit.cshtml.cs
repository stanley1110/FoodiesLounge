
using FoodiesLoungeDataAccess;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.Admin.Categories
{
 
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category  Category { get; set; }
        private readonly AppDbContext _db;
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        public async void OnGet(int id)
        {
            Category =  _db.Categories.Find(id);

        }
        public async Task<IActionResult> OnPost( Category category)
        {
            if(ModelState.IsValid)
            {
                 _db.Categories.Update(category);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Category successfully Upadted";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
