using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null) return false;

            Type type = obj.GetType();
            foreach (PropertyInfo property in type.GetProperties())
            {
                MyValidationAttribute[] validationAttributes =
                     property.GetCustomAttributes<MyValidationAttribute>().ToArray();
                if (validationAttributes.Length == 0) continue;

                object value = property.GetValue(obj);

                foreach (MyValidationAttribute attribute in validationAttributes)
                {
                    bool isValid = attribute.IsValid(value);
                    if (!isValid) return false;
                }

            }

            return true;
        }
    }
}