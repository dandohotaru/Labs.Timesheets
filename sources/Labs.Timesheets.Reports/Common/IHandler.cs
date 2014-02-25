namespace Labs.Timesheets.Reports.Common
{
    public interface IHandler<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
        where TResult : IResult
    {
        TResult Handle(TQuery request);
    }
}