using System.ComponentModel.DataAnnotations;

namespace FoodiesLoungeModel
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }

        [Display(Name ="Display Order")]
        public int DisplayOrder { get; set; }
    }
}
