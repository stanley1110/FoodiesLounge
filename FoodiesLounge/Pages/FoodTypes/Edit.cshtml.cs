
using FoodiesLoungeDataAccess;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.FoodTypes
{
 
    public class EditModel : PageModel
    {
        [BindProperty]
        public FoodType  Food { get; set; }
        private readonly AppDbContext _db;
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        public async void OnGet(int id)
        {
            Food =  _db.FoodTypes.Find(id);

        }
        public async Task<IActionResult> OnPost( )
        {
            if(ModelState.IsValid)
            {
                 _db.FoodTypes.Update(Food);
                await _db.SaveChangesAsync();
                TempData["Success"] = $"{Food.name} record  successfully updated";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
