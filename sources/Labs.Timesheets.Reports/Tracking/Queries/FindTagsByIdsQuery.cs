using System;
using System.Collections;
using System.Collections.Generic;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Models;

namespace Labs.Timesheets.Reports.Tracking.Queries
{
    public class FindTagsByIdsQuery : QueryBase<FindTagsByIdsResult>
    {
        public List<Guid> TagIds { get; private set; }

        public FindTagsByIdsQuery AddTagId(Guid tagId)
        {
            if (TagIds == null)
                TagIds = new List<Guid>();
            if (!TagIds.Contains(tagId))
                TagIds.Add(tagId);
            return this;
        }
    }

    public class FindTagsByIdsResult : ResultBase, IEnumerable<TagDetail>
    {
        public List<TagDetail> Tags { get; private set; }

        public FindTagsByIdsResult Add(TagDetail tag)
        {
            if (Tags == null)
                Tags = new List<TagDetail>();
            Tags.Add(tag);
            return this;
        }

        public FindTagsByIdsResult Add(IEnumerable<TagDetail> tags)
        {
            if (Tags == null)
                Tags = new List<TagDetail>();
            foreach (var project in tags)
            {
                Tags.Add(project);
            }
            return this;
        }

        public IEnumerator<TagDetail> GetEnumerator()
        {
            if (Tags == null)
                Tags = new List<TagDetail>();
            return Tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}