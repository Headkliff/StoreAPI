using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Store.Entity.Models
{
    public class User : EntityBase
    {
        [MaxLength(16), MinLength(4),Required]
        public string Nickname { get; set; }
        [MaxLength(16), MinLength(8), Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string SecondName { get; set; }
    }
}
