using RegressBioA.Stores;
using RegressBioA.Utilities;
using RegressBioA.ViewModels.PopupViewModels;

namespace RegressBioA.Commands
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
