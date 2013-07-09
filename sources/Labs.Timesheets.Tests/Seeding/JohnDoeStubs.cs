using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Security.Entities;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Tests.Seeding
{
    public static class JohnDoeStubs
    {
        public static readonly DateTime Date = new DateTime(2013, 7, 1);
        public static readonly Guid UserId = Guid.NewGuid();
        public static readonly Guid CustomerId = Guid.NewGuid();
        public static readonly string CustomerName = "Rndmzr";

        public static IStorage SeedJackDoe(this IStorage context)
        {
            var user = new User(UserId)
                .ApplyFirstName("John")
                .ApplyLastName("Doe")
                .ApplyUserName("john.doe")
                .ApplyEmail("john.doe@test.com");

            context.Add(user);
            context = context
                .SeedCustomers()
                .SeedTags()
                .SeedActivities();
            return context;
        }

        private static IStorage SeedCustomers(this IStorage context)
        {
            var customer = new Customer(CustomerId)
                .ApplyName(CustomerName)
                .ApplyNotes("Hell of a customer");

            context.Add(customer);
            return context;
        }

        private static IStorage SeedTags(this IStorage context)
        {
            // ToDo: Implement stubs;
            return context;
        }

        private static IStorage SeedActivities(this IStorage context)
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

            context.Add(setupSolution);
            context.Add(implementTestLayer);
            context.Add(configureGithub);
            context.Add(drinkCoffee);
            context.Add(smokeCigarette);
            context.Add(postOnTwitter);
            context.Add(outForLunch);

            return context;
        }
    }
}