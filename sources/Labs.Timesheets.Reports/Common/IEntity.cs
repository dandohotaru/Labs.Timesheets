using System;

namespace Labs.Timesheets.Reports.Common
{
    public interface IEntity
    {
        Guid Id { get; }

        Guid TenantId { get; }
    }
}