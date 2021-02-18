using System;

namespace Library.Entities
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ColumnNameAttribute : Attribute
    {
        public string DisplayName { get; }
        public string ColumnName { get; }

        public ColumnNameAttribute(string displayName, string columnName)
        {
            this.DisplayName = displayName.ToLower();
            this.ColumnName = columnName.ToLower();
        }
    }
}
