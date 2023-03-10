using RegressBioA.WPF.Commands;
using RegressBioA.Domain.Models;
using RegressBioA.WPF.Stores;
using RegressBioA.WPF.Utilities;
using System;
using System.Windows.Input;

namespace RegressBioA.WPF.ViewModels
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

        public Guid ID => Project.Id;

        public Project Project { get; private set; }

        public void Update(Project project)
        {
            Project = project;
            OnPropertyChanged(nameof(ProjectName));
        }
    }
}