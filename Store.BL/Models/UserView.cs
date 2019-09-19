using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BL.Models
{
    public class UserView
    {
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
