using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Entity.Models
{
    public class Item : EntityBase
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        public ItemCategory Category { get; set; }

        [Required]
        public ItemType Type { get; set; }

        [Required]
        public float Cost { get; set; }

        public ICollection<ItemOrder> Orders { get; set; }

        public Item() 
        {
            Orders = new List<ItemOrder>();
        }
    }
}
