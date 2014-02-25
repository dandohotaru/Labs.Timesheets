using System;
using System.Linq;

namespace Labs.Timesheets.Reports.Common
{
    public interface IReader : IDisposable
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;
    }
}