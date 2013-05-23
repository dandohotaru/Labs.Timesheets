using System;

namespace Labs.Timesheets.Domain.Common.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}