using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        /// <summary>
        /// Check all object's properties for custom attributes and if all custom attributes are valid, then the whole object is valid
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var objType = obj.GetType();
            var properties = objType.GetProperties();

            // If all properties are valid with their custom attributes -> Object is Valid
            foreach (PropertyInfo property in properties)
            {
                var attributes = property.GetCustomAttributes()
                    .Where(ca => ca is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                if (attributes.Any(attribute => !attribute.IsValid(property.GetValue(obj))))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
