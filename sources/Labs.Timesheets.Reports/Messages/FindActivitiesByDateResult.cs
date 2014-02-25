using System.Collections.Generic;
using Labs.Timesheets.Reports.Common;
using Labs.Timesheets.Reports.Models;

namespace Labs.Timesheets.Reports.Messages
{
    public class FindActivitiesByDateResult : Result
    {
        public List<ActivityModel> Activities { get; set; }
    }

    public static class FindActivitiesByDateExtensions
    {
        public static FindActivitiesByDateResult AddActivities(this FindActivitiesByDateResult instance, IEnumerable<ActivityModel> activities)
        {
            if (activities != null)
            {
                if (instance.Activities == null)
                    instance.Activities = new List<ActivityModel>();
                instance.Activities.AddRange(activities);
            }
            return instance;
        }
    }
}