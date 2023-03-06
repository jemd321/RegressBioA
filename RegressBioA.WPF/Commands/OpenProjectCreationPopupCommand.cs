using RegressBioA.WPF.Stores;
using RegressBioA.WPF.Utilities;
using RegressBioA.WPF.ViewModels.PopupViewModels;

namespace RegressBioA.WPF.Commands
{
    public class OpenProjectCreationPopupCommand : CommandBase
    {
        private readonly PopupNavigationStore _popupNavigationStore;
        private readonly ProjectStore _projectStore;
        private readonly AsyncCommandErrorHandler _asyncCommandErrorHandler;

        public OpenProjectCreationPopupCommand(PopupNavigationStore popupNavigationStore, ProjectStore projectStore, AsyncCommandErrorHandler asyncCommandErrorHandler)
        {
            _popupNavigationStore = popupNavigationStore;
            _projectStore = projectStore;
            _asyncCommandErrorHandler = asyncCommandErrorHandler;
        }

        public override void Execute(object? parameter)
        {
            _popupNavigationStore.OpenPopup(new CreateProjectPopupViewModel(_popupNavigationStore, _projectStore, _asyncCommandErrorHandler)); 
        }
    }
}
