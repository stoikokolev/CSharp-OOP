using System;

namespace ValidationAttributes.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class MyValidationAttribute : Attribute
    {
        /// <summary>
        /// Accepts property value and returns boolean dependent on it's validity
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool IsValid(object obj);
    }
}
