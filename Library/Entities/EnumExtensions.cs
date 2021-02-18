using Library.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Library.Entities
{
    public static class EnumExtensions<T>
    {
        public static string GetEnumDescription(string value)
        {
            Type type = typeof(T);

            var name = Enum.GetNames(type)
                .Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                .Select(d => d)
                .FirstOrDefault();

            if (name == null)
            {
                return string.Empty;
            }

            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute) customAttribute[0]).Description : name;
        }

        public static List<T> ToList<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException(MessageResource.TMustBeOfTypeSystemEnum);
            }

            Array enumValArray = Enum.GetValues(enumType);

            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }
    }
}