using System;

namespace Labs.Timesheets.Reports.Common
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        public Guid TenantId { get; protected set; }
    }
}