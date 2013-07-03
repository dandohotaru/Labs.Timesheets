using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Common.Handlers;
using Labs.Timesheets.Domain.Tracking.Commands;

namespace Labs.Timesheets.Domain.Tracking.Handlers
{
    public class CustomerWriteHandler
        : IWriteHandler<AddCustomerCommand>,
          IWriteHandler<RemoveCustomerCommand>,
          IWriteHandler<ModifyCustomerCommand>
    {
        public CustomerWriteHandler(IStorageAdapter context)
        {
            Context = context;
        }

        protected IStorageAdapter Context { get; set; }

        public void Handle(AddCustomerCommand command)
        {
            throw new NotImplementedException("ToDo");
        }

        public void Handle(RemoveCustomerCommand command)
        {
            throw new NotImplementedException("ToDo");
        }

        public void Handle(ModifyCustomerCommand command)
        {
            throw new NotImplementedException("ToDo");
        }
    }
}