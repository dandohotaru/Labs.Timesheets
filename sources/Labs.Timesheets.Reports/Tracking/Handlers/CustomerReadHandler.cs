using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Reports.Common.Handlers;
using Labs.Timesheets.Reports.Tracking.Queries;

namespace Labs.Timesheets.Reports.Tracking.Handlers
{
    public class CustomerReadHandler
        : IReadHandler<FindCustomerByIdQuery, FindCustomerByIdResult>,
          IReadHandler<FindCustomersByTextQuery, FindCustomersByTextResult>
    {
        public CustomerReadHandler(IStorageAdapter context)
        {
            Context = context;
        }

        protected IStorageAdapter Context { get; set; }

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