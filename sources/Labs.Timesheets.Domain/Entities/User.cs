using System;
using Labs.Timesheets.Domain.Common;

namespace Labs.Timesheets.Domain.Entities
{
    public class User : Entity
    {
        protected User()
        {
        }

        public User(Guid id) : base(id)
        {

        }

        public string UserName { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Email { get; protected set; }

        public User ApplyUserName(string name)
        {
            UserName = name;
            return this;
        }

        public User ApplyFirstName(string name)
        {
            FirstName = name;
            return this;
        }

        public User ApplyLastName(string name)
        {
            LastName = name;
            return this;
        }

        public User ApplyEmail(string email)
        {
            Email = email;
            return this;
        }
    }
}