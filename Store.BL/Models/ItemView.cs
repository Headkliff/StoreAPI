using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        [MinLength(4)]
        public string Category { get; set; }
        [Required]
        [MinLength(4)]
        public string Type { get; set; }
        [Required]
        public float Cost { get; set; }
    }
}
