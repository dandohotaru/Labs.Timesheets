using System;

namespace Labs.Timesheets.Adapters.Resolvers
{
    public interface IResolver
    {
        object Get(Type type);

        T Get<T>();
    }
}