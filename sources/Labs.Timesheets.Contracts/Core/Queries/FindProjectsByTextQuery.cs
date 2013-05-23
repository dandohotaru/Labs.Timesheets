using System.Collections;
using System.Collections.Generic;
using Labs.Timesheets.Contracts.Common.Queries;
using Labs.Timesheets.Contracts.Core.Models;

namespace Labs.Timesheets.Contracts.Core.Queries
{
    public class FindProjectsByTextQuery : QueryBase
    {
        public string SearchText { get; set; }
    }

    public class FindProjectsByTextResult : ResultBase, IEnumerable<ProjectBrief>
    {
        public List<ProjectBrief> Projects { get; private set; }

        public FindProjectsByTextResult Add(ProjectBrief project)
        {
            if (Projects == null)
                Projects = new List<ProjectBrief>();
            Projects.Add(project);
            return this;
        }

        public FindProjectsByTextResult Add(IEnumerable<ProjectBrief> projects)
        {
            if (Projects == null)
                Projects = new List<ProjectBrief>();
            foreach (var project in projects)
            {
                Projects.Add(project);
            }
            return this;
        }

        public IEnumerator<ProjectBrief> GetEnumerator()
        {
            if (Projects == null)
                Projects = new List<ProjectBrief>();
            return Projects.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}