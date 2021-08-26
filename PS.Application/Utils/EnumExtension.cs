using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace PS.Application.Utils
{
    public static class EnumExtension
    {
        /// <summary>
        /// Extension for enum types that will return the Display Name value.
        /// </summary>
        /// <param name="enumValue">The enum type</param>
        /// <returns>The value from Display Name annotation.</returns>
        public static string DisplayName(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Name;
            else
                return value.ToString();
        }
    }
}
