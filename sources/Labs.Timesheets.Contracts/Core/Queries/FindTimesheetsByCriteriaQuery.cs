using System;
using System.Collections.Generic;
using Labs.Timesheets.Contracts.Common.Queries;
using Labs.Timesheets.Contracts.Common.Values;
using Labs.Timesheets.Contracts.Core.Models;

namespace Labs.Timesheets.Contracts.Core.Queries
{
    public class FindTimesheetsByCriteriaQuery : QueryBase
    {
        public Guid? OwnerId { get; protected set; }

        public DateRange Coverage { get; protected set; }

        public string SearchText { get; protected set; }

        public FindTimesheetsByCriteriaQuery ApplyOwner(Guid ownerId)
        {
            OwnerId = ownerId;
            return this;
        }

        public FindTimesheetsByCriteriaQuery ApplyCoverage(DateRange coverage)
        {
            Coverage = coverage;
            return this;
        }

        public FindTimesheetsByCriteriaQuery ApplySearch(string searchText)
        {
            SearchText = searchText;
            return this;
        }
    }

    public class FindTimesheetsByCriteriaResult : ResultBase
    {
        public List<TimesheetBrief> Timesheets { get; protected set; }

        public FindTimesheetsByCriteriaResult Add(IEnumerable<TimesheetBrief> timesheets)
        {
            if (Timesheets == null)
                Timesheets = new List<TimesheetBrief>();
            Timesheets.AddRange(timesheets);
            return this;
        }

        public FindTimesheetsByCriteriaResult Add(TimesheetBrief timesheet)
        {
            return Add(new List<TimesheetBrief> { timesheet });
        }
    }
}