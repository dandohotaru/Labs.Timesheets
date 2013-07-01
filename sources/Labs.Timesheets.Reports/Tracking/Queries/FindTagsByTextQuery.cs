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

    public class FindTagsByTextResult : ResultBase, IEnumerable<TagBrief>
    {
        public List<TagBrief> Tags { get; private set; }

        public FindTagsByTextResult Add(TagBrief tag)
        {
            if (Tags == null)
                Tags = new List<TagBrief>();
            Tags.Add(tag);
            return this;
        }

        public FindTagsByTextResult Add(IEnumerable<TagBrief> tags)
        {
            if (Tags == null)
                Tags = new List<TagBrief>();
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
            return this;
        }

        public IEnumerator<TagBrief> GetEnumerator()
        {
            if (Tags == null)
                Tags = new List<TagBrief>();
            return Tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}