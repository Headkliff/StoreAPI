using System.ComponentModel.DataAnnotations;

namespace Store.BL.Models
{
    public class Login
    {
        [Required]
        [MaxLength(256)]
        public string Nickname { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
