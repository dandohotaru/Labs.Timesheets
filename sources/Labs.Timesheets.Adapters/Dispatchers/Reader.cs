using Labs.Timesheets.Common.Resolvers;
using Labs.Timesheets.Reports.Common.Handlers;
using Labs.Timesheets.Reports.Common.Queries;

namespace Labs.Timesheets.Adapters.Dispatchers
{
    public class Reader : IReader
    {
        public Reader(IResolver resolver)
        {
            Resolver = resolver;
        }

        protected IResolver Resolver { get; private set; }

        public TResult Fetch<TResult>(IQuery<TResult> query) where TResult : IResult
        {
            var type = typeof (IReadHandler<,>).MakeGenericType(query.GetType(), typeof (TResult));
            var handler = (dynamic) Resolver.Get(type);
            var result = (TResult) handler.Handle((dynamic) query);

            return result;
        }
    }
}