﻿using System;

namespace Labs.Timesheets.Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; }

        Guid TenantId { get; }
    }
}