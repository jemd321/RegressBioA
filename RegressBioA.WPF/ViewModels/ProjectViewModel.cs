using RegressBioA.WPF.Commands;
using RegressBioA.WPF.Stores;
using RegressBioA.WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RegressBioA.WPF.ViewModels
{
    /// <summary>
    /// ViewModel for the project explorer that is shown when the application starts or the user does not have a run opened.
    /// </summary>
    public class ProjectViewModel : ViewModelBase
    {
        private readonly SelectedProjectStore _selectedProjectStore;
        private readonly ProjectStore _projectStore;
        private readonly PopupNavigationStore _popupNavigationStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        /// <param name="selectedProjectStore">The project store, acting as the single source of truth for which project the user has open.</param>
        public ProjectViewModel(SelectedProjectStore selectedProjectStore, ProjectStore projectStore, PopupNavigationStore popupNavigationStore, AsyncCommandErrorHandler asyncCommandErrorHandler)
        {
            ProjectListingViewModel = new ProjectListingViewModel(asyncCommandErrorHandler, popupNavigationStore, selectedProjectStore, projectStore);
            AnalyticalRunListingViewModel = new AnalyticalRunListingViewModel(selectedProjectStore);
            _selectedProjectStore = selectedProjectStore;
            _projectStore = projectStore;
            _popupNavigationStore = popupNavigationStore;
            OpenProjectCreationPopupCommand = new OpenProjectCreationPopupCommand(_popupNavigationStore, _projectStore, asyncCommandErrorHandler);
            OpenProjectEditPopupCommand = new OpenProjectEditPopupCommand(asyncCommandErrorHandler, popupNavigationStore, projectStore, selectedProjectStore);
        }

        /// <summary>
        /// Gets the viewModel responsible for the ProjectListing.xaml component.
        /// </summary>
        public ProjectListingViewModel ProjectListingViewModel { get; }

        /// <summary>
        /// Gets the viewModel responsible for the AnalyticalRunListing.xaml component.
        /// </summary>
        public AnalyticalRunListingViewModel AnalyticalRunListingViewModel { get; }

        public ICommand OpenProjectCreationPopupCommand { get; }
        public ICommand OpenProjectEditPopupCommand { get; }
        public ICommand OpenRunCommand { get; }
        public ICommand EditRunCommand { get; }
        public ICommand ImportRunCommand { get; }
    }
}
