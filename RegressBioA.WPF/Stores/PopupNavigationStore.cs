using RegressBioA.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.WPF.Stores
{
    public class PopupNavigationStore
    {
        private ViewModelBase? _currentPopupViewModel;

        public event EventHandler? PopupContentChanged;

        public ViewModelBase? CurrentPopupViewModel
        {
            get => _currentPopupViewModel;
            private set
            {
                _currentPopupViewModel = value;
                OnPopupContentChanged();
            }
        }

        public bool IsOpen => CurrentPopupViewModel != null;


        public void OpenPopup(ViewModelBase popupViewModel)
        {
            CurrentPopupViewModel = popupViewModel;
        }

        public void ClosePopup()
        {
            CurrentPopupViewModel = null;
        }

        protected virtual void OnPopupContentChanged()
        {
            PopupContentChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
