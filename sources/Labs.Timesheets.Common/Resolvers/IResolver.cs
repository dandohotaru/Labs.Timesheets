using System;

namespace Labs.Timesheets.Common.Resolvers
{
    public interface IResolver
    {
        object Get(Type type);

        T Get<T>();
    }
}