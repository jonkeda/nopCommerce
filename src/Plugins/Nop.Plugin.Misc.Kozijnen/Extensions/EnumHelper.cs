﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nop.Plugin.Misc.Kozijnen.Extensions
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        /// <example><![CDATA[string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;]]></example>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            if (enumVal == null)
            {
                return null;
            }
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string ToText(this Enum enumVal)
        {
            var attribute = GetAttributeOfType<DisplayAttribute>(enumVal);
            if (attribute == null)
            {
                return enumVal.ToString();
            }

            return attribute.Name;
        }

        public static void AddLine(this StringBuilder sb, Enum enumVal)
        {
            sb.AppendLine(enumVal.ToText());
        }

        public static void AddLine(this StringBuilder sb, string field, Enum enumVal)
        {
            sb.AppendLine($"{field} {enumVal.ToText()}");
        }
    }
}