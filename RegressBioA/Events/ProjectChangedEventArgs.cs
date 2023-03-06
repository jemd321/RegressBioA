using RegressBioA.Models;
using System;

namespace RegressBioA.Events
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
