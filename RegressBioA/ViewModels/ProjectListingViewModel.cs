using RegressBioA.Commands;
using RegressBioA.Events;
using RegressBioA.Models;
using RegressBioA.Stores;
using RegressBioA.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RegressBioA.ViewModels
{
    /// <summary>
    /// ViewModel for the ProjectListing.xaml Component.
    /// </summary>
    public class ProjectListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ProjectListingItemViewModel> _projectListingItemViewModels = new();
        private readonly AsyncCommandErrorHandler _errorHandler;
        private readonly PopupNavigationStore _popupNavigationStore;
        private readonly SelectedProjectStore _selectedProjectStore;
        private readonly ProjectStore _projectStore;
        private ProjectListingItemViewModel _selectedProject;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectListingViewModel"/> class.
        /// </summary>
        /// <param name="selectedProjectStore">The project store, acting as the single source of truth for which project the user has open.</param>
        public ProjectListingViewModel(AsyncCommandErrorHandler errorHandler, PopupNavigationStore popupNavigationStore, SelectedProjectStore selectedProjectStore, ProjectStore projectStore)
        {
            _errorHandler = errorHandler;
            _popupNavigationStore = popupNavigationStore;
            _selectedProjectStore = selectedProjectStore;
            _projectStore = projectStore;

            WeakEventManager<ProjectStore, ProjectChangedEventArgs>.AddHandler(projectStore, nameof(ProjectStore.ProjectCreated), ProjectStore_ProjectCreated);
            WeakEventManager<ProjectStore, ProjectChangedEventArgs>.AddHandler(projectStore, nameof(ProjectStore.ProjectUpdated), ProjectStore_ProjectUpdated);
            WeakEventManager<ProjectStore, ProjectChangedEventArgs>.AddHandler(projectStore, nameof(ProjectStore.ProjectDeleted), ProjectStore_ProjectDeleted);
        }

        private void ProjectStore_ProjectDeleted(object? sender, ProjectChangedEventArgs e)
        {
            Guid projectID = e.Project.ID;
            var ItemVMToDelete = _projectListingItemViewModels.FirstOrDefault(itemVM => itemVM.ID == projectID);

            if (ItemVMToDelete is not null)
            {
                _projectListingItemViewModels.Remove(ItemVMToDelete);
            }
        }

        private void ProjectStore_ProjectUpdated(object? sender, ProjectChangedEventArgs e)
        {
            Guid projectID = e.Project.ID;
            var itemVMToUpdate = _projectListingItemViewModels.FirstOrDefault(itemVM => itemVM.ID == projectID);

            if (itemVMToUpdate is not null)
            {
                itemVMToUpdate.Update(e.Project);
            }
        }

        private void ProjectStore_ProjectCreated(object? sender, ProjectChangedEventArgs e)
        {
            var newProjectListingItemVM = new ProjectListingItemViewModel(e.Project, _errorHandler, _popupNavigationStore, _selectedProjectStore, _projectStore);
            _projectListingItemViewModels.Add(newProjectListingItemVM);
        }

        /// <summary>
        /// Gets the viewModels that represent individual projects as a sequence
        /// </summary>
        public IEnumerable<ProjectListingItemViewModel> ProjectListingItemViewModels => _projectListingItemViewModels;


        /// <summary>
        /// Gets or sets the currently selected project by the user in the listView.
        /// </summary>
        /// <remarks>When set, updates the project store which raises an event signalling this has updated.</remarks>
        public ProjectListingItemViewModel SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                OnPropertyChanged();
                _selectedProjectStore.SelectedProject = _selectedProject?.Project;
            }
        }

    }
}