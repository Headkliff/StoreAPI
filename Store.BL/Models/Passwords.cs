using System.ComponentModel.DataAnnotations;

namespace Store.BL.Models
{
    public class Passwords
    {
        [Required, MinLength(8)]
        public string Password { get; set; }
        [Required, MinLength(8)]
        public string NewPassword { get; set; }
    }
}
