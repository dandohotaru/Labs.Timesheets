using System;
using System.Collections.Generic;
using Labs.Timesheets.Contracts.Common.Values;
using Labs.Timesheets.Domain.Common.Entities;

namespace Labs.Timesheets.Domain.Tracking.Entities
{
    public class Activity : EntityBase
    {
        public Activity(Guid id) : base(id)
        {
        }

        public Guid DayId { get; protected set; }

        public string Notes { get; protected set; }

        public TimeRange Period { get; protected set; }

        public IList<Project> Projects { get; protected set; }

        public Activity ApplyDay(Guid dayId)
        {
            DayId = dayId;
            return this;
        }

        public Activity ApplyPeriod(TimeRange period)
        {
            Period = period;
            return this;
        }

        public Activity ApplyNotes(string notes)
        {
            Notes = notes;
            return this;
        }

        public Activity LinkProjects(IEnumerable<Project> projects)
        {
            if (Projects == null)
                Projects = new List<Project>();

            foreach (var project in projects)
            {
                Projects.Add(project);
            }

            return this;
        }

        public Activity LinkProject(Project project)
        {
            return LinkProjects(new List<Project> {project});
        }
    }
}