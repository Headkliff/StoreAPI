using System.ComponentModel.DataAnnotations;

namespace Store.BL.Models
{
    public class Register
    {
        public string Nickname { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
