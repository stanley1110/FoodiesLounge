
using FoodiesLoungeDataAccess;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
       
        public FoodType   FoodType { get; set; }
        private readonly AppDbContext _db;
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost( FoodType  foodType)
        {
            if(ModelState.IsValid)
            {
                await _db.FoodTypes.AddAsync(foodType);
                await _db.SaveChangesAsync();
                TempData["Success"] = $"{foodType.name} record successfully created";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
