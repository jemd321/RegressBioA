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
    public class CreateProjectCommand : AsyncCommandBase
    {
        private readonly PopupNavigationStore _popupNavigationStore;
        private readonly ProjectStore _projectStore;
        private readonly CreateProjectPopupViewModel _parentViewModel;

        public CreateProjectCommand(IErrorHandler errorHandler, PopupNavigationStore popupNavigationStore, ProjectStore projectStore, CreateProjectPopupViewModel parentViewModel) : base(errorHandler)
        {
            _popupNavigationStore = popupNavigationStore;
            _projectStore = projectStore;
            _parentViewModel = parentViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            string newProjectName = _parentViewModel.ProjectName;
            var newProject = new Project(Guid.NewGuid(), newProjectName, new List<AnalyticalRun>());
            await _projectStore.Create(newProject);
            _popupNavigationStore.ClosePopup();
        }
    }
}
