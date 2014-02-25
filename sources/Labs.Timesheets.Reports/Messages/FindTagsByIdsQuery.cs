using System;
using System.Collections.Generic;
using Labs.Timesheets.Reports.Common;

namespace Labs.Timesheets.Reports.Messages
{
    public class FindTagsByIdsQuery : Query<FindTagsByIdsResult>
    {
        public List<Guid> TagIds { get; set; }
    }
}