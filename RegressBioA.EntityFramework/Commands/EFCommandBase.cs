using Microsoft.EntityFrameworkCore;
using RegressBioA.Domain.Models;
using RegressBioA.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.EntityFramework.Commands
{
    public abstract class EFProjectCommandBase
    {
        protected readonly IDbContextFactory<ProjectsDbContext> _dbContextFactory;

        public EFProjectCommandBase(IDbContextFactory<ProjectsDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Execute(object parameter)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await ExecuteInternal(context, parameter);
        }

        protected abstract Task ExecuteInternal(ProjectsDbContext context, object parameter);

        protected static ProjectDTO CreateDTO(Project project)
        {
            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                AnalyticalRuns = project.AnalyticalRuns.ToList() ?? null
            };
        }
    }
}
