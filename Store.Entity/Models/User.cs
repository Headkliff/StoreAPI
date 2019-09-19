namespace Store.Entity.Models
{
    public class User : EntityBase
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Role { get; set; }
    }
}
