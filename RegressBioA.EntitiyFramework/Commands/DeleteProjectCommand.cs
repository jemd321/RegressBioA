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
    public class DeleteProjectCommand : EFProjectCommandBase, IDeleteProjectCommand
    {
        public DeleteProjectCommand(IDbContextFactory<ProjectsDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        protected override async Task ExecuteInternal(ProjectsDbContext context, object id)
        {
            ProjectDTO projectDTO = new ProjectDTO()
            {
                Id = (Guid)id
            };
            context.Projects.Remove(projectDTO);
            await context.SaveChangesAsync();
        }
    }
}
