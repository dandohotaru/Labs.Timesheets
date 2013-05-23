namespace Labs.Timesheets.Contracts.Common.Queries
{
    public static class Extensions
    {
        public static TResult Return<TResult>(this IResult instance)
            where TResult : class, IResult
        {
            return instance as TResult;
        }
    }
}