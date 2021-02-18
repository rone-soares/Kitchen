using Library.Entities;

namespace Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }

        public EntityBase()
        { }

        public EntityBase(int id)
        {
            Id = id;
        }
    }
}
