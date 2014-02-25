using Labs.Timesheets.Reports.Common;

namespace Labs.Timesheets.Reports
{
    public interface IQuerier
    {
        TResult Search<TResult>(IQuery<TResult> query) where TResult : IResult;
    }
}