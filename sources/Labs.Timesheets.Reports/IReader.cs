using Labs.Timesheets.Reports.Common.Queries;

namespace Labs.Timesheets.Reports
{
    public interface IReader
    {
        TResult Fetch<TResult>(IQuery<TResult> query) where TResult : IResult;
    }
}