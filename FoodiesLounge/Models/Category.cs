﻿using System.ComponentModel.DataAnnotations;

namespace FoodiesLounge.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }

        [Display(Name ="Display Order")]
        public string DisplayOrder { get; set; }
    }
}
