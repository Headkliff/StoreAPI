using System.ComponentModel.DataAnnotations;

namespace Store.Entity.Models
{
    public class User : EntityBase
    {
        [MaxLength(16), MinLength(4)]
        public string Nickname { get; set; }
        [MaxLength(16), MinLength(8)]
        public string Password { get; set; }
        public string Email { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string SecondName { get; set; }
    }
}
