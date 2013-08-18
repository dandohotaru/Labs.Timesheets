using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Security.Entities;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Tests.Seeding.Stories
{
    public class JohnDoeStory : StoryBase
    {
        public static readonly DateTime Date = new DateTime(2013, 7, 1);
        public static readonly Guid UserId = Guid.NewGuid();
        public static readonly Guid CustomerId = Guid.NewGuid();
        public static readonly string CustomerName = "Rndmzr";

        public JohnDoeStory(IStorage context)
            : base(context)
        {
        }

        public override void Seed()
        {
            SeedUser();
            SeedCustomers();
            SeedTags();
            SeedActivities();
        }

        private void SeedUser()
        {
            var user = new User(UserId)
                .ApplyFirstName("John")
                .ApplyLastName("Doe")
                .ApplyUserName("john.doe")
                .ApplyEmail("john.doe@test.com");

            Context.Add(user);
        }

        private void SeedCustomers()
        {
            var customer = new Customer(CustomerId)
                .ApplyName(CustomerName)
                .ApplyNotes("Hell of a customer");

            Context.Add(customer);
        }

        private void SeedTags()
        {
            // ToDo: Implement stubs;
        }

        private void SeedActivities()
        {
            var morning = new DateTime(Date.Year, Date.Month, Date.Day, 8, 0, 0);

            var setupSolution = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(morning, TimeSpan.FromHours(0.5))
                .ApplyNotes("Work on configuring the solution");

            var implementTestLayer = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(setupSolution.End, TimeSpan.FromHours(2))
                .ApplyNotes("Work on setting up the test layer");

            var configureGithub = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(implementTestLayer.End, TimeSpan.FromHours(1))
                .ApplyNotes("Configure source control with github");

            var drinkCoffee = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(configureGithub.End, TimeSpan.FromHours(0.25))
                .ApplyNotes("Hard work today I need a coffee");

            var smokeCigarette = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(drinkCoffee.End, TimeSpan.FromHours(0.25))
                .ApplyNotes("I know it's bad for my health but i deserve it");

            var postOnTwitter = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(smokeCigarette.End, TimeSpan.FromHours(0.5))
                .ApplyNotes("Praise myself about the great achievements of today");

            var outForLunch = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(postOnTwitter.End, TimeSpan.FromHours(1.5))
                .ApplyNotes("Feels like going for a drink i mean pizza");

            Context.Add(setupSolution);
            Context.Add(implementTestLayer);
            Context.Add(configureGithub);
            Context.Add(drinkCoffee);
            Context.Add(smokeCigarette);
            Context.Add(postOnTwitter);
            Context.Add(outForLunch);
        }
    }
}