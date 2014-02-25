using System;
using Labs.Timesheets.Reports.Common;

namespace Labs.Timesheets.Reports.Messages
{
    public class FindActivitiesByDateQuery : Query<FindActivitiesByDateQuery, FindActivitiesByDateResult>
    {
        public DateTime Date { get; set; }
    }
}