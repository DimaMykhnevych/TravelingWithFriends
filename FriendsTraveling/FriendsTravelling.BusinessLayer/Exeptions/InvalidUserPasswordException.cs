using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsTraveling.BusinessLayer.Exeptions
{
    public class InvalidUserPasswordException : Exception
    {
        private const String MESSAGE = "Invalid user password.";

        public InvalidUserPasswordException()
            : base(MESSAGE) { }

        public InvalidUserPasswordException(String message)
            : base(message) { }
    }
}
