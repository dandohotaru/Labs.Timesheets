using System;

namespace Labs.Timesheets.Domain.Exceptions
{
    public class StorageException : Exception
    {
        public StorageException(string format, params object[] paramters)
            : base(string.Format(format, paramters))
        {
        }
    }
}