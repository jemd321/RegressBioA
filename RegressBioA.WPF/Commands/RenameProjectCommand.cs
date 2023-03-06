using RegressBioA.Domain.Models;
using RegressBioA.WPF.Stores;
using RegressBioA.WPF.Utilities;
using RegressBioA.WPF.ViewModels.PopupViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.WPF.Commands
{
    public class RenameProjectCommand : AsyncCommandBase
    {
        private readonly PopupNavigationStore _popupNavigationStore;
        private readonly ProjectStore _projectStore;
        private readonly SelectedProjectStore _selectedProjectStore;
        private readonly EditProjectPopupViewModel _parentViewModel;

        public RenameProjectCommand(
            IErrorHandler errorHandler,
            PopupNavigationStore popupNavigationStore,
            ProjectStore projectStore,
            SelectedProjectStore selectedProjectStore,
            EditProjectPopupViewModel parentViewModel)
            : base(errorHandler)
        {
            _popupNavigationStore = popupNavigationStore;
            _projectStore = projectStore;
            _selectedProjectStore = selectedProjectStore;
            _parentViewModel = parentViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            string newProjectName = _parentViewModel.NewProjectName;
            Project selectedProject = _selectedProjectStore.SelectedProject;
            selectedProject.UpdateName(newProjectName);
            await _projectStore.Update(selectedProject);
            _popupNavigationStore.ClosePopup();
        }
    }
}
