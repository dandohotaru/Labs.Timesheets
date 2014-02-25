using System;
using Labs.Timesheets.Domain.Commands;
using Labs.Timesheets.Domain.Common;

namespace Labs.Timesheets.Domain.Handlers
{
    public class CustomerWriteHandler
        : IHandler<AddCustomerCommand>,
          IHandler<RemoveCustomerCommand>,
          IHandler<ModifyCustomerCommand>
    {
        public CustomerWriteHandler(IWriter context)
        {
            Context = context;
        }

        protected IWriter Context { get; set; }

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