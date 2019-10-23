using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.BL.Models
{
    public class TypeView
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
