using Labs.Timesheets.Reports.Common;

namespace Labs.Timesheets.Reports.Messages
{
    public class FindTagsByTextQuery : Query<FindTagsByTextResult>
    {
        public string SearchText { get; set; }
    }
}