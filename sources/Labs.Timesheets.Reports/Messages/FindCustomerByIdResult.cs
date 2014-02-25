using Labs.Timesheets.Reports.Common;
using Labs.Timesheets.Reports.Models;

namespace Labs.Timesheets.Reports.Messages
{
    public class FindCustomerByIdResult : Result
    {
        public CustomerModel Timesheet { get; set; }
    }
}