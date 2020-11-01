using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string DefExcMsg = "Invalid mission state!";

        public InvalidStateException()
            : base(DefExcMsg)
        {

        }

        public InvalidStateException(string message)
            : base(message)
        {

        }
    }
}