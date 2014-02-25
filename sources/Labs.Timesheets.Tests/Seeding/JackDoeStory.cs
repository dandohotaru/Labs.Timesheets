using System;
using Labs.Timesheets.Domain.Common;
using Labs.Timesheets.Domain.Entities;

namespace Labs.Timesheets.Tests.Seeding
{
    public class JackDoeStory : IStory
    {
        public static readonly Guid CustomerId = Guid.NewGuid();
        public static readonly string CustomerName = "Trvlr";
        public static readonly DateTime Date = new DateTime(2013, 7, 1);
        public static readonly Guid UserId = Guid.NewGuid();

        public JackDoeStory(IWriter context)
        {
            Context = context;
        }

        protected IWriter Context { get; set; }

        public void Build()
        {
            SeedUser();
            SeedCustomer();
            SeedTags();
            SeedActivities();
        }

        private void SeedUser()
        {
            var user = new User(UserId)
                .ApplyFirstName("Jack")
                .ApplyLastName("Doe")
                .ApplyUserName("jack.doe")
                .ApplyEmail("jack.doe@test.com");
            Context.Add(user);
        }

        private void SeedCustomer()
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
                .ApplyName("Pack solar charger")
                .ApplyNotes("There is no way I am leaving without a solar charger")
                .ApplyPeriod(morning, TimeSpan.FromHours(0.5));

            var packTrekingBoots = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Pack treking boots")
                .ApplyNotes("Have you seen those leaches as big as my cat")
                .ApplyPeriod(packSolarCharger.End, TimeSpan.FromHours(2));

            var packToothbrush = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Pack toothbrush")
                .ApplyNotes("Sharing is carrying but not this one")
                .ApplyPeriod(packTrekingBoots.End, TimeSpan.FromHours(0.5));

            var packHammock = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Pack hammock")
                .ApplyNotes("For the lazy afternoons")
                .ApplyPeriod(packToothbrush.End, TimeSpan.FromHours(0.25));

            var packKindle = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Pack kindle")
                .ApplyNotes("See previous activity")
                .ApplyPeriod(packHammock.End, TimeSpan.FromHours(0.25));

            var postOnTwitter = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Post on twitter")
                .ApplyNotes("Praise myself about the great future journey")
                .ApplyPeriod(packKindle.End, TimeSpan.FromHours(0.5));

            var exitStageLeft = new Activity(Guid.NewGuid())
                .ForTenant(UserId)
                .ApplyName("Exit stage left")
                .ApplyNotes("Need to drink with friends first")
                .ApplyPeriod(postOnTwitter.End, TimeSpan.FromHours(9.5));

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