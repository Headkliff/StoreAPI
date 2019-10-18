using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BL.Exceptions
{
    [Serializable]
    public class ItemDoseNotExistException :Exception
    {
        public ItemDoseNotExistException()
        {
        }

        public ItemDoseNotExistException(string message)
            : base(message)
        {
        }

        public ItemDoseNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
