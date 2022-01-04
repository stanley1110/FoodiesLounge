﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeModel
{
    public class ShoppingCart
    {
		public int Id { get; set; }
		public int MenuItemId { get; set; }
		[ForeignKey("MenuItemId")]
		[ValidateNever]
		public MenuItem MenuItem { get; set; }

		[Range(1, 100, ErrorMessage = "Please select a count between 1 and 100")]
		public int Count { get; set; }
		public string IdentityUserId { get; set; }
		[ForeignKey("IdentityUserId")]
		[ValidateNever]
		public IdentityUser user { get; set; }
	}
}
