using System;

namespace Library.Entities
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IgnoreNullValueAttribute : Attribute
    {
        public IgnoreNullValueAttribute()
        {
        }
    }
}
