using System;

namespace Store.BL.Exceptions
{
    [Serializable]
    public class BlockedUserException:Exception
    {
        public BlockedUserException()
        {
        }

        public BlockedUserException(string message)
            : base(message)
        {
        }

        public BlockedUserException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
