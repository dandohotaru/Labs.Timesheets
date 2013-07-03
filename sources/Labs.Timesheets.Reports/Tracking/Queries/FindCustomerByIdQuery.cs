using System;
using Labs.Timesheets.Reports.Common.Queries;
using Labs.Timesheets.Reports.Tracking.Models;

namespace Labs.Timesheets.Reports.Tracking.Queries
{
    public class FindCustomerByIdQuery : QueryBase<FindCustomerByIdResult>
    {
        public Guid TimesheetId { get; set; }
    }

    public class FindCustomerByIdResult : ResultBase
    {
        public CustomerInfo Timesheet { get; protected set; }

        public FindCustomerByIdResult Set(CustomerInfo detail)
        {
            Timesheet = detail;
            return this;
        }
    }
}