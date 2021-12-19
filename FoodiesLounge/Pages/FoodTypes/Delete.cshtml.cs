
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
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
        private IFoodTypeRepo _db;
        public DeleteModel(IFoodTypeRepo db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            FoodType = _db.GetFirstOrDefault(u=> u.Id ==id);
        }
        public async Task<IActionResult> OnPost(FoodType foodType)
        {
            
               
                    _db.Remove(foodType);
                     _db.Save();
                TempData["Success"] = $"{foodType.name} record successfully deleted";
            return RedirectToPage("Index");

                

                
            
            return Page();
        }
    }
}
