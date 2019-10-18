﻿using System.ComponentModel.DataAnnotations;

namespace Store.Entity.Models
{
    public class Item : EntityBase
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        [Required]
        [MinLength(4)]
        public string Category { get; set; }
        [Required]
        [MinLength(4)]
        public string Type { get; set; }
        [Required]
        public float Cost { get; set; }
    }
}
