using System;

namespace Labs.Timesheets.Domain.Common
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
        }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected set; }

        public Guid TenantId { get; protected set; }
    }
}