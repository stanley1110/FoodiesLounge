
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
       
        public FoodType   FoodType { get; set; }
        private IFoodTypeRepo _db;
        public CreateModel(IFoodTypeRepo db)
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
                 _db.Add(foodType);
                 _db.Save();
                TempData["Success"] = $"{foodType.name} record successfully created";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
