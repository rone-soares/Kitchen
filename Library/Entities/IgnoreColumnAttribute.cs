using System;

namespace Library.Entities
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class IgnoreColumnAttribute : Attribute
    {
        public IgnoreColumnAttribute()
        {
        }
    }
}
