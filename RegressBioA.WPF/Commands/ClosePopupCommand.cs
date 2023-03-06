using RegressBioA.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressBioA.WPF.Commands
{
    public class ClosePopupCommand : CommandBase
    {
        private readonly PopupNavigationStore _popupNavigationStore;

        public ClosePopupCommand(PopupNavigationStore popupNavigationStore)
        {
            _popupNavigationStore = popupNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            _popupNavigationStore.ClosePopup();
        }
    }
}
