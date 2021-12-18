using FoodiesLounge.Datas;
using FoodiesLounge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodiesLounge.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public IEnumerable<Category>  Categories { get; set;}

        public IndexModel( AppDbContext appDb)
        {
            _db = appDb;
        }
        public void OnGet()
        {
            Categories = _db.Categories;
        }
    }
}
