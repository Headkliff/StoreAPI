using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Entity.Models
{
    public class Order:EntityBase
    {
        [Required]
        public User User { get; set; }

        [Required]
        public ICollection<ItemOrder> Items { get; set; }

        [Required]
        public string Status { get; set; }


        public Order()
        {
            Items = new List<ItemOrder>();
        }
    }
}
