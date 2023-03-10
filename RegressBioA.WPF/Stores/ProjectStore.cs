using RegressBioA.WPF.Events;
using RegressBioA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegressBioA.Domain.Commands;
using RegressBioA.Domain.Queries;

namespace RegressBioA.WPF.Stores
{
    public class ProjectStore
    {
        private readonly IGetAllProjectsQuery _getAllProjectsQuery;
        private readonly ICreateProjectCommand _createProjectCommand;
        private readonly IUpdateProjectCommand _updateProjectCommand;
        private readonly IDeleteProjectCommand _deleteProjectCommand;

        public ProjectStore(IGetAllProjectsQuery getAllProjectsQuery,
            ICreateProjectCommand createProjectCommand,
            IUpdateProjectCommand updateProjectCommand,
            IDeleteProjectCommand deleteProjectCommand)
        {
            _getAllProjectsQuery = getAllProjectsQuery;
            _createProjectCommand = createProjectCommand;
            _updateProjectCommand = updateProjectCommand;
            _deleteProjectCommand = deleteProjectCommand;
        }

        public event EventHandler<ProjectChangedEventArgs> ProjectCreated;

        public event EventHandler<ProjectChangedEventArgs> ProjectDeleted;

        public event EventHandler<ProjectChangedEventArgs> ProjectUpdated;

        public async Task Create(Project project)
        {
            await _createProjectCommand.Execute(project);
            ProjectCreated?.Invoke(this, new ProjectChangedEventArgs(project));
        }

        public async Task Delete(Project project)
        {
            await _deleteProjectCommand.Execute(project.Id);
            ProjectDeleted?.Invoke(this, new ProjectChangedEventArgs(project));
        }

        public async Task Update(Project project)
        {
            await _updateProjectCommand.Execute(project);
            ProjectUpdated?.Invoke(this, new ProjectChangedEventArgs(project));
        }
    }
}
