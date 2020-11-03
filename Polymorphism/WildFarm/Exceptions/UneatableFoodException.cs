using System;

namespace WildFarm.Exceptions
{
    public class UneatableFoodException : Exception
    {
        public UneatableFoodException(string message)
        :base(message)
        {
            
        }
    }
}
