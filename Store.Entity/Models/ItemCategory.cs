using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Entity.Models
{
    public class ItemCategory :EntityBase
    {
        [Required]
        public string Name { get; set; }

        public  ICollection<Item> Items { get; set; }

        public ItemCategory()
        {
            Items =new List<Item>();
        }
    }
}
