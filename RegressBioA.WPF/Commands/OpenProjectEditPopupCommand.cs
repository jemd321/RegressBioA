using RegressBioA.WPF.Stores;
using RegressBioA.WPF.Utilities;
using RegressBioA.WPF.ViewModels;
using RegressBioA.WPF.ViewModels.PopupViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.WPF.Commands
{
    public class OpenProjectEditPopupCommand : CommandBase
    {
        private readonly PopupNavigationStore _popupNavigationStore;
        private readonly ProjectStore _projectStore;
        private readonly SelectedProjectStore _selectedProjectStore;
        private AsyncCommandErrorHandler _errorHandler;

        public OpenProjectEditPopupCommand(
            AsyncCommandErrorHandler asyncCommandErrorHandler,
            PopupNavigationStore popupNavigationStore,
            ProjectStore projectStore,
            SelectedProjectStore selectedProjectStore)
        {
            _popupNavigationStore = popupNavigationStore;
            _projectStore = projectStore;
            _selectedProjectStore = selectedProjectStore;
        }

        public override void Execute(object? parameter)
        {
            _popupNavigationStore.OpenPopup(new EditProjectPopupViewModel(_errorHandler, _popupNavigationStore, _projectStore, _selectedProjectStore));
        }
    }
}
