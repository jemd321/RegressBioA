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
    public class DeleteProjectCommand : AsyncCommandBase
    {
        private readonly PopupNavigationStore _popupNavigationStore;
        private readonly ProjectStore _projectStore;
        private readonly SelectedProjectStore _selectedProjectStore;

        public DeleteProjectCommand(
            IErrorHandler errorHandler,
            PopupNavigationStore popupNavigationStore,
            ProjectStore projectStore,
            SelectedProjectStore selectedProjectStore)
            : base(errorHandler)
        {
            _popupNavigationStore = popupNavigationStore;
            _projectStore = projectStore;
            _selectedProjectStore = selectedProjectStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            await _projectStore.Delete(_selectedProjectStore.SelectedProject);
            _popupNavigationStore.ClosePopup();
        }
    }
}
