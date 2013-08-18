﻿using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Security.Entities;
using Labs.Timesheets.Domain.Tracking.Entities;

namespace Labs.Timesheets.Tests.Seeding.Stories
{
    public class JackDoeStory : StoryBase
    {
        public static readonly DateTime Date = new DateTime(2013, 7, 1);
        public static readonly Guid UserId = Guid.NewGuid();
        public static readonly Guid CustomerId = Guid.NewGuid();
        public static readonly string CustomerName = "Trvlr";

        public JackDoeStory(IStorage context)
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

        public void SeedUser()
        {
            var user = new User(UserId)
                .ApplyFirstName("Jack")
                .ApplyLastName("Doe")
                .ApplyUserName("jack.doe")
                .ApplyEmail("jack.doe@test.com");

            Context.Add(user);
        }

        private void SeedCustomers()
        {
            var customer = new Customer(CustomerId)
                .ApplyName(CustomerName)
                .ApplyNotes("Hell of a journey");

            Context.Add(customer);
        }

        private void SeedTags()
        {
            // ToDo: Implement stubs;
        }

        private void SeedActivities()
        {
            var morning = new DateTime(Date.Year, Date.Month, Date.Day, 8, 0, 0);

            var packSolarCharger = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(morning, TimeSpan.FromHours(0.5))
                .ApplyNotes("There is no way I am leaving without a solar charger");

            var packTrekingBoots = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(packSolarCharger.End, TimeSpan.FromHours(2))
                .ApplyNotes("Have you seen those leaches as big as my cat");

            var packToothbrush = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(packTrekingBoots.End, TimeSpan.FromHours(0.5))
                .ApplyNotes("Sharing is carrying but not this one");

            var packHammock = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(packToothbrush.End, TimeSpan.FromHours(0.25))
                .ApplyNotes("For the lazy afternoons");

            var packKindle = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(packHammock.End, TimeSpan.FromHours(0.25))
                .ApplyNotes("See previous activity");

            var postOnTwitter = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(packKindle.End, TimeSpan.FromHours(0.5))
                .ApplyNotes("Praise myself about the great future journey");

            var exitStageLeft = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyPeriod(postOnTwitter.End, TimeSpan.FromHours(9.5))
                .ApplyNotes("Need to drink with friends first");

            Context.Add(packSolarCharger);
            Context.Add(packTrekingBoots);
            Context.Add(packToothbrush);
            Context.Add(packHammock);
            Context.Add(packKindle);
            Context.Add(postOnTwitter);
            Context.Add(exitStageLeft);
        }
    }
}