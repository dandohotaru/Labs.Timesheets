using Labs.Timesheets.Reports.Common.Queries;

namespace Labs.Timesheets.Reports.Common.Handlers
{
    public interface IReadHandler<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
        where TResult : IResult
    {
        TResult Handle(TQuery request);
    }
}