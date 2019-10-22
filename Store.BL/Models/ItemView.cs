﻿using System.ComponentModel.DataAnnotations;

namespace Store.BL.Models
{
    public class ItemView
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        public long ItemCategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        
        [Required]
        public long ItemTypeId { get; set; }

        [Required]
        public string TypeName { get; set; }

        [Required]
        public float Cost { get; set; }
    }
}
