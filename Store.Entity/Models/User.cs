using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Entity.Models
{
    public class User : EntityBase
    {
        [MaxLength(16), MinLength(4), Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [MaxLength(25), Required]
        public string FirstName { get; set; }
        [MaxLength(25), Required]
        public string SecondName { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public string Role { get; set; }

        public ICollection<Order> Orders { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }
    }
}
