using System;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Core.Entities;

namespace Labs.Timesheets.Tests.Seeding
{
    public static class StorageExtensions
    {
        private static readonly Guid EliaId = Guid.NewGuid();
        private static readonly Guid JohnDoeId = Guid.NewGuid();
        private static readonly Guid JaneDoeId = Guid.NewGuid();
        private static readonly Guid MayTimesheetId = Guid.NewGuid();
        private static readonly Guid JuneTimesheetId = Guid.NewGuid();
        private static readonly Guid MondayId = Guid.NewGuid();

        public static IStorageAdapter SeedJohnDoeTimesheetForMay(this IStorageAdapter context)
        {
            var timesheet = new Timesheet(MayTimesheetId)
                .ApplyName("TimesheetForMay")
                .ApplyNotes("Related with hours worked during May")
                .ApplyCustomer(EliaId)
                .ApplyOwner(JohnDoeId);

            var activityOne = new Activity(Guid.NewGuid());

            var monday = new Day(MondayId)
                .ApplyDate(new DateTimeOffset(new DateTime(2013, 5, 6)))
                .ApplyTimesheet(MayTimesheetId)
                .AddActivity(activityOne);


            context.Add(timesheet);
            context.Add(monday);

            return context;
        }
    }
}