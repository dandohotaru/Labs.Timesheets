using System;

namespace Labs.Timesheets.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string format, params object[] paramters)
            : base(string.Format(format, paramters))
        {
        }
    }
}