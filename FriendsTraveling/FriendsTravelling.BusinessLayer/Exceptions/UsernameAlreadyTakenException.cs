using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsTraveling.BusinessLayer.Exceptions
{
    public class UsernameAlreadyTakenException : Exception
    {
        private const String MESSAGE = "Username was already taken.";

        public UsernameAlreadyTakenException()
            : base(MESSAGE) { }

        public UsernameAlreadyTakenException(String message)
            : base(message) { }
    }
}
