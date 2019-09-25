using System.Net.Mail;

namespace Store.BL.Models
{
    public class Register
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
