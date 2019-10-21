using System.ComponentModel.DataAnnotations;

namespace Store.BL.Models
{
    public class UserEdit
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
