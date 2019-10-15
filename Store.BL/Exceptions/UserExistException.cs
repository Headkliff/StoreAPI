using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BL.Exceptions
{
    [Serializable]
    public class UserExistException:Exception
    {
        public UserExistException()
        {
        }

        public UserExistException(string message)
            : base(message)
        {
        }

        public UserExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
