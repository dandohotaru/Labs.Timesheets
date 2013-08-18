using System;
using Labs.Timesheets.Domain.Common.Adapters;

namespace Labs.Timesheets.Tests.Seeding
{
    public abstract class StoryBase : IStory
    {
        protected StoryBase(IStorage context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            Context = context;
        }

        protected IStorage Context { get; private set; }

        public abstract void Seed();
    }
}