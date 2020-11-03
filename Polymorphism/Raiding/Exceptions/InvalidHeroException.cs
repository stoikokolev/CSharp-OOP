using System;

namespace Raiding.Exceptions
{
    public class InvalidHeroException : Exception
    {
        private const string EXC_MSG = "Invalid hero!";
        
        public InvalidHeroException()
        :base(EXC_MSG)
        {
            
        }

        public InvalidHeroException(string msg)
            : base(msg)
        {

        }
    }
}
