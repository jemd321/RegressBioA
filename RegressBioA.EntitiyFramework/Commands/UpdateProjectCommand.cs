using Microsoft.EntityFrameworkCore;
using RegressBioA.Domain.Commands;
using RegressBioA.Domain.Models;
using RegressBioA.EntitiyFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.EntitiyFramework.Commands
{
    public class UpdateProjectCommand : EFProjectCommandBase, IUpdateProjectCommand
    {
        public UpdateProjectCommand(IDbContextFactory<ProjectsDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        protected override async Task ExecuteInternal(ProjectsDbContext context, object project)
        {
            ProjectDTO projectDTO = CreateDTO((Project)project);
            context.Projects.Update(projectDTO);
            await context.SaveChangesAsync();
        }
    }
}
