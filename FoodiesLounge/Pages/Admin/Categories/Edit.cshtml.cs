
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.Admin.Categories
{
 
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category  Category { get; set; }
        private ICategoryRepo _db;
        public EditModel(ICategoryRepo db)
        {
            _db = db;
        }
        public async void OnGet(int id)
        {
            Category =  _db.GetFirstOrDefault(u => u.Id == id);

        }
        public async Task<IActionResult> OnPost( Category category)
        {
            if(ModelState.IsValid)
            {
                 _db.Update(category);
                 _db.Save();
                TempData["Success"] = "Category successfully Upadted";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
