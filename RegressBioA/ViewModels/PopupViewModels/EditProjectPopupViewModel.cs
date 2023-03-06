using RegressBioA.Commands;
using RegressBioA.Stores;
using RegressBioA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.ViewModels.PopupViewModels
{
    public class EditProjectPopupViewModel : ViewModelBase
    {
        private readonly SelectedProjectStore _selectedProjectStore;
        private string _newProjectName;

        public EditProjectPopupViewModel(AsyncCommandErrorHandler errorHandler, PopupNavigationStore popupNavigationStore, ProjectStore projectStore, SelectedProjectStore selectedProjectStore)
        {
            RenameProjectCommand = new RenameProjectCommand(errorHandler, popupNavigationStore, projectStore, selectedProjectStore, this);
            DeleteProjectCommand = new DeleteProjectCommand(errorHandler, popupNavigationStore, projectStore, selectedProjectStore);
            ClosePopupCommand = new ClosePopupCommand(popupNavigationStore);
            _selectedProjectStore = selectedProjectStore;
        }
        
        public RenameProjectCommand RenameProjectCommand { get; }
        public DeleteProjectCommand DeleteProjectCommand { get; }
        public ClosePopupCommand ClosePopupCommand { get; }

        public string ProjectName => _selectedProjectStore.SelectedProject.Name;

        public string NewProjectName
        {
            get => _newProjectName;
            set
            {
                _newProjectName = value;
                OnPropertyChanged();
            }
        }
    }
}
