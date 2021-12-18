
using FoodiesLoungeDataAccess;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Pages.FoodTypes
{
 
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public FoodType  FoodType { get; set; }
        private readonly AppDbContext _db;
        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            FoodType = _db.FoodTypes.Find(id);
        }
        public async Task<IActionResult> OnPost(FoodType foodType)
        {
            
               
                    _db.FoodTypes.Remove(foodType);
                    await _db.SaveChangesAsync();
                TempData["Success"] = $"{foodType.name} record successfully deleted";
            return RedirectToPage("Index");

                

                
            
            return Page();
        }
    }
}
