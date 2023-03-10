using Microsoft.EntityFrameworkCore;
using RegressBioA.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.EntityFramework
{
    public sealed class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
        {
        }

        public DbSet<ProjectDTO> Projects { get; set; }
    }
}
