using System.Linq;
using Labs.Timesheets.Contracts.Tracking.Models;
using Labs.Timesheets.Contracts.Tracking.Queries;
using Labs.Timesheets.Domain.Common.Adapters;
using Labs.Timesheets.Domain.Tracking.Entities;
using Labs.Timesheets.Reports.Common.Handlers;

namespace Labs.Timesheets.Reports.Tracking.Handlers
{
    public class ProjectReadHandler
        : IReadHandler<FindProjectsByIdsQuery, FindProjectsByIdsResult>,
          IReadHandler<FindProjectsByTextQuery, FindProjectsByTextResult>
    {
        public ProjectReadHandler(IStorageAdapter context)
        {
            Context = context;
        }

        protected IStorageAdapter Context { get; set; }

        public FindProjectsByIdsResult Handle(FindProjectsByIdsQuery query)
        {
            var projects = from project in Context.Query<Project>()
                           where query.ProjectIds.Contains(project.Id)
                           select new ProjectDetail
                                      {
                                          ProjectId = project.Id,
                                          ProjectName = project.Name,
                                      };

            var results = new FindProjectsByIdsResult()
                .Add(projects);

            return results;
        }

        public FindProjectsByTextResult Handle(FindProjectsByTextQuery query)
        {
            var projects = from project in Context.Query<Project>()
                           where project.Name == query.SearchText
                                 || project.Name == query.SearchText
                           select new ProjectBrief
                                      {
                                          ProjectId = project.Id,
                                          ProjectName = project.Name,
                                      };

            var results = new FindProjectsByTextResult()
                .Add(projects);

            return results;
        }
    }
}