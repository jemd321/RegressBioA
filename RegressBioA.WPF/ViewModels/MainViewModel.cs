using RegressBioA.WPF.Stores;
using RegressBioA.WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RegressBioA.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly PopupNavigationStore _popupNavigationStore;
        private ViewModelBase? _popupContentViewModel;

        public MainViewModel(ProjectViewModel projectViewModel, PopupNavigationStore popupNavigationStore, AsyncCommandErrorHandler errorHandler)
        {
            ProjectViewModel = projectViewModel;
            _popupNavigationStore = popupNavigationStore;
            WeakEventManager<PopupNavigationStore, EventArgs>.AddHandler(popupNavigationStore, nameof(popupNavigationStore.PopupContentChanged), PopupNavigationStore_PopupContentChanged);
        }

        public ProjectViewModel ProjectViewModel { get; }

        public ViewModelBase? PopupContentViewModel
        {
            get => _popupContentViewModel;
            set
            {
                _popupContentViewModel = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPopupOpen));
            }
        }

        public bool IsPopupOpen => PopupContentViewModel != null;

        private void PopupNavigationStore_PopupContentChanged(object sender, EventArgs e)
        {
            PopupContentViewModel = _popupNavigationStore.CurrentPopupViewModel;
        }
    }
}
