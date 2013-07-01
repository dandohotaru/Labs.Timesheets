﻿using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Tests.Seeding
{
    public static class JohnDoeStubs
    {
        public static readonly Guid CustomerId = Guid.NewGuid();
        public static readonly string CustomerName = "Trello";

        public static IStorageAdapter SeedJohnDoeCustomers(this IStorageAdapter context)
        {
            var customer = new Customer(CustomerId)
                .ApplyName(CustomerName)
                .ApplyNotes("Hell of a cool customer");

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
            var morning = new TimeSpan(8, 0, 0);

            var setupSolution = new Activity(Guid.NewGuid())
                .ApplyDate(today)
                .ApplyPeriod(morning, 0.5)
                .ApplyNotes("Working on setting up the solution");

            var implementTestLayer = new Activity(Guid.NewGuid())
                .ApplyDate(today)
                .ApplyPeriod(setupSolution.Period.AddHours(2))
                .ApplyNotes("Working on a setting up the test layer");

            var configureGithub = new Activity(Guid.NewGuid())
                .ApplyDate(today)
                .ApplyPeriod(implementTestLayer.Period.AddHours(1))
                .ApplyNotes("Configure source control with github");

            var drinkCoffee = new Activity(Guid.NewGuid())
                .ApplyDate(today)
                .ApplyPeriod(configureGithub.Period.AddHours(0.25))
                .ApplyNotes("Hard work today I need a coffee");

            var smokeCigarette = new Activity(Guid.NewGuid())
                .ApplyDate(today)
                .ApplyPeriod(drinkCoffee.Period.AddHours(0.25))
                .ApplyNotes("I know it's bad for my health but i deserve it");

            var poetOnTwitter = new Activity(Guid.NewGuid())
                .ApplyDate(today)
                .ApplyPeriod(smokeCigarette.Period.AddHours(0.5))
                .ApplyNotes("Praise myself about the great achievements of today");

            var goOutForLunch = new Activity(Guid.NewGuid())
                .ApplyDate(today)
                .ApplyPeriod(poetOnTwitter.Period.AddHours(1.5))
                .ApplyNotes("Feel like going for a drink i mean pizza");

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