
using FoodiesLoungeDataAccess;
using FoodiesLoungeDataAccess.Repository;
using FoodiesLoungeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodiesLounge.Pages.Admin.FoodTypes
{
 
    public class EditModel : PageModel
    {
        [BindProperty]
        public FoodType  Food { get; set; }
        private IFoodTypeRepo _db;
        public EditModel(IFoodTypeRepo db)
        {
            _db = db;
        }
        public async void OnGet(int id)
        {
            Food =  _db.GetFirstOrDefault(u=> u.Id == id);

        }
        public async Task<IActionResult> OnPost( )
        {
            if(ModelState.IsValid)
            {
                 _db.Update(Food);
                 _db.Save();
                TempData["Success"] = $"{Food.name} record  successfully updated";
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
