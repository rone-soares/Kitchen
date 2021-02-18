using System;

namespace ApiKitchen.SwaggerExtensions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GroupSwagger : Attribute
    {
        public string GroupName { get; private set; }

        public GroupSwagger(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException(groupName);
            }

            GroupName = groupName;
        }
    }
}