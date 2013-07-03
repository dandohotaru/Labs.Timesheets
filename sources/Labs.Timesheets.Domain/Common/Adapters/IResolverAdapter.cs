using System;

namespace Labs.Timesheets.Domain.Common.Adapters
{
    public interface IResolverAdapter
    {
        object Get(Type type);

        T Get<T>();
    }
}