using System.Collections.Generic;
using Labs.Timesheets.Contracts.Common.Queries;
using Labs.Timesheets.Contracts.Core.Models;

namespace Labs.Timesheets.Contracts.Core.Queries
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