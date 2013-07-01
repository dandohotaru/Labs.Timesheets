﻿using System;
using System.Collections.Generic;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Models;

namespace Labs.Timesheets.Reports.Tracking.Queries
{
    public class FindTimesheetsByCriteriaQuery : QueryBase<FindTimesheetsByCriteriaResult>
    {
        public Guid? OwnerId { get; protected set; }

        public DateTimeOffset? StartDate { get; protected set; }

        public DateTimeOffset? EndDate { get; protected set; }

        public string SearchText { get; protected set; }

        public FindTimesheetsByCriteriaQuery ApplyOwner(Guid ownerId)
        {
            OwnerId = ownerId;
            return this;
        }

        public FindTimesheetsByCriteriaQuery ApplyStartDate(DateTimeOffset date)
        {
            StartDate = date;
            return this;
        }

        public FindTimesheetsByCriteriaQuery ApplyEndDate(DateTimeOffset date)
        {
            EndDate = date;
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
            return Add(new List<TimesheetBrief> {timesheet});
        }
    }
}