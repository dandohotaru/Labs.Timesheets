using System;
using Labs.Timesheets.Reports;
using Labs.Timesheets.Reports.Common;
using Ninject;
using Ninject.Parameters;

namespace Labs.Timesheets.Adapters.Dispatchers
{
    public class Querier : IQuerier
    {
        public Querier(Func<IReader> context, IKernel resolver)
        {
            Context = context;
            Resolver = resolver;
        }

        protected Func<IReader> Context { get; private set; }

        protected IKernel Resolver { get; private set; }

        public TResult Search<TResult>(IQuery<TResult> query) where TResult : IResult
        {
            using (var context = Context())
            {
                var contextParameter = new ConstructorArgument("context", context);
                var handlerType = typeof (IHandler<,>).MakeGenericType(query.GetType(), typeof (TResult));
                var handler = (dynamic) Resolver.Get(handlerType, contextParameter);
                var result = (TResult) handler.Handle((dynamic) query);

                return result;
            }
        }
    }
}