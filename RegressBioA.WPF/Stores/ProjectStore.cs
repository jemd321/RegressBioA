using RegressBioA.WPF.Events;
using RegressBioA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.WPF.Stores
{
    public class ProjectStore
    {
        public event EventHandler<ProjectChangedEventArgs> ProjectCreated;

        public event EventHandler<ProjectChangedEventArgs> ProjectDeleted;

        public event EventHandler<ProjectChangedEventArgs> ProjectUpdated;

        public async Task Create(Project project)
        {
            ProjectCreated?.Invoke(this, new ProjectChangedEventArgs(project));
        }

        public async Task Delete(Project project)
        {
            ProjectDeleted?.Invoke(this, new ProjectChangedEventArgs(project));
        }

        public async Task Update(Project project)
        {
            ProjectUpdated?.Invoke(this, new ProjectChangedEventArgs(project));
        }
    }
}
