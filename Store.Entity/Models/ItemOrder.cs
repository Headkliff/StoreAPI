using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Entity.Models
{
    public class ItemOrder:EntityBase
    {
        [Required]
        public Item Item { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public Order Order { get; set; }
    }
}
