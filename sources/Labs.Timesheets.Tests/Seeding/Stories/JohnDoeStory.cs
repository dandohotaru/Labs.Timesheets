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
                .ApplyName("Setup solution")
                .ApplyNotes("Work on configuring the solution")
                .ApplyPeriod(morning, TimeSpan.FromHours(0.5));

            var implementTestLayer = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Implement Test Layer")
                .ApplyNotes("Work on setting up the test layer")
                .ApplyPeriod(setupSolution.End, TimeSpan.FromHours(2));

            var configureGithub = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Configure Github")
                .ApplyNotes("Configure source control with github")
                .ApplyPeriod(implementTestLayer.End, TimeSpan.FromHours(1));

            var drinkCoffee = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Drink coffee")
                .ApplyNotes("Hard work today I deserve a break")
                .ApplyPeriod(configureGithub.End, TimeSpan.FromHours(0.25));

            var smokeCigarette = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Smoke cigarette")
                .ApplyNotes("Hard work today I deserve even longer breaks")
                .ApplyPeriod(drinkCoffee.End, TimeSpan.FromHours(0.25));

            var postOnTwitter = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Post on twitter")
                .ApplyNotes("Praise myself about the great achievements of today")
                .ApplyPeriod(smokeCigarette.End, TimeSpan.FromHours(0.5));

            var outForBeer = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Go out for beer")
                .ApplyNotes("Must have been an exhausting day feels like going for a beer")
                .ApplyPeriod(postOnTwitter.End, TimeSpan.FromHours(6.5));

            Context.Add(setupSolution);
            Context.Add(implementTestLayer);
            Context.Add(configureGithub);
            Context.Add(drinkCoffee);
            Context.Add(smokeCigarette);
            Context.Add(postOnTwitter);
            Context.Add(outForBeer);
        }
    }
}