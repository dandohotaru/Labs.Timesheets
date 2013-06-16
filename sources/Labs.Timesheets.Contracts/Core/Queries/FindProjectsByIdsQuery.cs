using System;
using System.Collections;
using System.Collections.Generic;
using Labs.Timesheets.Contracts.Common.Queries;
using Labs.Timesheets.Contracts.Core.Models;

namespace Labs.Timesheets.Contracts.Core.Queries
{
    public class FindProjectsByIdsQuery : QueryBase<FindProjectsByIdsResult>
    {
        public List<Guid> ProjectIds { get; private set; }

        public FindProjectsByIdsQuery AddProjectId(Guid projectId)
        {
            if (ProjectIds == null)
                ProjectIds = new List<Guid>();
            if (!ProjectIds.Contains(projectId))
                ProjectIds.Add(projectId);
            return this;
        }
    }

    public class FindProjectsByIdsResult : ResultBase, IEnumerable<ProjectDetail>
    {
        public List<ProjectDetail> Projects { get; private set; }

        public FindProjectsByIdsResult Add(ProjectDetail project)
        {
            if (Projects == null)
                Projects = new List<ProjectDetail>();
            Projects.Add(project);
            return this;
        }

        public FindProjectsByIdsResult Add(IEnumerable<ProjectDetail> projects)
        {
            if (Projects == null)
                Projects = new List<ProjectDetail>();
            foreach (var project in projects)
            {
                Projects.Add(project);
            }
            return this;
        }

        public IEnumerator<ProjectDetail> GetEnumerator()
        {
            if (Projects == null)
                Projects = new List<ProjectDetail>();
            return Projects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}