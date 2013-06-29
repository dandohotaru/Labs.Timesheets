using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Handlers;
using Labs.Timesheets.Reports.Tracking.Queries;

namespace Labs.Timesheets.Reports
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