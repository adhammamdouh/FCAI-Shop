using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FCAI_Shop.Utilities
{
    /// <summary>
    /// Specifies that a data field value is unique across the table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueKeyAttribute : ValidationAttribute
    {
        public static bool IsUniqueKeyAttribute(IMutableEntityType entityType, IMutableProperty property)
        {
            if (entityType == null)
                throw new ArgumentNullException(nameof(entityType));
            else if (entityType.ClrType == null)
                throw new ArgumentNullException(nameof(entityType.ClrType));
            else if (property == null)
                throw new ArgumentNullException(nameof(property));
            else if (property.Name == null)
                throw new ArgumentNullException(nameof(property.Name));

            var propInfo = entityType.ClrType.GetProperty(
                property.Name,
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly);
            return propInfo != null && propInfo.GetCustomAttribute<UniqueKeyAttribute>() != null;
        }
    }

}