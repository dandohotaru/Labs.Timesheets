using System.Linq;
using Labs.Timesheets.Reports.Common;
using Labs.Timesheets.Reports.Entities;
using Labs.Timesheets.Reports.Messages;
using Labs.Timesheets.Reports.Models;

namespace Labs.Timesheets.Reports.Handlers
{
    public class TagReadHandler
        : IHandler<FindTagsByIdsQuery, FindTagsByIdsResult>,
          IHandler<FindTagsByTextQuery, FindTagsByTextResult>
    {
        public TagReadHandler(IReader context)
        {
            Context = context;
        }

        protected IReader Context { get; set; }

        public FindTagsByIdsResult Handle(FindTagsByIdsQuery request)
        {
            var query = from tag in Context.Query<Tag>()
                        where request.TagIds.Contains(tag.Id)
                        select tag;

            var views = from tag in query
                        select new TagModel
                            {
                                TagId = tag.Id,
                                TagName = tag.Name,
                            };

            return new FindTagsByIdsResult().AddTags(views);
        }

        public FindTagsByTextResult Handle(FindTagsByTextQuery request)
        {
            var query = from tag in Context.Query<Tag>()
                        where tag.Name == request.SearchText
                              || tag.Name == request.SearchText
                        select tag;

            var views = from tag in query
                        select new TagModel
                            {
                                TagId = tag.Id,
                                TagName = tag.Name,
                            };

            return new FindTagsByTextResult().AddTags(views);
        }
    }
}