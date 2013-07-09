using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Handlers;
using Labs.Timesheets.Reports.Tracking.Queries;

namespace Labs.Timesheets.Reports
{
    public class Reader : IReader
    {
        public Reader(Func<IStorage> contextBuilder)
        {
            ContextBuilder = contextBuilder;
        }

        protected Func<IStorage> ContextBuilder { get; set; }

        public TResult Execute<TResult>(IQuery<TResult> query) where TResult : IResult
        {
            using (var context = ContextBuilder())
            {
                var instance = (dynamic) this;
                return instance.When((dynamic) query, context);
            }
        }

        public FindTagsByIdsResult When(FindTagsByIdsQuery query, IStorage context)
        {
            return new TagReadHandler(context).Handle(query);
        }

        public FindTagsByTextResult When(FindTagsByTextQuery query, IStorage context)
        {
            return new TagReadHandler(context).Handle(query);
        }

        public FindActivitiesByDateResult When(FindActivitiesByDateQuery query, IStorage context)
        {
            return new ActivityReadHandler(context).Handle(query);
        }
    }
}