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
        public long ItemCategoryId { get; set; }

        [Required]
        public ItemType Type { get; set; }

        [Required]
        public long ItemTypeId { get; set; }

        [Required]
        public float Cost { get; set; }
    }
}
