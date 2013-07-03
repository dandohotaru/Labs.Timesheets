using System;

namespace Labs.Timesheets.Domain.Common.Entities
{
    public abstract class EntityBase : IEntity
    {
        protected EntityBase(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected set; }

        public Guid TenantId { get; protected set; }
    }
}