using System;
using Labs.Timesheets.Adapters.Resolvers;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Reports.Common.Handlers;
using Labs.Timesheets.Reports.Common.Queries;

namespace Labs.Timesheets.Adapters.Dispatchers
{
    public class Reader : IReader
    {
        public Reader(Func<IStorage> context, IResolver resolver)
        {
            Context = context;
            Resolver = resolver;
        }

        protected Func<IStorage> Context { get; private set; }

        protected IResolver Resolver { get; private set; }

        public TResult Fetch<TResult>(IQuery<TResult> query) where TResult : IResult
        {
            using (Context())
            {
                var type = typeof (IReadHandler<,>).MakeGenericType(query.GetType(), typeof (TResult));
                var handler = (dynamic) Resolver.Get(type);
                var result = (TResult) handler.Handle((dynamic) query);

                return result;
            }
        }
    }
}