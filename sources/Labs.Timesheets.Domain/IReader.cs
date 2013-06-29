using Labs.Timesheets.Contracts.Common.Queries;

namespace Labs.Timesheets.Domain
{
    public interface IReader
    {
        TResult Execute<TResult>(IQuery<TResult> query) where TResult : IResult;
    }
}