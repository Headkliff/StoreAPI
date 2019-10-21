using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Entity.Models
{
    public class EntityBase
    {
        [Key]
        [Required]
        public long Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
