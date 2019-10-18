using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BL.Exceptions
{
    [Serializable]
    public class ItemExistException : Exception
    {
        public ItemExistException()
        {
        }

        public ItemExistException(string message)
            : base(message)
        {
        }

        public ItemExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
