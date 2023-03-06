using RegressBioA.Commands;
using RegressBioA.Models;
using RegressBioA.Stores;
using RegressBioA.Utilities;
using System;
using System.Windows.Input;

namespace RegressBioA.ViewModels
{
    public class ProjectListingItemViewModel : ViewModelBase
    {
        public ProjectListingItemViewModel(Project project, AsyncCommandErrorHandler errorHandler, PopupNavigationStore popupNavigationStore, SelectedProjectStore selectedProjectStore, ProjectStore projectStore)
        {
            Project = project;

            OpenProjectEditPopupCommand = new OpenProjectEditPopupCommand(errorHandler, popupNavigationStore, projectStore, selectedProjectStore);
            DeleteProjectCommand = new DeleteProjectCommand(errorHandler, popupNavigationStore, projectStore, selectedProjectStore);
        }

        public ICommand OpenProjectEditPopupCommand { get; }
        public ICommand DeleteProjectCommand { get; }

        public string ProjectName => Project.Name;

        public Guid ID => Project.ID;

        public Project Project { get; private set; }

        public void Update(Project project)
        {
            Project = project;
            OnPropertyChanged(nameof(ProjectName));
        }
    }
}