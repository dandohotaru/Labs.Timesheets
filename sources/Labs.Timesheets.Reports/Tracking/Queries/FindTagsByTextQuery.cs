using System.Collections;
using System.Collections.Generic;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Models;

namespace Labs.Timesheets.Reports.Tracking.Queries
{
    public class FindTagsByTextQuery : QueryBase<FindTagsByTextResult>
    {
        public string SearchText { get; set; }
    }

    public class FindTagsByTextResult : ResultBase, IEnumerable<TagInfo>
    {
        public List<TagInfo> Tags { get; private set; }

        public FindTagsByTextResult Add(TagInfo tag)
        {
            if (Tags == null)
                Tags = new List<TagInfo>();
            Tags.Add(tag);
            return this;
        }

        public FindTagsByTextResult Add(IEnumerable<TagInfo> tags)
        {
            if (Tags == null)
                Tags = new List<TagInfo>();
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
            return this;
        }

        public IEnumerator<TagInfo> GetEnumerator()
        {
            if (Tags == null)
                Tags = new List<TagInfo>();
            return Tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}