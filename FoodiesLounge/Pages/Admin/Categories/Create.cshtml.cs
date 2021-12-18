
using FoodiesLoungeDataAccess;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
       
        public Category  Category { get; set; }
        private readonly AppDbContext _db;
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost( Category category)
        {
            if(ModelState.IsValid)
            {
                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                TempData["Success"] = $"{category.name} record Category successfully created";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
