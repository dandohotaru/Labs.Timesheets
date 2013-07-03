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

    public class FindTagsByIdsResult : ResultBase, IEnumerable<TagInfo>
    {
        public List<TagInfo> Tags { get; private set; }

        public FindTagsByIdsResult Add(TagInfo tag)
        {
            if (Tags == null)
                Tags = new List<TagInfo>();
            Tags.Add(tag);
            return this;
        }

        public FindTagsByIdsResult Add(IEnumerable<TagInfo> tags)
        {
            if (Tags == null)
                Tags = new List<TagInfo>();
            foreach (var project in tags)
            {
                Tags.Add(project);
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