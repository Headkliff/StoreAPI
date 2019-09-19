using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.BL.Models
{
    public class RequestToken
    {
        [Required]
        [MaxLength(256)]
        public string Nickname { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
