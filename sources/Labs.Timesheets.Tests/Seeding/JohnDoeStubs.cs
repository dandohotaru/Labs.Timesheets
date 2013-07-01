using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Tests.Seeding
{
    public static class JohnDoeStubs
    {
        public static readonly Guid CustomerId = Guid.NewGuid();
        public static readonly string CustomerName = "Rndmzr";

        public static IStorageAdapter SeedJohnDoeCustomers(this IStorageAdapter context)
        {
            var customer = new Customer(CustomerId)
                .ApplyName(CustomerName)
                .ApplyNotes("Hell of a customer");

            context.Add(customer);
            return context;
        }

        public static IStorageAdapter SeedJohnDoeTags(this IStorageAdapter context)
        {
            // ToDo: Implement stubs;
            return context;
        }

        public static IStorageAdapter SeedJohnDoeActivities(this IStorageAdapter context)
        {
            var today = DateTime.Now.Date;
            var morning = new DateTime(today.Year, today.Month, today.Day, 8, 0, 0);

            var setupSolution = new Activity(Guid.NewGuid())
                .ApplyPeriod(morning, 0.5)
                .ApplyNotes("Work on configuring the solution");

            var implementTestLayer = new Activity(Guid.NewGuid())
                .ApplyPeriod(setupSolution.End, 2)
                .ApplyNotes("Work on setting up the test layer");

            var configureGithub = new Activity(Guid.NewGuid())
                .ApplyPeriod(implementTestLayer.End, 1)
                .ApplyNotes("Configure source control with github");

            var drinkCoffee = new Activity(Guid.NewGuid())
                .ApplyPeriod(configureGithub.End, 0.25)
                .ApplyNotes("Hard work today I need a coffee");

            var smokeCigarette = new Activity(Guid.NewGuid())
                .ApplyPeriod(drinkCoffee.End, 0.25)
                .ApplyNotes("I know it's bad for my health but i deserve it");

            var poetOnTwitter = new Activity(Guid.NewGuid())
                .ApplyPeriod(smokeCigarette.End, 0.5)
                .ApplyNotes("Praise myself about the great achievements of today");

            var goOutForLunch = new Activity(Guid.NewGuid())
                .ApplyPeriod(poetOnTwitter.End, 1.5)
                .ApplyNotes("Feels like going for a drink i mean pizza");

            context.Add(setupSolution);
            context.Add(implementTestLayer);
            context.Add(configureGithub);
            context.Add(drinkCoffee);
            context.Add(smokeCigarette);
            context.Add(poetOnTwitter);
            context.Add(goOutForLunch);

            return context;
        }
    }
}