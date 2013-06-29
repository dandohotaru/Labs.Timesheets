using System;
using Labs.Timesheets.Contracts.Common.Queries;
using Labs.Timesheets.Contracts.Core.Queries;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Core.Handlers;

namespace Labs.Timesheets.Domain
{
    public class Reader : IReader
    {
        public Reader(Func<IStorageAdapter> contextBuilder)
        {
            ContextBuilder = contextBuilder;
        }

        protected Func<IStorageAdapter> ContextBuilder { get; set; }

        public TResult Execute<TResult>(IQuery<TResult> query) where TResult : IResult
        {
            using (var context = ContextBuilder())
            {
                var instance = (dynamic) this;
                return instance.When((dynamic) query, context);
            }
        }

        public FindProjectsByIdsResult When(FindProjectsByIdsQuery query, IStorageAdapter context)
        {
            return new ProjectReadHandler(context).Handle(query);
        }

        public FindProjectsByTextResult When(FindProjectsByTextQuery query, IStorageAdapter context)
        {
            return new ProjectReadHandler(context).Handle(query);
        }
    }
}