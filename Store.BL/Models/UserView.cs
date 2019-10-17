using System.ComponentModel.DataAnnotations;

namespace Store.BL.Models
{
    public class UserView
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public bool IsDeleted { get; set; }
        public string Role { get; set; }
    }
}
