using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Store.Entity.Models
{
    public class ItemType: EntityBase
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }

        public ItemType()
        {
            Items = new List<Item>();
        }
    }
}
