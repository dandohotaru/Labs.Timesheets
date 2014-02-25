using System.Collections.Generic;
using Labs.Timesheets.Reports.Common;
using Labs.Timesheets.Reports.Models;

namespace Labs.Timesheets.Reports.Messages
{
    public class FindTagsByIdsResult : Result
    {
        public List<TagModel> Tags { get; set; }
    }

    public static class FindTagsByIdsExtensions
    {
        public static FindTagsByIdsResult AddTags(this FindTagsByIdsResult instance, IEnumerable<TagModel> tags)
        {
            if (tags != null)
            {
                if (instance.Tags == null)
                    instance.Tags = new List<TagModel>();
                instance.Tags.AddRange(tags);
            }
            return instance;
        }
    }
}