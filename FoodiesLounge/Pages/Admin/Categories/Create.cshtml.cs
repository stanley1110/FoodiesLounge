
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
       
        public Category  Category { get; set; }
        private ICategoryRepo   _db;
        public CreateModel(ICategoryRepo db)
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
                 _db.Add(category);
                 _db.Save();
                TempData["Success"] = $"{category.name} record Category successfully created";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
