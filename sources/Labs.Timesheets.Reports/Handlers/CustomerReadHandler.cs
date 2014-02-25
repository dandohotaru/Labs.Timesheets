using System;
using Labs.Timesheets.Reports.Common;
using Labs.Timesheets.Reports.Messages;

namespace Labs.Timesheets.Reports.Handlers
{
    public class CustomerReadHandler
        : IHandler<FindCustomerByIdQuery, FindCustomerByIdResult>,
          IHandler<FindCustomersByTextQuery, FindCustomersByTextResult>
    {
        public CustomerReadHandler(IReader context)
        {
            Context = context;
        }

        protected IReader Context { get; set; }

        public FindCustomerByIdResult Handle(FindCustomerByIdQuery request)
        {
            throw new NotImplementedException("ToDo");
        }

        public FindCustomersByTextResult Handle(FindCustomersByTextQuery request)
        {
            throw new NotImplementedException("ToDo");
        }
    }
}