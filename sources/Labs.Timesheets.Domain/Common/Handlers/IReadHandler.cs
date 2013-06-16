using Labs.Timesheets.Contracts.Common.Queries;

namespace Labs.Timesheets.Domain.Common.Handlers
{
    public interface IReadHandler<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
        where TResult : IResult
    {
        TResult Handle(TQuery query);
    }
}