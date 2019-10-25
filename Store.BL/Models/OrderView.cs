using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Store.Entity.Models;

namespace Store.BL.Models
{
    public class OrderView
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public ICollection<ItemOrder> Items { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
