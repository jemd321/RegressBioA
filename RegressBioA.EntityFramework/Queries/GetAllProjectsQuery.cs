using Microsoft.EntityFrameworkCore;
using RegressBioA.Domain.Models;
using RegressBioA.Domain.Queries;
using RegressBioA.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.EntityFramework.Queries
{
    public class GetAllProjectsQuery : IGetAllProjectsQuery
    {
        private readonly IDbContextFactory<ProjectsDbContext> _dbContextFactory;

        public GetAllProjectsQuery(IDbContextFactory<ProjectsDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Project>> Execute()
        {
            using var context = _dbContextFactory.CreateDbContext();

            IEnumerable<ProjectDTO> projectDTOs = await context.Projects.ToListAsync();

            return projectDTOs
                .Select(p => new Project(
                    p.Id, p.Name, p.AnalyticalRuns
                        .Select(ar => new AnalyticalRun(ar.Name, ar.Id)).ToList()));
        }
    }
}
