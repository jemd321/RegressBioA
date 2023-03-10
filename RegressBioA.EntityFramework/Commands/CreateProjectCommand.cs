using Microsoft.EntityFrameworkCore;
using RegressBioA.Domain.Commands;
using RegressBioA.Domain.Models;
using RegressBioA.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.EntityFramework.Commands
{
    public class CreateProjectCommand : EFProjectCommandBase, ICreateProjectCommand
    {
        public CreateProjectCommand(IDbContextFactory<ProjectsDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        protected override async Task ExecuteInternal(ProjectsDbContext context, object project)
        {
            ProjectDTO projectDTO = CreateDTO((Project)project);
            context.Projects.Add(projectDTO);
            await context.SaveChangesAsync();
        }
    }
}
