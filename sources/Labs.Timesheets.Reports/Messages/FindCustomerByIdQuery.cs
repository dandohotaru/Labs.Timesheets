using System;
using Labs.Timesheets.Reports.Common;

namespace Labs.Timesheets.Reports.Messages
{
    public class FindCustomerByIdQuery : Query<FindCustomerByIdResult>
    {
        public Guid TimesheetId { get; set; }
    }
}