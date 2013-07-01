using System.Linq;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Tracking.Entities;
using Labs.Timesheets.Reports.Common.Handlers;
using Labs.Timesheets.Reports.Tracking.Models;
using Labs.Timesheets.Reports.Tracking.Queries;

namespace Labs.Timesheets.Reports.Tracking.Handlers
{
    public class TagReadHandler
        : IReadHandler<FindTagsByIdsQuery, FindTagsByIdsResult>,
          IReadHandler<FindTagsByTextQuery, FindTagsByTextResult>
    {
        public TagReadHandler(IStorageAdapter context)
        {
            Context = context;
        }

        protected IStorageAdapter Context { get; set; }

        public FindTagsByIdsResult Handle(FindTagsByIdsQuery request)
        {
            var query = from tag in Context.Query<Tag>()
                        where request.TagIds.Contains(tag.Id)
                        select tag;

            var views = from tag in query
                        select new TagDetail
                                   {
                                       TagId = tag.Id,
                                       TagName = tag.Name,
                                   };

            return new FindTagsByIdsResult().Add(views);
        }

        public FindTagsByTextResult Handle(FindTagsByTextQuery request)
        {
            var query = from tag in Context.Query<Tag>()
                        where tag.Name == request.SearchText
                              || tag.Name == request.SearchText
                        select tag;

            var views = from tag in query
                        select new TagBrief
                                   {
                                       TagId = tag.Id,
                                       TagName = tag.Name,
                                   };

            return new FindTagsByTextResult().Add(views);
        }
    }
}