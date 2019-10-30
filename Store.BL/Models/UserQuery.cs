using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BL.Models
{
    public class UserQuery
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public int PageNumber { get; set; }
    }
}
