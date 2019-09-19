using System;

namespace Store.Entity.Models
{
    public class User : EntityBase
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Role { get; set; }

        public User(long id,string nickname, string password, string firstName, string secondName, string role)
        {
            Id = id;
            Nickname = nickname;
            Password = password;
            FirstName = firstName;
            SecondName = secondName;
            Role = role;
            CreateDateTime = DateTime.Now;
            UpdateDateTime = null;
        }
    }
}
