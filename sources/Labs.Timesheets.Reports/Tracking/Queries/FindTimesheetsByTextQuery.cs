using System.Collections.Generic;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Models;

namespace Labs.Timesheets.Reports.Tracking.Queries
{
    public class FindTimesheetsByTextQuery : QueryBase<FindTimesheetsByTextResult>
    {
        public string SearchText { get; set; }
    }

    public class FindTimesheetsByTextResult : ResultBase
    {
        public List<TimesheetBrief> Timesheets { get; private set; }

        public FindTimesheetsByTextResult Add(IEnumerable<TimesheetBrief> timesheets)
        {
            if (Timesheets == null)
                Timesheets = new List<TimesheetBrief>();
            Timesheets.AddRange(timesheets);
            return this;
        }

        public FindTimesheetsByTextResult Add(TimesheetBrief timesheet)
        {
            return Add(new List<TimesheetBrief> {timesheet});
        }
    }
}