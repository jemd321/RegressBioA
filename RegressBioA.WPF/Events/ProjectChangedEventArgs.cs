using RegressBioA.Domain.Models;
using System;

namespace RegressBioA.WPF.Events
{
    public class ProjectChangedEventArgs : EventArgs
    {
        public ProjectChangedEventArgs(Project project)
        {
            Project = project;
        }

        public Project Project { get; }
    }
}
